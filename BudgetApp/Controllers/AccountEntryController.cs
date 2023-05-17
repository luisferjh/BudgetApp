using Budget.Application.Services;
using Budget.Infrastructure.Common;
using Budget.Infrastructure.DTOS.AccountEntry;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountEntryController : ControllerBase
    {
        private readonly IAccountEntriesServices _accountEntryService;
        private readonly IMapping _mapping;

        public AccountEntryController(
            IAccountEntriesServices accountEntryService,
            IMapping mapping)
        {
            _accountEntryService = accountEntryService;
            _mapping = mapping;
        }

        [Authorize(Policy = "IsAdmin")]
        [HttpGet("[action]")]
        public async Task<IEnumerable<AccountEntriesDTO>> GetAllAsync()
        {
            return await _accountEntryService.GetAllAsync();             
        }

        [Authorize(Policy = "IsAdminOrUser")]
        [HttpGet("[action]/{id:int}")]
        public async Task<ActionResult> GetAsync([FromRoute] int id) 
        {
            var accountEntry = await _accountEntryService.GetAsync(id);

            if (accountEntry == null)
                return NotFound();

            return Ok(accountEntry);
        }
    }
}
