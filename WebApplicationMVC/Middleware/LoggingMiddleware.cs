using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using WebApplicationMVC.Repositories;

namespace WebApplicationMVC.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var requestRepository = context.RequestServices.GetService<IRequestRepository>();

            // Формируем полный URL включая query-параметры
            string url = $"{context.Request.Scheme}://{context.Request.Host}{context.Request.Path}{context.Request.QueryString}";

            try
            {
                await requestRepository.LogRequestAsync(url);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[!] Logging failed: {ex.Message}");
            }

            await _next.Invoke(context);
        }
    }
}