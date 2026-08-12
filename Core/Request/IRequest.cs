using System.Net.Http;

namespace SwaggerPetstoreOpenApi30.Core.Request;

internal interface IRequest
{
    HttpContent Get();

    bool CanRetry { get; }
}