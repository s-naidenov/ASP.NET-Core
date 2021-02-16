using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GettingKnowWeb.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private RequestDelegate _next;
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            await _next.Invoke(context);
            int status = context.Response.StatusCode;
            switch (status) 
            {
                case 404:
                    await context.Response.WriteAsync("Not Found");
                    break;
                case 416:
                    await context.Response.WriteAsync("Not Enough right");
                    break;
                case 417:
                    await context.Response.WriteAsync("Default page");
                    break;
                case 418:
                    await context.Response.WriteAsync("Path does not exist");
                    break;
            }
        }
    }
}
