using ApiCatalogoSecond.Domain.Models;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace ApiCatalogoSecond.Extensions.Exceptions;

public static class ExceptionMiddlewareExtensions
{
    public static void ConfigureExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async ctx =>
            {
                ctx.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                ctx.Response.ContentType = "application/json";

                var contextFeatures = ctx.Features.Get<IExceptionHandlerFeature>();

                if (contextFeatures != null)
                {
                    await ctx.Response.WriteAsync(new ErrorDetails()
                    {
                        StatusCode = ctx.Response.StatusCode,
                        Message = contextFeatures.Error.Message,
                        Trace = contextFeatures.Error.StackTrace,
                    }.ToString());
                }
            });
        });
    }
}
