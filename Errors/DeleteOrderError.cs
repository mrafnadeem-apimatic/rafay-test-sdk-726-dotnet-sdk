using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SwaggerPetstoreOpenApi30.Core.ErrorResponse;
using SwaggerPetstoreOpenApi30.Core.Models;

namespace SwaggerPetstoreOpenApi30.Errors;

public sealed class DeleteOrderError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private DeleteOrderError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static DeleteOrderError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static DeleteOrderError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<DeleteOrderError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 404 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class DeleteOrderErrorResponse : IErrorResponse<DeleteOrderError>
{
    public static DeleteOrderErrorResponse Instance { get; } = new();

    private DeleteOrderErrorResponse()
    {
    }

    public Task<DeleteOrderError> Map(HttpResponseMessage response, CancellationToken ct) =>
        DeleteOrderError.Create(response, ct);
}
