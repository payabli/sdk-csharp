using global::System.Text.Json;
using PayabliApi.Core;

namespace PayabliApi;

public partial class TaptopayClient : ITaptopayClient
{
    private readonly RawClient _client;

    internal TaptopayClient(RawClient client)
    {
        _client = client;
    }

    private async Task<
        WithRawResponse<TapToPayActivationChallengeResponse>
    > ActivationChallengeAsyncCore(
        TapToPayActivationChallengeRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new PayabliApi.Core.QueryStringBuilder.Builder(capacity: 0)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new PayabliApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.GetAuthHeadersForEndpoint(new[] { new[] { "BearerAuth" } }))
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Post,
                    Path = "v2/device/taptopay/activate/challenge",
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
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<TapToPayActivationChallengeResponse>(
                    responseBody
                )!;
                return new WithRawResponse<TapToPayActivationChallengeResponse>()
                {
                    Data = responseData,
                    RawResponse = new PayabliApi.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new PayabliApiClientApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e,
                    rawResponse: new PayabliApi.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    }
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
                        throw new BadRequestError(
                            JsonUtils.Deserialize<object>(responseBody),
                            rawResponse: new PayabliApi.RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            }
                        );
                    case 401:
                        throw new UnauthorizedError(
                            JsonUtils.Deserialize<PayabliErrorBody>(responseBody),
                            rawResponse: new PayabliApi.RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            }
                        );
                    case 403:
                        throw new ForbiddenError(
                            JsonUtils.Deserialize<object>(responseBody),
                            rawResponse: new PayabliApi.RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            }
                        );
                    case 404:
                        throw new NotFoundError(
                            JsonUtils.Deserialize<object>(responseBody),
                            rawResponse: new PayabliApi.RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            }
                        );
                    case 500:
                        throw new InternalServerError(
                            JsonUtils.Deserialize<object>(responseBody),
                            rawResponse: new PayabliApi.RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            }
                        );
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new PayabliApiClientApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody,
                rawResponse: new PayabliApi.RawResponse()
                {
                    StatusCode = response.Raw.StatusCode,
                    Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                    Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                }
            );
        }
    }

    /// <summary>
    /// Issues a short-lived activation code for a Tap to Pay device in the
    /// `Pending` state. This endpoint is for Tap to Pay devices only.
    /// Deliver the code to the device to complete activation.
    ///
    /// A code is valid for 30 minutes after it's issued. Calling this
    /// endpoint again for the same device before the code expires returns
    /// the same code, with `alreadyIssued` set to `true`, instead of
    /// generating a new one. A new code is only generated when no valid
    /// code exists.
    ///
    /// Authenticate with an OAuth2 bearer token that has the `pos_create`
    /// permission. See [Accept Tap to Pay payments](/guides/pay-in-developer-tap-to-pay)
    /// for the full integration guide.
    /// </summary>
    /// <example><code>
    /// await client.Taptopay.ActivationChallengeAsync(
    ///     new TapToPayActivationChallengeRequest
    ///     {
    ///         Entry = "8cfec329267",
    ///         DeviceId = "499585-389fj484-3jcj8hj3",
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<TapToPayActivationChallengeResponse> ActivationChallengeAsync(
        TapToPayActivationChallengeRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<TapToPayActivationChallengeResponse>(
            ActivationChallengeAsyncCore(request, options, cancellationToken)
        );
    }
}
