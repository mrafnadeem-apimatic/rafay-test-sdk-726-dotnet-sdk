using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SwaggerPetstoreOpenApi30.Core.ErrorResponse;
using SwaggerPetstoreOpenApi30.Core.Models;

namespace SwaggerPetstoreOpenApi30.Errors;

public sealed class GetOrderByIdError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private GetOrderByIdError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static GetOrderByIdError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static GetOrderByIdError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<GetOrderByIdError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 404 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetOrderByIdErrorResponse : IErrorResponse<GetOrderByIdError>
{
    public static GetOrderByIdErrorResponse Instance { get; } = new();

    private GetOrderByIdErrorResponse()
    {
    }

    public Task<GetOrderByIdError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetOrderByIdError.Create(response, ct);
}
