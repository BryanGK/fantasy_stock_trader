using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                Console.WriteLine("An exception ({0}) occured.", e.GetType().Name);
                Console.WriteLine("Message:\n {0}\n", e.Message);
                Console.WriteLine("Stack Trace:\n {0}\n", e.StackTrace);
            }
        }
    }
}
