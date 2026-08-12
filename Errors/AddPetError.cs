using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SwaggerPetstoreOpenApi30.Core.ErrorResponse;
using SwaggerPetstoreOpenApi30.Core.Models;

namespace SwaggerPetstoreOpenApi30.Errors;

public sealed class AddPetError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private AddPetError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static AddPetError AsNoContent(RawError value) => new(Optional<RawError>.Some(value), default);

    private static AddPetError AsFallback(RawError value) => new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<AddPetError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 422 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class AddPetErrorResponse : IErrorResponse<AddPetError>
{
    public static AddPetErrorResponse Instance { get; } = new();

    private AddPetErrorResponse()
    {
    }

    public Task<AddPetError> Map(HttpResponseMessage response, CancellationToken ct) =>
        AddPetError.Create(response, ct);
}
