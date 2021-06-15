using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Core.Entities;
using Core.IEXModels;
using Infrastructure.Exceptions;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Core.Services
{
    public interface IStockService
    {
        Task<QuoteModel> GetStockQuote(string symbol);

        Task<CompanyModel> GetCompanyData(string symbol);

        Task<List<NewsModel>> GetCompanyNews(string symbol);

        Task<LogoModel> GetCompanyLogo(string symbol);

        Task<Dictionary<string, LatestPriceModel>> LatestPrice(List<TransactionEntity> holdings);
    }

    public class StockService : IStockService
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;

        public StockService(IApiHelper apiHelper, IConfiguration configuration)
        {
            _client = apiHelper.InitializeClient();
            _configuration = configuration;
        }

        public async Task<QuoteModel> GetStockQuote(string symbol)
        {
            var response = await _client.GetAsync($"https://cloud.iexapis.com/stable/stock/{symbol}/quote?token=" + _configuration["IEX:ApiKey"]);

            if (response.IsSuccessStatusCode)
            {
                var iexResponse = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<QuoteModel>(iexResponse);
            }

            throw new StockNotFoundException($"Error - The Stock symbol '{symbol}' was not found.");
        }

        public async Task<CompanyModel> GetCompanyData(string symbol)
        {
            var response = await _client.GetAsync($"https://cloud.iexapis.com/stable/stock/{symbol}/company?token=" + _configuration["IEX:ApiKey"]);

            if (response.IsSuccessStatusCode)
            {
                var iexResponse = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<CompanyModel>(iexResponse);
            }

            throw new StockNotFoundException($"Error - The Stock symbol '{symbol}' was not found.");
        }

        public async Task<List<NewsModel>> GetCompanyNews(string symbol)
        {
            var response = await _client.GetAsync($"https://cloud.iexapis.com/stable/stock/{symbol}/news?token=" + _configuration["IEX:ApiKey"]);

            if (response.IsSuccessStatusCode)
            {
                var iexResponse = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<NewsModel>>(iexResponse);
            }

            throw new StockNotFoundException($"Error - The Stock symbol '{symbol}' was not found.");

        }

        public async Task<LogoModel> GetCompanyLogo(string symbol)
        {
            var response = await _client.GetAsync($"https://cloud.iexapis.com/stable/stock/{symbol}/logo?token=" + _configuration["IEX:ApiKey"]);

            if (response.IsSuccessStatusCode)
            {
                var iexResponse = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<LogoModel>(iexResponse);
            }

            throw new StockNotFoundException($"Error - The Stock symbol '{symbol}' was not found.");

        }

        public async Task<Dictionary<string, LatestPriceModel>> LatestPrice(List<TransactionEntity> holdings)
        {
            var query = "";

            foreach (var holding in holdings)
            {
                query += $"{holding.Stock},";
            }
            var response = await _client.GetAsync($"https://cloud.iexapis.com/stable/stock/market/batch?symbols={query}&types=quote&format=json&range=1m&last=5&token=" + _configuration["IEX:ApiKey"]);

            if (response.IsSuccessStatusCode)
            {

                var iexResponse = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<Dictionary<string, LatestPriceModel>>(iexResponse);
           
            }

            throw new StockNotFoundException("Error in Stock Service - Error getting latest price.");
        }
    }
}
