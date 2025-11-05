using System.Text.Json;
using PayabliApi.Core;

namespace PayabliApi;

public partial class TokenStorageClient
{
    private RawClient _client;

    internal TokenStorageClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Saves a payment method for reuse. This call exchanges sensitive payment information for a token that can be used to process future transactions. The `ReferenceId` value in the response is the `storedMethodId` to use with transactions.
    /// </summary>
    /// <example><code>
    /// await client.TokenStorage.AddMethodAsync(
    ///     new AddMethodRequest
    ///     {
    ///         Body = new RequestTokenStorage
    ///         {
    ///             CustomerData = new PayorDataRequest { CustomerId = 4440 },
    ///             EntryPoint = "f743aed24a",
    ///             FallbackAuth = true,
    ///             PaymentMethod = new TokenizeCard
    ///             {
    ///                 Cardcvv = "123",
    ///                 Cardexp = "02/25",
    ///                 CardHolder = "John Doe",
    ///                 Cardnumber = "4111111111111111",
    ///                 Cardzip = "12345",
    ///                 Method = "card",
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<AddMethodResponse> AddMethodAsync(
        AddMethodRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.AchValidation != null)
        {
            _query["achValidation"] = JsonUtils.Serialize(request.AchValidation.Value);
        }
        if (request.CreateAnonymous != null)
        {
            _query["createAnonymous"] = JsonUtils.Serialize(request.CreateAnonymous.Value);
        }
        if (request.ForceCustomerCreation != null)
        {
            _query["forceCustomerCreation"] = JsonUtils.Serialize(
                request.ForceCustomerCreation.Value
            );
        }
        if (request.Temporary != null)
        {
            _query["temporary"] = JsonUtils.Serialize(request.Temporary.Value);
        }
        var _headers = new Headers(new Dictionary<string, string>() { });
        if (request.IdempotencyKey != null)
        {
            _headers["idempotencyKey"] = request.IdempotencyKey;
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = "TokenStorage/add",
                    Body = request.Body,
                    Query = _query,
                    Headers = _headers,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<AddMethodResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new PayabliApiException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<PayabliApiResponse>(responseBody)
                        );
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new PayabliApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    /// <summary>
    /// Retrieves details for a saved payment method.
    /// </summary>
    /// <example><code>
    /// await client.TokenStorage.GetMethodAsync(
    ///     "32-8877drt00045632-678",
    ///     new GetMethodRequest { CardExpirationFormat = 1, IncludeTemporary = false }
    /// );
    /// </code></example>
    public async Task<GetMethodResponse> GetMethodAsync(
        string methodId,
        GetMethodRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.CardExpirationFormat != null)
        {
            _query["cardExpirationFormat"] = request.CardExpirationFormat.Value.ToString();
        }
        if (request.IncludeTemporary != null)
        {
            _query["includeTemporary"] = JsonUtils.Serialize(request.IncludeTemporary.Value);
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "TokenStorage/{0}",
                        ValueConvert.ToPathParameterString(methodId)
                    ),
                    Query = _query,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<GetMethodResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new PayabliApiException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<PayabliApiResponse>(responseBody)
                        );
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new PayabliApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    /// <summary>
    /// Deletes a saved payment method.
    /// </summary>
    /// <example><code>
    /// await client.TokenStorage.RemoveMethodAsync("32-8877drt00045632-678");
    /// </code></example>
    public async Task<PayabliApiResponsePaymethodDelete> RemoveMethodAsync(
        string methodId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Delete,
                    Path = string.Format(
                        "TokenStorage/{0}",
                        ValueConvert.ToPathParameterString(methodId)
                    ),
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<PayabliApiResponsePaymethodDelete>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new PayabliApiException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<PayabliApiResponse>(responseBody)
                        );
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new PayabliApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    /// <summary>
    /// Updates a saved payment method.
    /// </summary>
    /// <example><code>
    /// await client.TokenStorage.UpdateMethodAsync(
    ///     "32-8877drt00045632-678",
    ///     new UpdateMethodRequest
    ///     {
    ///         Body = new RequestTokenStorage
    ///         {
    ///             CustomerData = new PayorDataRequest { CustomerId = 4440 },
    ///             EntryPoint = "f743aed24a",
    ///             FallbackAuth = true,
    ///             PaymentMethod = new TokenizeCard
    ///             {
    ///                 Cardcvv = "123",
    ///                 Cardexp = "02/25",
    ///                 CardHolder = "John Doe",
    ///                 Cardnumber = "4111111111111111",
    ///                 Cardzip = "12345",
    ///                 Method = "card",
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<PayabliApiResponsePaymethodDelete> UpdateMethodAsync(
        string methodId,
        UpdateMethodRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.AchValidation != null)
        {
            _query["achValidation"] = JsonUtils.Serialize(request.AchValidation.Value);
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Put,
                    Path = string.Format(
                        "TokenStorage/{0}",
                        ValueConvert.ToPathParameterString(methodId)
                    ),
                    Body = request.Body,
                    Query = _query,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<PayabliApiResponsePaymethodDelete>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new PayabliApiException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<PayabliApiResponse>(responseBody)
                        );
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new PayabliApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }
}
