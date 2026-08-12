# Swagger Petstore - OpenAPI 3.0

[![Built with APIMatic][apimatic-badge]][apimatic-url] [![License: MIT][license-badge]][license-url]

The Swagger Petstore - OpenAPI 3.0 SDK for .NET provides access to the [Swagger Petstore - OpenAPI 3.0 REST APIs](https://swagger.io) from .NET applications.

This is a sample Pet Store Server based on the OpenAPI 3.0 specification.  You can find out more about
Swagger at [https://swagger.io](https://swagger.io). In the third iteration of the pet store, we've switched to the design first approach!
You can now help us improve the API whether it's by making changes to the definition itself or to the code.
That way, with time, we can improve the API in general, and expose some of the new features in OAS3.

Some useful links:
- [The Pet Store repository](https://github.com/swagger-api/swagger-petstore)
- [The source API definition for the Pet Store](https://github.com/swagger-api/swagger-petstore/blob/master/src/main/resources/openapi.yaml)

---

## Installation

Add the .NET SDK as a project reference into your solution:

```bash
dotnet add reference <path-to-sdk>/SwaggerPetstoreOpenApi30.csproj
```

---

## Quick Start

### Dependency Injection

Register the client with `IServiceCollection` and resolve it from the container. The `HttpClient` is managed by `IHttpClientFactory`. Configure the client's behavior through [SwaggerPetstoreOpenApi30ClientOptions](SwaggerPetstoreOpenApi30ClientOptions.cs).

```csharp
services.AddSwaggerPetstoreOpenApi30Client(options =>
    {
        options.PetstoreAuth = "YOUR_API_KEY";
        options.ApiKey = "YOUR_API_KEY";
        options.Environment = ServerEnvironment.Production;
        // TODO: configure more client options here
    });
```

### Direct Instantiation

Create the client by passing an `HttpClient` you manage yourself. Configure the client's behavior through [SwaggerPetstoreOpenApi30ClientOptions](SwaggerPetstoreOpenApi30ClientOptions.cs).

```csharp
var httpClient = new HttpClient();
// TODO: configure more client options here
var options =
    new SwaggerPetstoreOpenApi30ClientOptions
    {
        PetstoreAuth = "YOUR_API_KEY",
        ApiKey = "YOUR_API_KEY",
        Environment = ServerEnvironment.Production,
    };
var client = new SwaggerPetstoreOpenApi30Client(httpClient, options);
```

---

## Usage

For code examples and error responses, see [API Reference](api-reference.md).

## Best Practices

> [!TIP]
> Use a **single `SwaggerPetstoreOpenApi30Client` instance** for the lifetime of your application and
> reuse it across all requests. Creating a new instance per request might exhaust the
> connection pool.

## License

This SDK is distributed under the [MIT License](LICENSE).

---

## Support

Refer to the [API reference](api-reference.md) for detailed information on available operations with code samples.

For further assistance, please contact support at apiteam@swagger.io.

---

[license-url]: LICENSE
[license-badge]: https://img.shields.io/badge/License-MIT-blue.svg
[apimatic-url]: https://www.apimatic.io
[apimatic-badge]: https://www.apimatic.io/hubfs/Built-with-APIMatic-badge.svg
