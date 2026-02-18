using System.Text.Json;
using PayabliApi.Core;

namespace PayabliApi;

public partial class PaymentMethodDomainClient : IPaymentMethodDomainClient
{
    private RawClient _client;

    internal PaymentMethodDomainClient(RawClient client)
    {
        _client = client;
    }

    private async Task<
        WithRawResponse<AddPaymentMethodDomainApiResponse>
    > AddPaymentMethodDomainAsyncCore(
        AddPaymentMethodDomainRequest request,
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
                    Method = HttpMethod.Post,
                    Path = "PaymentMethodDomain",
                    Body = request,
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
                var responseData = JsonUtils.Deserialize<AddPaymentMethodDomainApiResponse>(
                    responseBody
                )!;
                return new WithRawResponse<AddPaymentMethodDomainApiResponse>()
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

    private async Task<
        WithRawResponse<PaymentMethodDomainGeneralResponse>
    > CascadePaymentMethodDomainAsyncCore(
        string domainId,
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
                    Method = HttpMethod.Post,
                    Path = string.Format(
                        "PaymentMethodDomain/{0}/cascade",
                        ValueConvert.ToPathParameterString(domainId)
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
                var responseData = JsonUtils.Deserialize<PaymentMethodDomainGeneralResponse>(
                    responseBody
                )!;
                return new WithRawResponse<PaymentMethodDomainGeneralResponse>()
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

    private async Task<
        WithRawResponse<DeletePaymentMethodDomainResponse>
    > DeletePaymentMethodDomainAsyncCore(
        string domainId,
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
                        "PaymentMethodDomain/{0}",
                        ValueConvert.ToPathParameterString(domainId)
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
                var responseData = JsonUtils.Deserialize<DeletePaymentMethodDomainResponse>(
                    responseBody
                )!;
                return new WithRawResponse<DeletePaymentMethodDomainResponse>()
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

    private async Task<
        WithRawResponse<PaymentMethodDomainApiResponse>
    > GetPaymentMethodDomainAsyncCore(
        string domainId,
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
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "PaymentMethodDomain/{0}",
                        ValueConvert.ToPathParameterString(domainId)
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
                var responseData = JsonUtils.Deserialize<PaymentMethodDomainApiResponse>(
                    responseBody
                )!;
                return new WithRawResponse<PaymentMethodDomainApiResponse>()
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

    private async Task<
        WithRawResponse<ListPaymentMethodDomainsResponse>
    > ListPaymentMethodDomainsAsyncCore(
        ListPaymentMethodDomainsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new PayabliApi.Core.QueryStringBuilder.Builder(capacity: 4)
            .Add("entityId", request.EntityId)
            .Add("entityType", request.EntityType)
            .Add("fromRecord", request.FromRecord)
            .Add("limitRecord", request.LimitRecord)
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
                    Path = "PaymentMethodDomain/list",
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
                var responseData = JsonUtils.Deserialize<ListPaymentMethodDomainsResponse>(
                    responseBody
                )!;
                return new WithRawResponse<ListPaymentMethodDomainsResponse>()
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

    private async Task<
        WithRawResponse<PaymentMethodDomainGeneralResponse>
    > UpdatePaymentMethodDomainAsyncCore(
        string domainId,
        UpdatePaymentMethodDomainRequest request,
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
                    Method = HttpMethodExtensions.Patch,
                    Path = string.Format(
                        "PaymentMethodDomain/{0}",
                        ValueConvert.ToPathParameterString(domainId)
                    ),
                    Body = request,
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
                var responseData = JsonUtils.Deserialize<PaymentMethodDomainGeneralResponse>(
                    responseBody
                )!;
                return new WithRawResponse<PaymentMethodDomainGeneralResponse>()
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

    private async Task<
        WithRawResponse<PaymentMethodDomainGeneralResponse>
    > VerifyPaymentMethodDomainAsyncCore(
        string domainId,
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
                    Method = HttpMethod.Post,
                    Path = string.Format(
                        "PaymentMethodDomain/{0}/verify",
                        ValueConvert.ToPathParameterString(domainId)
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
                var responseData = JsonUtils.Deserialize<PaymentMethodDomainGeneralResponse>(
                    responseBody
                )!;
                return new WithRawResponse<PaymentMethodDomainGeneralResponse>()
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
    /// Add a payment method domain to an organization or paypoint.
    /// </summary>
    /// <example><code>
    /// await client.PaymentMethodDomain.AddPaymentMethodDomainAsync(
    ///     new AddPaymentMethodDomainRequest
    ///     {
    ///         DomainName = "checkout.example.com",
    ///         EntityId = 109,
    ///         EntityType = "paypoint",
    ///         ApplePay = new AddPaymentMethodDomainRequestApplePay { IsEnabled = true },
    ///         GooglePay = new AddPaymentMethodDomainRequestGooglePay { IsEnabled = true },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<AddPaymentMethodDomainApiResponse> AddPaymentMethodDomainAsync(
        AddPaymentMethodDomainRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<AddPaymentMethodDomainApiResponse>(
            AddPaymentMethodDomainAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Cascades a payment method domain to all child entities. All paypoints and suborganization under this parent will inherit this domain and its settings.
    /// </summary>
    /// <example><code>
    /// await client.PaymentMethodDomain.CascadePaymentMethodDomainAsync(
    ///     "pmd_b8237fa45c964d8a9ef27160cd42b8c5"
    /// );
    /// </code></example>
    public WithRawResponseTask<PaymentMethodDomainGeneralResponse> CascadePaymentMethodDomainAsync(
        string domainId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<PaymentMethodDomainGeneralResponse>(
            CascadePaymentMethodDomainAsyncCore(domainId, options, cancellationToken)
        );
    }

    /// <summary>
    /// Delete a payment method domain. You can't delete an inherited domain, you must delete a domain at the organization level.
    /// </summary>
    /// <example><code>
    /// await client.PaymentMethodDomain.DeletePaymentMethodDomainAsync(
    ///     "pmd_b8237fa45c964d8a9ef27160cd42b8c5"
    /// );
    /// </code></example>
    public WithRawResponseTask<DeletePaymentMethodDomainResponse> DeletePaymentMethodDomainAsync(
        string domainId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<DeletePaymentMethodDomainResponse>(
            DeletePaymentMethodDomainAsyncCore(domainId, options, cancellationToken)
        );
    }

    /// <summary>
    /// Get the details for a payment method domain.
    /// </summary>
    /// <example><code>
    /// await client.PaymentMethodDomain.GetPaymentMethodDomainAsync(
    ///     "pmd_b8237fa45c964d8a9ef27160cd42b8c5"
    /// );
    /// </code></example>
    public WithRawResponseTask<PaymentMethodDomainApiResponse> GetPaymentMethodDomainAsync(
        string domainId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<PaymentMethodDomainApiResponse>(
            GetPaymentMethodDomainAsyncCore(domainId, options, cancellationToken)
        );
    }

    /// <summary>
    /// Get a list of payment method domains that belong to a PSP, organization, or paypoint.
    /// </summary>
    /// <example><code>
    /// await client.PaymentMethodDomain.ListPaymentMethodDomainsAsync(
    ///     new ListPaymentMethodDomainsRequest { EntityId = 1147, EntityType = "paypoint" }
    /// );
    /// </code></example>
    public WithRawResponseTask<ListPaymentMethodDomainsResponse> ListPaymentMethodDomainsAsync(
        ListPaymentMethodDomainsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ListPaymentMethodDomainsResponse>(
            ListPaymentMethodDomainsAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Update a payment method domain's configuration values.
    /// </summary>
    /// <example><code>
    /// await client.PaymentMethodDomain.UpdatePaymentMethodDomainAsync(
    ///     "pmd_b8237fa45c964d8a9ef27160cd42b8c5",
    ///     new UpdatePaymentMethodDomainRequest
    ///     {
    ///         ApplePay = new UpdatePaymentMethodDomainRequestWallet { IsEnabled = false },
    ///         GooglePay = new UpdatePaymentMethodDomainRequestWallet { IsEnabled = false },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<PaymentMethodDomainGeneralResponse> UpdatePaymentMethodDomainAsync(
        string domainId,
        UpdatePaymentMethodDomainRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<PaymentMethodDomainGeneralResponse>(
            UpdatePaymentMethodDomainAsyncCore(domainId, request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Verify a new payment method domain. If verification is successful, Apple Pay is automatically activated for the domain.
    /// </summary>
    /// <example><code>
    /// await client.PaymentMethodDomain.VerifyPaymentMethodDomainAsync(
    ///     "pmd_b8237fa45c964d8a9ef27160cd42b8c5"
    /// );
    /// </code></example>
    public WithRawResponseTask<PaymentMethodDomainGeneralResponse> VerifyPaymentMethodDomainAsync(
        string domainId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<PaymentMethodDomainGeneralResponse>(
            VerifyPaymentMethodDomainAsyncCore(domainId, options, cancellationToken)
        );
    }
}
