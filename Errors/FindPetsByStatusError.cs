using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SwaggerPetstoreOpenApi30.Core.ErrorResponse;
using SwaggerPetstoreOpenApi30.Core.Models;

namespace SwaggerPetstoreOpenApi30.Errors;

public sealed class FindPetsByStatusError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private FindPetsByStatusError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static FindPetsByStatusError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static FindPetsByStatusError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<FindPetsByStatusError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class FindPetsByStatusErrorResponse : IErrorResponse<FindPetsByStatusError>
{
    public static FindPetsByStatusErrorResponse Instance { get; } = new();

    private FindPetsByStatusErrorResponse()
    {
    }

    public Task<FindPetsByStatusError> Map(HttpResponseMessage response, CancellationToken ct) =>
        FindPetsByStatusError.Create(response, ct);
}
