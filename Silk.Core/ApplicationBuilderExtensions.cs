using System;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Silk.Core.Attributes;

namespace Silk.Core
{
    public static class ApplicationBuilderExtensions
    {
        public static void RegisterHandler<T>(this IApplicationBuilder app) where T : IHttpRequestHandler, new()
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            app.Use(async (context, next) =>
            {
                var route = typeof(T).GetTypeInfo().GetCustomAttribute<RouteAttribute>()?.Pattern ??
                            throw new Exception($"{typeof(T).Name} must have a route defined");

                var path = context.Request.Path;

                if (string.Equals(path, route, StringComparison.CurrentCultureIgnoreCase))
                {
                    var handler = Activator.CreateInstance<T>();

                    var result = await handler.ExecuteAsync(context);

                    await result.ExecuteAsync();
                }
                else
                {
                    await next();
                }
            });
        }
    }
}