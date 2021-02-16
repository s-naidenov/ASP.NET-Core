using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GettingKnowWeb.Middleware
{
    public class AuthenticationMiddleware
    {
        private RequestDelegate _next;
        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Query["token"].ToString();
            int v;
            if (!string.IsNullOrEmpty(token))
            {
                v = Int32.Parse(token);

                if (v > 200 && v < 356)
                {
                    await _next.Invoke(context);
                }
                else
                {
                    context.Response.StatusCode = 416;
                }
            }
            else 
            {
                context.Response.StatusCode = 417;
            }
         
            
        }
    }
}
