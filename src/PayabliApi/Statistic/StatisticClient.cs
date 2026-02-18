using System.Text.Json;
using PayabliApi.Core;

namespace PayabliApi;

public partial class StatisticClient : IStatisticClient
{
    private RawClient _client;

    internal StatisticClient(RawClient client)
    {
        _client = client;
    }

    private async Task<
        WithRawResponse<IEnumerable<StatBasicExtendedQueryRecord>>
    > BasicStatsAsyncCore(
        string mode,
        string freq,
        int level,
        long entryId,
        BasicStatsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new PayabliApi.Core.QueryStringBuilder.Builder(capacity: 3)
            .Add("endDate", request.EndDate)
            .Add("parameters", request.Parameters)
            .Add("startDate", request.StartDate)
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
                        "Statistic/basic/{0}/{1}/{2}/{3}",
                        ValueConvert.ToPathParameterString(mode),
                        ValueConvert.ToPathParameterString(freq),
                        ValueConvert.ToPathParameterString(level),
                        ValueConvert.ToPathParameterString(entryId)
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
                var responseData = JsonUtils.Deserialize<IEnumerable<StatBasicExtendedQueryRecord>>(
                    responseBody
                )!;
                return new WithRawResponse<IEnumerable<StatBasicExtendedQueryRecord>>()
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
        WithRawResponse<IEnumerable<SubscriptionStatsQueryRecord>>
    > CustomerBasicStatsAsyncCore(
        string mode,
        string freq,
        int customerId,
        CustomerBasicStatsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new PayabliApi.Core.QueryStringBuilder.Builder(capacity: 1)
            .Add("parameters", request.Parameters)
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
                        "Statistic/customerbasic/{0}/{1}/{2}",
                        ValueConvert.ToPathParameterString(mode),
                        ValueConvert.ToPathParameterString(freq),
                        ValueConvert.ToPathParameterString(customerId)
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
                var responseData = JsonUtils.Deserialize<IEnumerable<SubscriptionStatsQueryRecord>>(
                    responseBody
                )!;
                return new WithRawResponse<IEnumerable<SubscriptionStatsQueryRecord>>()
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

    private async Task<WithRawResponse<IEnumerable<StatBasicQueryRecord>>> SubStatsAsyncCore(
        string interval,
        int level,
        long entryId,
        SubStatsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new PayabliApi.Core.QueryStringBuilder.Builder(capacity: 1)
            .Add("parameters", request.Parameters)
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
                        "Statistic/subscriptions/{0}/{1}/{2}",
                        ValueConvert.ToPathParameterString(interval),
                        ValueConvert.ToPathParameterString(level),
                        ValueConvert.ToPathParameterString(entryId)
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
                var responseData = JsonUtils.Deserialize<IEnumerable<StatBasicQueryRecord>>(
                    responseBody
                )!;
                return new WithRawResponse<IEnumerable<StatBasicQueryRecord>>()
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
        WithRawResponse<IEnumerable<StatisticsVendorQueryRecord>>
    > VendorBasicStatsAsyncCore(
        string mode,
        string freq,
        int idVendor,
        VendorBasicStatsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new PayabliApi.Core.QueryStringBuilder.Builder(capacity: 1)
            .Add("parameters", request.Parameters)
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
                        "Statistic/vendorbasic/{0}/{1}/{2}",
                        ValueConvert.ToPathParameterString(mode),
                        ValueConvert.ToPathParameterString(freq),
                        ValueConvert.ToPathParameterString(idVendor)
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
                var responseData = JsonUtils.Deserialize<IEnumerable<StatisticsVendorQueryRecord>>(
                    responseBody
                )!;
                return new WithRawResponse<IEnumerable<StatisticsVendorQueryRecord>>()
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
    /// Retrieves the basic statistics for an organization or a paypoint, for a given time period, grouped by a particular frequency.
    /// </summary>
    /// <example><code>
    /// await client.Statistic.BasicStatsAsync(
    ///     1000000,
    ///     "m",
    ///     1,
    ///     "ytd",
    ///     new BasicStatsRequest { EndDate = "2025-11-01", StartDate = "2025-11-30" }
    /// );
    /// </code></example>
    public WithRawResponseTask<IEnumerable<StatBasicExtendedQueryRecord>> BasicStatsAsync(
        string mode,
        string freq,
        int level,
        long entryId,
        BasicStatsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<IEnumerable<StatBasicExtendedQueryRecord>>(
            BasicStatsAsyncCore(mode, freq, level, entryId, request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Retrieves the basic statistics for a customer for a specific time period, grouped by a selected frequency.
    /// </summary>
    /// <example><code>
    /// await client.Statistic.CustomerBasicStatsAsync(998, "m", "ytd", new CustomerBasicStatsRequest());
    /// </code></example>
    public WithRawResponseTask<IEnumerable<SubscriptionStatsQueryRecord>> CustomerBasicStatsAsync(
        string mode,
        string freq,
        int customerId,
        CustomerBasicStatsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<IEnumerable<SubscriptionStatsQueryRecord>>(
            CustomerBasicStatsAsyncCore(mode, freq, customerId, request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Retrieves the subscription statistics for a given interval for a paypoint or organization.
    /// </summary>
    /// <example><code>
    /// await client.Statistic.SubStatsAsync(1000000, "30", 1, new SubStatsRequest());
    /// </code></example>
    public WithRawResponseTask<IEnumerable<StatBasicQueryRecord>> SubStatsAsync(
        string interval,
        int level,
        long entryId,
        SubStatsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<IEnumerable<StatBasicQueryRecord>>(
            SubStatsAsyncCore(interval, level, entryId, request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Retrieve the basic statistics about a vendor for a given time period, grouped by frequency.
    /// </summary>
    /// <example><code>
    /// await client.Statistic.VendorBasicStatsAsync("m", 1, "ytd", new VendorBasicStatsRequest());
    /// </code></example>
    public WithRawResponseTask<IEnumerable<StatisticsVendorQueryRecord>> VendorBasicStatsAsync(
        string mode,
        string freq,
        int idVendor,
        VendorBasicStatsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<IEnumerable<StatisticsVendorQueryRecord>>(
            VendorBasicStatsAsyncCore(mode, freq, idVendor, request, options, cancellationToken)
        );
    }
}
