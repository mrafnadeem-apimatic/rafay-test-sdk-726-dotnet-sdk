using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SwaggerPetstoreOpenApi30.Core.ErrorResponse;
using SwaggerPetstoreOpenApi30.Core.Models;

namespace SwaggerPetstoreOpenApi30.Errors;

public sealed class UpdatePetError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private UpdatePetError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static UpdatePetError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static UpdatePetError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<UpdatePetError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 404 or 422 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class UpdatePetErrorResponse : IErrorResponse<UpdatePetError>
{
    public static UpdatePetErrorResponse Instance { get; } = new();

    private UpdatePetErrorResponse()
    {
    }

    public Task<UpdatePetError> Map(HttpResponseMessage response, CancellationToken ct) =>
        UpdatePetError.Create(response, ct);
}
