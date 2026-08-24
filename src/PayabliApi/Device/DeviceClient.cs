using global::System.Text.Json;
using PayabliApi.Core;

namespace PayabliApi;

public partial class DeviceClient : IDeviceClient
{
    private readonly RawClient _client;

    internal DeviceClient(RawClient client)
    {
        _client = client;
    }

    private async Task<WithRawResponse<DeviceChallengeResponse>> ChallengeAsyncCore(
        string entry,
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
                    Path = string.Format(
                        "Device/challenge/{0}",
                        ValueConvert.ToPathParameterString(entry)
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
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<DeviceChallengeResponse>(responseBody)!;
                return new WithRawResponse<DeviceChallengeResponse>()
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
    /// Generates a one-time, 6-digit verification code for activating a
    /// semi-integrated card-present device in a paypoint. After calling this endpoint, an operator enters the returned code
    /// on the device's terminal, along with a device name, to register the
    /// device to the paypoint resolved from `{entry}`.
    ///
    /// A code expires 5 minutes after it's issued. A paypoint can have several
    /// codes active at once — for example, when activating a batch of devices —
    /// and a code binds to whichever device enters it first.
    ///
    /// Authenticate with an OAuth2 Bearer token that has the `device_registry` scope.
    /// </summary>
    /// <example><code>
    /// await client.Device.ChallengeAsync("8cfec329267");
    /// </code></example>
    public WithRawResponseTask<DeviceChallengeResponse> ChallengeAsync(
        string entry,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<DeviceChallengeResponse>(
            ChallengeAsyncCore(entry, options, cancellationToken)
        );
    }
}
