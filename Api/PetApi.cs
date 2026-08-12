using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SwaggerPetstoreOpenApi30.Core;
using SwaggerPetstoreOpenApi30.Core.Authentication;
using SwaggerPetstoreOpenApi30.Core.Exceptions;
using SwaggerPetstoreOpenApi30.Core.Models;
using SwaggerPetstoreOpenApi30.Core.Request;
using SwaggerPetstoreOpenApi30.Core.Response;
using SwaggerPetstoreOpenApi30.Errors;
using SwaggerPetstoreOpenApi30.Models;
using SwaggerPetstoreOpenApi30.Models.Enums;

namespace SwaggerPetstoreOpenApi30.Api;

/// <summary>
/// Everything about your Pets
/// </summary>
public sealed class PetApi
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal PetApi(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Add a new pet to the store.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="photoUrls"></param>
    /// <param name="id"></param>
    /// <param name="category"></param>
    /// <param name="tags"></param>
    /// <param name="status"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="Pet"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="AddPetError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Add a new pet to the store.
    /// </remarks>
    public Task<Pet> AddPet(string name,
        IReadOnlyList<string> photoUrls,
        long? id,
        Category? category,
        IReadOnlyList<Tag>? tags,
        PetStatus? status,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/pet"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            FormUrlEncodedRequest.Create([new Param("name", name),
                    new Param("photoUrls", photoUrls),
                    new Param("id", id),
                    new Param("category", category),
                    new Param("tags", tags),
                    new Param("status", status)]),
            JsonResponse.Create<Pet>(),
            AddPetErrorResponse.Instance,
            [_auth.PetstoreAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Deletes a pet.
    /// </summary>
    /// <param name="petId">Pet id to delete</param>
    /// <param name="apiKey"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="DeletePetError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Delete a pet.
    /// </remarks>
    public Task DeletePet(long petId,
        string? apiKey,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/pet/{petId}"),
            [new TemplateParam("petId", petId)],
            [],
            [new HeaderParam("api_key", apiKey), new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Delete,
            EmptyBody.Instance,
            VoidResponse.Instance,
            DeletePetErrorResponse.Instance,
            [_auth.PetstoreAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Finds Pets by status.
    /// </summary>
    /// <param name="status">Status values that need to be considered for filter</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="IReadOnlyList{T}"/> of <see cref="Pet"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="FindPetsByStatusError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Multiple status values can be provided with comma separated strings.
    /// </remarks>
    public Task<IReadOnlyList<Pet>> FindPetsByStatus(PetStatus? status,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/pet/findByStatus"),
            [],
            [new Param("status", status)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<IReadOnlyList<Pet>>(),
            FindPetsByStatusErrorResponse.Instance,
            [_auth.PetstoreAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Finds Pets by tags.
    /// </summary>
    /// <param name="tags">Tags to filter by</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="IReadOnlyList{T}"/> of <see cref="Pet"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="FindPetsByTagsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Multiple tags can be provided with comma separated strings. Use tag1, tag2, tag3 for testing.
    /// </remarks>
    public Task<IReadOnlyList<Pet>> FindPetsByTags(IReadOnlyList<string>? tags,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/pet/findByTags"),
            [],
            [new Param("tags", tags)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<IReadOnlyList<Pet>>(),
            FindPetsByTagsErrorResponse.Instance,
            [_auth.PetstoreAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Find pet by ID.
    /// </summary>
    /// <param name="petId">ID of pet to return</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="Pet"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetPetByIdError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns a single pet.
    /// </remarks>
    public Task<Pet> GetPetById(long petId, RequestOptions? requestOptions = null, CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/pet/{petId}"),
            [new TemplateParam("petId", petId)],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<Pet>(),
            GetPetByIdErrorResponse.Instance,
            [new AuthSchemeAny(_auth.ApiKey, _auth.PetstoreAuth)],
            requestOptions,
            ct);

    /// <summary>
    /// Update an existing pet.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="photoUrls"></param>
    /// <param name="id"></param>
    /// <param name="category"></param>
    /// <param name="tags"></param>
    /// <param name="status"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="Pet"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="UpdatePetError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Update an existing pet by Id.
    /// </remarks>
    public Task<Pet> UpdatePet(string name,
        IReadOnlyList<string> photoUrls,
        long? id,
        Category? category,
        IReadOnlyList<Tag>? tags,
        PetStatus? status,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/pet"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Put,
            FormUrlEncodedRequest.Create([new Param("name", name),
                    new Param("photoUrls", photoUrls),
                    new Param("id", id),
                    new Param("category", category),
                    new Param("tags", tags),
                    new Param("status", status)]),
            JsonResponse.Create<Pet>(),
            UpdatePetErrorResponse.Instance,
            [_auth.PetstoreAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Updates a pet in the store with form data.
    /// </summary>
    /// <param name="petId">ID of pet that needs to be updated</param>
    /// <param name="name">Name of pet that needs to be updated</param>
    /// <param name="status">Status of pet that needs to be updated</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="Pet"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="UpdatePetWithFormError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Updates a pet resource based on the form data.
    /// </remarks>
    public Task<Pet> UpdatePetWithForm(long petId,
        string? name,
        string? status,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/pet/{petId}"),
            [new TemplateParam("petId", petId)],
            [new Param("name", name), new Param("status", status)],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            EmptyBody.Instance,
            JsonResponse.Create<Pet>(),
            UpdatePetWithFormErrorResponse.Instance,
            [_auth.PetstoreAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Uploads an image.
    /// </summary>
    /// <param name="petId">ID of pet to update</param>
    /// <param name="additionalMetadata">Additional Metadata</param>
    /// <param name="body"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ApiResponseModel"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="UploadFileError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Upload image of the pet.
    /// </remarks>
    public Task<ApiResponseModel> UploadFile(long petId,
        string? additionalMetadata,
        BinaryContent? body,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/pet/{petId}/uploadImage"),
            [new TemplateParam("petId", petId)],
            [new Param("additionalMetadata", additionalMetadata)],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            BinaryRequest.Create(body),
            JsonResponse.Create<ApiResponseModel>(),
            UploadFileErrorResponse.Instance,
            [_auth.PetstoreAuth],
            requestOptions,
            ct);
}
