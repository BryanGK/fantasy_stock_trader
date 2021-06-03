using System;
using System.Threading.Tasks;
using Core.Services;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [Route("api/[controller]")]

    public class StocksController : Controller
    {
        private readonly IStockService _stockService;

        public StocksController(IStockService stockService)
        {
            _stockService = stockService;
        }

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
    }
}
