
using Budget.Application.Interfaces;
using Budget.Domain.DTOS.Models;
using Budget.Domain.Entities;
using Budget.Domain.Interfaces;
using Budget.Infrastructure.Common.Configs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly IUnitOfWork _unitOfWork;
        private readonly JwtSettings _jwtSettings;

        public TokenService(IConfiguration config, 
            IOptions<JwtSettings> jwtSettings,
            IUnitOfWork unitOfWork)
        {
            _config = config;
            _unitOfWork = unitOfWork;
            _jwtSettings = jwtSettings.Value;
        }

        public JwtSettingsDTO GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetValue<string>("JwtSettings:SecretKey")));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Name),                
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            JwtSecurityToken token = new JwtSecurityToken(
            //_config.GetConnectionString("JwtSettings:Issuer"),
            //_config.GetConnectionString("JwtSettings:Audience"),
            _jwtSettings.Issuer,
            _jwtSettings.Audience,            
            claims,
            expires: DateTime.Now.Add(_jwtSettings.TokenLifeTime),
            signingCredentials: credentials);

            var refreshToken = new RefreshToken()
            {                
                JwtId = token.Id,
                UserId = user.Id,
                CreationDate = DateTime.UtcNow,
                ExpiryDate = DateTime.UtcNow.Add(_jwtSettings.TokenLifeTime)
            };

            _unitOfWork.RefreshTokenRepository.Add(refreshToken);
            _unitOfWork.Save();

            return new JwtSettingsDTO
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                ExpireTime = token.ValidTo
            };
        }
    }
}
