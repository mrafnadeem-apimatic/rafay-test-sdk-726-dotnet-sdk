
# User

*This model accepts additional fields of type object.*

## Structure

`User`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `long?` | Optional | - |
| `Username` | `string` | Optional | - |
| `FirstName` | `string` | Optional | - |
| `LastName` | `string` | Optional | - |
| `Email` | `string` | Optional | - |
| `Password` | `string` | Optional | - |
| `Phone` | `string` | Optional | - |
| `UserStatus` | `int?` | Optional | User Status |
| `AdditionalProperties` | `object this[string key]` | Optional | - |

## Example

```csharp
using SwaggerPetstoreOpenApi30.Standard.Models;
using SwaggerPetstoreOpenApi30.Standard.Utilities;

User user = new User
{
    Id = 76L,
    Username = "username0",
    FirstName = "firstName4",
    LastName = "lastName4",
    Email = "email6",
    ["exampleAdditionalProperty"] = ApiHelper.JsonDeserialize<object>("{\"key1\":\"val1\",\"key2\":\"val2\"}"),
};
```

