using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using api_trustedfund.Models;
using api_trustedfund.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace api_trustedfund.Controllers
{
    [ApiController]
    [Route("trade")]
    public class TradeController : ControllerBase
    {
        private readonly TradeService _tradeService;


        public TradeController(TradeService tradeService)
        {
            _tradeService = tradeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTrades()
        {
            var trades = await _tradeService.GetAllTrades();
            return Ok(trades);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetTradeById(int id)
        {
            var trade = await _tradeService.GetTradeById(id);

            if (trade == null) return NotFound();

            return Ok(trade);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Trades trade)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newTrade = await _tradeService.AddNewTrade(trade);
            return CreatedAtAction(nameof(GetTradeById), new { id = newTrade.Id }, newTrade);
        }
    }
}