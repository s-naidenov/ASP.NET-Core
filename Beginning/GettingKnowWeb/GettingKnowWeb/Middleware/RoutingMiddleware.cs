using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GettingKnowWeb.Middleware
{
    public class RoutingMiddleware
    {
        private readonly RequestDelegate _next;
        public RoutingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string path = context.Request.Path.Value.ToLower();
            switch (path) 
            {
                case "/home":
                    await context.Response.WriteAsync("Home Page");
                    break;
                case "/about":
                    await context.Response.WriteAsync("About");
                    break;
                case "/empty":
                    context.Response.StatusCode = 404;
                    break;
                default:
                    context.Response.StatusCode = 418;
                    break;

            }
           
        }
    }
}
