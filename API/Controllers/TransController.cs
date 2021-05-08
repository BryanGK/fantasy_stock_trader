using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [Route("api/[controller]")]

    public class TransController : Controller
    {
        private readonly IAuthService _authService;
        private readonly ITransService _transService;

        public TransController(IAuthService authService, ITransService transService)
        {
            _authService = authService;
            _transService = transService;
        }

        [Route("buy")]
        [HttpPost]
        public ActionResult<UserWallet> Post([FromBody] TransModel userData)
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
