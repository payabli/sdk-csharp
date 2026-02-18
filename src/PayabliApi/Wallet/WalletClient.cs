using System.Text.Json;
using PayabliApi.Core;

namespace PayabliApi;

public partial class WalletClient : IWalletClient
{
    private RawClient _client;

    internal WalletClient(RawClient client)
    {
        _client = client;
    }

    private async Task<
        WithRawResponse<ConfigureApplePayOrganizationApiResponse>
    > ConfigureApplePayOrganizationAsyncCore(
        ConfigureOrganizationRequestApplePay request,
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
                    Path = "Wallet/applepay/configure-organization",
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
                var responseData = JsonUtils.Deserialize<ConfigureApplePayOrganizationApiResponse>(
                    responseBody
                )!;
                return new WithRawResponse<ConfigureApplePayOrganizationApiResponse>()
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
        WithRawResponse<ConfigureApplePaypointApiResponse>
    > ConfigureApplePayPaypointAsyncCore(
        ConfigurePaypointRequestApplePay request,
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
                    Path = "Wallet/applepay/configure-paypoint",
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
                var responseData = JsonUtils.Deserialize<ConfigureApplePaypointApiResponse>(
                    responseBody
                )!;
                return new WithRawResponse<ConfigureApplePaypointApiResponse>()
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
        WithRawResponse<ConfigureApplePayOrganizationApiResponse>
    > ConfigureGooglePayOrganizationAsyncCore(
        ConfigureOrganizationRequestGooglePay request,
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
                    Path = "Wallet/googlepay/configure-organization",
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
                var responseData = JsonUtils.Deserialize<ConfigureApplePayOrganizationApiResponse>(
                    responseBody
                )!;
                return new WithRawResponse<ConfigureApplePayOrganizationApiResponse>()
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
        WithRawResponse<ConfigureGooglePaypointApiResponse>
    > ConfigureGooglePayPaypointAsyncCore(
        ConfigurePaypointRequestGooglePay request,
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
                    Path = "Wallet/googlepay/configure-paypoint",
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
                var responseData = JsonUtils.Deserialize<ConfigureGooglePaypointApiResponse>(
                    responseBody
                )!;
                return new WithRawResponse<ConfigureGooglePaypointApiResponse>()
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
    /// Configure and activate Apple Pay for a Payabli organization
    /// </summary>
    /// <example><code>
    /// await client.Wallet.ConfigureApplePayOrganizationAsync(
    ///     new ConfigureOrganizationRequestApplePay
    ///     {
    ///         Cascade = true,
    ///         IsEnabled = true,
    ///         OrgId = 901,
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<ConfigureApplePayOrganizationApiResponse> ConfigureApplePayOrganizationAsync(
        ConfigureOrganizationRequestApplePay request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ConfigureApplePayOrganizationApiResponse>(
            ConfigureApplePayOrganizationAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Configure and activate Apple Pay for a Payabli paypoint
    /// </summary>
    /// <example><code>
    /// await client.Wallet.ConfigureApplePayPaypointAsync(
    ///     new ConfigurePaypointRequestApplePay { Entry = "8cfec329267", IsEnabled = true }
    /// );
    /// </code></example>
    public WithRawResponseTask<ConfigureApplePaypointApiResponse> ConfigureApplePayPaypointAsync(
        ConfigurePaypointRequestApplePay request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ConfigureApplePaypointApiResponse>(
            ConfigureApplePayPaypointAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Configure and activate Google Pay for a Payabli organization
    /// </summary>
    /// <example><code>
    /// await client.Wallet.ConfigureGooglePayOrganizationAsync(
    ///     new ConfigureOrganizationRequestGooglePay
    ///     {
    ///         Cascade = true,
    ///         IsEnabled = true,
    ///         OrgId = 901,
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<ConfigureApplePayOrganizationApiResponse> ConfigureGooglePayOrganizationAsync(
        ConfigureOrganizationRequestGooglePay request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ConfigureApplePayOrganizationApiResponse>(
            ConfigureGooglePayOrganizationAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Configure and activate Google Pay for a Payabli paypoint
    /// </summary>
    /// <example><code>
    /// await client.Wallet.ConfigureGooglePayPaypointAsync(
    ///     new ConfigurePaypointRequestGooglePay { Entry = "8cfec329267", IsEnabled = true }
    /// );
    /// </code></example>
    public WithRawResponseTask<ConfigureGooglePaypointApiResponse> ConfigureGooglePayPaypointAsync(
        ConfigurePaypointRequestGooglePay request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ConfigureGooglePaypointApiResponse>(
            ConfigureGooglePayPaypointAsyncCore(request, options, cancellationToken)
        );
    }
}
