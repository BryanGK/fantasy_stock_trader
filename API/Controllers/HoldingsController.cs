using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;
using AutoMapper;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [Route("api/[controller]")]

    public class HoldingsController : Controller
    {

        private readonly IHoldingsService _holdingsService;
        private readonly ITransactionQueryService _transactionQueryService;
        private readonly IMapper _mapper;

        public HoldingsController(IHoldingsService holdingsService,
            ITransactionQueryService transactionQueryService,
            IMapper mapper)
        {

            _holdingsService = holdingsService;
            _transactionQueryService = transactionQueryService;
            _mapper = mapper;

        }

        [Route("get/holdings")]
        [HttpGet]
        public async Task<ActionResult<TotalHoldingsModel>> Holdings([FromHeader] HoldingsInputModel userData)
        {
            var holdings = await _holdingsService.GetHoldings(userData.userId);

            var mappedHoldings = _mapper.Map<TotalHoldingsModel>(holdings);

            return Ok(mappedHoldings);

        }

        [Route("get/transactions")]
        [HttpGet]
        public ActionResult<List<TransactionModel>> Transactions([FromHeader] HoldingsInputModel userData)
        {

            var transactions = _transactionQueryService.GetTransactions(userData.userId);

            var mappedTransactions = _mapper.Map<List<TransactionModel>>(transactions);

            return Ok(mappedTransactions);

        }

        public class HoldingsInputModel
        {
            [FromHeader]
            public string userId { get; set; }
        }
    }
}
