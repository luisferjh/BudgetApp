using Budget.Application.Interfaces;
using Budget.Infrastructure.Common.Utils;
using Budget.Domain.DTOS.Models;
using Budget.Domain.Entities;
using Budget.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Runtime.InteropServices;

namespace Budget.Application.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;
        private readonly SecurityTools _st;
        private readonly TokenValidationParameters _tokenValidationParameters;

        public LoginService(IUnitOfWork unitOfWork, 
               ITokenService tokenService, 
               SecurityTools st, 
               TokenValidationParameters tokenValidationParameters)
        {
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
            _st = st;
            _tokenValidationParameters = tokenValidationParameters;
        }

        public async Task<AuthenticationResultDTO> LoginAsync(LoginDTO loginUser)
        {
            (User user, AuthenticationResultDTO result) = await AuthenticateAsync(loginUser);

            if (user == null)
                return result;

            JwtSettingsDTO token = await _tokenService.GenerateToken(user);

            result.Result = token;
            result.Success = true;

            return result;
        }

        public async Task<(User, AuthenticationResultDTO)> AuthenticateAsync(LoginDTO loginDTO)
        {
            User user = await _unitOfWork.UserRepository.Get(loginDTO.Email);
            AuthenticationResultDTO result = new AuthenticationResultDTO();
            if (user == null)
            {
                result.Success = false;
                result.Errors.Add("User does not exist");
                return (null, result);
            }

            if (!CheckPassword(user.Password, loginDTO.Password))
            {
                result.Success = false;
                result.Errors.Add("Password combination failed");
                return (null, result);
            }

            return (user, result);
        }

        public async Task<AuthenticationResultDTO> RefreshTokenAsync(string token, string refreshToken)
        {
            var validadedToken = GetPrincipalFromToken(token);

            if (validadedToken == null)
            {
                return new AuthenticationResultDTO { 
                    Errors = new List<string>() { "Invalid Token" }
                };
            }

            var expiryDateUnix = long.Parse(validadedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Exp).Value);

            var expiryDateTimeUTC = new DateTime(1970, 1,1,0,0,0, DateTimeKind.Utc)
                .AddSeconds(expiryDateUnix);

            //if (expiryDateTimeUTC > DateTime.Now)
            //{
            //    return new AuthenticationResultDTO
            //    {
            //        Errors = new List<string>() { "This token hasn't expired yet" }
            //    };
            //}

            var Jti = validadedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Jti).Value;

            var storeRefrestToken = await _unitOfWork.RefreshTokenRepository.Get(Jti);

            if (storeRefrestToken == null)
            {
                return new AuthenticationResultDTO
                {
                    Errors = new List<string>() { "This refresh token does not exists" }
                };
            }

            if (DateTime.UtcNow > storeRefrestToken.ExpiryDate)
            {
                return new AuthenticationResultDTO
                {
                    Errors = new List<string>() { "This refresh token has expired " }
                };
            }

            if (storeRefrestToken.Invalidated)
            {
                return new AuthenticationResultDTO
                {
                    Errors = new List<string>() { "This refresh token has been invalidated" }
                };
            }

            if (storeRefrestToken.Used)
            {
                return new AuthenticationResultDTO
                {
                    Errors = new List<string>() { "This refresh token has been used" }
                };
            }

            if (storeRefrestToken.JwtId != Jti)
            {
                return new AuthenticationResultDTO
                {
                    Errors = new List<string>() { "This refresh token does not match this JWT" }
                };
            }

            storeRefrestToken.Used = true;
            _unitOfWork.RefreshTokenRepository.Update(storeRefrestToken);
            await _unitOfWork.SaveAsync();

            var user = await _unitOfWork.UserRepository.GetAsync(storeRefrestToken.UserId);

            JwtSettingsDTO newRefreshtoken = await _tokenService.GenerateToken(user);

            return new AuthenticationResultDTO { Result = newRefreshtoken, Success = true };
        }

        private ClaimsPrincipal GetPrincipalFromToken(string token) 
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                var principal = tokenHandler.ValidateToken(token, _tokenValidationParameters, out var validadedToken);
                if (!IsJwtWithValidSecurityAlgoritm(validadedToken))
                    return null;

                return principal;
                                
            }
            catch
            {
                return null;
            }
        }

        private bool IsJwtWithValidSecurityAlgoritm(SecurityToken validadedToken) 
        {
            return (validadedToken is JwtSecurityToken jwtSecurityToken) &&
                    jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                        StringComparison.InvariantCultureIgnoreCase);
        }

        private bool CheckPassword(string passwordStore, string passwordSent)          
            => _st.DecryptString(passwordStore) == passwordSent;

    }
}
