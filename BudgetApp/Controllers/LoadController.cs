using Budget.Application.Interfaces;
using Budget.Domain.DTOS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BudgetApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoadController:ControllerBase
    {
        private readonly ILoadsService _loadsService;

        public LoadController(ILoadsService loadsService)
        {
            _loadsService = loadsService;
        }

        [HttpPost]
        public ActionResult LoadBanks(IFormFile file)
        {
            ResponseServiceDTO serviceResult = new ResponseServiceDTO();
            try
            {
                serviceResult = _loadsService.LoadBanks(file);

                if (!serviceResult.Result)                                  
                    return BadRequest(serviceResult);

                return Ok(serviceResult);
            }             
            catch
            {
                return BadRequest();
            }            
        }
    }
}
