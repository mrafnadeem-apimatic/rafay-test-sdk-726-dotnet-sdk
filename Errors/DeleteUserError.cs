using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SwaggerPetstoreOpenApi30.Core.ErrorResponse;
using SwaggerPetstoreOpenApi30.Core.Models;

namespace SwaggerPetstoreOpenApi30.Errors;

public sealed class DeleteUserError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private DeleteUserError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static DeleteUserError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static DeleteUserError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<DeleteUserError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 404 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class DeleteUserErrorResponse : IErrorResponse<DeleteUserError>
{
    public static DeleteUserErrorResponse Instance { get; } = new();

    private DeleteUserErrorResponse()
    {
    }

    public Task<DeleteUserError> Map(HttpResponseMessage response, CancellationToken ct) =>
        DeleteUserError.Create(response, ct);
}
