using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace WebSampleApp.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CustomHeadingMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomHeadingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            httpContext.Response.Headers.Add("myheader", "my app");
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CustomHeadingMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomHeadingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomHeadingMiddleware>();
        }
    }
}
