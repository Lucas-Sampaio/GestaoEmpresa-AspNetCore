using Microsoft.AspNetCore.Http;
using System.Net;
using System.Threading.Tasks;

namespace GestaoEmpresa.Web.Extensions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {      
            //as requisiçoes passa por esse metodo, se der erro ele trata se não continua
            try
            {
                await _next(httpContext);
            }
            catch (CustomHttpRequestException ex)
            {
                HandleRequestExceptionAsync(httpContext, ex.StatusCode);
            }
        }
        private static void HandleRequestExceptionAsync(HttpContext context, HttpStatusCode statusCode)
        {     
            context.Response.StatusCode = (int)statusCode;
        }
    }
}
