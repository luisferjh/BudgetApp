using Budget.Domain.DTOS.Models;
using Budget.Domain.Entities;
using Budget.Infrastructure.DTOS.Incomes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Budget.Infrastructure.DTOS.Spents;
using Budget.Application.Interfaces;
using System.Text.Json;

namespace BudgetApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsUser")]
    public class SpentController: ControllerBase
    {
        private readonly ISpentService _spentService;
        private readonly ILogService _logService;

        public SpentController(ISpentService spentService, ILogService logService)
        {
            _spentService = spentService;
            _logService = logService;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> AddSpent(CreateSpentDTO createSpentDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(createSpentDTO);

                ResponseServiceDTO responseService = await _spentService.AddSpentAsync(createSpentDTO);
                if (!responseService.Result)
                    return BadRequest(createSpentDTO);

                return Ok(createSpentDTO);
            }
            catch (Exception ex)
            {
                LogError logError = new LogError
                {
                    Data = JsonSerializer.Serialize(createSpentDTO),
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
        public async Task<IEnumerable<SpentDTO>> GetSpentsUser(
            [FromRoute] int idUser,
            [FromQuery] int year,
            [FromQuery] int idSpentItem)
        {
            return await _spentService.GetSpentsByUser(idUser, year, idSpentItem);
        }
    }
}
