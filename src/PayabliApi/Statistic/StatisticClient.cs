using System.Text.Json;
using PayabliApi.Core;

namespace PayabliApi;

public partial class StatisticClient
{
    private RawClient _client;

    internal StatisticClient(RawClient client)
    {
        _client = client;
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
    public async Task<IEnumerable<StatBasicExtendedQueryRecord>> BasicStatsAsync(
        string mode,
        string freq,
        int level,
        long entryId,
        BasicStatsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.EndDate != null)
        {
            _query["endDate"] = request.EndDate;
        }
        if (request.Parameters != null)
        {
            _query["parameters"] = JsonUtils.Serialize(request.Parameters);
        }
        if (request.StartDate != null)
        {
            _query["startDate"] = request.StartDate;
        }
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
                    Query = _query,
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
                return JsonUtils.Deserialize<IEnumerable<StatBasicExtendedQueryRecord>>(
                    responseBody
                )!;
            }
            catch (JsonException e)
            {
                throw new PayabliApiException("Failed to deserialize response", e);
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

    /// <summary>
    /// Retrieves the basic statistics for a customer for a specific time period, grouped by a selected frequency.
    /// </summary>
    /// <example><code>
    /// await client.Statistic.CustomerBasicStatsAsync(998, "m", "ytd", new CustomerBasicStatsRequest());
    /// </code></example>
    public async Task<IEnumerable<SubscriptionStatsQueryRecord>> CustomerBasicStatsAsync(
        string mode,
        string freq,
        int customerId,
        CustomerBasicStatsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.Parameters != null)
        {
            _query["parameters"] = JsonUtils.Serialize(request.Parameters);
        }
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
                    Query = _query,
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
                return JsonUtils.Deserialize<IEnumerable<SubscriptionStatsQueryRecord>>(
                    responseBody
                )!;
            }
            catch (JsonException e)
            {
                throw new PayabliApiException("Failed to deserialize response", e);
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

    /// <summary>
    /// Retrieves the subscription statistics for a given interval for a paypoint or organization.
    /// </summary>
    /// <example><code>
    /// await client.Statistic.SubStatsAsync(1000000, "30", 1, new SubStatsRequest());
    /// </code></example>
    public async Task<IEnumerable<StatBasicQueryRecord>> SubStatsAsync(
        string interval,
        int level,
        long entryId,
        SubStatsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.Parameters != null)
        {
            _query["parameters"] = JsonUtils.Serialize(request.Parameters);
        }
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
                    Query = _query,
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
                return JsonUtils.Deserialize<IEnumerable<StatBasicQueryRecord>>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new PayabliApiException("Failed to deserialize response", e);
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

    /// <summary>
    /// Retrieve the basic statistics about a vendor for a given time period, grouped by frequency.
    /// </summary>
    /// <example><code>
    /// await client.Statistic.VendorBasicStatsAsync("m", 1, "ytd", new VendorBasicStatsRequest());
    /// </code></example>
    public async Task<IEnumerable<StatisticsVendorQueryRecord>> VendorBasicStatsAsync(
        string mode,
        string freq,
        int idVendor,
        VendorBasicStatsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.Parameters != null)
        {
            _query["parameters"] = JsonUtils.Serialize(request.Parameters);
        }
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
                    Query = _query,
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
                return JsonUtils.Deserialize<IEnumerable<StatisticsVendorQueryRecord>>(
                    responseBody
                )!;
            }
            catch (JsonException e)
            {
                throw new PayabliApiException("Failed to deserialize response", e);
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
}
