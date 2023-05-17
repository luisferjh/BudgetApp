using Budget.Application.Interfaces;
using Budget.Infrastructure.DTOS.FinancialProduct;
using Budget.Infrastructure.DTOS.Incomes;
using HashidsNet;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BudgetApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
    public class IncomeCategoryController : ControllerBase
    {
        private readonly IIncomeCategoryService _incomeCategoryService;
        private readonly IHashids _hashids;

        public IncomeCategoryController(
            IIncomeCategoryService incomeCategoryService,
            IHashids hashids)
        {
            _incomeCategoryService = incomeCategoryService;
            _hashids = hashids;
        }

        [Authorize(Policy = "IsAdminOrUser")]
        [HttpGet("[action]")]
        public async Task<IEnumerable<IncomeCategoryDTO>> GetAllAsync()
        {

            var finProd = await _incomeCategoryService.GetAllAsync();
            return finProd;
        }

        [Authorize(Policy = "IsAdminOrUser")]
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult> Get([FromRoute] string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest("you must provide an id");

            var arrayIdDecoded = _hashids.Decode(id);
            if (arrayIdDecoded.Length <= 0)
                return NotFound();

            var incomeCategory = await _incomeCategoryService.GetAsync(arrayIdDecoded[0]);

            if (incomeCategory == null)
                return NotFound();

            return Ok(incomeCategory);
        }

        [Authorize(Policy = "IsAdmin")]
        [HttpPost("[action]")]
        public async Task<ActionResult> Post([FromBody] CreateIncomeCategoryDTO createIncomeCategory)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _incomeCategoryService.AddAsync(createIncomeCategory);

            if (result <= 0)
                return BadRequest();

            return Ok();
        }

        [Authorize(Policy = "IsAdmin")]
        [HttpPut("[action]/{id}")]
        public async Task<ActionResult> Update([FromRoute] string id, [FromBody] CreateIncomeCategoryDTO createIncomeCategory)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var arrayIdDecoded = _hashids.Decode(id);
            if (arrayIdDecoded.Length <= 0)
                return NotFound();

            var incomeCategoryExists = await _incomeCategoryService.IncomeCategoryExistAsync(arrayIdDecoded[0]);
            if (!incomeCategoryExists)
                return NotFound("the income category doesn't exist");

            var result = _incomeCategoryService.Update(createIncomeCategory);

            if (result <= 0)
                return BadRequest();

            return Ok("income category updated");
        }

        [Authorize(Policy = "IsAdmin")]
        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult> Delete([FromRoute] string id)
        {
            var arrayIdDecoded = _hashids.Decode(id);
            if (arrayIdDecoded.Length <= 0)
                return NotFound();

            var incomeCategoryExists = await _incomeCategoryService.IncomeCategoryExistAsync(arrayIdDecoded[0]);
            if (!incomeCategoryExists)
                return NotFound("the income category doesn't exist");

            var result = _incomeCategoryService.Delete(arrayIdDecoded[0]);

            if (result <= 0)
                return BadRequest();

            return Ok("Income category deleted");
        }
    }
}
