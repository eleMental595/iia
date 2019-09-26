using System;
using System.Text;
using System.Threading.Tasks;
using iia.contracts.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace iia.middlewares
{
    public class ExceptionHandler : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                Error errResponse = new Error() { Message = ex.Message };
                var res = JsonConvert.SerializeObject(new ApiSuccessResponse<Error>(errResponse) { Status = Status.Failure });
                context.Response.ContentType = "application/json";
                await context.Response.Body.WriteAsync(Encoding.UTF8.GetBytes(res));
                
            }
        }
    }
}