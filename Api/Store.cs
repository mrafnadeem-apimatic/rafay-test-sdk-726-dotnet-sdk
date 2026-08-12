using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SwaggerPetstoreOpenApi30.Core;
using SwaggerPetstoreOpenApi30.Core.ErrorResponse;
using SwaggerPetstoreOpenApi30.Core.Exceptions;
using SwaggerPetstoreOpenApi30.Core.Models;
using SwaggerPetstoreOpenApi30.Core.Request;
using SwaggerPetstoreOpenApi30.Core.Response;
using SwaggerPetstoreOpenApi30.Errors;
using SwaggerPetstoreOpenApi30.Models;
using SwaggerPetstoreOpenApi30.Models.Enums;

namespace SwaggerPetstoreOpenApi30.Api;

/// <summary>
/// Access to Petstore orders
/// </summary>
public sealed class Store
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal Store(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Delete purchase order by identifier.
    /// </summary>
    /// <param name="orderId">ID of the order that needs to be deleted</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="DeleteOrderError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// For valid response try integer IDs with value &lt; 1000. Anything above 1000 or non-integers will generate API errors.
    /// </remarks>
    public Task DeleteOrder(long orderId, RequestOptions? requestOptions = null, CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/store/order/{orderId}"),
            [new TemplateParam("orderId", orderId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Delete,
            EmptyBody.Instance,
            VoidResponse.Instance,
            DeleteOrderErrorResponse.Instance,
            [],
            requestOptions,
            ct);

    /// <summary>
    /// Returns pet inventories by status.
    /// </summary>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="IReadOnlyDictionary{TKey, TValue}"/> of <see cref="int"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns a map of status codes to quantities.
    /// </remarks>
    public Task<IReadOnlyDictionary<string, int>> GetInventory(RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/store/inventory"),
            [],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<IReadOnlyDictionary<string, int>>(),
            RawErrorResponse.Instance,
            [_auth.ApiKey],
            requestOptions,
            ct);

    /// <summary>
    /// Find purchase order by ID.
    /// </summary>
    /// <param name="orderId">ID of order that needs to be fetched</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="Order"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetOrderByIdError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// For valid response try integer IDs with value &lt;= 5 or &gt; 10. Other values will generate exceptions.
    /// </remarks>
    public Task<Order> GetOrderById(long orderId,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/store/order/{orderId}"),
            [new TemplateParam("orderId", orderId)],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<Order>(),
            GetOrderByIdErrorResponse.Instance,
            [],
            requestOptions,
            ct);

    /// <summary>
    /// Place an order for a pet.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="petId"></param>
    /// <param name="quantity"></param>
    /// <param name="shipDate"></param>
    /// <param name="status"></param>
    /// <param name="complete"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="Order"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="PlaceOrderError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Place a new order in the store.
    /// </remarks>
    public Task<Order> PlaceOrder(long? id,
        long? petId,
        int? quantity,
        DateTimeOffset? shipDate,
        OrderStatus? status,
        bool? complete,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/store/order"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            FormUrlEncodedRequest.Create([new Param("id", id),
                    new Param("petId", petId),
                    new Param("quantity", quantity),
                    new Param("shipDate", shipDate),
                    new Param("status", status),
                    new Param("complete", complete)]),
            JsonResponse.Create<Order>(),
            PlaceOrderErrorResponse.Instance,
            [],
            requestOptions,
            ct);
}
