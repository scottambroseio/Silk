using System;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Silk.Core;
using Silk.Core.Attributes;

namespace Silk.Example
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IGreeterService, GreeterService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IServiceProvider serviceProvider)
        {
            loggerFactory.AddConsole();


            app.Use(async (context, next) =>
            {
                try
                {
                    var route = typeof(IndexHandler).GetTypeInfo().GetCustomAttribute<RouteAttribute>()?.Pattern ??
                                throw new Exception($"{typeof(IndexHandler).Name} must have a route defined");

                    var path = context.Request.Path;

                    if (string.Equals(path, route, StringComparison.CurrentCultureIgnoreCase))
                    {
                        var ctor = typeof(IndexHandler).GetConstructors(BindingFlags.Public | BindingFlags.Instance)
                                       .OrderByDescending(c => c.GetParameters().Length).FirstOrDefault() ??
                                   throw new Exception("no ctor");

                        // resolve deps from container
                        var args = ctor.GetParameters().Select(p => serviceProvider.GetService(p.ParameterType)).ToArray();

                        var handler = (IHttpRequestHandler) ctor.Invoke(args);

                        var result = await handler.ExecuteAsync(context);

                        await result.ExecuteAsync();
                    }
                    else
                    {
                        await next();
                    }
                }
                catch (Exception e)
                {
                }
            });
        }
    }
}