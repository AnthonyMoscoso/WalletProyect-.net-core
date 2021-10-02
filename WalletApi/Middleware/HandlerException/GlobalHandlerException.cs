using Core.Entities.Utilities.Logs;
using Entities.Dto.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace WalletApi.Middleware.HandlerException
{
    public class GlobalHandlerException
    {
        private readonly RequestDelegate _next;
        private readonly ILogManager _logger;
        public GlobalHandlerException(RequestDelegate next,ILogManager logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {

                string message = e?.InnerException?.InnerException?.Message ?? e.InnerException?.Message ?? e.Message;
                _logger.Write($"{message}",MessageType.error);
                await HandleExceptionAsync(context, e);
            }
        }


        private async Task HandleExceptionAsync(HttpContext context, Exception e)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError);
            await context.Response.WriteAsync(new ErrorRequest()
            {
                StatusCode = context.Response.StatusCode,
                Message = e?.InnerException?.InnerException?.Message ?? e.InnerException?.Message ?? e.Message
            }.ToString());
        }
    }
}
