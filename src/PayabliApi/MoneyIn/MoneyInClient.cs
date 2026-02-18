using System.Text.Json;
using PayabliApi.Core;

namespace PayabliApi;

public partial class MoneyInClient : IMoneyInClient
{
    private RawClient _client;

    internal MoneyInClient(RawClient client)
    {
        _client = client;
    }

    private async Task<WithRawResponse<AuthResponse>> AuthorizeAsyncCore(
        RequestPaymentAuthorize request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new PayabliApi.Core.QueryStringBuilder.Builder(capacity: 1)
            .Add("forceCustomerCreation", request.ForceCustomerCreation)
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
                    Path = "MoneyIn/authorize",
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
                var responseData = JsonUtils.Deserialize<AuthResponse>(responseBody)!;
                return new WithRawResponse<AuthResponse>()
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

    private async Task<WithRawResponse<CaptureResponse>> CaptureAsyncCore(
        string transId,
        double amount,
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
                        "MoneyIn/capture/{0}/{1}",
                        ValueConvert.ToPathParameterString(transId),
                        ValueConvert.ToPathParameterString(amount)
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
                var responseData = JsonUtils.Deserialize<CaptureResponse>(responseBody)!;
                return new WithRawResponse<CaptureResponse>()
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

    private async Task<WithRawResponse<CaptureResponse>> CaptureAuthAsyncCore(
        string transId,
        CaptureRequest request,
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
                        "MoneyIn/capture/{0}",
                        ValueConvert.ToPathParameterString(transId)
                    ),
                    Body = request,
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
                var responseData = JsonUtils.Deserialize<CaptureResponse>(responseBody)!;
                return new WithRawResponse<CaptureResponse>()
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

    private async Task<WithRawResponse<PayabliApiResponse0>> CreditAsyncCore(
        RequestCredit request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new PayabliApi.Core.QueryStringBuilder.Builder(capacity: 1)
            .Add("forceCustomerCreation", request.ForceCustomerCreation)
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
                    Path = "MoneyIn/makecredit",
                    Body = request,
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
                var responseData = JsonUtils.Deserialize<PayabliApiResponse0>(responseBody)!;
                return new WithRawResponse<PayabliApiResponse0>()
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

    private async Task<WithRawResponse<TransactionQueryRecordsCustomer>> DetailsAsyncCore(
        string transId,
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
                        "MoneyIn/details/{0}",
                        ValueConvert.ToPathParameterString(transId)
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
                var responseData = JsonUtils.Deserialize<TransactionQueryRecordsCustomer>(
                    responseBody
                )!;
                return new WithRawResponse<TransactionQueryRecordsCustomer>()
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

    private async Task<WithRawResponse<PayabliApiResponseGetPaid>> GetpaidAsyncCore(
        RequestPayment request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new PayabliApi.Core.QueryStringBuilder.Builder(capacity: 3)
            .Add("achValidation", request.AchValidation)
            .Add("forceCustomerCreation", request.ForceCustomerCreation)
            .Add("includeDetails", request.IncludeDetails)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new PayabliApi.Core.HeadersBuilder.Builder()
            .Add("idempotencyKey", request.IdempotencyKey)
            .Add("validationCode", request.ValidationCode)
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
                    Path = "MoneyIn/getpaid",
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
                var responseData = JsonUtils.Deserialize<PayabliApiResponseGetPaid>(responseBody)!;
                return new WithRawResponse<PayabliApiResponseGetPaid>()
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

    private async Task<WithRawResponse<ReverseResponse>> ReverseAsyncCore(
        string transId,
        double amount,
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
                        "MoneyIn/reverse/{0}/{1}",
                        ValueConvert.ToPathParameterString(transId),
                        ValueConvert.ToPathParameterString(amount)
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
                var responseData = JsonUtils.Deserialize<ReverseResponse>(responseBody)!;
                return new WithRawResponse<ReverseResponse>()
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

    private async Task<WithRawResponse<RefundResponse>> RefundAsyncCore(
        string transId,
        double amount,
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
                        "MoneyIn/refund/{0}/{1}",
                        ValueConvert.ToPathParameterString(transId),
                        ValueConvert.ToPathParameterString(amount)
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
                var responseData = JsonUtils.Deserialize<RefundResponse>(responseBody)!;
                return new WithRawResponse<RefundResponse>()
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
        WithRawResponse<RefundWithInstructionsResponse>
    > RefundWithInstructionsAsyncCore(
        string transId,
        RequestRefund request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
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
                    Path = string.Format(
                        "MoneyIn/refund/{0}",
                        ValueConvert.ToPathParameterString(transId)
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
                var responseData = JsonUtils.Deserialize<RefundWithInstructionsResponse>(
                    responseBody
                )!;
                return new WithRawResponse<RefundWithInstructionsResponse>()
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

    private async Task<WithRawResponse<PayabliApiResponse>> ReverseCreditAsyncCore(
        string transId,
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
                        "MoneyIn/reverseCredit/{0}",
                        ValueConvert.ToPathParameterString(transId)
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
                var responseData = JsonUtils.Deserialize<PayabliApiResponse>(responseBody)!;
                return new WithRawResponse<PayabliApiResponse>()
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

    private async Task<WithRawResponse<ReceiptResponse>> SendReceipt2TransAsyncCore(
        string transId,
        SendReceipt2TransRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new PayabliApi.Core.QueryStringBuilder.Builder(capacity: 1)
            .Add("email", request.Email)
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
                        "MoneyIn/sendreceipt/{0}",
                        ValueConvert.ToPathParameterString(transId)
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
                var responseData = JsonUtils.Deserialize<ReceiptResponse>(responseBody)!;
                return new WithRawResponse<ReceiptResponse>()
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

    private async Task<WithRawResponse<ValidateResponse>> ValidateAsyncCore(
        RequestPaymentValidate request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
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
                    Path = "MoneyIn/validate",
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
                var responseData = JsonUtils.Deserialize<ValidateResponse>(responseBody)!;
                return new WithRawResponse<ValidateResponse>()
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

    private async Task<WithRawResponse<VoidResponse>> VoidAsyncCore(
        string transId,
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
                        "MoneyIn/void/{0}",
                        ValueConvert.ToPathParameterString(transId)
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
                var responseData = JsonUtils.Deserialize<VoidResponse>(responseBody)!;
                return new WithRawResponse<VoidResponse>()
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

    private async Task<WithRawResponse<V2TransactionResponseWrapper>> Getpaidv2AsyncCore(
        RequestPaymentV2 request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new PayabliApi.Core.QueryStringBuilder.Builder(capacity: 2)
            .Add("achValidation", request.AchValidation)
            .Add("forceCustomerCreation", request.ForceCustomerCreation)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new PayabliApi.Core.HeadersBuilder.Builder()
            .Add("idempotencyKey", request.IdempotencyKey)
            .Add("validationCode", request.ValidationCode)
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
                    Path = "v2/MoneyIn/getpaid",
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
                var responseData = JsonUtils.Deserialize<V2TransactionResponseWrapper>(
                    responseBody
                )!;
                return new WithRawResponse<V2TransactionResponseWrapper>()
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
                        throw new BadRequestAuthResponseErrorV2(
                            JsonUtils.Deserialize<V2BadRequestError>(responseBody)
                        );
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new DeclinedAuthResponseErrorV2(
                            JsonUtils.Deserialize<V2DeclinedTransactionResponseWrapper>(
                                responseBody
                            )
                        );
                    case 500:
                        throw new InternalServerResponseErrorV2(
                            JsonUtils.Deserialize<V2InternalServerError>(responseBody)
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

    private async Task<WithRawResponse<V2TransactionResponseWrapper>> Authorizev2AsyncCore(
        RequestPaymentAuthorizeV2 request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new PayabliApi.Core.QueryStringBuilder.Builder(capacity: 1)
            .Add("forceCustomerCreation", request.ForceCustomerCreation)
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
                    Path = "v2/MoneyIn/authorize",
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
                var responseData = JsonUtils.Deserialize<V2TransactionResponseWrapper>(
                    responseBody
                )!;
                return new WithRawResponse<V2TransactionResponseWrapper>()
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
                        throw new BadRequestAuthResponseErrorV2(
                            JsonUtils.Deserialize<V2BadRequestError>(responseBody)
                        );
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new DeclinedAuthResponseErrorV2(
                            JsonUtils.Deserialize<V2DeclinedTransactionResponseWrapper>(
                                responseBody
                            )
                        );
                    case 500:
                        throw new InternalServerResponseErrorV2(
                            JsonUtils.Deserialize<V2InternalServerError>(responseBody)
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

    private async Task<WithRawResponse<V2TransactionResponseWrapper>> Capturev2AsyncCore(
        string transId,
        CaptureRequest request,
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
                        "v2/MoneyIn/capture/{0}",
                        ValueConvert.ToPathParameterString(transId)
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
                var responseData = JsonUtils.Deserialize<V2TransactionResponseWrapper>(
                    responseBody
                )!;
                return new WithRawResponse<V2TransactionResponseWrapper>()
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
                        throw new BadRequestCaptureResponseErrorV2(
                            JsonUtils.Deserialize<V2BadRequestError>(responseBody)
                        );
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new DeclinedCaptureResponseErrorV2(
                            JsonUtils.Deserialize<V2DeclinedTransactionResponseWrapper>(
                                responseBody
                            )
                        );
                    case 500:
                        throw new InternalServerResponseErrorV2(
                            JsonUtils.Deserialize<V2InternalServerError>(responseBody)
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

    private async Task<WithRawResponse<V2TransactionResponseWrapper>> Refundv2AsyncCore(
        string transId,
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
                        "v2/MoneyIn/refund/{0}",
                        ValueConvert.ToPathParameterString(transId)
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
                var responseData = JsonUtils.Deserialize<V2TransactionResponseWrapper>(
                    responseBody
                )!;
                return new WithRawResponse<V2TransactionResponseWrapper>()
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
                        throw new BadRequestRefundResponseErrorV2(
                            JsonUtils.Deserialize<V2BadRequestError>(responseBody)
                        );
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new DeclinedRefundResponseErrorV2(
                            JsonUtils.Deserialize<V2DeclinedTransactionResponseWrapper>(
                                responseBody
                            )
                        );
                    case 500:
                        throw new InternalServerResponseErrorV2(
                            JsonUtils.Deserialize<V2InternalServerError>(responseBody)
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

    private async Task<WithRawResponse<V2TransactionResponseWrapper>> Refundv2AmountAsyncCore(
        string transId,
        double amount,
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
                        "v2/MoneyIn/refund/{0}/{1}",
                        ValueConvert.ToPathParameterString(transId),
                        ValueConvert.ToPathParameterString(amount)
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
                var responseData = JsonUtils.Deserialize<V2TransactionResponseWrapper>(
                    responseBody
                )!;
                return new WithRawResponse<V2TransactionResponseWrapper>()
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
                        throw new BadRequestRefundResponseErrorV2(
                            JsonUtils.Deserialize<V2BadRequestError>(responseBody)
                        );
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new DeclinedRefundResponseErrorV2(
                            JsonUtils.Deserialize<V2DeclinedTransactionResponseWrapper>(
                                responseBody
                            )
                        );
                    case 500:
                        throw new InternalServerResponseErrorV2(
                            JsonUtils.Deserialize<V2InternalServerError>(responseBody)
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

    private async Task<WithRawResponse<V2TransactionResponseWrapper>> Voidv2AsyncCore(
        string transId,
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
                        "v2/MoneyIn/void/{0}",
                        ValueConvert.ToPathParameterString(transId)
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
                var responseData = JsonUtils.Deserialize<V2TransactionResponseWrapper>(
                    responseBody
                )!;
                return new WithRawResponse<V2TransactionResponseWrapper>()
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
                        throw new BadRequestVoidResponseErrorV2(
                            JsonUtils.Deserialize<V2BadRequestError>(responseBody)
                        );
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new DeclinedVoidResponseErrorV2(
                            JsonUtils.Deserialize<V2DeclinedTransactionResponseWrapper>(
                                responseBody
                            )
                        );
                    case 500:
                        throw new InternalServerResponseErrorV2(
                            JsonUtils.Deserialize<V2InternalServerError>(responseBody)
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
    /// Authorize a card transaction. This returns an authorization code and reserves funds for the merchant. Authorized transactions aren't flagged for settlement until [captured](/developers/api-reference/moneyin/capture-an-authorized-transaction).
    /// Only card transactions can be authorized. This endpoint can't be used for ACH transactions.
    /// &lt;Tip&gt;
    ///   Consider migrating to the [v2 Authorize endpoint](/developers/api-reference/moneyinV2/authorize-a-transaction) to take advantage of unified response codes and improved response consistency.
    /// &lt;/Tip&gt;
    /// </summary>
    /// <example><code>
    /// await client.MoneyIn.AuthorizeAsync(
    ///     new RequestPaymentAuthorize
    ///     {
    ///         Body = new TransRequestBody
    ///         {
    ///             CustomerData = new PayorDataRequest { CustomerId = 4440 },
    ///             EntryPoint = "f743aed24a",
    ///             Ipaddress = "255.255.255.255",
    ///             PaymentDetails = new PaymentDetail { ServiceFee = 0, TotalAmount = 100 },
    ///             PaymentMethod = new PayMethodCredit
    ///             {
    ///                 Cardcvv = "999",
    ///                 Cardexp = "02/27",
    ///                 CardHolder = "John Cassian",
    ///                 Cardnumber = "4111111111111111",
    ///                 Cardzip = "12345",
    ///                 Initiator = "payor",
    ///                 Method = "card",
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<AuthResponse> AuthorizeAsync(
        RequestPaymentAuthorize request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<AuthResponse>(
            AuthorizeAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// &lt;Warning&gt;
    ///   This endpoint is deprecated and will be sunset on November 24, 2025. Migrate to [POST `/capture/{transId}`](/developers/api-reference/moneyin/capture-an-authorized-transaction)`.
    /// &lt;/Warning&gt;
    ///
    ///   Capture an [authorized
    /// transaction](/developers/api-reference/moneyin/authorize-a-transaction) to complete the transaction and move funds from the customer to merchant account.
    /// </summary>
    /// <example><code>
    /// await client.MoneyIn.CaptureAsync("10-7d9cd67d-2d5d-4cd7-a1b7-72b8b201ec13", 0);
    /// </code></example>
    public WithRawResponseTask<CaptureResponse> CaptureAsync(
        string transId,
        double amount,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<CaptureResponse>(
            CaptureAsyncCore(transId, amount, options, cancellationToken)
        );
    }

    /// <summary>
    /// Capture an [authorized transaction](/developers/api-reference/moneyin/authorize-a-transaction) to complete the transaction and move funds from the customer to merchant account.
    ///
    /// You can use this endpoint to capture both full and partial amounts of the original authorized transaction. See [Capture an authorized transaction](/developers/developer-guides/pay-in-auth-and-capture) for more information about this endpoint.
    ///
    /// &lt;Tip&gt;
    /// Consider migrating to the [v2 Capture endpoint](/developers/api-reference/moneyinV2/capture-an-authorized-transaction) to take advantage of unified response codes and improved response consistency.
    /// &lt;/Tip&gt;
    /// </summary>
    /// <example><code>
    /// await client.MoneyIn.CaptureAuthAsync(
    ///     "10-7d9cd67d-2d5d-4cd7-a1b7-72b8b201ec13",
    ///     new CaptureRequest
    ///     {
    ///         PaymentDetails = new CapturePaymentDetails { TotalAmount = 105, ServiceFee = 5 },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<CaptureResponse> CaptureAuthAsync(
        string transId,
        CaptureRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<CaptureResponse>(
            CaptureAuthAsyncCore(transId, request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Make a temporary microdeposit in a customer account to verify the customer's ownership and access to the target account. Reverse the microdeposit with `reverseCredit`.
    ///
    /// This feature must be enabled by Payabli on a per-merchant basis. Contact support for help.
    /// </summary>
    /// <example><code>
    /// await client.MoneyIn.CreditAsync(
    ///     new RequestCredit
    ///     {
    ///         IdempotencyKey = "6B29FC40-CA47-1067-B31D-00DD010662DA",
    ///         CustomerData = new PayorDataRequest
    ///         {
    ///             BillingAddress1 = "5127 Linkwood ave",
    ///             CustomerNumber = "100",
    ///         },
    ///         Entrypoint = "my-entrypoint",
    ///         PaymentDetails = new PaymentDetailCredit { ServiceFee = 0, TotalAmount = 1 },
    ///         PaymentMethod = new RequestCreditPaymentMethod
    ///         {
    ///             AchAccount = "88354454",
    ///             AchAccountType = Achaccounttype.Checking,
    ///             AchHolder = "John Smith",
    ///             AchRouting = "021000021",
    ///             Method = "ach",
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<PayabliApiResponse0> CreditAsync(
        RequestCredit request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<PayabliApiResponse0>(
            CreditAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Retrieve a processed transaction's details.
    /// </summary>
    /// <example><code>
    /// await client.MoneyIn.DetailsAsync("45-as456777hhhhhhhhhh77777777-324");
    /// </code></example>
    public WithRawResponseTask<TransactionQueryRecordsCustomer> DetailsAsync(
        string transId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<TransactionQueryRecordsCustomer>(
            DetailsAsyncCore(transId, options, cancellationToken)
        );
    }

    /// <summary>
    /// Make a single transaction. This method authorizes and captures a payment in one step.
    ///
    ///   &lt;Tip&gt;
    ///   Consider migrating to the [v2 Make a transaction endpoint](/developers/api-reference/moneyinV2/make-a-transaction) to take advantage of unified response codes and improved response consistency.
    ///   &lt;/Tip&gt;
    /// </summary>
    /// <example><code>
    /// await client.MoneyIn.GetpaidAsync(
    ///     new RequestPayment
    ///     {
    ///         Body = new TransRequestBody
    ///         {
    ///             CustomerData = new PayorDataRequest { CustomerId = 4440 },
    ///             EntryPoint = "f743aed24a",
    ///             Ipaddress = "255.255.255.255",
    ///             PaymentDetails = new PaymentDetail { ServiceFee = 0, TotalAmount = 100 },
    ///             PaymentMethod = new PayMethodCredit
    ///             {
    ///                 Cardcvv = "999",
    ///                 Cardexp = "02/27",
    ///                 CardHolder = "John Cassian",
    ///                 Cardnumber = "4111111111111111",
    ///                 Cardzip = "12345",
    ///                 Initiator = "payor",
    ///                 Method = "card",
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<PayabliApiResponseGetPaid> GetpaidAsync(
        RequestPayment request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<PayabliApiResponseGetPaid>(
            GetpaidAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// A reversal either refunds or voids a transaction independent of the transaction's settlement status. Send a reversal request for a transaction, and Payabli automatically determines whether it's a refund or void. You don't need to know whether the transaction is settled or not.
    /// </summary>
    /// <example><code>
    /// await client.MoneyIn.ReverseAsync(0, "10-3ffa27df-b171-44e0-b251-e95fbfc7a723");
    /// </code></example>
    public WithRawResponseTask<ReverseResponse> ReverseAsync(
        string transId,
        double amount,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ReverseResponse>(
            ReverseAsyncCore(transId, amount, options, cancellationToken)
        );
    }

    /// <summary>
    /// Refund a transaction that has settled and send money back to the account holder. If a transaction hasn't been settled, void it instead.
    ///
    ///   &lt;Tip&gt;
    ///   Consider migrating to the [v2 Refund endpoint](/developers/api-reference/moneyinV2/refund-a-settled-transaction) to take advantage of unified response codes and improved response consistency.
    ///   &lt;/Tip&gt;
    /// </summary>
    /// <example><code>
    /// await client.MoneyIn.RefundAsync(0, "10-3ffa27df-b171-44e0-b251-e95fbfc7a723");
    /// </code></example>
    public WithRawResponseTask<RefundResponse> RefundAsync(
        string transId,
        double amount,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<RefundResponse>(
            RefundAsyncCore(transId, amount, options, cancellationToken)
        );
    }

    /// <summary>
    /// Refunds a settled transaction with split instructions.
    /// </summary>
    /// <example><code>
    /// await client.MoneyIn.RefundWithInstructionsAsync(
    ///     "10-3ffa27df-b171-44e0-b251-e95fbfc7a723",
    ///     new RequestRefund
    ///     {
    ///         IdempotencyKey = "8A29FC40-CA47-1067-B31D-00DD010662DB",
    ///         Source = "api",
    ///         OrderDescription = "Materials deposit",
    ///         Amount = 100,
    ///         RefundDetails = new RefundDetail
    ///         {
    ///             SplitRefunding = new List&lt;SplitFundingRefundContent&gt;()
    ///             {
    ///                 new SplitFundingRefundContent
    ///                 {
    ///                     OriginationEntryPoint = "7f1a381696",
    ///                     AccountId = "187-342",
    ///                     Description = "Refunding undelivered materials",
    ///                     Amount = 60,
    ///                 },
    ///                 new SplitFundingRefundContent
    ///                 {
    ///                     OriginationEntryPoint = "7f1a381696",
    ///                     AccountId = "187-343",
    ///                     Description = "Refunding deposit for undelivered materials",
    ///                     Amount = 40,
    ///                 },
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<RefundWithInstructionsResponse> RefundWithInstructionsAsync(
        string transId,
        RequestRefund request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<RefundWithInstructionsResponse>(
            RefundWithInstructionsAsyncCore(transId, request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Reverse microdeposits that are used to verify customer account ownership and access. The `transId` value is returned in the success response for the original credit transaction made with `api/MoneyIn/makecredit`.
    /// </summary>
    /// <example><code>
    /// await client.MoneyIn.ReverseCreditAsync("45-as456777hhhhhhhhhh77777777-324");
    /// </code></example>
    public WithRawResponseTask<PayabliApiResponse> ReverseCreditAsync(
        string transId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<PayabliApiResponse>(
            ReverseCreditAsyncCore(transId, options, cancellationToken)
        );
    }

    /// <summary>
    /// Send a payment receipt for a transaction.
    /// </summary>
    /// <example><code>
    /// await client.MoneyIn.SendReceipt2TransAsync(
    ///     "45-as456777hhhhhhhhhh77777777-324",
    ///     new SendReceipt2TransRequest { Email = "example@email.com" }
    /// );
    /// </code></example>
    public WithRawResponseTask<ReceiptResponse> SendReceipt2TransAsync(
        string transId,
        SendReceipt2TransRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ReceiptResponse>(
            SendReceipt2TransAsyncCore(transId, request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Validates a card number without running a transaction or authorizing a charge.
    /// </summary>
    /// <example><code>
    /// await client.MoneyIn.ValidateAsync(
    ///     new RequestPaymentValidate
    ///     {
    ///         IdempotencyKey = "6B29FC40-CA47-1067-B31D-00DD010662DA",
    ///         EntryPoint = "entry132",
    ///         PaymentMethod = new RequestPaymentValidatePaymentMethod
    ///         {
    ///             Method = RequestPaymentValidatePaymentMethodMethod.Card,
    ///             Cardnumber = "4360000001000005",
    ///             Cardexp = "12/29",
    ///             Cardzip = "14602-8328",
    ///             CardHolder = "Dianne Becker-Smith",
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<ValidateResponse> ValidateAsync(
        RequestPaymentValidate request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ValidateResponse>(
            ValidateAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Cancel a transaction that hasn't been settled yet. Voiding non-captured authorizations prevents future captures. If a transaction has been settled, refund it instead.
    ///
    ///   &lt;Tip&gt;
    ///   Consider migrating to the [v2 Void endpoint](/developers/api-reference/moneyinV2/void-a-transaction) to take advantage of unified response codes and improved response consistency.
    ///   &lt;/Tip&gt;
    /// </summary>
    /// <example><code>
    /// await client.MoneyIn.VoidAsync("10-3ffa27df-b171-44e0-b251-e95fbfc7a723");
    /// </code></example>
    public WithRawResponseTask<VoidResponse> VoidAsync(
        string transId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<VoidResponse>(
            VoidAsyncCore(transId, options, cancellationToken)
        );
    }

    /// <summary>
    /// Make a single transaction. This method authorizes and captures a payment in one step. This is the v2 version of the `api/MoneyIn/getpaid` endpoint, and returns the unified response format. See [Pay In unified response codes reference](/guides/pay-in-unified-response-codes-reference) for more information.
    /// </summary>
    /// <example><code>
    /// await client.MoneyIn.Getpaidv2Async(
    ///     new RequestPaymentV2
    ///     {
    ///         Body = new TransRequestBody
    ///         {
    ///             CustomerData = new PayorDataRequest { CustomerId = 4440 },
    ///             EntryPoint = "f743aed24a",
    ///             Ipaddress = "255.255.255.255",
    ///             PaymentDetails = new PaymentDetail { ServiceFee = 0, TotalAmount = 100 },
    ///             PaymentMethod = new PayMethodCredit
    ///             {
    ///                 Cardcvv = "999",
    ///                 Cardexp = "02/27",
    ///                 CardHolder = "John Cassian",
    ///                 Cardnumber = "4111111111111111",
    ///                 Cardzip = "12345",
    ///                 Initiator = "payor",
    ///                 Method = "card",
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<V2TransactionResponseWrapper> Getpaidv2Async(
        RequestPaymentV2 request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<V2TransactionResponseWrapper>(
            Getpaidv2AsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Authorize a card transaction. This returns an authorization code and reserves funds for the merchant. Authorized transactions aren't flagged for settlement until captured. This is the v2 version of the `api/MoneyIn/authorize` endpoint, and returns the unified response format. See [Pay In unified response codes reference](/guides/pay-in-unified-response-codes-reference) for more information.
    ///
    /// **Note**: Only card transactions can be authorized. This endpoint can't be used for ACH transactions.
    /// </summary>
    /// <example><code>
    /// await client.MoneyIn.Authorizev2Async(
    ///     new RequestPaymentAuthorizeV2
    ///     {
    ///         Body = new TransRequestBody
    ///         {
    ///             CustomerData = new PayorDataRequest { CustomerId = 4440 },
    ///             EntryPoint = "f743aed24a",
    ///             Ipaddress = "255.255.255.255",
    ///             PaymentDetails = new PaymentDetail { ServiceFee = 0, TotalAmount = 100 },
    ///             PaymentMethod = new PayMethodCredit
    ///             {
    ///                 Cardcvv = "999",
    ///                 Cardexp = "02/27",
    ///                 CardHolder = "John Cassian",
    ///                 Cardnumber = "4111111111111111",
    ///                 Cardzip = "12345",
    ///                 Initiator = "payor",
    ///                 Method = "card",
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<V2TransactionResponseWrapper> Authorizev2Async(
        RequestPaymentAuthorizeV2 request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<V2TransactionResponseWrapper>(
            Authorizev2AsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Capture an authorized transaction to complete the transaction and move funds from the customer to merchant account. This is the v2 version of the `api/MoneyIn/capture/{transId}` endpoint, and returns the unified response format. See [Pay In unified response codes reference](/guides/pay-in-unified-response-codes-reference) for more information.
    /// </summary>
    /// <example><code>
    /// await client.MoneyIn.Capturev2Async(
    ///     "10-7d9cd67d-2d5d-4cd7-a1b7-72b8b201ec13",
    ///     new CaptureRequest
    ///     {
    ///         PaymentDetails = new CapturePaymentDetails { TotalAmount = 105, ServiceFee = 5 },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<V2TransactionResponseWrapper> Capturev2Async(
        string transId,
        CaptureRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<V2TransactionResponseWrapper>(
            Capturev2AsyncCore(transId, request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Give a full refund for a transaction that has settled and send money back to the account holder. To perform a partial refund, see [Partially refund a transaction](developers/api-reference/moneyinV2/partial-refund-a-settled-transaction).
    ///
    /// This is the v2 version of the refund endpoint, and returns the unified response format. See [Pay In unified response codes reference](/guides/pay-in-unified-response-codes-reference) for more information.
    /// </summary>
    /// <example><code>
    /// await client.MoneyIn.Refundv2Async("10-3ffa27df-b171-44e0-b251-e95fbfc7a723");
    /// </code></example>
    public WithRawResponseTask<V2TransactionResponseWrapper> Refundv2Async(
        string transId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<V2TransactionResponseWrapper>(
            Refundv2AsyncCore(transId, options, cancellationToken)
        );
    }

    /// <summary>
    /// Refund a transaction that has settled and send money back to the account holder. If `amount` is omitted or set to 0, performs a full refund. When a non-zero `amount` is provided, this endpoint performs a partial refund.
    ///
    /// This is the v2 version of the refund endpoint, and returns the unified response format. See [Pay In unified response codes reference](/guides/pay-in-unified-response-codes-reference) for more information.
    /// </summary>
    /// <example><code>
    /// await client.MoneyIn.Refundv2AmountAsync("10-3ffa27df-b171-44e0-b251-e95fbfc7a723", 0);
    /// </code></example>
    public WithRawResponseTask<V2TransactionResponseWrapper> Refundv2AmountAsync(
        string transId,
        double amount,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<V2TransactionResponseWrapper>(
            Refundv2AmountAsyncCore(transId, amount, options, cancellationToken)
        );
    }

    /// <summary>
    /// Cancel a transaction that hasn't been settled yet. Voiding non-captured authorizations prevents future captures. This is the v2 version of the `api/MoneyIn/void/{transId}` endpoint, and returns the unified response format. See [Pay In unified response codes reference](/guides/pay-in-unified-response-codes-reference) for more information.
    /// </summary>
    /// <example><code>
    /// await client.MoneyIn.Voidv2Async("10-3ffa27df-b171-44e0-b251-e95fbfc7a723");
    /// </code></example>
    public WithRawResponseTask<V2TransactionResponseWrapper> Voidv2Async(
        string transId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<V2TransactionResponseWrapper>(
            Voidv2AsyncCore(transId, options, cancellationToken)
        );
    }
}
