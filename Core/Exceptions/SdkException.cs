using System;

namespace SwaggerPetstoreOpenApi30.Core.Exceptions;

public sealed class SdkException<TError> : Exception
{
    public required TError Error { get; init; }
}