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

namespace SwaggerPetstoreOpenApi30.Api;

/// <summary>
/// Operations about user
/// </summary>
public sealed class UserApi
{
    private readonly RawClient _rawClient;
    private readonly Server _server;

    internal UserApi(RawClient rawClient, Server server)
    {
        _rawClient = rawClient;
        _server = server;
    }

    /// <summary>
    /// Create user.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="username"></param>
    /// <param name="firstName"></param>
    /// <param name="lastName"></param>
    /// <param name="email"></param>
    /// <param name="password"></param>
    /// <param name="phone"></param>
    /// <param name="userStatus"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="User"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This can only be done by the logged in user.
    /// </remarks>
    public Task<User> CreateUser(long? id,
        string? username,
        string? firstName,
        string? lastName,
        string? email,
        string? password,
        string? phone,
        int? userStatus,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/user"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            FormUrlEncodedRequest.Create([new Param("id", id),
                    new Param("username", username),
                    new Param("firstName", firstName),
                    new Param("lastName", lastName),
                    new Param("email", email),
                    new Param("password", password),
                    new Param("phone", phone),
                    new Param("userStatus", userStatus)]),
            JsonResponse.Create<User>(),
            RawErrorResponse.Instance,
            [],
            requestOptions,
            ct);

    /// <summary>
    /// Creates list of users with given input array.
    /// </summary>
    /// <param name="body"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="User"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Creates list of users with given input array.
    /// </remarks>
    public Task<User> CreateUsersWithListInput(IReadOnlyList<User>? body,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/user/createWithList"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<User>(),
            RawErrorResponse.Instance,
            [],
            requestOptions,
            ct);

    /// <summary>
    /// Delete user resource.
    /// </summary>
    /// <param name="usersname">The username that needs to be processed</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="DeleteUserError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This can only be done by the logged in user.
    /// </remarks>
    public Task DeleteUser(string usersname, RequestOptions? requestOptions = null, CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/user/{usersname}"),
            [new TemplateParam("usersname", usersname)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Delete,
            EmptyBody.Instance,
            VoidResponse.Instance,
            DeleteUserErrorResponse.Instance,
            [],
            requestOptions,
            ct);

    /// <summary>
    /// Get user by user name.
    /// </summary>
    /// <param name="usersname">The username that needs to be processed</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="User"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetUserByNameError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Get user detail based on username.
    /// </remarks>
    public Task<User> GetUserByName(string usersname,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/user/{usersname}"),
            [new TemplateParam("usersname", usersname)],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<User>(),
            GetUserByNameErrorResponse.Instance,
            [],
            requestOptions,
            ct);

    /// <summary>
    /// Logs user into the system.
    /// </summary>
    /// <param name="username">The user name for login</param>
    /// <param name="password">The password for login in clear text</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="LoginUserError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Log into the system.
    /// </remarks>
    public Task LoginUser(string? username,
        string? password,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/user/login"),
            [],
            [new Param("username", username), new Param("password", password)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            VoidResponse.Instance,
            LoginUserErrorResponse.Instance,
            [],
            requestOptions,
            ct);

    /// <summary>
    /// Logs out current logged in user session.
    /// </summary>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Log user out of the system.
    /// </remarks>
    public Task LogoutUser(RequestOptions? requestOptions = null, CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/user/logout"),
            [],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            VoidResponse.Instance,
            RawErrorResponse.Instance,
            [],
            requestOptions,
            ct);

    /// <summary>
    /// Update user resource.
    /// </summary>
    /// <param name="usersname">The username that needs to be processed</param>
    /// <param name="id"></param>
    /// <param name="username"></param>
    /// <param name="firstName"></param>
    /// <param name="lastName"></param>
    /// <param name="email"></param>
    /// <param name="password"></param>
    /// <param name="phone"></param>
    /// <param name="userStatus"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="UpdateUserError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This can only be done by the logged in user.
    /// </remarks>
    public Task UpdateUser(string usersname,
        long? id,
        string? username,
        string? firstName,
        string? lastName,
        string? email,
        string? password,
        string? phone,
        int? userStatus,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/user/{usersname}"),
            [new TemplateParam("usersname", usersname)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Put,
            FormUrlEncodedRequest.Create([new Param("id", id),
                    new Param("username", username),
                    new Param("firstName", firstName),
                    new Param("lastName", lastName),
                    new Param("email", email),
                    new Param("password", password),
                    new Param("phone", phone),
                    new Param("userStatus", userStatus)]),
            VoidResponse.Instance,
            UpdateUserErrorResponse.Instance,
            [],
            requestOptions,
            ct);
}
