using System;
using System.Net.Http;
using System.Threading.Tasks;
using API.Models;

namespace API.Services
{
    public interface IStockService
    {
        Task<QuoteModel> GetStock();
    }

    public class StockService : IStockService
    {
        private readonly HttpClient _client;

        public StockService(IApiHelper apiHelper)
        {
            _client = apiHelper.InitializeClient();
        }

        public  Task<QuoteModel> GetStock()
        {
            throw new NotImplementedException();
        }
    }
}
