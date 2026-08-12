using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SwaggerPetstoreOpenApi30.Core.ErrorResponse;
using SwaggerPetstoreOpenApi30.Core.Models;

namespace SwaggerPetstoreOpenApi30.Errors;

public sealed class GetPetByIdError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private GetPetByIdError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static GetPetByIdError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static GetPetByIdError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<GetPetByIdError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 404 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetPetByIdErrorResponse : IErrorResponse<GetPetByIdError>
{
    public static GetPetByIdErrorResponse Instance { get; } = new();

    private GetPetByIdErrorResponse()
    {
    }

    public Task<GetPetByIdError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetPetByIdError.Create(response, ct);
}
