using AutoMapper;
using Budget.Application.Interfaces;
using Budget.Domain.DTOS.Models;
using Budget.Domain.DTOS.user;
using Budget.Infrastructure.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BudgetApp.Controllers
{
    [Route("api/controller")]
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
                {
                    return BadRequest(ModelState);
                }

                //var userDto = mapper.Map<UserCreateDTO, UserDto>(userCreationDto);
                ResponseServiceDTO resultService = await _userService.InsertAsync(userCreationDto);

                if (resultService.Result)
                    return Ok(resultService);
                else
                    return BadRequest(resultService);
                                
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
            ResponseServiceDTO resultService = await _userService.DeleteAsync(email);
            if (resultService.Result)
                return Ok();
            else
                return BadRequest();
        }
    }
}
