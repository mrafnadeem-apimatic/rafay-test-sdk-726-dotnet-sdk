using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SwaggerPetstoreOpenApi30.Core.ErrorResponse;
using SwaggerPetstoreOpenApi30.Core.Models;

namespace SwaggerPetstoreOpenApi30.Errors;

public sealed class DeletePetError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private DeletePetError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static DeletePetError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static DeletePetError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<DeletePetError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class DeletePetErrorResponse : IErrorResponse<DeletePetError>
{
    public static DeletePetErrorResponse Instance { get; } = new();

    private DeletePetErrorResponse()
    {
    }

    public Task<DeletePetError> Map(HttpResponseMessage response, CancellationToken ct) =>
        DeletePetError.Create(response, ct);
}
