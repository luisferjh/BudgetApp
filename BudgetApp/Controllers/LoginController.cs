using System;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Budget.Application.Interfaces;
using Budget.Domain.DTOS.Models;
using Budget.Infrastructure.DTOS.user.Requests;
using Budget.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BudgetApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _login;
        private readonly ILogService _logService;

        public LoginController(ILoginService login,
            ILogService logService)
        {
            _login = login;
            _logService = logService;
        }

        [HttpPost]
        public async Task<ActionResult> Login([FromBody] LoginDTO loginModel) 
        {
         
            AuthenticationResultDTO result = null;
            try
            {
                if (!ModelState.IsValid)
                    return Unauthorized();

                result = await _login.LoginAsync(loginModel);

                if (!result.Success)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                await _logService.SaveLog(new LogError {
                    Data = loginModel.ToString(),
                    DateLog = DateTime.Now,
                    Method = "LoginController",
                    Trace = ex.Message,
                    Layer = Layers.Presentation
                });

                return BadRequest(result);
                //return StatusCode(StatusCodes.Status500InternalServerError);
            }

           
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            AuthenticationResultDTO result = null;
            try
            {
                if (!ModelState.IsValid)
                    return Unauthorized();

                result = await _login.RefreshTokenAsync(request.Token, request.RefreshToken);

                if (!result.Success)
                    return BadRequest(result);

                return Ok(result);
            }
            catch 
            {
                return BadRequest(result);
            }
           
        }

    }
}
