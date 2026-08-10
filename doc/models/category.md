
# Category

*This model accepts additional fields of type object.*

## Structure

`Category`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `long?` | Optional | - |
| `Name` | `string` | Optional | - |
| `AdditionalProperties` | `object this[string key]` | Optional | - |

## Example

```csharp
using SwaggerPetstoreOpenApi30.Standard.Models;
using SwaggerPetstoreOpenApi30.Standard.Utilities;

Category category = new Category
{
    Id = 232L,
    Name = "name2",
    ["exampleAdditionalProperty"] = ApiHelper.JsonDeserialize<object>("{\"key1\":\"val1\",\"key2\":\"val2\"}"),
};
```

