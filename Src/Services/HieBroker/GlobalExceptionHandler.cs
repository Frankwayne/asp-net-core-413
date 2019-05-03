using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace test
{
    public static class GlobalExceptionHandler
    {
        public static void ConfigureGlobalExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var test = contextFeature.Error;
                });
            });
        }
    }
}
