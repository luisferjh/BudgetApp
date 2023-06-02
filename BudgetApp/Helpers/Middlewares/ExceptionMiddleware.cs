using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace BudgetApp.Helpers.Middlewares
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
            catch (Exception ex)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine($"Error Detail: {context.Request.Path}");

                await response.WriteAsync("Error");
            }
        }
    }
}
