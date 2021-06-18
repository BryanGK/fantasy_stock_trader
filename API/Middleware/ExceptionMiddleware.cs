using System;
using System.Threading.Tasks;
using Infrastructure.Exceptions;
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
            catch (UserNotFoundException ex)
            {

                context.Response.StatusCode = 404;
                context.Response.Headers.Add("content-type", "application/json");
                await context.Response.WriteAsync(ex.Message);

            }
            catch (StockNotFoundException ex)
            {

                context.Response.StatusCode = 404;
                context.Response.Headers.Add("content-type", "application/json");
                await context.Response.WriteAsync(ex.Message);

            }
            catch (UserAlreadyExistsException ex)
            {

                context.Response.StatusCode = 403;
                context.Response.Headers.Add("content-type", "application/json");
                await context.Response.WriteAsync(ex.Message);

            }
            catch (InsufficientAvailableFundsException ex)
            {

                context.Response.StatusCode = 403;
                context.Response.Headers.Add("content-type", "application/json");
                await context.Response.WriteAsync(ex.Message);

            }
            catch (Exception ex)
            {

                Console.WriteLine("An exception ({0}) occured.", ex.GetType().Name);
                Console.WriteLine("Message:\n {0}\n", ex.Message);
                Console.WriteLine("Stack Trace:\n {0}\n", ex.StackTrace);
                context.Response.StatusCode = 500;
                context.Response.Headers.Add("content-type", "application/json");
                await context.Response.WriteAsync(ex.Message);

            }
        }
    }
}
