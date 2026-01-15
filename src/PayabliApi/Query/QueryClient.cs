using System.Text.Json;
using PayabliApi.Core;

namespace PayabliApi;

public partial class QueryClient
{
    private RawClient _client;

    internal QueryClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Retrieve a list of batches and their details, including settled and
    /// unsettled transactions for a paypoint. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
    /// </summary>
    /// <example><code>
    /// await client.Query.ListBatchDetailsAsync(
    ///     "8cfec329267",
    ///     new ListBatchDetailsRequest
    ///     {
    ///         FromRecord = 251,
    ///         LimitRecord = 0,
    ///         SortBy = "desc(field_name)",
    ///     }
    /// );
    /// </code></example>
    public async Task<QueryBatchesDetailResponse> ListBatchDetailsAsync(
        string entry,
        ListBatchDetailsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.ExportFormat != null)
        {
            _query["exportFormat"] = request.ExportFormat.Value.Stringify();
        }
        if (request.FromRecord != null)
        {
            _query["fromRecord"] = request.FromRecord.Value.ToString();
        }
        if (request.LimitRecord != null)
        {
            _query["limitRecord"] = request.LimitRecord.Value.ToString();
        }
        if (request.Parameters != null)
        {
            _query["parameters"] = JsonUtils.Serialize(request.Parameters);
        }
        if (request.SortBy != null)
        {
            _query["sortBy"] = request.SortBy;
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "Query/batchDetails/{0}",
                        ValueConvert.ToPathParameterString(entry)
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
                return JsonUtils.Deserialize<QueryBatchesDetailResponse>(responseBody)!;
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
    /// Retrieve a list of batches and their details, including settled and unsettled transactions for an organization. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
    /// </summary>
    /// <example><code>
    /// await client.Query.ListBatchDetailsOrgAsync(
    ///     123,
    ///     new ListBatchDetailsOrgRequest
    ///     {
    ///         FromRecord = 251,
    ///         LimitRecord = 0,
    ///         SortBy = "desc(field_name)",
    ///     }
    /// );
    /// </code></example>
    public async Task<QueryResponseSettlements> ListBatchDetailsOrgAsync(
        int orgId,
        ListBatchDetailsOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.ExportFormat != null)
        {
            _query["exportFormat"] = request.ExportFormat.Value.Stringify();
        }
        if (request.FromRecord != null)
        {
            _query["fromRecord"] = request.FromRecord.Value.ToString();
        }
        if (request.LimitRecord != null)
        {
            _query["limitRecord"] = request.LimitRecord.Value.ToString();
        }
        if (request.Parameters != null)
        {
            _query["parameters"] = JsonUtils.Serialize(request.Parameters);
        }
        if (request.SortBy != null)
        {
            _query["sortBy"] = request.SortBy;
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "Query/batchDetails/org/{0}",
                        ValueConvert.ToPathParameterString(orgId)
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
                return JsonUtils.Deserialize<QueryResponseSettlements>(responseBody)!;
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
    /// Retrieve a list of batches for a paypoint. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
    /// </summary>
    /// <example><code>
    /// await client.Query.ListBatchesAsync(
    ///     "8cfec329267",
    ///     new ListBatchesRequest
    ///     {
    ///         FromRecord = 251,
    ///         LimitRecord = 0,
    ///         SortBy = "desc(field_name)",
    ///     }
    /// );
    /// </code></example>
    public async Task<QueryBatchesResponse> ListBatchesAsync(
        string entry,
        ListBatchesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.ExportFormat != null)
        {
            _query["exportFormat"] = request.ExportFormat.Value.Stringify();
        }
        if (request.FromRecord != null)
        {
            _query["fromRecord"] = request.FromRecord.Value.ToString();
        }
        if (request.LimitRecord != null)
        {
            _query["limitRecord"] = request.LimitRecord.Value.ToString();
        }
        if (request.Parameters != null)
        {
            _query["parameters"] = JsonUtils.Serialize(request.Parameters);
        }
        if (request.SortBy != null)
        {
            _query["sortBy"] = request.SortBy;
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "Query/batches/{0}",
                        ValueConvert.ToPathParameterString(entry)
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
                return JsonUtils.Deserialize<QueryBatchesResponse>(responseBody)!;
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
    /// Retrieve a list of batches for an org. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
    /// </summary>
    /// <example><code>
    /// await client.Query.ListBatchesOrgAsync(
    ///     123,
    ///     new ListBatchesOrgRequest
    ///     {
    ///         FromRecord = 251,
    ///         LimitRecord = 0,
    ///         SortBy = "desc(field_name)",
    ///     }
    /// );
    /// </code></example>
    public async Task<QueryBatchesResponse> ListBatchesOrgAsync(
        int orgId,
        ListBatchesOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.ExportFormat != null)
        {
            _query["exportFormat"] = request.ExportFormat.Value.Stringify();
        }
        if (request.FromRecord != null)
        {
            _query["fromRecord"] = request.FromRecord.Value.ToString();
        }
        if (request.LimitRecord != null)
        {
            _query["limitRecord"] = request.LimitRecord.Value.ToString();
        }
        if (request.Parameters != null)
        {
            _query["parameters"] = JsonUtils.Serialize(request.Parameters);
        }
        if (request.SortBy != null)
        {
            _query["sortBy"] = request.SortBy;
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "Query/batches/org/{0}",
                        ValueConvert.ToPathParameterString(orgId)
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
                return JsonUtils.Deserialize<QueryBatchesResponse>(responseBody)!;
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
    /// Retrieve a list of MoneyOut batches for a paypoint. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
    /// </summary>
    /// <example><code>
    /// await client.Query.ListBatchesOutAsync(
    ///     "8cfec329267",
    ///     new ListBatchesOutRequest
    ///     {
    ///         FromRecord = 251,
    ///         LimitRecord = 0,
    ///         SortBy = "desc(field_name)",
    ///     }
    /// );
    /// </code></example>
    public async Task<QueryBatchesOutResponse> ListBatchesOutAsync(
        string entry,
        ListBatchesOutRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.ExportFormat != null)
        {
            _query["exportFormat"] = request.ExportFormat.Value.Stringify();
        }
        if (request.FromRecord != null)
        {
            _query["fromRecord"] = request.FromRecord.Value.ToString();
        }
        if (request.LimitRecord != null)
        {
            _query["limitRecord"] = request.LimitRecord.Value.ToString();
        }
        if (request.Parameters != null)
        {
            _query["parameters"] = JsonUtils.Serialize(request.Parameters);
        }
        if (request.SortBy != null)
        {
            _query["sortBy"] = request.SortBy;
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "Query/batchesOut/{0}",
                        ValueConvert.ToPathParameterString(entry)
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
                return JsonUtils.Deserialize<QueryBatchesOutResponse>(responseBody)!;
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
    /// Retrieve a list of MoneyOut batches for an org. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
    /// </summary>
    /// <example><code>
    /// await client.Query.ListBatchesOutOrgAsync(
    ///     123,
    ///     new ListBatchesOutOrgRequest
    ///     {
    ///         FromRecord = 251,
    ///         LimitRecord = 0,
    ///         SortBy = "desc(field_name)",
    ///     }
    /// );
    /// </code></example>
    public async Task<QueryBatchesOutResponse> ListBatchesOutOrgAsync(
        int orgId,
        ListBatchesOutOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.ExportFormat != null)
        {
            _query["exportFormat"] = request.ExportFormat.Value.Stringify();
        }
        if (request.FromRecord != null)
        {
            _query["fromRecord"] = request.FromRecord.Value.ToString();
        }
        if (request.LimitRecord != null)
        {
            _query["limitRecord"] = request.LimitRecord.Value.ToString();
        }
        if (request.Parameters != null)
        {
            _query["parameters"] = JsonUtils.Serialize(request.Parameters);
        }
        if (request.SortBy != null)
        {
            _query["sortBy"] = request.SortBy;
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "Query/batchesOut/org/{0}",
                        ValueConvert.ToPathParameterString(orgId)
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
                return JsonUtils.Deserialize<QueryBatchesOutResponse>(responseBody)!;
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
    /// Retrieves a list of chargebacks and returned transactions for a paypoint. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
    /// </summary>
    /// <example><code>
    /// await client.Query.ListChargebacksAsync(
    ///     "8cfec329267",
    ///     new ListChargebacksRequest
    ///     {
    ///         FromRecord = 251,
    ///         LimitRecord = 0,
    ///         SortBy = "desc(field_name)",
    ///     }
    /// );
    /// </code></example>
    public async Task<QueryChargebacksResponse> ListChargebacksAsync(
        string entry,
        ListChargebacksRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.ExportFormat != null)
        {
            _query["exportFormat"] = request.ExportFormat.Value.Stringify();
        }
        if (request.FromRecord != null)
        {
            _query["fromRecord"] = request.FromRecord.Value.ToString();
        }
        if (request.LimitRecord != null)
        {
            _query["limitRecord"] = request.LimitRecord.Value.ToString();
        }
        if (request.Parameters != null)
        {
            _query["parameters"] = JsonUtils.Serialize(request.Parameters);
        }
        if (request.SortBy != null)
        {
            _query["sortBy"] = request.SortBy;
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "Query/chargebacks/{0}",
                        ValueConvert.ToPathParameterString(entry)
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
                return JsonUtils.Deserialize<QueryChargebacksResponse>(responseBody)!;
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
    /// Retrieve a list of chargebacks and returned transactions for an org. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
    /// </summary>
    /// <example><code>
    /// await client.Query.ListChargebacksOrgAsync(
    ///     123,
    ///     new ListChargebacksOrgRequest
    ///     {
    ///         FromRecord = 251,
    ///         LimitRecord = 0,
    ///         SortBy = "desc(field_name)",
    ///     }
    /// );
    /// </code></example>
    public async Task<QueryChargebacksResponse> ListChargebacksOrgAsync(
        int orgId,
        ListChargebacksOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.ExportFormat != null)
        {
            _query["exportFormat"] = request.ExportFormat.Value.Stringify();
        }
        if (request.FromRecord != null)
        {
            _query["fromRecord"] = request.FromRecord.Value.ToString();
        }
        if (request.LimitRecord != null)
        {
            _query["limitRecord"] = request.LimitRecord.Value.ToString();
        }
        if (request.Parameters != null)
        {
            _query["parameters"] = JsonUtils.Serialize(request.Parameters);
        }
        if (request.SortBy != null)
        {
            _query["sortBy"] = request.SortBy;
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "Query/chargebacks/org/{0}",
                        ValueConvert.ToPathParameterString(orgId)
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
                return JsonUtils.Deserialize<QueryChargebacksResponse>(responseBody)!;
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
    /// Retrieves a list of customers for a paypoint. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
    /// </summary>
    /// <example><code>
    /// await client.Query.ListCustomersAsync(
    ///     "8cfec329267",
    ///     new ListCustomersRequest
    ///     {
    ///         FromRecord = 251,
    ///         LimitRecord = 0,
    ///         SortBy = "desc(field_name)",
    ///     }
    /// );
    /// </code></example>
    public async Task<QueryCustomerResponse> ListCustomersAsync(
        string entry,
        ListCustomersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.ExportFormat != null)
        {
            _query["exportFormat"] = request.ExportFormat.Value.Stringify();
        }
        if (request.FromRecord != null)
        {
            _query["fromRecord"] = request.FromRecord.Value.ToString();
        }
        if (request.LimitRecord != null)
        {
            _query["limitRecord"] = request.LimitRecord.Value.ToString();
        }
        if (request.Parameters != null)
        {
            _query["parameters"] = JsonUtils.Serialize(request.Parameters);
        }
        if (request.SortBy != null)
        {
            _query["sortBy"] = request.SortBy;
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "Query/customers/{0}",
                        ValueConvert.ToPathParameterString(entry)
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
                return JsonUtils.Deserialize<QueryCustomerResponse>(responseBody)!;
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
    /// Retrieves a list of customers for an org. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
    /// </summary>
    /// <example><code>
    /// await client.Query.ListCustomersOrgAsync(
    ///     123,
    ///     new ListCustomersOrgRequest
    ///     {
    ///         FromRecord = 251,
    ///         LimitRecord = 0,
    ///         SortBy = "desc(field_name)",
    ///     }
    /// );
    /// </code></example>
    public async Task<QueryCustomerResponse> ListCustomersOrgAsync(
        int orgId,
        ListCustomersOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.ExportFormat != null)
        {
            _query["exportFormat"] = request.ExportFormat.Value.Stringify();
        }
        if (request.FromRecord != null)
        {
            _query["fromRecord"] = request.FromRecord.Value.ToString();
        }
        if (request.LimitRecord != null)
        {
            _query["limitRecord"] = request.LimitRecord.Value.ToString();
        }
        if (request.Parameters != null)
        {
            _query["parameters"] = JsonUtils.Serialize(request.Parameters);
        }
        if (request.SortBy != null)
        {
            _query["sortBy"] = request.SortBy;
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "Query/customers/org/{0}",
                        ValueConvert.ToPathParameterString(orgId)
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
                return JsonUtils.Deserialize<QueryCustomerResponse>(responseBody)!;
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
    /// Returns a list of all reports generated in the last 60 days for a single entrypoint. Use filters to limit results.
    /// </summary>
    /// <example><code>
    /// await client.Query.ListNotificationReportsAsync(
    ///     "8cfec329267",
    ///     new ListNotificationReportsRequest
    ///     {
    ///         FromRecord = 251,
    ///         LimitRecord = 0,
    ///         SortBy = "desc(field_name)",
    ///     }
    /// );
    /// </code></example>
    public async Task<QueryResponseNotificationReports> ListNotificationReportsAsync(
        string entry,
        ListNotificationReportsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.FromRecord != null)
        {
            _query["fromRecord"] = request.FromRecord.Value.ToString();
        }
        if (request.LimitRecord != null)
        {
            _query["limitRecord"] = request.LimitRecord.Value.ToString();
        }
        if (request.Parameters != null)
        {
            _query["parameters"] = JsonUtils.Serialize(request.Parameters);
        }
        if (request.SortBy != null)
        {
            _query["sortBy"] = request.SortBy;
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "Query/notificationReports/{0}",
                        ValueConvert.ToPathParameterString(entry)
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
                return JsonUtils.Deserialize<QueryResponseNotificationReports>(responseBody)!;
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
    /// Returns a list of all reports generated in the last 60 days for an organization. Use filters to limit results.
    /// </summary>
    /// <example><code>
    /// await client.Query.ListNotificationReportsOrgAsync(
    ///     123,
    ///     new ListNotificationReportsOrgRequest
    ///     {
    ///         FromRecord = 251,
    ///         LimitRecord = 0,
    ///         SortBy = "desc(field_name)",
    ///     }
    /// );
    /// </code></example>
    public async Task<QueryResponseNotificationReports> ListNotificationReportsOrgAsync(
        int orgId,
        ListNotificationReportsOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.FromRecord != null)
        {
            _query["fromRecord"] = request.FromRecord.Value.ToString();
        }
        if (request.LimitRecord != null)
        {
            _query["limitRecord"] = request.LimitRecord.Value.ToString();
        }
        if (request.Parameters != null)
        {
            _query["parameters"] = JsonUtils.Serialize(request.Parameters);
        }
        if (request.SortBy != null)
        {
            _query["sortBy"] = request.SortBy;
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "Query/notificationReports/org/{0}",
                        ValueConvert.ToPathParameterString(orgId)
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
                return JsonUtils.Deserialize<QueryResponseNotificationReports>(responseBody)!;
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
    /// Returns a list of notifications for an entrypoint. Use filters to limit results.
    /// </summary>
    /// <example><code>
    /// await client.Query.ListNotificationsAsync(
    ///     "8cfec329267",
    ///     new ListNotificationsRequest
    ///     {
    ///         FromRecord = 251,
    ///         LimitRecord = 0,
    ///         SortBy = "desc(field_name)",
    ///     }
    /// );
    /// </code></example>
    public async Task<QueryResponseNotifications> ListNotificationsAsync(
        string entry,
        ListNotificationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.FromRecord != null)
        {
            _query["fromRecord"] = request.FromRecord.Value.ToString();
        }
        if (request.LimitRecord != null)
        {
            _query["limitRecord"] = request.LimitRecord.Value.ToString();
        }
        if (request.Parameters != null)
        {
            _query["parameters"] = JsonUtils.Serialize(request.Parameters);
        }
        if (request.SortBy != null)
        {
            _query["sortBy"] = request.SortBy;
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "Query/notifications/{0}",
                        ValueConvert.ToPathParameterString(entry)
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
                return JsonUtils.Deserialize<QueryResponseNotifications>(responseBody)!;
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
    /// Return a list of notifications for an organization. Use filters to limit results.
    /// </summary>
    /// <example><code>
    /// await client.Query.ListNotificationsOrgAsync(
    ///     123,
    ///     new ListNotificationsOrgRequest
    ///     {
    ///         FromRecord = 251,
    ///         LimitRecord = 0,
    ///         SortBy = "desc(field_name)",
    ///     }
    /// );
    /// </code></example>
    public async Task<QueryResponseNotifications> ListNotificationsOrgAsync(
        int orgId,
        ListNotificationsOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.FromRecord != null)
        {
            _query["fromRecord"] = request.FromRecord.Value.ToString();
        }
        if (request.LimitRecord != null)
        {
            _query["limitRecord"] = request.LimitRecord.Value.ToString();
        }
        if (request.Parameters != null)
        {
            _query["parameters"] = JsonUtils.Serialize(request.Parameters);
        }
        if (request.SortBy != null)
        {
            _query["sortBy"] = request.SortBy;
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "Query/notifications/org/{0}",
                        ValueConvert.ToPathParameterString(orgId)
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
                return JsonUtils.Deserialize<QueryResponseNotifications>(responseBody)!;
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
    /// Retrieves a list of an organization's suborganizations and their full details such as orgId, users, and settings. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
    /// </summary>
    /// <example><code>
    /// await client.Query.ListOrganizationsAsync(
    ///     123,
    ///     new ListOrganizationsRequest
    ///     {
    ///         FromRecord = 251,
    ///         LimitRecord = 0,
    ///         SortBy = "desc(field_name)",
    ///     }
    /// );
    /// </code></example>
    public async Task<ListOrganizationsResponse> ListOrganizationsAsync(
        int orgId,
        ListOrganizationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.ExportFormat != null)
        {
            _query["exportFormat"] = request.ExportFormat.Value.Stringify();
        }
        if (request.FromRecord != null)
        {
            _query["fromRecord"] = request.FromRecord.Value.ToString();
        }
        if (request.LimitRecord != null)
        {
            _query["limitRecord"] = request.LimitRecord.Value.ToString();
        }
        if (request.Parameters != null)
        {
            _query["parameters"] = JsonUtils.Serialize(request.Parameters);
        }
        if (request.SortBy != null)
        {
            _query["sortBy"] = request.SortBy;
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "Query/organizations/{0}",
                        ValueConvert.ToPathParameterString(orgId)
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
                return JsonUtils.Deserialize<ListOrganizationsResponse>(responseBody)!;
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
    /// Retrieves a list of money out transactions (payouts) for a paypoint. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
    /// </summary>
    /// <example><code>
    /// await client.Query.ListPayoutAsync(
    ///     "8cfec329267",
    ///     new ListPayoutRequest
    ///     {
    ///         FromRecord = 251,
    ///         LimitRecord = 0,
    ///         SortBy = "desc(field_name)",
    ///     }
    /// );
    /// </code></example>
    public async Task<QueryPayoutTransaction> ListPayoutAsync(
        string entry,
        ListPayoutRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.ExportFormat != null)
        {
            _query["exportFormat"] = request.ExportFormat.Value.Stringify();
        }
        if (request.FromRecord != null)
        {
            _query["fromRecord"] = request.FromRecord.Value.ToString();
        }
        if (request.LimitRecord != null)
        {
            _query["limitRecord"] = request.LimitRecord.Value.ToString();
        }
        if (request.Parameters != null)
        {
            _query["parameters"] = JsonUtils.Serialize(request.Parameters);
        }
        if (request.SortBy != null)
        {
            _query["sortBy"] = request.SortBy;
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "Query/payouts/{0}",
                        ValueConvert.ToPathParameterString(entry)
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
                return JsonUtils.Deserialize<QueryPayoutTransaction>(responseBody)!;
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
    /// Retrieves a list of money out transactions (payouts) for an organization. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
    /// </summary>
    /// <example><code>
    /// await client.Query.ListPayoutOrgAsync(
    ///     123,
    ///     new ListPayoutOrgRequest
    ///     {
    ///         FromRecord = 251,
    ///         LimitRecord = 0,
    ///         SortBy = "desc(field_name)",
    ///     }
    /// );
    /// </code></example>
    public async Task<QueryPayoutTransaction> ListPayoutOrgAsync(
        int orgId,
        ListPayoutOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.ExportFormat != null)
        {
            _query["exportFormat"] = request.ExportFormat.Value.Stringify();
        }
        if (request.FromRecord != null)
        {
            _query["fromRecord"] = request.FromRecord.Value.ToString();
        }
        if (request.LimitRecord != null)
        {
            _query["limitRecord"] = request.LimitRecord.Value.ToString();
        }
        if (request.Parameters != null)
        {
            _query["parameters"] = JsonUtils.Serialize(request.Parameters);
        }
        if (request.SortBy != null)
        {
            _query["sortBy"] = request.SortBy;
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "Query/payouts/org/{0}",
                        ValueConvert.ToPathParameterString(orgId)
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
                return JsonUtils.Deserialize<QueryPayoutTransaction>(responseBody)!;
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
    /// Returns a list of paypoints in an organization. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
    /// </summary>
    /// <example><code>
    /// await client.Query.ListPaypointsAsync(
    ///     123,
    ///     new ListPaypointsRequest
    ///     {
    ///         FromRecord = 251,
    ///         LimitRecord = 0,
    ///         SortBy = "desc(field_name)",
    ///     }
    /// );
    /// </code></example>
    public async Task<QueryEntrypointResponse> ListPaypointsAsync(
        int orgId,
        ListPaypointsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.ExportFormat != null)
        {
            _query["exportFormat"] = request.ExportFormat.Value.Stringify();
        }
        if (request.FromRecord != null)
        {
            _query["fromRecord"] = request.FromRecord.Value.ToString();
        }
        if (request.LimitRecord != null)
        {
            _query["limitRecord"] = request.LimitRecord.Value.ToString();
        }
        if (request.Parameters != null)
        {
            _query["parameters"] = JsonUtils.Serialize(request.Parameters);
        }
        if (request.SortBy != null)
        {
            _query["sortBy"] = request.SortBy;
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "Query/paypoints/{0}",
                        ValueConvert.ToPathParameterString(orgId)
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
                return JsonUtils.Deserialize<QueryEntrypointResponse>(responseBody)!;
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
    /// Retrieve a list of settled transactions for a paypoint. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
    /// </summary>
    /// <example><code>
    /// await client.Query.ListSettlementsAsync(
    ///     "8cfec329267",
    ///     new ListSettlementsRequest
    ///     {
    ///         FromRecord = 251,
    ///         LimitRecord = 0,
    ///         SortBy = "desc(field_name)",
    ///     }
    /// );
    /// </code></example>
    public async Task<QueryResponseSettlements> ListSettlementsAsync(
        string entry,
        ListSettlementsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.ExportFormat != null)
        {
            _query["exportFormat"] = request.ExportFormat.Value.Stringify();
        }
        if (request.FromRecord != null)
        {
            _query["fromRecord"] = request.FromRecord.Value.ToString();
        }
        if (request.LimitRecord != null)
        {
            _query["limitRecord"] = request.LimitRecord.Value.ToString();
        }
        if (request.Parameters != null)
        {
            _query["parameters"] = JsonUtils.Serialize(request.Parameters);
        }
        if (request.SortBy != null)
        {
            _query["sortBy"] = request.SortBy;
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "Query/settlements/{0}",
                        ValueConvert.ToPathParameterString(entry)
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
                return JsonUtils.Deserialize<QueryResponseSettlements>(responseBody)!;
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
    /// Retrieve a list of settled transactions for an organization. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
    /// </summary>
    /// <example><code>
    /// await client.Query.ListSettlementsOrgAsync(
    ///     123,
    ///     new ListSettlementsOrgRequest
    ///     {
    ///         FromRecord = 251,
    ///         LimitRecord = 0,
    ///         SortBy = "desc(field_name)",
    ///     }
    /// );
    /// </code></example>
    public async Task<QueryResponseSettlements> ListSettlementsOrgAsync(
        int orgId,
        ListSettlementsOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.ExportFormat != null)
        {
            _query["exportFormat"] = request.ExportFormat.Value.Stringify();
        }
        if (request.FromRecord != null)
        {
            _query["fromRecord"] = request.FromRecord.Value.ToString();
        }
        if (request.LimitRecord != null)
        {
            _query["limitRecord"] = request.LimitRecord.Value.ToString();
        }
        if (request.Parameters != null)
        {
            _query["parameters"] = JsonUtils.Serialize(request.Parameters);
        }
        if (request.SortBy != null)
        {
            _query["sortBy"] = request.SortBy;
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "Query/settlements/org/{0}",
                        ValueConvert.ToPathParameterString(orgId)
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
                return JsonUtils.Deserialize<QueryResponseSettlements>(responseBody)!;
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
    /// Returns a list of subscriptions for a single paypoint. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
    /// </summary>
    /// <example><code>
    /// await client.Query.ListSubscriptionsAsync(
    ///     "8cfec329267",
    ///     new ListSubscriptionsRequest
    ///     {
    ///         FromRecord = 251,
    ///         LimitRecord = 0,
    ///         SortBy = "desc(field_name)",
    ///     }
    /// );
    /// </code></example>
    public async Task<QuerySubscriptionResponse> ListSubscriptionsAsync(
        string entry,
        ListSubscriptionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.ExportFormat != null)
        {
            _query["exportFormat"] = request.ExportFormat.Value.Stringify();
        }
        if (request.FromRecord != null)
        {
            _query["fromRecord"] = request.FromRecord.Value.ToString();
        }
        if (request.LimitRecord != null)
        {
            _query["limitRecord"] = request.LimitRecord.Value.ToString();
        }
        if (request.Parameters != null)
        {
            _query["parameters"] = JsonUtils.Serialize(request.Parameters);
        }
        if (request.SortBy != null)
        {
            _query["sortBy"] = request.SortBy;
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "Query/subscriptions/{0}",
                        ValueConvert.ToPathParameterString(entry)
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
                return JsonUtils.Deserialize<QuerySubscriptionResponse>(responseBody)!;
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
    /// Returns a list of subscriptions for a single org. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
    /// </summary>
    /// <example><code>
    /// await client.Query.ListSubscriptionsOrgAsync(
    ///     123,
    ///     new ListSubscriptionsOrgRequest
    ///     {
    ///         FromRecord = 251,
    ///         LimitRecord = 0,
    ///         SortBy = "desc(field_name)",
    ///     }
    /// );
    /// </code></example>
    public async Task<QuerySubscriptionResponse> ListSubscriptionsOrgAsync(
        int orgId,
        ListSubscriptionsOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.ExportFormat != null)
        {
            _query["exportFormat"] = request.ExportFormat.Value.Stringify();
        }
        if (request.FromRecord != null)
        {
            _query["fromRecord"] = request.FromRecord.Value.ToString();
        }
        if (request.LimitRecord != null)
        {
            _query["limitRecord"] = request.LimitRecord.Value.ToString();
        }
        if (request.Parameters != null)
        {
            _query["parameters"] = JsonUtils.Serialize(request.Parameters);
        }
        if (request.SortBy != null)
        {
            _query["sortBy"] = request.SortBy;
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "Query/subscriptions/org/{0}",
                        ValueConvert.ToPathParameterString(orgId)
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
                return JsonUtils.Deserialize<QuerySubscriptionResponse>(responseBody)!;
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
    /// Retrieve a list of transactions for a paypoint. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
    /// By default, this endpoint returns only transactions from the last 60 days. To query transactions outside of this period, include `transactionDate` filters.
    /// For example, this request parameters filter for transactions between April 01, 2024 and April 09, 2024.
    /// ``` curl --request GET \
    ///   --url https://sandbox.payabli.com/api/Query/transactions/org/1?limitRecord=20&fromRecord=0&transactionDate(ge)=2024-04-01T00:00:00&transactionDate(le)=2024-04-09T23:59:59\
    ///   --header 'requestToken: &lt;api-key&gt;'
    ///
    ///   ```
    /// </summary>
    /// <example><code>
    /// await client.Query.ListTransactionsAsync(
    ///     "8cfec329267",
    ///     new ListTransactionsRequest
    ///     {
    ///         FromRecord = 251,
    ///         LimitRecord = 0,
    ///         SortBy = "desc(field_name)",
    ///     }
    /// );
    /// </code></example>
    public async Task<QueryResponseTransactions> ListTransactionsAsync(
        string entry,
        ListTransactionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.ExportFormat != null)
        {
            _query["exportFormat"] = request.ExportFormat.Value.Stringify();
        }
        if (request.FromRecord != null)
        {
            _query["fromRecord"] = request.FromRecord.Value.ToString();
        }
        if (request.LimitRecord != null)
        {
            _query["limitRecord"] = request.LimitRecord.Value.ToString();
        }
        if (request.Parameters != null)
        {
            _query["parameters"] = JsonUtils.Serialize(request.Parameters);
        }
        if (request.SortBy != null)
        {
            _query["sortBy"] = request.SortBy;
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "Query/transactions/{0}",
                        ValueConvert.ToPathParameterString(entry)
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
                return JsonUtils.Deserialize<QueryResponseTransactions>(responseBody)!;
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
    /// Retrieve a list of transactions for an organization. Use filters to
    /// limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
    ///
    ///
    /// By default, this endpoint returns only transactions from the last 60 days. To query transactions outside of this period, include `transactionDate` filters.
    ///
    /// For example, this request parameters filter for transactions between April 01, 2024 and April 09, 2024.
    ///
    /// ```
    /// curl --request GET \
    ///   --url https://sandbox.payabli.com/api/Query/transactions/org/1?limitRecord=20&fromRecord=0&transactionDate(ge)=2024-04-01T00:00:00&transactionDate(le)=2024-04-09T23:59:59\
    ///   --header 'requestToken: &lt;api-key&gt;'
    ///
    ///   ```
    /// </summary>
    /// <example><code>
    /// await client.Query.ListTransactionsOrgAsync(
    ///     123,
    ///     new ListTransactionsOrgRequest
    ///     {
    ///         FromRecord = 251,
    ///         LimitRecord = 0,
    ///         SortBy = "desc(field_name)",
    ///     }
    /// );
    /// </code></example>
    public async Task<QueryResponseTransactions> ListTransactionsOrgAsync(
        int orgId,
        ListTransactionsOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.ExportFormat != null)
        {
            _query["exportFormat"] = request.ExportFormat.Value.Stringify();
        }
        if (request.FromRecord != null)
        {
            _query["fromRecord"] = request.FromRecord.Value.ToString();
        }
        if (request.LimitRecord != null)
        {
            _query["limitRecord"] = request.LimitRecord.Value.ToString();
        }
        if (request.Parameters != null)
        {
            _query["parameters"] = JsonUtils.Serialize(request.Parameters);
        }
        if (request.SortBy != null)
        {
            _query["sortBy"] = request.SortBy;
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "Query/transactions/org/{0}",
                        ValueConvert.ToPathParameterString(orgId)
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
                return JsonUtils.Deserialize<QueryResponseTransactions>(responseBody)!;
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
    /// Retrieve a list of transfer details records for a paypoint. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
    /// </summary>
    /// <example><code>
    /// await client.Query.ListTransferDetailsAsync("47862acd", 123456, new ListTransfersPaypointRequest());
    /// </code></example>
    public async Task<QueryTransferDetailResponse> ListTransferDetailsAsync(
        string entry,
        int transferId,
        ListTransfersPaypointRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.ExportFormat != null)
        {
            _query["exportFormat"] = request.ExportFormat.Value.Stringify();
        }
        if (request.FromRecord != null)
        {
            _query["fromRecord"] = request.FromRecord.Value.ToString();
        }
        if (request.LimitRecord != null)
        {
            _query["limitRecord"] = request.LimitRecord.Value.ToString();
        }
        if (request.Parameters != null)
        {
            _query["parameters"] = JsonUtils.Serialize(request.Parameters);
        }
        if (request.SortBy != null)
        {
            _query["sortBy"] = request.SortBy;
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "Query/transferDetails/{0}/{1}",
                        ValueConvert.ToPathParameterString(entry),
                        ValueConvert.ToPathParameterString(transferId)
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
                return JsonUtils.Deserialize<QueryTransferDetailResponse>(responseBody)!;
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
    /// Retrieve a list of transfers for a paypoint. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
    /// </summary>
    /// <example><code>
    /// await client.Query.ListTransfersAsync(
    ///     "47862acd",
    ///     new ListTransfersRequest { FromRecord = 0, LimitRecord = 20 }
    /// );
    /// </code></example>
    public async Task<TransferQueryResponse> ListTransfersAsync(
        string entry,
        ListTransfersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.ExportFormat != null)
        {
            _query["exportFormat"] = request.ExportFormat.Value.Stringify();
        }
        if (request.FromRecord != null)
        {
            _query["fromRecord"] = request.FromRecord.Value.ToString();
        }
        if (request.LimitRecord != null)
        {
            _query["limitRecord"] = request.LimitRecord.Value.ToString();
        }
        if (request.Parameters != null)
        {
            _query["parameters"] = JsonUtils.Serialize(request.Parameters);
        }
        if (request.SortBy != null)
        {
            _query["sortBy"] = request.SortBy;
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "Query/transfers/{0}",
                        ValueConvert.ToPathParameterString(entry)
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
                return JsonUtils.Deserialize<TransferQueryResponse>(responseBody)!;
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
    /// Retrieve a list of transfers for an org. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
    /// </summary>
    /// <example><code>
    /// await client.Query.ListTransfersOrgAsync(
    ///     new ListTransfersRequestOrg
    ///     {
    ///         OrgId = 123,
    ///         FromRecord = 0,
    ///         LimitRecord = 20,
    ///     }
    /// );
    /// </code></example>
    public async Task<TransferQueryResponse> ListTransfersOrgAsync(
        ListTransfersRequestOrg request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.ExportFormat != null)
        {
            _query["exportFormat"] = request.ExportFormat.Value.Stringify();
        }
        if (request.FromRecord != null)
        {
            _query["fromRecord"] = request.FromRecord.Value.ToString();
        }
        if (request.LimitRecord != null)
        {
            _query["limitRecord"] = request.LimitRecord.Value.ToString();
        }
        if (request.Parameters != null)
        {
            _query["parameters"] = JsonUtils.Serialize(request.Parameters);
        }
        if (request.SortBy != null)
        {
            _query["sortBy"] = request.SortBy;
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "Query/transfers/org/{0}",
                        ValueConvert.ToPathParameterString(request.OrgId)
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
                return JsonUtils.Deserialize<TransferQueryResponse>(responseBody)!;
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
    /// Get list of users for an org. Use filters to limit results.
    /// </summary>
    /// <example><code>
    /// await client.Query.ListUsersOrgAsync(
    ///     123,
    ///     new ListUsersOrgRequest
    ///     {
    ///         FromRecord = 251,
    ///         LimitRecord = 0,
    ///         SortBy = "desc(field_name)",
    ///     }
    /// );
    /// </code></example>
    public async Task<QueryUserResponse> ListUsersOrgAsync(
        int orgId,
        ListUsersOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.FromRecord != null)
        {
            _query["fromRecord"] = request.FromRecord.Value.ToString();
        }
        if (request.LimitRecord != null)
        {
            _query["limitRecord"] = request.LimitRecord.Value.ToString();
        }
        if (request.Parameters != null)
        {
            _query["parameters"] = JsonUtils.Serialize(request.Parameters);
        }
        if (request.SortBy != null)
        {
            _query["sortBy"] = request.SortBy;
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "Query/users/org/{0}",
                        ValueConvert.ToPathParameterString(orgId)
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
                return JsonUtils.Deserialize<QueryUserResponse>(responseBody)!;
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
    /// Get list of users for a paypoint. Use filters to limit results.
    /// </summary>
    /// <example><code>
    /// await client.Query.ListUsersPaypointAsync(
    ///     "8cfec329267",
    ///     new ListUsersPaypointRequest
    ///     {
    ///         FromRecord = 251,
    ///         LimitRecord = 0,
    ///         SortBy = "desc(field_name)",
    ///     }
    /// );
    /// </code></example>
    public async Task<QueryUserResponse> ListUsersPaypointAsync(
        string entry,
        ListUsersPaypointRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.FromRecord != null)
        {
            _query["fromRecord"] = request.FromRecord.Value.ToString();
        }
        if (request.LimitRecord != null)
        {
            _query["limitRecord"] = request.LimitRecord.Value.ToString();
        }
        if (request.Parameters != null)
        {
            _query["parameters"] = JsonUtils.Serialize(request.Parameters);
        }
        if (request.SortBy != null)
        {
            _query["sortBy"] = request.SortBy;
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "Query/users/point/{0}",
                        ValueConvert.ToPathParameterString(entry)
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
                return JsonUtils.Deserialize<QueryUserResponse>(responseBody)!;
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
    /// Retrieve a list of vendors for an entrypoint. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
    /// </summary>
    /// <example><code>
    /// await client.Query.ListVendorsAsync(
    ///     "8cfec329267",
    ///     new ListVendorsRequest
    ///     {
    ///         FromRecord = 251,
    ///         LimitRecord = 0,
    ///         SortBy = "desc(field_name)",
    ///     }
    /// );
    /// </code></example>
    public async Task<QueryResponseVendors> ListVendorsAsync(
        string entry,
        ListVendorsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.ExportFormat != null)
        {
            _query["exportFormat"] = request.ExportFormat.Value.Stringify();
        }
        if (request.FromRecord != null)
        {
            _query["fromRecord"] = request.FromRecord.Value.ToString();
        }
        if (request.LimitRecord != null)
        {
            _query["limitRecord"] = request.LimitRecord.Value.ToString();
        }
        if (request.Parameters != null)
        {
            _query["parameters"] = JsonUtils.Serialize(request.Parameters);
        }
        if (request.SortBy != null)
        {
            _query["sortBy"] = request.SortBy;
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "Query/vendors/{0}",
                        ValueConvert.ToPathParameterString(entry)
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
                return JsonUtils.Deserialize<QueryResponseVendors>(responseBody)!;
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
    /// Retrieve a list of vendors for an organization. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
    /// </summary>
    /// <example><code>
    /// await client.Query.ListVendorsOrgAsync(
    ///     123,
    ///     new ListVendorsOrgRequest
    ///     {
    ///         FromRecord = 251,
    ///         LimitRecord = 0,
    ///         SortBy = "desc(field_name)",
    ///     }
    /// );
    /// </code></example>
    public async Task<QueryResponseVendors> ListVendorsOrgAsync(
        int orgId,
        ListVendorsOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.ExportFormat != null)
        {
            _query["exportFormat"] = request.ExportFormat.Value.Stringify();
        }
        if (request.FromRecord != null)
        {
            _query["fromRecord"] = request.FromRecord.Value.ToString();
        }
        if (request.LimitRecord != null)
        {
            _query["limitRecord"] = request.LimitRecord.Value.ToString();
        }
        if (request.Parameters != null)
        {
            _query["parameters"] = JsonUtils.Serialize(request.Parameters);
        }
        if (request.SortBy != null)
        {
            _query["sortBy"] = request.SortBy;
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "Query/vendors/org/{0}",
                        ValueConvert.ToPathParameterString(orgId)
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
                return JsonUtils.Deserialize<QueryResponseVendors>(responseBody)!;
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
    /// Retrieve a list of vcards (virtual credit cards) issued for an entrypoint. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
    /// </summary>
    /// <example><code>
    /// await client.Query.ListVcardsAsync(
    ///     "8cfec329267",
    ///     new ListVcardsRequest
    ///     {
    ///         FromRecord = 251,
    ///         LimitRecord = 0,
    ///         SortBy = "desc(field_name)",
    ///     }
    /// );
    /// </code></example>
    public async Task<VCardQueryResponse> ListVcardsAsync(
        string entry,
        ListVcardsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.ExportFormat != null)
        {
            _query["exportFormat"] = request.ExportFormat.Value.Stringify();
        }
        if (request.FromRecord != null)
        {
            _query["fromRecord"] = request.FromRecord.Value.ToString();
        }
        if (request.LimitRecord != null)
        {
            _query["limitRecord"] = request.LimitRecord.Value.ToString();
        }
        if (request.Parameters != null)
        {
            _query["parameters"] = JsonUtils.Serialize(request.Parameters);
        }
        if (request.SortBy != null)
        {
            _query["sortBy"] = request.SortBy;
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "Query/vcards/{0}",
                        ValueConvert.ToPathParameterString(entry)
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
                return JsonUtils.Deserialize<VCardQueryResponse>(responseBody)!;
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
    /// Retrieve a list of vcards (virtual credit cards) issued for an organization. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
    /// </summary>
    /// <example><code>
    /// await client.Query.ListVcardsOrgAsync(
    ///     123,
    ///     new ListVcardsOrgRequest
    ///     {
    ///         FromRecord = 251,
    ///         LimitRecord = 0,
    ///         SortBy = "desc(field_name)",
    ///     }
    /// );
    /// </code></example>
    public async Task<VCardQueryResponse> ListVcardsOrgAsync(
        int orgId,
        ListVcardsOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.ExportFormat != null)
        {
            _query["exportFormat"] = request.ExportFormat.Value.Stringify();
        }
        if (request.FromRecord != null)
        {
            _query["fromRecord"] = request.FromRecord.Value.ToString();
        }
        if (request.LimitRecord != null)
        {
            _query["limitRecord"] = request.LimitRecord.Value.ToString();
        }
        if (request.Parameters != null)
        {
            _query["parameters"] = JsonUtils.Serialize(request.Parameters);
        }
        if (request.SortBy != null)
        {
            _query["sortBy"] = request.SortBy;
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "Query/vcards/org/{0}",
                        ValueConvert.ToPathParameterString(orgId)
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
                return JsonUtils.Deserialize<VCardQueryResponse>(responseBody)!;
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
