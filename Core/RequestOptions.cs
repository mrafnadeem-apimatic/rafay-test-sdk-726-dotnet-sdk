using Microsoft.Extensions.Logging;

namespace SwaggerPetstoreOpenApi30.Core;

public sealed record RequestOptions
{
    public LogLevel? LogLevel { get; init; }
}
