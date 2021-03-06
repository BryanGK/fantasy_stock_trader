using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;

namespace Core.Services
{
    public interface IApiHelper
    {
        HttpClient InitializeClient();
    }

    public class ApiHelper : IApiHelper
    {
        private readonly IConfiguration _configuration;

        public ApiHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public HttpClient InitializeClient()
        {
            var apiClient = new HttpClient();

            apiClient.DefaultRequestHeaders.Accept.Clear();

            apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return apiClient;
        }
    }

}
