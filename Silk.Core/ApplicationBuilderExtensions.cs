using System;
using Microsoft.AspNetCore.Builder;

namespace Silk.Core
{
    public static class ApplicationBuilderExtensions
    {
        public static void RegisterHandler<T>(this IApplicationBuilder app) where T : IHttpRequestHandler, new()
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            app.Run(async context =>
            {
                var handler = Activator.CreateInstance<T>();

                var result = await handler.ExecuteAsync(context);

                await result.ExecuteAsync();
            });
        }
    }
}