
# Tag

*This model accepts additional fields of type object.*

## Structure

`Tag`

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

Tag tag = new Tag
{
    Id = 168L,
    Name = "name6",
    ["exampleAdditionalProperty"] = ApiHelper.JsonDeserialize<object>("{\"key1\":\"val1\",\"key2\":\"val2\"}"),
};
```

