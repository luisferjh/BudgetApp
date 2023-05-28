using AutoMapper;
using Budget.Application.Interfaces;
using Budget.Domain.DTOS.Models;
using Budget.Domain.Entities;
using Budget.Infrastructure.Common;
using Budget.Infrastructure.DTOS.Incomes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace BudgetApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsUser")]
    public class IncomeController : ControllerBase
    {
        private readonly IIncomeService _incomeService;
        private readonly ILogService _logService;
        private readonly IMapper _mapper;

        public IncomeController(IIncomeService incomeService, ILogService logService)
        {
            _incomeService = incomeService;
            _mapper = AutomapperSingleton.GetMapper();
            _logService = logService;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> AddIncome([FromBody] CreateIncomeDTO createIncomeDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(createIncomeDTO);

                ResponseServiceDTO responseService = await _incomeService.AddIncomeAsync(createIncomeDTO);
                if (!responseService.Result)
                    return BadRequest(createIncomeDTO);

                return Ok(createIncomeDTO);
            }
            catch (Exception ex)
            {
                LogError logError = new LogError {
                    Data = JsonSerializer.Serialize(createIncomeDTO),
                    MessageError = ex.Message,
                    StackTrace = ex.StackTrace,
                    Layer = Layers.Presentation,
                    DateLog = DateTime.Now,
                };
                await _logService.SaveLog(logError);

                return BadRequest();
            }


        }

        [HttpGet("[action]/{idUser:int}")]
        public async Task<IEnumerable<IncomeDTO>> GetIncomesUser(
            [FromRoute] int idUser,
            [FromQuery] int year,
            [FromQuery] int idIncomeCategory) 
        {
           return await _incomeService.GetIncomesByUser(idUser, year, idIncomeCategory);
        }
    }
}
