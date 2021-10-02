using Entities.Dto.Utilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace WalletApi.Middleware.HandlerException
{
    public static class ExceptionHandlerConfigure
    {

        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<GlobalHandlerException>();
        }
    }
}
