using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SwaggerPetstoreOpenApi30.Core.ErrorResponse;
using SwaggerPetstoreOpenApi30.Core.Models;

namespace SwaggerPetstoreOpenApi30.Errors;

public sealed class UploadFileError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private UploadFileError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static UploadFileError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static UploadFileError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<UploadFileError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 404 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class UploadFileErrorResponse : IErrorResponse<UploadFileError>
{
    public static UploadFileErrorResponse Instance { get; } = new();

    private UploadFileErrorResponse()
    {
    }

    public Task<UploadFileError> Map(HttpResponseMessage response, CancellationToken ct) =>
        UploadFileError.Create(response, ct);
}
