
# Api Response

*This model accepts additional fields of type object.*

## Structure

`ApiResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Code` | `int?` | Optional | - |
| `Type` | `string` | Optional | - |
| `Message` | `string` | Optional | - |
| `AdditionalProperties` | `object this[string key]` | Optional | - |

## Example

```csharp
using SwaggerPetstoreOpenApi30.Standard.Models;
using SwaggerPetstoreOpenApi30.Standard.Utilities;

ApiResponse apiResponse = new ApiResponse
{
    Code = 146,
    Type = "type4",
    Message = "message4",
    ["exampleAdditionalProperty"] = ApiHelper.JsonDeserialize<object>("{\"key1\":\"val1\",\"key2\":\"val2\"}"),
};
```

