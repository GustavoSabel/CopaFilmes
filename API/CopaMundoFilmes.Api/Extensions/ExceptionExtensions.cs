using CopaMundoFilmes.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System.Text.Json;

namespace CopaMundoFilmes.Api.Extensions
{
    public static class ExceptionExtensions
    {
        public static void UseExceptionHandlerApp(this IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IWebHostEnvironment env)
        {
            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    var exceptionHandlerPathFeature =
                        context.Features.Get<IExceptionHandlerPathFeature>();

                    if (exceptionHandlerPathFeature?.Error != null)
                    {
                        if (exceptionHandlerPathFeature.Error is DominioException ex)
                        {
                            context.Response.StatusCode = (int)ex.HttpStatusCode;
                            context.Response.ContentType = "application/json";
                            await context.Response.WriteAsync(JsonSerializer.Serialize(new { mensagem = ex.Message }));
                            return;
                        }

                        if (env.IsDevelopment())
                        {
                            context.Response.StatusCode = 500;
                            context.Response.ContentType = "text/html";
                            await context.Response.WriteAsync(exceptionHandlerPathFeature.Error.ToString());
                            return;
                        }
                    }

                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "text/html";
                    context.Response.ContentType = "Ocorreu um erro";
                });
            });
        }
    }
}
