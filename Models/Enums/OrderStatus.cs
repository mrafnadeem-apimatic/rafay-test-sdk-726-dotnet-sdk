using System.Text.Json.Serialization;
using SwaggerPetstoreOpenApi30.Core.Enum;

namespace SwaggerPetstoreOpenApi30.Models.Enums;

/// <summary>
/// Order Status
/// </summary>
[JsonConverter(typeof(StringEnumConverter<OrderStatus>))]
public sealed record OrderStatus : StringEnum<OrderStatus>
{
    private OrderStatus(string value) : base(value)
    {
    }

    public static readonly OrderStatus Placed = new("placed");

    public static readonly OrderStatus Approved = new("approved");

    public static readonly OrderStatus Delivered = new("delivered");

    public static OrderStatus FromValue(string value) => FromValueCore(value);
}
