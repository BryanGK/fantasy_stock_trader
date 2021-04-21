using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]

    public class StocksController : Controller
    {
        public StocksController(IStockService stockService)
        {
            _stockService = stockService;
        }

        private readonly IStockService _stockService;

        [Route("quote/{symbol}")]
        [HttpGet]
        public async Task<IActionResult> GetStockQuote(string symbol)
        {
            try
            {
                return Ok(await _stockService.GetStockQuote(symbol));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [Route("company/{symbol}")]
        [HttpGet]
        public async Task<IActionResult> GetCompanyData(string symbol)
        {
            try
            {
                return Ok(await _stockService.GetCompanyData(symbol));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [Route("news/{symbol}")]
        [HttpGet]
        public async Task<IActionResult> GetCompanyNews(string symbol)
        {
            try
            {
                return Ok(await _stockService.GetCompanyNews(symbol));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [Route("logo/{symbol}")]
        [HttpGet]
        public async Task<IActionResult> GetCompanyLogo(string symbol)
        {
            try
            {
                return Ok(await _stockService.GetCompanyLogo(symbol));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
