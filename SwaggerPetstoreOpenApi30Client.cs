using System.Net.Http;
using SwaggerPetstoreOpenApi30.Api;
using SwaggerPetstoreOpenApi30.Core;
using SwaggerPetstoreOpenApi30.Core.Logging;
using SwaggerPetstoreOpenApi30.Core.Models;

namespace SwaggerPetstoreOpenApi30;

/// <summary>
/// This is a sample Pet Store Server based on the OpenAPI 3.0 specification.  You can find out more about
/// Swagger at <see href="https://swagger.io">https://swagger.io</see>. In the third iteration of the pet store, we've switched to the design first approach!
/// You can now help us improve the API whether it's by making changes to the definition itself or to the code.
/// That way, with time, we can improve the API in general, and expose some of the new features in OAS3.
/// <para>
/// Some useful links:
/// - <see href="https://github.com/swagger-api/swagger-petstore">The Pet Store repository</see>
/// - <see href="https://github.com/swagger-api/swagger-petstore/blob/master/src/main/resources/openapi.yaml">The source API definition for the Pet Store</see>
/// </para>
/// </summary>
public sealed class SwaggerPetstoreOpenApi30Client
{
    public SwaggerPetstoreOpenApi30Client(HttpClient httpClient, SwaggerPetstoreOpenApi30ClientOptions options)
    {
        var server = new Server(options.Environment, options.Server);
        var queryParameterFactory = new QueryParameterFactory([]);
        var templateParamsFactory = new TemplateParamsFactory([]);
        var urlFactory = new UriFactory(queryParameterFactory, templateParamsFactory);
        var httpStatusPolicy = new HttpStatusPolicy([]);
        var headersFactory =
            new HeadersFactory([new HeaderParam("User-Agent", "SwaggerPetstoreOpenApi30Client/1.0.26 CSharp"),
                    new HeaderParam("X-APIMatic-Lang", "CSharp"),
                    new HeaderParam("X-APIMatic-Package-Version", "1.0.26"),
                    new HeaderParam("X-APIMatic-Gen-Version", "4.0.0"),
                    new HeaderParam("X-APIMatic-OS", RuntimeEnvironment.Os),
                    new HeaderParam("X-APIMatic-Runtime", RuntimeEnvironment.Runtime)]);
        var resiliencePipelineFactory = new ResiliencePipelineFactory(options.Retry);
        var httpLogger = new HttpLogger(options.Logging, "SwaggerPetstoreOpenApi30Client");
        var rawClient =
            new RawClient(httpClient, urlFactory, httpStatusPolicy, headersFactory, resiliencePipelineFactory, httpLogger);
        var auth = new AuthSchemes(options);
        PetApi = new PetApi(rawClient, server, auth);
        Store = new Store(rawClient, server, auth);
        UserApi = new UserApi(rawClient, server);
    }

    /// <summary>
    /// Everything about your Pets
    /// </summary>
    public PetApi PetApi { get; }

    /// <summary>
    /// Access to Petstore orders
    /// </summary>
    public Store Store { get; }

    /// <summary>
    /// Operations about user
    /// </summary>
    public UserApi UserApi { get; }
}
