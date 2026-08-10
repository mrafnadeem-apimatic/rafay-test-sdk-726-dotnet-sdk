
# Order

*This model accepts additional fields of type object.*

## Structure

`Order`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `long?` | Optional | - |
| `PetId` | `long?` | Optional | - |
| `Quantity` | `int?` | Optional | - |
| `ShipDate` | `DateTime?` | Optional | - |
| `Status` | [`OrderStatus?`](../../doc/models/order-status.md) | Optional | Order Status |
| `Complete` | `bool?` | Optional | - |
| `AdditionalProperties` | `object this[string key]` | Optional | - |

## Example

```csharp
using SwaggerPetstoreOpenApi30.Standard.Models;
using SwaggerPetstoreOpenApi30.Standard.Utilities;
using System.Globalization;

Order order = new Order
{
    Id = 144L,
    PetId = 184L,
    Quantity = 100,
    ShipDate = DateTime.ParseExact("2016-03-13T12:52:32.123Z", "yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFFK",
        provider: CultureInfo.InvariantCulture,
        DateTimeStyles.RoundtripKind),
    Status = OrderStatus.Placed,
    ["exampleAdditionalProperty"] = ApiHelper.JsonDeserialize<object>("{\"key1\":\"val1\",\"key2\":\"val2\"}"),
};
```

