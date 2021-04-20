using System;
using System.Net.Http;
using System.Threading.Tasks;
using API.Models;
using Newtonsoft.Json;

namespace API.Services
{
    public interface IStockService
    {
        Task<QuoteModel> GetStockQuote(string symbol);
    }

    public class StockService : IStockService
    {
        private readonly HttpClient _client;

        public StockService(IApiHelper apiHelper)
        {
            _client = apiHelper.InitializeClient();
        }

        public async Task<QuoteModel> GetStockQuote(string symbol)
        {
            var response = await _client.GetAsync($"https://cloud.iexapis.com/stable/stock/{symbol}/quote?token=pk_20caca1edd3b4f539ae575748c1416c2");

            if (response.IsSuccessStatusCode)
            {
                var iexResponse = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<QuoteModel>(iexResponse);
            }

            throw new Exception("Error in Stock Service");
        }
    }
}
