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

    public class TransController : Controller
    {
        private readonly ILoginService _loginService;
        private readonly ITransService _transService;

        public TransController(ILoginService loginService, ITransService transService)
        {
            _loginService = loginService;
            _transService = transService;
        }

        [Route("buy")]
        [HttpPost]
        public ActionResult<WalletModel> Post([FromBody] TransactionModel userData)
         {
            try
            {
                return Ok(_transService.Buy(userData));
            }
            catch (Exception e)
            {
                return StatusCode(500, $"{e.Message} {e.StackTrace} - Something's not right.");
            }
        }
    }
}
