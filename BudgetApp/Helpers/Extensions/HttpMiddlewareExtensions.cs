using BudgetApp.Helpers.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace BudgetApp.Helpers.Extensions
{
    public static class HttpMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionGlobalHandler(this IApplicationBuilder builder) 
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
