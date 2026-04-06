using global::System.Text.Json;
using PayabliApi.Core;

namespace PayabliApi;

public partial class GhostCardClient : IGhostCardClient
{
    private readonly RawClient _client;

    internal GhostCardClient(RawClient client)
    {
        _client = client;
    }

    private async Task<WithRawResponse<CreateGhostCardResponse>> CreateGhostCardAsyncCore(
        string entry,
        CreateGhostCardRequestBody request,
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
                    Method = HttpMethod.Post,
                    Path = string.Format(
                        "MoneyOutCard/GhostCard/{0}",
                        ValueConvert.ToPathParameterString(entry)
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
                var responseData = JsonUtils.Deserialize<CreateGhostCardResponse>(responseBody)!;
                return new WithRawResponse<CreateGhostCardResponse>()
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

    private async Task<WithRawResponse<PayabliApiResponse>> UpdateCardAsyncCore(
        string entry,
        UpdateCardRequestBody request,
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
                    Method = HttpMethodExtensions.Patch,
                    Path = string.Format(
                        "MoneyOutCard/card/{0}",
                        ValueConvert.ToPathParameterString(entry)
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
    /// Creates a ghost card, a multi-use virtual debit card issued to a vendor for recurring or discretionary spend.
    ///
    /// Unlike single-use virtual cards issued as part of a payout transaction, ghost cards aren't tied to a specific payout. They're issued directly to a vendor and can be reused up to a configurable number of times within the card's spending limits.
    /// </summary>
    /// <example><code>
    /// await client.GhostCard.CreateGhostCardAsync(
    ///     "8cfec2e0fa",
    ///     new CreateGhostCardRequestBody
    ///     {
    ///         VendorId = 42,
    ///         ExpenseLimit = 500,
    ///         MaxNumberOfUses = 3,
    ///         ExactAmount = false,
    ///         ExpenseLimitPeriod = "monthly",
    ///         BillingCycle = "monthly",
    ///         BillingCycleDay = "1",
    ///         DailyTransactionCount = 5,
    ///         DailyAmountLimit = 200,
    ///         TransactionAmountLimit = 100,
    ///         Mcc = "5411",
    ///         Tcc = "R",
    ///         Misc1 = "PO-98765",
    ///         Misc2 = "Dept-Finance",
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<CreateGhostCardResponse> CreateGhostCardAsync(
        string entry,
        CreateGhostCardRequestBody request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<CreateGhostCardResponse>(
            CreateGhostCardAsyncCore(entry, request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Updates the status of a virtual card (including ghost cards) under a paypoint.
    /// </summary>
    /// <example><code>
    /// await client.GhostCard.UpdateCardAsync(
    ///     "8cfec2e0fa",
    ///     new UpdateCardRequestBody { CardToken = "gc_abc123def456", Status = CardStatus.Cancelled }
    /// );
    /// </code></example>
    public WithRawResponseTask<PayabliApiResponse> UpdateCardAsync(
        string entry,
        UpdateCardRequestBody request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<PayabliApiResponse>(
            UpdateCardAsyncCore(entry, request, options, cancellationToken)
        );
    }
}
