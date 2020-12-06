using Elmah.Io.AspNetCore;
using Elmah.Io.Extensions.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace LocaCar.Api.Configuration
{
    public static class LoggerConfig
    {
        public static IServiceCollection AddLoggingConfig(this IServiceCollection services)
        {
            services.AddElmahIo(o =>
            {
                o.ApiKey = "38bb9ae7cbe3462e9105c8b4503581c8";
                o.LogId = new Guid("c4c4c185-aedc-4908-832c-c2d79ee335d5");
            });
             
            services.AddLogging(builder =>
            {
                builder.AddElmahIo(o =>
                {
                    o.ApiKey = "38bb9ae7cbe3462e9105c8b4503581c8";
                    o.LogId = new Guid("c4c4c185-aedc-4908-832c-c2d79ee335d5");
                });
                builder.AddFilter<ElmahIoLoggerProvider>(null, LogLevel.Warning);
            });



            return services;
        }

        public static IApplicationBuilder UseLoggingConfiguration(this IApplicationBuilder app)
        {
            app.UseElmahIo();

            return app;
        }
    }
}
