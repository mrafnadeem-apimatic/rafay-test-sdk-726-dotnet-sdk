using System;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace SwaggerPetstoreOpenApi30;

public static class ServiceCollectionExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddSwaggerPetstoreOpenApi30Client(Action<SwaggerPetstoreOpenApi30ClientOptions>? configure = null)
        {
            var options = new SwaggerPetstoreOpenApi30ClientOptions();
            configure?.Invoke(options);
            services.AddHttpClient();
            services.AddSingleton(sp =>
                {
                    options.Logging =
                        options.Logging with
                        {
                            LoggerFactory = options.Logging.LoggerFactory ?? sp.GetService<ILoggerFactory>()
                        };
                    var httpClientFactory = sp.GetRequiredService<IHttpClientFactory>();
                    var httpClient = httpClientFactory.CreateClient();
                    return new SwaggerPetstoreOpenApi30Client(httpClient, options);
                });
            return services;
        }
    }
}
