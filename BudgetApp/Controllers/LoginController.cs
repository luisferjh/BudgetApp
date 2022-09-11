﻿using System;
using Budget.Domain.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Budget.Application.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BudgetApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _login;
        public LoginController(ILoginService login)
        {
            _login = login;
        }

        [HttpPost("[action]")]
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
                
            }
            catch (Exception ex)
            {
                throw;
            }

            return Ok(result);
        }
    }
}