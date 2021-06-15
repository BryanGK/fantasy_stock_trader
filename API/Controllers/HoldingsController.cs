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

        private readonly ITransactionQueryService _transactionQueryService;

        public HoldingsController(IHoldingsService holdingsService,
            IHoldingsProcessor holdingsProcessor,
            ITransactionQueryService transactionQueryService)
        {

            _holdingsService = holdingsService;

            _holdingsProcessor = holdingsProcessor;

            _transactionQueryService = transactionQueryService;

        }

        [Route("get/holdings")]
        [HttpGet]
        public ActionResult<HoldingsModel> Holdings([FromHeader] HoldingsInputModel userData)
        {

            return Ok(_holdingsService.GetHoldings(userData.userId));

        }

        [Route("get/transactions")]
        [HttpGet]
        public ActionResult<List<TransactionModel>> Transactions([FromHeader] HoldingsInputModel userData)
        {

            var transactions = _transactionQueryService.GetTransactions(userData.userId);

            return Ok(_holdingsProcessor.Transactions(transactions));

        }

        public class HoldingsInputModel
        {
            [FromHeader]
            public string userId { get; set; }
        }
    }
}
