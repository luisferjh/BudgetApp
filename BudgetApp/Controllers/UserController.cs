using AutoMapper;
using Budget.Application.Interfaces;
using Budget.Domain.DTOS.Models;
using Budget.Domain.DTOS.user;
using Budget.Infrastructure.Common;
using HashidsNet;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BudgetApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdminOrUser")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IHashids _hashids;
        private readonly IMapper mapper;
        public UserController(
            IUserService userService,
            IHashids hashids
            )
        {
            _userService = userService;
            _hashids = hashids;
            mapper = AutomapperSingleton.GetMapper();
        }

        [HttpGet("[action]")]
        [HttpHead("[action]")]
        [HttpOptions("[action]")]
        public async Task<IEnumerable<UserDto>> GetAll()
        {
            return await _userService.GetAllAsync();
        }

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult> Get([FromRoute] string id)
        {
            var rawDecoded = _hashids.Decode(id);
            if (rawDecoded.Length <= 0)
                return NotFound();

            var userDto = await _userService.GetAsync(rawDecoded[0]);
            return Ok(userDto);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> Register(UserCreateDTO userCreationDto) 
        {
            try
            {
                if (!ModelState.IsValid)                
                    return BadRequest(ModelState);                
               
                ResponseServiceDTO resultService = await _userService.InsertAsync(userCreationDto);

                if (!resultService.Result)
                    return BadRequest(resultService);                                 

                return Ok(resultService);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseServiceDTO
                {
                    Result = false,
                    Response = null,
                    Message = ex.Message
                });
            }         
        }

        [HttpDelete("{email}")]
        public async Task<ActionResult> Deactivate(string email)
        {
            ResponseServiceDTO resultService;
            try
            {
                var user = await _userService.GetAsync(email);

                if (user == null) return NotFound();

                string emailClaim = User.FindFirst("email").Value;

                if (!string.IsNullOrEmpty(emailClaim) &&
                    user.Email != emailClaim)
                    return BadRequest();

                resultService = await _userService.DeleteAsync(email);

                if (!resultService.Result)
                    return BadRequest();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
           
        }
    }
}
