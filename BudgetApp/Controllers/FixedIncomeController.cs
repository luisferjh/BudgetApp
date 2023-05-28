using Budget.Application.Interfaces;
using Budget.Infrastructure.DTOS.FixedIncomes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BudgetApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FixedIncomeController:ControllerBase
    {
        private readonly IFixedIncomeService _fixedIncomeService;

        public FixedIncomeController(IFixedIncomeService fixedIncomeService)
        {
            _fixedIncomeService = fixedIncomeService;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> AddFixedIncome([FromBody] CreateFixedIncomeDTO createFixedIncomeDTO) 
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var responseService = await _fixedIncomeService.AddFixedIncomeAsync(createFixedIncomeDTO);
                if (!responseService.Result)
                    return BadRequest(responseService);

                return Ok(responseService); 
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> RunFixedIncomes()
        {
            try
            {                
                var responseService = await _fixedIncomeService.RunFixedIncomeAsync();
             
                if (!responseService.Result)
                    return BadRequest(responseService);

                return Ok(responseService);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
