# Pet

Everything about your Pets

Find out more: [https://swagger.io](https://swagger.io)

```csharp
PetApi petApi = client.PetApi;
```

## Class Name

`PetApi`

## Methods

* [Update Pet](../../doc/controllers/pet.md#update-pet)
* [Add Pet](../../doc/controllers/pet.md#add-pet)
* [Find Pets by Status](../../doc/controllers/pet.md#find-pets-by-status)
* [Find Pets by Tags](../../doc/controllers/pet.md#find-pets-by-tags)
* [Get Pet by Id](../../doc/controllers/pet.md#get-pet-by-id)
* [Update Pet with Form](../../doc/controllers/pet.md#update-pet-with-form)
* [Delete Pet](../../doc/controllers/pet.md#delete-pet)
* [Upload File](../../doc/controllers/pet.md#upload-file)


# Update Pet

Update an existing pet by Id.

```csharp
UpdatePetAsync(
    string name,
    List<string> photoUrls,
    long? id = null,
    Models.Category category = null,
    List<Models.Tag> tags = null,
    Models.PetStatus? status = null)
```

## Authentication

This endpoint requires [petstore_auth](../../doc/auth/oauth-2-implicit-grant.md)

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `name` | `string` | Form, Required | - |
| `photoUrls` | `List<string>` | Form, Required | - |
| `id` | `long?` | Form, Optional | - |
| `category` | [`Category`](../../doc/models/category.md) | Form, Optional | - |
| `tags` | [`List<Tag>`](../../doc/models/tag.md) | Form, Optional | - |
| `status` | [`PetStatus?`](../../doc/models/pet-status.md) | Form, Optional | pet status in the store |

## Requires scope

### petstore_auth

`read:pets`, `write:pets`

## Response Type

**200**: Successful operation

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.Pet](../../doc/models/pet.md).

## Example Usage

```csharp
string name = "doggie";
List<string> photoUrls = new List<string>
{
    "photoUrls5",
    "photoUrls6",
    "photoUrls7",
};

long? id = 10L;
List<Tag> tags = new List<Tag>
{
    new Tag
    {
    },
};

try
{
    ApiResponse<Pet> result = await petApi.UpdatePetAsync(
        name,
        photoUrls,
        id,
        null,
        tags
    );
}
catch (ApiException e)
{
    Console.WriteLine(e.Message);
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | Invalid ID supplied | `ApiException` |
| 404 | Pet not found | `ApiException` |
| 422 | Validation exception | `ApiException` |
| Default | Unexpected error | `ApiException` |


# Add Pet

Add a new pet to the store.

```csharp
AddPetAsync(
    string name,
    List<string> photoUrls,
    long? id = null,
    Models.Category category = null,
    List<Models.Tag> tags = null,
    Models.PetStatus? status = null)
```

## Authentication

This endpoint requires [petstore_auth](../../doc/auth/oauth-2-implicit-grant.md)

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `name` | `string` | Form, Required | - |
| `photoUrls` | `List<string>` | Form, Required | - |
| `id` | `long?` | Form, Optional | - |
| `category` | [`Category`](../../doc/models/category.md) | Form, Optional | - |
| `tags` | [`List<Tag>`](../../doc/models/tag.md) | Form, Optional | - |
| `status` | [`PetStatus?`](../../doc/models/pet-status.md) | Form, Optional | pet status in the store |

## Requires scope

### petstore_auth

`read:pets`, `write:pets`

## Response Type

**200**: Successful operation

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.Pet](../../doc/models/pet.md).

## Example Usage

```csharp
string name = "doggie";
List<string> photoUrls = new List<string>
{
    "photoUrls5",
    "photoUrls6",
    "photoUrls7",
};

long? id = 10L;
List<Tag> tags = new List<Tag>
{
    new Tag
    {
    },
};

try
{
    ApiResponse<Pet> result = await petApi.AddPetAsync(
        name,
        photoUrls,
        id,
        null,
        tags
    );
}
catch (ApiException e)
{
    Console.WriteLine(e.Message);
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | Invalid input | `ApiException` |
| 422 | Validation exception | `ApiException` |
| Default | Unexpected error | `ApiException` |


# Find Pets by Status

Multiple status values can be provided with comma separated strings.

```csharp
FindPetsByStatusAsync(
    Models.PetStatus? status = null)
```

## Authentication

This endpoint requires [petstore_auth](../../doc/auth/oauth-2-implicit-grant.md)

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `status` | [`PetStatus?`](../../doc/models/pet-status.md) | Query, Optional | Status values that need to be considered for filter |

## Requires scope

### petstore_auth

`read:pets`, `write:pets`

## Response Type

**200**: successful operation

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [List<Models.Pet>](../../doc/models/pet.md).

## Example Usage

```csharp
try
{
    ApiResponse<List<Pet>> result = await petApi.FindPetsByStatusAsync();
}
catch (ApiException e)
{
    Console.WriteLine(e.Message);
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | Invalid status value | `ApiException` |
| Default | Unexpected error | `ApiException` |


# Find Pets by Tags

Multiple tags can be provided with comma separated strings. Use tag1, tag2, tag3 for testing.

```csharp
FindPetsByTagsAsync(
    List<string> tags = null)
```

## Authentication

This endpoint requires [petstore_auth](../../doc/auth/oauth-2-implicit-grant.md)

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `tags` | `List<string>` | Query, Optional | Tags to filter by |

## Requires scope

### petstore_auth

`read:pets`, `write:pets`

## Response Type

**200**: successful operation

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [List<Models.Pet>](../../doc/models/pet.md).

## Example Usage

```csharp
try
{
    ApiResponse<List<Pet>> result = await petApi.FindPetsByTagsAsync();
}
catch (ApiException e)
{
    Console.WriteLine(e.Message);
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | Invalid tag value | `ApiException` |
| Default | Unexpected error | `ApiException` |


# Get Pet by Id

Returns a single pet.

```csharp
GetPetByIdAsync(
    long petId)
```

## Authentication

This endpoint requires [api_key](../../doc/auth/custom-header-signature.md) **OR** [petstore_auth](../../doc/auth/oauth-2-implicit-grant.md)

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `petId` | `long` | Template, Required | ID of pet to return |

## Requires scope

### petstore_auth

`read:pets`, `write:pets`

## Response Type

**200**: successful operation

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.Pet](../../doc/models/pet.md).

## Example Usage

```csharp
long petId = 10L;
try
{
    ApiResponse<Pet> result = await petApi.GetPetByIdAsync(petId);
}
catch (ApiException e)
{
    Console.WriteLine(e.Message);
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | Invalid ID supplied | `ApiException` |
| 404 | Pet not found | `ApiException` |
| Default | Unexpected error | `ApiException` |


# Update Pet with Form

Updates a pet resource based on the form data.

```csharp
UpdatePetWithFormAsync(
    long petId,
    string name = null,
    string status = null)
```

## Authentication

This endpoint requires [petstore_auth](../../doc/auth/oauth-2-implicit-grant.md)

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `petId` | `long` | Template, Required | ID of pet that needs to be updated |
| `name` | `string` | Query, Optional | Name of pet that needs to be updated |
| `status` | `string` | Query, Optional | Status of pet that needs to be updated |

## Requires scope

### petstore_auth

`read:pets`, `write:pets`

## Response Type

**200**: successful operation

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.Pet](../../doc/models/pet.md).

## Example Usage

```csharp
long petId = 10L;
try
{
    ApiResponse<Pet> result = await petApi.UpdatePetWithFormAsync(petId);
}
catch (ApiException e)
{
    Console.WriteLine(e.Message);
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | Invalid input | `ApiException` |
| Default | Unexpected error | `ApiException` |


# Delete Pet

Delete a pet.

```csharp
DeletePetAsync(
    long petId,
    string apiKey = null)
```

## Authentication

This endpoint requires [petstore_auth](../../doc/auth/oauth-2-implicit-grant.md)

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `petId` | `long` | Template, Required | Pet id to delete |
| `apiKey` | `string` | Header, Optional | - |

## Requires scope

### petstore_auth

`read:pets`, `write:pets`

## Response Type

**200**: Pet deleted

`Task`

## Example Usage

```csharp
long petId = 10L;
try
{
    await petApi.DeletePetAsync(petId);
}
catch (ApiException e)
{
    Console.WriteLine(e.Message);
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | Invalid pet value | `ApiException` |
| Default | Unexpected error | `ApiException` |


# Upload File

Upload image of the pet.

```csharp
UploadFileAsync(
    long petId,
    string additionalMetadata = null,
    FileStreamInfo body = null)
```

## Authentication

This endpoint requires [petstore_auth](../../doc/auth/oauth-2-implicit-grant.md)

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `petId` | `long` | Template, Required | ID of pet to update |
| `additionalMetadata` | `string` | Query, Optional | Additional Metadata |
| `body` | `FileStreamInfo` | Form, Optional | - |

## Requires scope

### petstore_auth

`read:pets`, `write:pets`

## Response Type

**200**: successful operation

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.ApiResponse](../../doc/models/api-response.md).

## Example Usage

```csharp
long petId = 10L;
try
{
    ApiResponse<ApiResponse> result = await petApi.UploadFileAsync(petId);
}
catch (ApiException e)
{
    Console.WriteLine(e.Message);
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | No file uploaded | `ApiException` |
| 404 | Pet not found | `ApiException` |
| Default | Unexpected error | `ApiException` |

