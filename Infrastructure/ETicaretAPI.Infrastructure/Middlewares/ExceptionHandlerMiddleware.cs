using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Infrastructure.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private RequestDelegate next; 
        public ExceptionHandlerMiddleware(RequestDelegate Next)
        {
            next = Next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await next.Invoke(httpContext);
            }
            catch (Exception ex)
            {
                //Hata yönetimi
            }
            
        }
    }
}
