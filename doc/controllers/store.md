# Store

Access to Petstore orders

Find out more about our store: [https://swagger.io](https://swagger.io)

```csharp
StoreApi storeApi = client.StoreApi;
```

## Class Name

`StoreApi`

## Methods

* [Get Inventory](../../doc/controllers/store.md#get-inventory)
* [Place Order](../../doc/controllers/store.md#place-order)
* [Get Order by Id](../../doc/controllers/store.md#get-order-by-id)
* [Delete Order](../../doc/controllers/store.md#delete-order)


# Get Inventory

Returns a map of status codes to quantities.

```csharp
GetInventoryAsync()
```

## Authentication

This endpoint requires [api_key](../../doc/auth/custom-header-signature.md)

## Response Type

**200**: successful operation

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type Dictionary<string, int>.

## Example Usage

```csharp
try
{
    ApiResponse<Dictionary<string, int>> result = await storeApi.GetInventoryAsync();
}
catch (ApiException e)
{
    Console.WriteLine(e.Message);
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| Default | Unexpected error | `ApiException` |


# Place Order

Place a new order in the store.

:information_source: **Note** This endpoint does not require authentication.

```csharp
PlaceOrderAsync(
    long? id = null,
    long? petId = null,
    int? quantity = null,
    DateTime? shipDate = null,
    Models.OrderStatus? status = null,
    bool? complete = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `id` | `long?` | Form, Optional | - |
| `petId` | `long?` | Form, Optional | - |
| `quantity` | `int?` | Form, Optional | - |
| `shipDate` | `DateTime?` | Form, Optional | - |
| `status` | [`OrderStatus?`](../../doc/models/order-status.md) | Form, Optional | Order Status |
| `complete` | `bool?` | Form, Optional | - |

## Response Type

**200**: successful operation

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.Order](../../doc/models/order.md).

## Example Usage

```csharp
long? id = 10L;
long? petId = 198772L;
int? quantity = 7;
try
{
    ApiResponse<Order> result = await storeApi.PlaceOrderAsync(
        id,
        petId,
        quantity
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


# Get Order by Id

For valid response try integer IDs with value <= 5 or > 10. Other values will generate exceptions.

:information_source: **Note** This endpoint does not require authentication.

```csharp
GetOrderByIdAsync(
    long orderId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `orderId` | `long` | Template, Required | ID of order that needs to be fetched |

## Response Type

**200**: successful operation

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.Order](../../doc/models/order.md).

## Example Usage

```csharp
long orderId = 62L;
try
{
    ApiResponse<Order> result = await storeApi.GetOrderByIdAsync(orderId);
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
| 404 | Order not found | `ApiException` |
| Default | Unexpected error | `ApiException` |


# Delete Order

For valid response try integer IDs with value < 1000. Anything above 1000 or non-integers will generate API errors.

:information_source: **Note** This endpoint does not require authentication.

```csharp
DeleteOrderAsync(
    long orderId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `orderId` | `long` | Template, Required | ID of the order that needs to be deleted |

## Response Type

**200**: order deleted

`Task`

## Example Usage

```csharp
long orderId = 62L;
try
{
    await storeApi.DeleteOrderAsync(orderId);
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
| 404 | Order not found | `ApiException` |
| Default | Unexpected error | `ApiException` |

