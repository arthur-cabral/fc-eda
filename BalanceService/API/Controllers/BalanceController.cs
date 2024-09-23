using API.ExternalAPIs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("balances")]
    [ApiController]
    public class BalanceController : ControllerBase
    {
        private readonly IWalletService _walletService;

        public BalanceController(IWalletService walletService)
        {
            _walletService = walletService;
        }

        [HttpGet("/{account_id}")]
        public async Task<ActionResult<double>> GetBalanceByAccountId(string account_id)
        {
            var balance = _walletService.GetBalanceByAccountId(account_id);
            return Ok(balance);
        }
    }
}
