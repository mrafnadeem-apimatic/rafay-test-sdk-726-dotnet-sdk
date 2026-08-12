using SwaggerPetstoreOpenApi30.Core.Authentication;
using SwaggerPetstoreOpenApi30.Core.Authentication.ApiKey;

namespace SwaggerPetstoreOpenApi30;

internal sealed class AuthSchemes
{
    public IAuthScheme PetstoreAuth { get; }
    public IAuthScheme ApiKey { get; }

    public AuthSchemes(SwaggerPetstoreOpenApi30ClientOptions options)
    {
        PetstoreAuth = ApiKeyHeaderScheme.Create("Authorization", options.PetstoreAuth);
        ApiKey = ApiKeyHeaderScheme.Create("api_key", options.ApiKey);
    }
}
