using global::System.Text.Json;
using PayabliApi.Core;

namespace PayabliApi;

public partial class PayoutSubscriptionClient : IPayoutSubscriptionClient
{
    private readonly RawClient _client;

    internal PayoutSubscriptionClient(RawClient client)
    {
        _client = client;
    }

    private async Task<
        WithRawResponse<AddPayoutSubscriptionResponse>
    > CreatePayoutSubscriptionAsyncCore(
        RequestPayoutSchedule request,
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
                    Method = HttpMethod.Post,
                    Path = "PayoutSubscription",
                    Body = request.Body,
                    Headers = _headers,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<AddPayoutSubscriptionResponse>(
                    responseBody
                )!;
                return new WithRawResponse<AddPayoutSubscriptionResponse>()
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
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
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
        WithRawResponse<GetPayoutSubscriptionResponse>
    > GetPayoutSubscriptionAsyncCore(
        long id,
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
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "PayoutSubscription/{0}",
                        ValueConvert.ToPathParameterString(id)
                    ),
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<GetPayoutSubscriptionResponse>(
                    responseBody
                )!;
                return new WithRawResponse<GetPayoutSubscriptionResponse>()
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
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
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
        WithRawResponse<UpdatePayoutSubscriptionResponse>
    > UpdatePayoutSubscriptionAsyncCore(
        long id,
        UpdatePayoutSubscriptionBody request,
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
                    Method = HttpMethod.Put,
                    Path = string.Format(
                        "PayoutSubscription/{0}",
                        ValueConvert.ToPathParameterString(id)
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
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<UpdatePayoutSubscriptionResponse>(
                    responseBody
                )!;
                return new WithRawResponse<UpdatePayoutSubscriptionResponse>()
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
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
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
        WithRawResponse<DeletePayoutSubscriptionResponse>
    > DeletePayoutSubscriptionAsyncCore(
        long id,
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
                    Method = HttpMethod.Delete,
                    Path = string.Format(
                        "PayoutSubscription/{0}",
                        ValueConvert.ToPathParameterString(id)
                    ),
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<DeletePayoutSubscriptionResponse>(
                    responseBody
                )!;
                return new WithRawResponse<DeletePayoutSubscriptionResponse>()
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
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
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
    /// Creates a payout subscription to automatically send payouts to a vendor on a recurring schedule. See [Manage payout subscriptions](/guides/pay-out-developer-payout-subscriptions-manage) for a step-by-step guide.
    /// </summary>
    /// <example><code>
    /// await client.PayoutSubscription.CreatePayoutSubscriptionAsync(
    ///     new RequestPayoutSchedule
    ///     {
    ///         Body = new PayoutSubscriptionRequestBody
    ///         {
    ///             EntryPoint = "d193cf9a46",
    ///             PaymentMethod = new AuthorizePaymentMethod
    ///             {
    ///                 Method = "ach",
    ///                 AchHolder = "Herman Coatings",
    ///                 AchRouting = "021000021",
    ///                 AchAccount = "3453445666",
    ///                 AchAccountType = "checking",
    ///             },
    ///             PaymentDetails = new PayoutPaymentDetail
    ///             {
    ///                 TotalAmount = 500,
    ///                 ServiceFee = 0,
    ///                 Currency = "USD",
    ///             },
    ///             VendorData = new RequestOutAuthorizeVendorData { VendorId = 1501 },
    ///             BillData = new List&lt;BillPayOutDataRequest&gt;()
    ///             {
    ///                 new BillPayOutDataRequest
    ///                 {
    ///                     InvoiceNumber = "INV-5001",
    ///                     NetAmount = "500",
    ///                     InvoiceDate = new DateOnly(2025, 8, 1),
    ///                     DueDate = new DateOnly(2025, 8, 15),
    ///                 },
    ///             },
    ///             ScheduleDetails = new PayoutScheduleDetail
    ///             {
    ///                 StartDate = "09/01/2025",
    ///                 EndDate = "09/01/2026",
    ///                 Frequency = Frequency.Monthly,
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<AddPayoutSubscriptionResponse> CreatePayoutSubscriptionAsync(
        RequestPayoutSchedule request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<AddPayoutSubscriptionResponse>(
            CreatePayoutSubscriptionAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Retrieves a single payout subscription's details. See [Manage payout subscriptions](/guides/pay-out-developer-payout-subscriptions-manage) for more information.
    /// </summary>
    /// <example><code>
    /// await client.PayoutSubscription.GetPayoutSubscriptionAsync(42);
    /// </code></example>
    public WithRawResponseTask<GetPayoutSubscriptionResponse> GetPayoutSubscriptionAsync(
        long id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GetPayoutSubscriptionResponse>(
            GetPayoutSubscriptionAsyncCore(id, options, cancellationToken)
        );
    }

    /// <summary>
    /// Updates a payout subscription's details. See [Manage payout subscriptions](/guides/pay-out-developer-payout-subscriptions-manage) for more information.
    /// </summary>
    /// <example><code>
    /// await client.PayoutSubscription.UpdatePayoutSubscriptionAsync(
    ///     42,
    ///     new UpdatePayoutSubscriptionBody { SetPause = true }
    /// );
    /// </code></example>
    public WithRawResponseTask<UpdatePayoutSubscriptionResponse> UpdatePayoutSubscriptionAsync(
        long id,
        UpdatePayoutSubscriptionBody request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<UpdatePayoutSubscriptionResponse>(
            UpdatePayoutSubscriptionAsyncCore(id, request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Deletes a payout subscription and prevents future payouts. See [Manage payout subscriptions](/guides/pay-out-developer-payout-subscriptions-manage) for more information.
    /// </summary>
    /// <example><code>
    /// await client.PayoutSubscription.DeletePayoutSubscriptionAsync(42);
    /// </code></example>
    public WithRawResponseTask<DeletePayoutSubscriptionResponse> DeletePayoutSubscriptionAsync(
        long id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<DeletePayoutSubscriptionResponse>(
            DeletePayoutSubscriptionAsyncCore(id, options, cancellationToken)
        );
    }
}
