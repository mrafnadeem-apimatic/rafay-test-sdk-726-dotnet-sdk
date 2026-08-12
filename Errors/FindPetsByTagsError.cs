using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SwaggerPetstoreOpenApi30.Core.ErrorResponse;
using SwaggerPetstoreOpenApi30.Core.Models;

namespace SwaggerPetstoreOpenApi30.Errors;

public sealed class FindPetsByTagsError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private FindPetsByTagsError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static FindPetsByTagsError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static FindPetsByTagsError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<FindPetsByTagsError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class FindPetsByTagsErrorResponse : IErrorResponse<FindPetsByTagsError>
{
    public static FindPetsByTagsErrorResponse Instance { get; } = new();

    private FindPetsByTagsErrorResponse()
    {
    }

    public Task<FindPetsByTagsError> Map(HttpResponseMessage response, CancellationToken ct) =>
        FindPetsByTagsError.Create(response, ct);
}
