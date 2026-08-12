using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SwaggerPetstoreOpenApi30.Core.ErrorResponse;
using SwaggerPetstoreOpenApi30.Core.Models;

namespace SwaggerPetstoreOpenApi30.Errors;

public sealed class PlaceOrderError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private PlaceOrderError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static PlaceOrderError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static PlaceOrderError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<PlaceOrderError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 422 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class PlaceOrderErrorResponse : IErrorResponse<PlaceOrderError>
{
    public static PlaceOrderErrorResponse Instance { get; } = new();

    private PlaceOrderErrorResponse()
    {
    }

    public Task<PlaceOrderError> Map(HttpResponseMessage response, CancellationToken ct) =>
        PlaceOrderError.Create(response, ct);
}
