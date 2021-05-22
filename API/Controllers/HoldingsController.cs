using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Core.Entities;
using Core.Services;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [Route("api/[controller]")]

    public class HoldingsController : Controller
    {

        private readonly IHoldingsService _holdingsService;

        private readonly IHoldingsProcessor _holdingsProcessor;

        public HoldingsController(IHoldingsService holdingsService, IHoldingsProcessor holdingsProcessor)
        {
            _holdingsService = holdingsService;

            _holdingsProcessor = holdingsProcessor;
        }

        [Route("get/{userId}")]
        [HttpGet]
        public ActionResult<List<HoldingsModel>> Get(string userId)
        {
            try
            {
                var transactions = _holdingsService.GetTransactions(userId);

                var processedHoldings = _holdingsProcessor.HoldingsCombiner(transactions);

                var holdingsValue = _holdingsProcessor.HoldingsValue(transactions);

                var cash = _holdingsService.GetWallet(userId);

                var holdings = new HoldingsModel()
                {
                    Cash = cash.Cash,
                    Value = holdingsValue,
                    Holdings = processedHoldings
                };

                // Get Value
                // Get Cash

                return Ok(holdings);

            }
            catch (Exception e)
            {

                return StatusCode(500, $"{e.Message} {e.StackTrace} - Something's not right.");

            }
        }
    }
}
