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
                var holdings = _holdingsService.Get(userId);
                Console.WriteLine($"HOLDINGS: {holdings}");
                var processedHoldings = _holdingsProcessor.HoldingsCombiner(holdings);
                Console.WriteLine($"HOLDINGS: {processedHoldings}");
                return Ok(processedHoldings);

            }
            catch (Exception e)
            {

                return StatusCode(500, $"{e.Message} {e.StackTrace} - Something's not right.");

            }
        }
    }
}
