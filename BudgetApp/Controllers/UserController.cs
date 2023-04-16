using AutoMapper;
using Budget.Application.Interfaces;
using Budget.Domain.DTOS.Models;
using Budget.Domain.DTOS.user;
using Budget.Infrastructure.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BudgetApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper mapper;
        public UserController(IUserService userService)
        {
            _userService = userService;
            mapper = AutomapperSingleton.GetMapper();
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<UserDto>> GetAll()
        {
            return await _userService.GetAllAsync();
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> Get([FromRoute] int id)
        {
            var userDto = await _userService.GetAsync(id);
            return Ok(userDto);
        }

        [HttpPost]
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
