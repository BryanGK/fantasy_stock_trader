using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [Route("api/[controller]")]

    public class HoldingsController : Controller
    {

        private readonly IHoldingsService _holdingsService;

        private readonly IHoldingsProcessor _holdingsProcessor;

        private readonly IStockService _stockService;

        public HoldingsController(IHoldingsService holdingsService, IHoldingsProcessor holdingsProcessor, IStockService stockService)
        {

            _holdingsService = holdingsService;

            _holdingsProcessor = holdingsProcessor;

            _stockService = stockService;

        }

        [Route("get/holdings")]
        [HttpGet]
        public async Task<ActionResult<List<HoldingsModel>>> Holdings([FromHeader] HoldingsInputModel userData)
        {

            var transactions = _holdingsService.GetHoldings(userData.userId);

            if (transactions.Count > 0)
            {

                var latestPrice = await _stockService.LatestPrice(transactions);

                var processedHoldings = _holdingsProcessor.HoldingsCombiner(transactions, latestPrice);

                var holdingsValue = _holdingsProcessor.HoldingsValue(processedHoldings);

                var cash = _holdingsService.GetWallet(userData.userId);

                var holdings = new HoldingsModel()
                {
                    Cash = cash.Cash,
                    Value = holdingsValue,
                    Holdings = processedHoldings
                };

                return Ok(holdings);
            }
            else
            {
                var cash = _holdingsService.GetWallet(userData.userId);

                var holdings = new HoldingsModel()
                {
                    Cash = cash.Cash,
                };

                return Ok(holdings);
            }
        }

        [Route("get/transactions")]
        [HttpGet]
        public ActionResult<List<TransactionModel>> Transactions([FromHeader] HoldingsInputModel userData)
        {

            var transactions = _holdingsService.GetHoldings(userData.userId);

            var transactionList = _holdingsProcessor.Transactions(transactions);

            return Ok(transactionList);

        }

        public class HoldingsInputModel
        {
            [FromHeader]
            public string userId { get; set; }
        }
    }
}
