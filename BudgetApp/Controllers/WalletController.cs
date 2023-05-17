using Budget.Application.Interfaces;
using Budget.Domain.Entities;
using Budget.Infrastructure.DTOS.Wallet;
using HashidsNet;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace BudgetApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdminOrUser")]
    public class WalletController : ControllerBase
    {
        private readonly IWalletService _walletService;
        private readonly IHashids _hashids;
        private readonly ILogService _logService;

        public WalletController(
            IWalletService walletService,
            IHashids hashids,
            ILogService logService)
        {
            _walletService = walletService;
            _hashids = hashids;
            _logService = logService;
        }
        
        [HttpGet("[action]/{idUser}")]
        public async Task<ActionResult> GetWalletsByUser([FromRoute] string idUser)
        {
            try
            {               
                var rawDecoded = _hashids.Decode(idUser);
                if (rawDecoded.Length <= 0)
                    return NotFound();
                                
                IEnumerable<WalletDTO> wallets = await _walletService.GetFinanceProductUser(rawDecoded[0]);
                return Ok(wallets); 
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
       
        [HttpGet("[action]/{docUser}")]
        public async Task<ActionResult> GetWalletsByDocUser([FromRoute] string docUser)
        {
            try
            {               
                if (string.IsNullOrEmpty(docUser))
                    return NotFound();

                IEnumerable<WalletDTO> wallets = await _walletService.GetFinanceProductUser(docUser);
                return Ok(wallets);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> CreateFinanceProductAsync([FromBody] CreateWalletDTO createWalletDTO) 
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var responseService = await _walletService.InsertAsync(createWalletDTO);

                if (!responseService.Result)
                    return BadRequest(responseService);

                return Ok(responseService);                
            }
            catch (Exception ex)
            {
                LogError log = new LogError
                {
                    DateLog = DateTime.Now,
                    Layer = Layers.Presentation,
                    Method = "CreateFinanceProductAsync",
                    MessageError = ex.Message,
                    Exception = ex.ToString(),
                    Data = JsonSerializer.Serialize(createWalletDTO)
                };

                _logService.SaveLog(log);
                return BadRequest();
            }
        }
    }
}
