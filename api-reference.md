# Reference

> Source: [SwaggerPetstoreOpenApi30Client](SwaggerPetstoreOpenApi30Client.cs)

## PetApi

> Source: [PetApi](Api/PetApi.cs)

<details>
<summary><code>Task&lt;Pet&gt; AddPet(string name, IReadOnlyList&lt;string&gt; photoUrls, long? id, Category? category, IReadOnlyList&lt;Tag&gt;? tags, PetStatus? status, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Add a new pet to the store.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.PetApi.AddPet(name, photoUrls, id, category, tags, status);
    // TODO: Handle 'response' of type Pet
}
catch (SdkException<AddPetError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type AddPetError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>name</code> | <code>string</code> | - |
| <code>photoUrls</code> | <code>IReadOnlyList&lt;string&gt;</code> | - |
| <code>id</code> | <code>long?</code> | - |
| <code>category</code> | <code>[Category?](Models/Category.cs)</code> | - |
| <code>tags</code> | <code>IReadOnlyList&lt;[Tag](Models/Tag.cs)&gt;?</code> | - |
| <code>status</code> | <code>[PetStatus?](Models/Enums/PetStatus.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[Pet](Models/Pet.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[AddPetError](Errors/AddPetError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task DeletePet(long petId, string? apiKey, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Delete a pet.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    await client.PetApi.DeletePet(petId, apiKey);
}
catch (SdkException<DeletePetError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type DeletePetError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>petId</code> | <code>long</code> | Pet id to delete |
| <code>apiKey</code> | <code>string?</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: No content

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[DeletePetError](Errors/DeletePetError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;IReadOnlyList&lt;Pet&gt;&gt; FindPetsByStatus(PetStatus? status, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Multiple status values can be provided with comma separated strings.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.PetApi.FindPetsByStatus(status);
    // TODO: Handle 'response' of type IReadOnlyList<Pet>
}
catch (SdkException<FindPetsByStatusError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type FindPetsByStatusError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>status</code> | <code>[PetStatus?](Models/Enums/PetStatus.cs)</code> | Status values that need to be considered for filter |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>IReadOnlyList&lt;[Pet](Models/Pet.cs)&gt;</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[FindPetsByStatusError](Errors/FindPetsByStatusError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;IReadOnlyList&lt;Pet&gt;&gt; FindPetsByTags(IReadOnlyList&lt;string&gt;? tags, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Multiple tags can be provided with comma separated strings. Use tag1, tag2, tag3 for testing.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.PetApi.FindPetsByTags(tags);
    // TODO: Handle 'response' of type IReadOnlyList<Pet>
}
catch (SdkException<FindPetsByTagsError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type FindPetsByTagsError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>tags</code> | <code>IReadOnlyList&lt;string&gt;?</code> | Tags to filter by |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>IReadOnlyList&lt;[Pet](Models/Pet.cs)&gt;</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[FindPetsByTagsError](Errors/FindPetsByTagsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;Pet&gt; GetPetById(long petId, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns a single pet.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.PetApi.GetPetById(petId);
    // TODO: Handle 'response' of type Pet
}
catch (SdkException<GetPetByIdError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type GetPetByIdError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>petId</code> | <code>long</code> | ID of pet to return |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[Pet](Models/Pet.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetPetByIdError](Errors/GetPetByIdError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;Pet&gt; UpdatePet(string name, IReadOnlyList&lt;string&gt; photoUrls, long? id, Category? category, IReadOnlyList&lt;Tag&gt;? tags, PetStatus? status, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Update an existing pet by Id.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.PetApi.UpdatePet(name, photoUrls, id, category, tags, status);
    // TODO: Handle 'response' of type Pet
}
catch (SdkException<UpdatePetError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type UpdatePetError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>name</code> | <code>string</code> | - |
| <code>photoUrls</code> | <code>IReadOnlyList&lt;string&gt;</code> | - |
| <code>id</code> | <code>long?</code> | - |
| <code>category</code> | <code>[Category?](Models/Category.cs)</code> | - |
| <code>tags</code> | <code>IReadOnlyList&lt;[Tag](Models/Tag.cs)&gt;?</code> | - |
| <code>status</code> | <code>[PetStatus?](Models/Enums/PetStatus.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[Pet](Models/Pet.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[UpdatePetError](Errors/UpdatePetError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;Pet&gt; UpdatePetWithForm(long petId, string? name, string? status, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Updates a pet resource based on the form data.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.PetApi.UpdatePetWithForm(petId, name, status);
    // TODO: Handle 'response' of type Pet
}
catch (SdkException<UpdatePetWithFormError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type UpdatePetWithFormError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>petId</code> | <code>long</code> | ID of pet that needs to be updated |
| <code>name</code> | <code>string?</code> | Name of pet that needs to be updated |
| <code>status</code> | <code>string?</code> | Status of pet that needs to be updated |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[Pet](Models/Pet.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[UpdatePetWithFormError](Errors/UpdatePetWithFormError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ApiResponseModel&gt; UploadFile(long petId, string? additionalMetadata, BinaryContent? body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Upload image of the pet.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.PetApi.UploadFile(petId, additionalMetadata, body);
    // TODO: Handle 'response' of type ApiResponseModel
}
catch (SdkException<UploadFileError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type UploadFileError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>petId</code> | <code>long</code> | ID of pet to update |
| <code>additionalMetadata</code> | <code>string?</code> | Additional Metadata |
| <code>body</code> | <code>BinaryContent?</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ApiResponseModel](Models/ApiResponseModel.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[UploadFileError](Errors/UploadFileError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Store

> Source: [Store](Api/Store.cs)

<details>
<summary><code>Task DeleteOrder(long orderId, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

For valid response try integer IDs with value < 1000. Anything above 1000 or non-integers will generate API errors.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    await client.Store.DeleteOrder(orderId);
}
catch (SdkException<DeleteOrderError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type DeleteOrderError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>orderId</code> | <code>long</code> | ID of the order that needs to be deleted |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: No content

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[DeleteOrderError](Errors/DeleteOrderError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;IReadOnlyDictionary&lt;string, int&gt;&gt; GetInventory(RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns a map of status codes to quantities.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Store.GetInventory();
    // TODO: Handle 'response' of type IReadOnlyDictionary<string, int>
}
catch (SdkException<RawError> ex)
{
    // TODO: Handle 'ex.Error' of type RawError
}
```

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>IReadOnlyDictionary&lt;string, int&gt;</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[RawError](Core/ErrorResponse/RawError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;Order&gt; GetOrderById(long orderId, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

For valid response try integer IDs with value <= 5 or > 10. Other values will generate exceptions.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Store.GetOrderById(orderId);
    // TODO: Handle 'response' of type Order
}
catch (SdkException<GetOrderByIdError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type GetOrderByIdError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>orderId</code> | <code>long</code> | ID of order that needs to be fetched |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[Order](Models/Order.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetOrderByIdError](Errors/GetOrderByIdError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;Order&gt; PlaceOrder(long? id, long? petId, int? quantity, DateTimeOffset? shipDate, OrderStatus? status, bool? complete, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Place a new order in the store.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Store.PlaceOrder(id, petId, quantity, shipDate, status, complete);
    // TODO: Handle 'response' of type Order
}
catch (SdkException<PlaceOrderError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type PlaceOrderError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>id</code> | <code>long?</code> | - |
| <code>petId</code> | <code>long?</code> | - |
| <code>quantity</code> | <code>int?</code> | - |
| <code>shipDate</code> | <code>DateTimeOffset?</code> | - |
| <code>status</code> | <code>[OrderStatus?](Models/Enums/OrderStatus.cs)</code> | - |
| <code>complete</code> | <code>bool?</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[Order](Models/Order.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[PlaceOrderError](Errors/PlaceOrderError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## UserApi

> Source: [UserApi](Api/UserApi.cs)

<details>
<summary><code>Task&lt;User&gt; CreateUser(long? id, string? username, string? firstName, string? lastName, string? email, string? password, string? phone, int? userStatus, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This can only be done by the logged in user.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.UserApi.CreateUser(id,
        username,
        firstName,
        lastName,
        email,
        password,
        phone,
        userStatus);
    // TODO: Handle 'response' of type User
}
catch (SdkException<RawError> ex)
{
    // TODO: Handle 'ex.Error' of type RawError
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>id</code> | <code>long?</code> | - |
| <code>username</code> | <code>string?</code> | - |
| <code>firstName</code> | <code>string?</code> | - |
| <code>lastName</code> | <code>string?</code> | - |
| <code>email</code> | <code>string?</code> | - |
| <code>password</code> | <code>string?</code> | - |
| <code>phone</code> | <code>string?</code> | - |
| <code>userStatus</code> | <code>int?</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[User](Models/User.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[RawError](Core/ErrorResponse/RawError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;User&gt; CreateUsersWithListInput(IReadOnlyList&lt;User&gt;? body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Creates list of users with given input array.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.UserApi.CreateUsersWithListInput(body);
    // TODO: Handle 'response' of type User
}
catch (SdkException<RawError> ex)
{
    // TODO: Handle 'ex.Error' of type RawError
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>body</code> | <code>IReadOnlyList&lt;[User](Models/User.cs)&gt;?</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[User](Models/User.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[RawError](Core/ErrorResponse/RawError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task DeleteUser(string usersname, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This can only be done by the logged in user.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    await client.UserApi.DeleteUser(usersname);
}
catch (SdkException<DeleteUserError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type DeleteUserError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>usersname</code> | <code>string</code> | The username that needs to be processed |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: No content

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[DeleteUserError](Errors/DeleteUserError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;User&gt; GetUserByName(string usersname, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Get user detail based on username.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.UserApi.GetUserByName(usersname);
    // TODO: Handle 'response' of type User
}
catch (SdkException<GetUserByNameError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type GetUserByNameError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>usersname</code> | <code>string</code> | The username that needs to be processed |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[User](Models/User.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetUserByNameError](Errors/GetUserByNameError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task LoginUser(string? username, string? password, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Log into the system.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    await client.UserApi.LoginUser(username, password);
}
catch (SdkException<LoginUserError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type LoginUserError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>username</code> | <code>string?</code> | The user name for login |
| <code>password</code> | <code>string?</code> | The password for login in clear text |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: No content

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[LoginUserError](Errors/LoginUserError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task LogoutUser(RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Log user out of the system.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    await client.UserApi.LogoutUser();
}
catch (SdkException<RawError> ex)
{
    // TODO: Handle 'ex.Error' of type RawError
}
```

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: No content

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[RawError](Core/ErrorResponse/RawError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task UpdateUser(string usersname, long? id, string? username, string? firstName, string? lastName, string? email, string? password, string? phone, int? userStatus, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This can only be done by the logged in user.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    await client.UserApi.UpdateUser(usersname,
        id,
        username,
        firstName,
        lastName,
        email,
        password,
        phone,
        userStatus);
}
catch (SdkException<UpdateUserError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type UpdateUserError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>usersname</code> | <code>string</code> | The username that needs to be processed |
| <code>id</code> | <code>long?</code> | - |
| <code>username</code> | <code>string?</code> | - |
| <code>firstName</code> | <code>string?</code> | - |
| <code>lastName</code> | <code>string?</code> | - |
| <code>email</code> | <code>string?</code> | - |
| <code>password</code> | <code>string?</code> | - |
| <code>phone</code> | <code>string?</code> | - |
| <code>userStatus</code> | <code>int?</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: No content

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[UpdateUserError](Errors/UpdateUserError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

