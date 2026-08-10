
# Client Class Documentation

The following parameters are configurable for the API Client:

| Parameter | Type | Description |
|  --- | --- | --- |
| Environment | [`Environment`](../README.md#environments) | The API environment. <br> **Default: `Environment.Production`** |
| Timeout | `TimeSpan` | Http client timeout.<br>*Default*: `TimeSpan.FromSeconds(30)` |
| HttpClientConfiguration | [`Action<HttpClientConfiguration.Builder>`](../doc/http-client-configuration-builder.md) | Action delegate that configures the HTTP client by using the HttpClientConfiguration.Builder for customizing API call settings.<br>*Default*: `new HttpClient()` |
| LogBuilder | [`LogBuilder`](../doc/log-builder.md) | Represents the logging configuration builder for API calls |
| PetstoreAuthCredentials | [`PetstoreAuthCredentials`](auth/oauth-2-implicit-grant.md) | The Credentials Setter for OAuth 2 Implicit Grant |
| ApiKeyCredentials | [`ApiKeyCredentials`](auth/custom-header-signature.md) | The Credentials Setter for Custom Header Signature |

The API client can be initialized as follows:

## Code-Based Initialization

```csharp
using Microsoft.Extensions.Logging;
using SwaggerPetstoreOpenApi30.Standard;
using SwaggerPetstoreOpenApi30.Standard.Authentication;
using SwaggerPetstoreOpenApi30.Standard.Models;
using System.Collections.Generic;

namespace ConsoleApp;

SwaggerPetstoreOpenApi30Client client = new SwaggerPetstoreOpenApi30Client.Builder()
    .PetstoreAuthCredentials(
        new PetstoreAuthModel.Builder(
            "OAuthClientId",
            "OAuthRedirectUri"
        )
        .OauthScopes(
            new List<OauthScopePetstoreAuth>
            {
                OauthScopePetstoreAuth.Writepets,
                OauthScopePetstoreAuth.Readpets,
            })
        .Build())
    .ApiKeyCredentials(
        new ApiKeyModel.Builder(
            "api_key"
        )
        .Build())
    .HttpClientConfig(httpClientConfig =>
        httpClientConfig.Timeout(TimeSpan.FromSeconds(100)))
    .Environment(SwaggerPetstoreOpenApi30.Standard.Environment.Production)
    .LoggingConfig(config => config
        .LogLevel(LogLevel.Information)
        .RequestConfig(reqConfig => reqConfig.Body(true))
        .ResponseConfig(respConfig => respConfig.Headers(true))
    )
    .Build();
```

## Configuration-Based Initialization

```csharp
using SwaggerPetstoreOpenApi30.Standard;
using Microsoft.Extensions.Configuration;

namespace ConsoleApp;

// Build the IConfiguration using .NET conventions (JSON, environment, etc.)
var configuration = new ConfigurationBuilder()
    .AddJsonFile("config.json")
    .AddEnvironmentVariables() // [optional] read environment variables
    .Build();

// Instantiate your SDK and configure it from IConfiguration
var client = SwaggerPetstoreOpenApi30Client
    .FromConfiguration(configuration.GetSection("SwaggerPetstoreOpenApi30"));
```

See the [Configuration-Based Initialization](../doc/configuration-based-initialization.md) section for details.

## Swagger Petstore - OpenAPI 3.0Client Class

The gateway for the SDK. This class acts as a factory for the Apis and also holds the configuration of the SDK.

### Controllers

| Name | Description |
|  --- | --- |
| PetApi | Gets PetApi. |
| StoreApi | Gets StoreApi. |
| UserApi | Gets UserApi. |

### Properties

| Name | Description | Type |
|  --- | --- | --- |
| HttpClientConfiguration | Gets the configuration of the Http Client associated with this client. | [`IHttpClientConfiguration`](../doc/http-client-configuration.md) |
| Timeout | Http client timeout. | `TimeSpan` |
| Environment | Current API environment. | `Environment` |
| PetstoreAuthCredentials | Gets the credentials to use with PetstoreAuth. | [`IPetstoreAuthCredentials`](auth/oauth-2-implicit-grant.md) |
| ApiKeyCredentials | Gets the credentials to use with ApiKey. | [`IApiKeyCredentials`](auth/custom-header-signature.md) |

### Methods

| Name | Description | Return Type |
|  --- | --- | --- |
| `GetBaseUri(Server alias = Server.Default)` | Gets the URL for a particular alias in the current environment and appends it with template parameters. | `string` |
| `ToBuilder()` | Creates an object of the Swagger Petstore - OpenAPI 3.0Client using the values provided for the builder. | `Builder` |

## Swagger Petstore - OpenAPI 3.0Client Builder Class

Class to build instances of Swagger Petstore - OpenAPI 3.0Client.

### Methods

| Name | Description | Return Type |
|  --- | --- | --- |
| `HttpClientConfiguration(Action<`[`HttpClientConfiguration.Builder`](../doc/http-client-configuration-builder.md)`> action)` | Gets the configuration of the Http Client associated with this client. | `Builder` |
| `Timeout(TimeSpan timeout)` | Http client timeout. | `Builder` |
| `Environment(Environment environment)` | Current API environment. | `Builder` |
| `PetstoreAuthCredentials(Action<PetstoreAuthModel.Builder> action)` | Sets credentials for PetstoreAuth. | `Builder` |
| `ApiKeyCredentials(Action<ApiKeyModel.Builder> action)` | Sets credentials for ApiKey. | `Builder` |

