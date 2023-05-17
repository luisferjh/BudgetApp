using Budget.Application.Interfaces;
using Budget.Application.Services;
using Budget.Infrastructure.DTOS.FinancialProduct;
using HashidsNet;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BudgetApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class FinancialProductController : ControllerBase
    {
        private readonly IFinancialProductService _financialProductService;
        private readonly IHashids _hashids;

        public FinancialProductController(
            IFinancialProductService financialProductService,
            IHashids hashids)
        {
            _financialProductService = financialProductService;
            _hashids = hashids;
        }

        [Authorize(Policy = "IsAdminOrUser")]
        [HttpGet("[action]")]
        public async Task<IEnumerable<FinancialProductDTO>> GetAll()
        {                       

            var finProd = await _financialProductService.GetAllAsync();            
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

            var finProd = await _financialProductService.GetAsync(arrayIdDecoded[0]);

            if (finProd == null)
                return NotFound();

            return Ok(finProd);
        }

        [Authorize(Policy = "IsAdmin")]
        [HttpPost("[action]")]
        public async Task<ActionResult> Post([FromBody] CreateFinanceProductDTO createFinanceProduct)
        {
            if (!ModelState.IsValid)
                return BadRequest(); 
                      
            var result = await _financialProductService.AddAsync(createFinanceProduct);

            if (result <= 0)
                return BadRequest();

            return Ok();
        }

        [Authorize(Policy = "IsAdmin")]
        [HttpPut("[action]/{id}")]
        public async Task<ActionResult> Update([FromRoute] string id, [FromBody] CreateFinanceProductDTO createFinanceProduct)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var arrayIdDecoded = _hashids.Decode(id);
            if (arrayIdDecoded.Length <= 0)
                return NotFound();

            var financeProductExists = await _financialProductService.ProductExistAsync(arrayIdDecoded[0]);
            if (!financeProductExists)
                return NotFound("the finance product doesn't exist");

            var result = _financialProductService.Update(createFinanceProduct);

            if (result <= 0)
                return BadRequest();

            return Ok("Finance product updated");
        }

        [Authorize(Policy = "IsAdmin")]
        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult> Delete([FromRoute] string id)
        {           
            var arrayIdDecoded = _hashids.Decode(id);
            if (arrayIdDecoded.Length <= 0)
                return NotFound();

            var financeProductExists = await _financialProductService.ProductExistAsync(arrayIdDecoded[0]);
            if (!financeProductExists)
                return NotFound("the finance product doesn't exist");

            var result = _financialProductService.Delete(arrayIdDecoded[0]);

            if (result <= 0)
                return BadRequest();

            return Ok("Finance product deleted");
        }

    }
}
