using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SwaggerPetstoreOpenApi30.Core.ErrorResponse;
using SwaggerPetstoreOpenApi30.Core.Models;

namespace SwaggerPetstoreOpenApi30.Errors;

public sealed class UpdatePetWithFormError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private UpdatePetWithFormError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static UpdatePetWithFormError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static UpdatePetWithFormError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<UpdatePetWithFormError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class UpdatePetWithFormErrorResponse : IErrorResponse<UpdatePetWithFormError>
{
    public static UpdatePetWithFormErrorResponse Instance { get; } = new();

    private UpdatePetWithFormErrorResponse()
    {
    }

    public Task<UpdatePetWithFormError> Map(HttpResponseMessage response, CancellationToken ct) =>
        UpdatePetWithFormError.Create(response, ct);
}
