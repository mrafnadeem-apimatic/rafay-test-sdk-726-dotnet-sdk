using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SwaggerPetstoreOpenApi30.Core.ErrorResponse;
using SwaggerPetstoreOpenApi30.Core.Models;

namespace SwaggerPetstoreOpenApi30.Errors;

public sealed class UpdateUserError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private UpdateUserError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static UpdateUserError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static UpdateUserError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<UpdateUserError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 404 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class UpdateUserErrorResponse : IErrorResponse<UpdateUserError>
{
    public static UpdateUserErrorResponse Instance { get; } = new();

    private UpdateUserErrorResponse()
    {
    }

    public Task<UpdateUserError> Map(HttpResponseMessage response, CancellationToken ct) =>
        UpdateUserError.Create(response, ct);
}
