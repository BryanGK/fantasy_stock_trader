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
        private readonly ITransService _transService;
        private readonly IMapper _mapper;

        public TransactionController(ITransService transService, IMapper mapper)
        {
            _transService = transService;
            _mapper = mapper;
        }

        [Route("buy")]
        [HttpPost]
        public ActionResult<WalletModel> Buy([FromBody] TransactionInputModel userData)
        {
            var wallet = _transService.Buy(userData.UserId, userData.Stock, userData.Price, userData.Quantity);

            var mappedWallet = _mapper.Map<WalletModel>(wallet);

            return Ok(mappedWallet);

        }

        [Route("sell")]
        [HttpPost]
        public ActionResult<WalletModel> Sell([FromBody] TransactionInputModel userData)
        {
            var wallet = _transService.Sell(userData.UserId, userData.Stock, userData.Price, userData.Quantity);

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
