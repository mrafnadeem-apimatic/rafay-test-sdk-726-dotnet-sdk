using SwaggerPetstoreOpenApi30.Core.Configuration;
using SwaggerPetstoreOpenApi30.Servers;

namespace SwaggerPetstoreOpenApi30;

public class SwaggerPetstoreOpenApi30ClientOptions
{
    public ServerEnvironment Environment { get; set; } = ServerEnvironment.Default();
    public RetryOptions Retry { get; set; } = RetryOptions.Default();
    public LoggingOptions Logging { get; set; } = new();
    public ServerOptions Server { get; set; } = new();
    public string? PetstoreAuth { get; set; }
    public string? ApiKey { get; set; }
}
