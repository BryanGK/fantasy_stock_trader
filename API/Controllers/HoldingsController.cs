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
        private readonly ITransService _transService;

        public HoldingsController(IHoldingsService holdingsService, ITransService transService)
        {
            _holdingsService = holdingsService;
        }

        [Route("get/{userId}")]
        [HttpGet]
        public ActionResult<List<HoldingsModel>> Get(string userId)
        {
            try
            {
                Console.WriteLine($"USER ID @ GET CONTROLLER: {userId}");
                return Ok(_holdingsService.Get(userId));

            }
            catch (Exception e)
            {

                return StatusCode(500, $"{e.Message} {e.StackTrace} - Something's not right.");

            }
        }
    }
}
