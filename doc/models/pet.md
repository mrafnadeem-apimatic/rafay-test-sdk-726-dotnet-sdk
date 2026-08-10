
# Pet

*This model accepts additional fields of type object.*

## Structure

`Pet`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `long?` | Optional | - |
| `Name` | `string` | Required | - |
| `Category` | [`Category`](../../doc/models/category.md) | Optional | - |
| `PhotoUrls` | `List<string>` | Required | - |
| `Tags` | [`List<Tag>`](../../doc/models/tag.md) | Optional | - |
| `Status` | [`PetStatus?`](../../doc/models/pet-status.md) | Optional | pet status in the store |
| `AdditionalProperties` | `object this[string key]` | Optional | - |

## Example

```csharp
using SwaggerPetstoreOpenApi30.Standard.Models;
using SwaggerPetstoreOpenApi30.Standard.Utilities;
using System.Collections.Generic;

Pet pet = new Pet
{
    Name = "name0",
    PhotoUrls = new List<string>
    {
        "photoUrls5",
        "photoUrls6",
    },
    Id = 72L,
    Category = new Category
    {
        Id = 232L,
        Name = "name2",
        ["exampleAdditionalProperty"] = ApiHelper.JsonDeserialize<object>("{\"key1\":\"val1\",\"key2\":\"val2\"}"),
    },
    Tags = new List<Tag>
    {
        new Tag
        {
            Id = 26L,
            Name = "name0",
            ["exampleAdditionalProperty"] = ApiHelper.JsonDeserialize<object>("{\"key1\":\"val1\",\"key2\":\"val2\"}"),
        },
    },
    Status = PetStatus.Available,
    ["exampleAdditionalProperty"] = ApiHelper.JsonDeserialize<object>("{\"key1\":\"val1\",\"key2\":\"val2\"}"),
};
```

