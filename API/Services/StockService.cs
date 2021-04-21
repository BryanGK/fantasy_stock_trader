using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using API.Models;
using Newtonsoft.Json;

namespace API.Services
{
    public interface IStockService
    {
        Task<QuoteModel> GetStockQuote(string symbol);

        Task<CompanyModel> GetCompanyData(string symbol);

        Task<List<NewsModel>> GetCompanyNews(string symbol);

        Task<LogoModel> GetCompanyLogo(string symbol);
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

        public async Task<CompanyModel> GetCompanyData(string symbol)
        {
            var response = await _client.GetAsync($"https://cloud.iexapis.com/stable/stock/{symbol}/company?token=pk_20caca1edd3b4f539ae575748c1416c2");

            if (response.IsSuccessStatusCode)
            {
                var iexResponse = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<CompanyModel>(iexResponse);
            }

            throw new Exception("Error in Stock Service");
        }

        public async Task<List<NewsModel>> GetCompanyNews(string symbol)
        {
            var response = await _client.GetAsync($"https://cloud.iexapis.com/stable/stock/{symbol}/news?token=pk_20caca1edd3b4f539ae575748c1416c2");

            if (response.IsSuccessStatusCode)
            {
                var iexResponse = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<NewsModel>>(iexResponse);
            }

            throw new Exception("Error in Stock Service");
        }

        public async Task<LogoModel> GetCompanyLogo(string symbol)
        {
            var response = await _client.GetAsync($"https://cloud.iexapis.com/stable/stock/{symbol}/logo?token=pk_20caca1edd3b4f539ae575748c1416c2");

            if (response.IsSuccessStatusCode)
            {
                var iexResponse = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<LogoModel>(iexResponse);
            }

            throw new Exception("Error in Stock Service");
        }
    }
}
