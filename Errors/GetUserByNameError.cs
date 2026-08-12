using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SwaggerPetstoreOpenApi30.Core.ErrorResponse;
using SwaggerPetstoreOpenApi30.Core.Models;

namespace SwaggerPetstoreOpenApi30.Errors;

public sealed class GetUserByNameError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private GetUserByNameError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static GetUserByNameError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static GetUserByNameError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<GetUserByNameError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 404 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetUserByNameErrorResponse : IErrorResponse<GetUserByNameError>
{
    public static GetUserByNameErrorResponse Instance { get; } = new();

    private GetUserByNameErrorResponse()
    {
    }

    public Task<GetUserByNameError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetUserByNameError.Create(response, ct);
}
