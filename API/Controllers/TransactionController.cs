using System;
using API.Models;
using AutoMapper;
using Core.Services;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [Route("api/[controller]")]

    public class TransactionController : Controller
    {
        private readonly ITransactionService _transactionService;
        private readonly IMapper _mapper;

        public TransactionController(ITransactionService transService, IMapper mapper)
        {
            _transactionService = transService;
            _mapper = mapper;
        }

        [Route("buy")]
        [HttpPost]
        public ActionResult<WalletModel> Buy([FromBody] TransactionInputModel userData)
        {
            var wallet = _transactionService.Buy(userData.UserId, userData.Stock, userData.Price, userData.Quantity);

            var mappedWallet = _mapper.Map<WalletModel>(wallet);

            return Ok(mappedWallet);

        }

        [Route("sell")]
        [HttpPost]
        public ActionResult<WalletModel> Sell([FromBody] TransactionInputModel userData)
        {
            var wallet = _transactionService.Sell(userData.UserId, userData.Stock, userData.Price, userData.Quantity);

            var mappedWallet = _mapper.Map<WalletModel>(wallet);

            return Ok(mappedWallet);

        }
    }

    public class TransactionInputModel
    {
        public virtual Guid TransactionId { get; set; }

        public virtual string UserId { get; set; }

        public virtual string Stock { get; set; }

        public virtual decimal Price { get; set; }

        public virtual int Quantity { get; set; }
    }
}
