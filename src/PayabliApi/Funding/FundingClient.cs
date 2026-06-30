using global::System.Text.Json;
using PayabliApi.Core;

namespace PayabliApi;

public partial class FundingClient : IFundingClient
{
    private readonly RawClient _client;

    internal FundingClient(RawClient client)
    {
        _client = client;
    }

    private async Task<WithRawResponse<DepositFundsResponse>> DepositFundsAsyncCore(
        DepositFundsRequest request,
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
                    Path = "Funding/depositFunds",
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
                var responseData = JsonUtils.Deserialize<DepositFundsResponse>(responseBody)!;
                return new WithRawResponse<DepositFundsResponse>()
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
                        throw new UnauthorizedError(
                            JsonUtils.Deserialize<PayabliErrorBody>(responseBody)
                        );
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<PayabliErrorBody>(responseBody)
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
    /// Deposits funds into a paypoint's available payout balance. Deposited funds enter a pending state and aren't available for instant payouts until confirmed through FBO reconciliation.
    /// </summary>
    /// <example><code>
    /// await client.Funding.DepositFundsAsync(
    ///     new DepositFundsRequest
    ///     {
    ///         Amount = 10,
    ///         Entrypoint = "48acde49",
    ///         AccountId = "333",
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<DepositFundsResponse> DepositFundsAsync(
        DepositFundsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<DepositFundsResponse>(
            DepositFundsAsyncCore(request, options, cancellationToken)
        );
    }
}
