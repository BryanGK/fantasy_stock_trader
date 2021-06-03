using System;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [Route("api/[controller]")]

    public class TransController : Controller
    {
        private readonly ITransService _transService;

        public TransController(IHoldingsService holdingsService, ITransService transService)
        {
            _transService = transService;
        }

        [Route("buy")]
        [HttpPost]
        public ActionResult<WalletModel> Buy([FromBody] TransactionInputModel userData)
        {

            return Ok(_transService.Buy(userData.UserId, userData.Stock, userData.Price, userData.Quantity));

        }

        [Route("sell")]
        [HttpPost]
        public ActionResult<WalletModel> Sell([FromBody] TransactionInputModel userData)
        {

            return Ok(_transService.Sell(userData.UserId, userData.Stock, userData.Price, userData.Quantity));

        }
    }
}
