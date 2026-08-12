using System.Text.Json.Serialization;
using SwaggerPetstoreOpenApi30.Core.Enum;

namespace SwaggerPetstoreOpenApi30.Models.Enums;

/// <summary>
/// pet status in the store
/// </summary>
[JsonConverter(typeof(StringEnumConverter<PetStatus>))]
public sealed record PetStatus : StringEnum<PetStatus>
{
    private PetStatus(string value) : base(value)
    {
    }

    public static readonly PetStatus Available = new("available");

    public static readonly PetStatus Pending = new("pending");

    public static readonly PetStatus Sold = new("sold");

    public static PetStatus FromValue(string value) => FromValueCore(value);
}
