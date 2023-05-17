using Budget.Application.Interfaces;
using Budget.Application.Services;
using Budget.Infrastructure.Common;
using Budget.Infrastructure.DTOS.AccountEntry;
using Budget.Infrastructure.DTOS.Operation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BudgetApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class OperationController : ControllerBase
    {
        private readonly IOperationService _operationService;
        private readonly IMapping _mapping;

        public OperationController(
            IOperationService operationService,
            IMapping mapping)
        {
            _operationService = operationService;
            _mapping = mapping;
        }

        [Authorize(Policy = "IsAdmin")]
        [HttpGet("[action]")]
        public async Task<IEnumerable<OperationDTO>> GetAllAsync()
        {
            return await _operationService.GetAllAsync();
        }

        [Authorize(Policy = "IsAdminOrUser")]
        [HttpGet("[action]/{id:int}")]
        public async Task<ActionResult> GetAsync([FromRoute] int id)
        {
            var operation = await _operationService.GetAsync(id);

            if (operation == null)
                return NotFound();

            return Ok(operation);
        }

    }
}
