using SwaggerPetstoreOpenApi30.Servers;

namespace SwaggerPetstoreOpenApi30;

public class ServerOptions
{
    public DefaultOptions Default { get; set; } = new();
    public AuthServerOptions AuthServer { get; set; } = new();
}
