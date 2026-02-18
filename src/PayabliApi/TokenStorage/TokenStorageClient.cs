using System.Text.Json;
using PayabliApi.Core;

namespace PayabliApi;

public partial class TokenStorageClient : ITokenStorageClient
{
    private RawClient _client;

    internal TokenStorageClient(RawClient client)
    {
        _client = client;
    }

    private async Task<WithRawResponse<AddMethodResponse>> AddMethodAsyncCore(
        AddMethodRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new PayabliApi.Core.QueryStringBuilder.Builder(capacity: 4)
            .Add("achValidation", request.AchValidation)
            .Add("createAnonymous", request.CreateAnonymous)
            .Add("forceCustomerCreation", request.ForceCustomerCreation)
            .Add("temporary", request.Temporary)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new PayabliApi.Core.HeadersBuilder.Builder()
            .Add("idempotencyKey", request.IdempotencyKey)
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = "TokenStorage/add",
                    Body = request.Body,
                    QueryString = _queryString,
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
                var responseData = JsonUtils.Deserialize<AddMethodResponse>(responseBody)!;
                return new WithRawResponse<AddMethodResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new PayabliApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
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

    private async Task<WithRawResponse<GetMethodResponse>> GetMethodAsyncCore(
        string methodId,
        GetMethodRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new PayabliApi.Core.QueryStringBuilder.Builder(capacity: 2)
            .Add("cardExpirationFormat", request.CardExpirationFormat)
            .Add("includeTemporary", request.IncludeTemporary)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new PayabliApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
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
                    QueryString = _queryString,
                    Headers = _headers,
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
                var responseData = JsonUtils.Deserialize<GetMethodResponse>(responseBody)!;
                return new WithRawResponse<GetMethodResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new PayabliApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
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

    private async Task<WithRawResponse<PayabliApiResponsePaymethodDelete>> RemoveMethodAsyncCore(
        string methodId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _headers = await new PayabliApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
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
                    Headers = _headers,
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
                var responseData = JsonUtils.Deserialize<PayabliApiResponsePaymethodDelete>(
                    responseBody
                )!;
                return new WithRawResponse<PayabliApiResponsePaymethodDelete>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new PayabliApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
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

    private async Task<WithRawResponse<PayabliApiResponsePaymethodDelete>> UpdateMethodAsyncCore(
        string methodId,
        UpdateMethodRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new PayabliApi.Core.QueryStringBuilder.Builder(capacity: 1)
            .Add("achValidation", request.AchValidation)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new PayabliApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
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
                    QueryString = _queryString,
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
                var responseData = JsonUtils.Deserialize<PayabliApiResponsePaymethodDelete>(
                    responseBody
                )!;
                return new WithRawResponse<PayabliApiResponsePaymethodDelete>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new PayabliApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            throw new PayabliApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
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
    public WithRawResponseTask<AddMethodResponse> AddMethodAsync(
        AddMethodRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<AddMethodResponse>(
            AddMethodAsyncCore(request, options, cancellationToken)
        );
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
    public WithRawResponseTask<GetMethodResponse> GetMethodAsync(
        string methodId,
        GetMethodRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GetMethodResponse>(
            GetMethodAsyncCore(methodId, request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Deletes a saved payment method.
    /// </summary>
    /// <example><code>
    /// await client.TokenStorage.RemoveMethodAsync("32-8877drt00045632-678");
    /// </code></example>
    public WithRawResponseTask<PayabliApiResponsePaymethodDelete> RemoveMethodAsync(
        string methodId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<PayabliApiResponsePaymethodDelete>(
            RemoveMethodAsyncCore(methodId, options, cancellationToken)
        );
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
    public WithRawResponseTask<PayabliApiResponsePaymethodDelete> UpdateMethodAsync(
        string methodId,
        UpdateMethodRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<PayabliApiResponsePaymethodDelete>(
            UpdateMethodAsyncCore(methodId, request, options, cancellationToken)
        );
    }
}
