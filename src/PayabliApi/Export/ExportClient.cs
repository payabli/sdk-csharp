using System.Text.Json;
using PayabliApi.Core;

namespace PayabliApi;

public partial class ExportClient
{
    private RawClient _client;

    internal ExportClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Export a list of boarding applications for an organization. Use filters to limit results.
    /// </summary>
    /// <example><code>
    /// await client.Export.ExportApplicationsAsync(
    ///     ExportFormat1.Csv,
    ///     123,
    ///     new ExportApplicationsRequest
    ///     {
    ///         ColumnsExport = "BatchDate:Batch_Date,PaypointName:Legal_name",
    ///         FromRecord = 251,
    ///         LimitRecord = 1000,
    ///     }
    /// );
    /// </code></example>
    public async Task<Dictionary<string, object?>> ExportApplicationsAsync(
        ExportFormat1 format,
        int orgId,
        ExportApplicationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.ColumnsExport != null)
        {
            _query["columnsExport"] = request.ColumnsExport;
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
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "Export/boarding/{0}/{1}",
                        ValueConvert.ToPathParameterString(format),
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
                return JsonUtils.Deserialize<Dictionary<string, object?>>(responseBody)!;
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
    /// This endpoint is deprecated. Export batch details for a paypoint. Use filters to limit results.
    /// </summary>
    /// <example><code>
    /// await client.Export.ExportBatchDetailsAsync(
    ///     "8cfec329267",
    ///     ExportFormat1.Csv,
    ///     new ExportBatchDetailsRequest
    ///     {
    ///         ColumnsExport = "BatchDate:Batch_Date,PaypointName:Legal_name",
    ///         FromRecord = 251,
    ///         LimitRecord = 1000,
    ///     }
    /// );
    /// </code></example>
    public async Task<Dictionary<string, object?>> ExportBatchDetailsAsync(
        ExportFormat1 format,
        string entry,
        ExportBatchDetailsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.ColumnsExport != null)
        {
            _query["columnsExport"] = request.ColumnsExport;
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
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "Export/batchDetails/{0}/{1}",
                        ValueConvert.ToPathParameterString(format),
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
                return JsonUtils.Deserialize<Dictionary<string, object?>>(responseBody)!;
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
    /// This endpoint is deprecated. Export batch details for an organization. Use filters to limit results.
    /// </summary>
    /// <example><code>
    /// await client.Export.ExportBatchDetailsOrgAsync(
    ///     ExportFormat1.Csv,
    ///     123,
    ///     new ExportBatchDetailsOrgRequest
    ///     {
    ///         ColumnsExport = "BatchDate:Batch_Date,PaypointName:Legal_name",
    ///         FromRecord = 251,
    ///         LimitRecord = 1000,
    ///     }
    /// );
    /// </code></example>
    public async Task<Dictionary<string, object?>> ExportBatchDetailsOrgAsync(
        ExportFormat1 format,
        int orgId,
        ExportBatchDetailsOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.ColumnsExport != null)
        {
            _query["columnsExport"] = request.ColumnsExport;
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
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "Export/batchDetails/{0}/org/{1}",
                        ValueConvert.ToPathParameterString(format),
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
                return JsonUtils.Deserialize<Dictionary<string, object?>>(responseBody)!;
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
    /// Export a list of batches for an entrypoint. Use filters to limit results.
    /// </summary>
    /// <example><code>
    /// await client.Export.ExportBatchesAsync(
    ///     "8cfec329267",
    ///     ExportFormat1.Csv,
    ///     new ExportBatchesRequest
    ///     {
    ///         ColumnsExport = "BatchDate:Batch_Date,PaypointName:Legal_name",
    ///         FromRecord = 251,
    ///         LimitRecord = 1000,
    ///     }
    /// );
    /// </code></example>
    public async Task<Dictionary<string, object?>> ExportBatchesAsync(
        ExportFormat1 format,
        string entry,
        ExportBatchesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.ColumnsExport != null)
        {
            _query["columnsExport"] = request.ColumnsExport;
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
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "Export/batches/{0}/{1}",
                        ValueConvert.ToPathParameterString(format),
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
                return JsonUtils.Deserialize<Dictionary<string, object?>>(responseBody)!;
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
    /// Export a list of batches for an organization. Use filters to limit results.
    /// </summary>
    /// <example><code>
    /// await client.Export.ExportBatchesOrgAsync(
    ///     ExportFormat1.Csv,
    ///     123,
    ///     new ExportBatchesOrgRequest
    ///     {
    ///         ColumnsExport = "BatchDate:Batch_Date,PaypointName:Legal_name",
    ///         FromRecord = 251,
    ///         LimitRecord = 1000,
    ///     }
    /// );
    /// </code></example>
    public async Task<Dictionary<string, object?>> ExportBatchesOrgAsync(
        ExportFormat1 format,
        int orgId,
        ExportBatchesOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.ColumnsExport != null)
        {
            _query["columnsExport"] = request.ColumnsExport;
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
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "Export/batches/{0}/org/{1}",
                        ValueConvert.ToPathParameterString(format),
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
                return JsonUtils.Deserialize<Dictionary<string, object?>>(responseBody)!;
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
    /// Export a list of money out batches for a paypoint. Use filters to limit results.
    /// </summary>
    /// <example><code>
    /// await client.Export.ExportBatchesOutAsync(
    ///     "8cfec329267",
    ///     ExportFormat1.Csv,
    ///     new ExportBatchesOutRequest
    ///     {
    ///         ColumnsExport = "BatchDate:Batch_Date,PaypointName:Legal_name",
    ///         FromRecord = 251,
    ///         LimitRecord = 1000,
    ///     }
    /// );
    /// </code></example>
    public async Task<Dictionary<string, object?>> ExportBatchesOutAsync(
        ExportFormat1 format,
        string entry,
        ExportBatchesOutRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.ColumnsExport != null)
        {
            _query["columnsExport"] = request.ColumnsExport;
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
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "Export/batchesOut/{0}/{1}",
                        ValueConvert.ToPathParameterString(format),
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
                return JsonUtils.Deserialize<Dictionary<string, object?>>(responseBody)!;
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
    /// Export a list of money out batches for an organization. Use filters to limit results.
    /// </summary>
    /// <example><code>
    /// await client.Export.ExportBatchesOutOrgAsync(
    ///     ExportFormat1.Csv,
    ///     123,
    ///     new ExportBatchesOutOrgRequest
    ///     {
    ///         ColumnsExport = "BatchDate:Batch_Date,PaypointName:Legal_name",
    ///         FromRecord = 251,
    ///         LimitRecord = 1000,
    ///     }
    /// );
    /// </code></example>
    public async Task<Dictionary<string, object?>> ExportBatchesOutOrgAsync(
        ExportFormat1 format,
        int orgId,
        ExportBatchesOutOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.ColumnsExport != null)
        {
            _query["columnsExport"] = request.ColumnsExport;
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
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "Export/batchesOut/{0}/org/{1}",
                        ValueConvert.ToPathParameterString(format),
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
                return JsonUtils.Deserialize<Dictionary<string, object?>>(responseBody)!;
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
    /// Export a list of bills for an entrypoint. Use filters to limit results.
    /// </summary>
    /// <example><code>
    /// await client.Export.ExportBillsAsync(
    ///     "8cfec329267",
    ///     ExportFormat1.Csv,
    ///     new ExportBillsRequest
    ///     {
    ///         ColumnsExport = "BatchDate:Batch_Date,PaypointName:Legal_name",
    ///         FromRecord = 251,
    ///         LimitRecord = 1000,
    ///     }
    /// );
    /// </code></example>
    public async Task<Dictionary<string, object?>> ExportBillsAsync(
        ExportFormat1 format,
        string entry,
        ExportBillsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.ColumnsExport != null)
        {
            _query["columnsExport"] = request.ColumnsExport;
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
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "Export/bills/{0}/{1}",
                        ValueConvert.ToPathParameterString(format),
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
                return JsonUtils.Deserialize<Dictionary<string, object?>>(responseBody)!;
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
    /// Export a list of bills for an organization. Use filters to limit results.
    /// </summary>
    /// <example><code>
    /// await client.Export.ExportBillsOrgAsync(
    ///     ExportFormat1.Csv,
    ///     123,
    ///     new ExportBillsOrgRequest
    ///     {
    ///         ColumnsExport = "BatchDate:Batch_Date,PaypointName:Legal_name",
    ///         FromRecord = 251,
    ///         LimitRecord = 1000,
    ///     }
    /// );
    /// </code></example>
    public async Task<Dictionary<string, object?>> ExportBillsOrgAsync(
        ExportFormat1 format,
        int orgId,
        ExportBillsOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.ColumnsExport != null)
        {
            _query["columnsExport"] = request.ColumnsExport;
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
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "Export/bills/{0}/org/{1}",
                        ValueConvert.ToPathParameterString(format),
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
                return JsonUtils.Deserialize<Dictionary<string, object?>>(responseBody)!;
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
    /// Export a list of chargebacks and ACH returns for an entrypoint. Use filters to limit results.
    /// </summary>
    /// <example><code>
    /// await client.Export.ExportChargebacksAsync(
    ///     "8cfec329267",
    ///     ExportFormat1.Csv,
    ///     new ExportChargebacksRequest
    ///     {
    ///         ColumnsExport = "BatchDate:Batch_Date,PaypointName:Legal_name",
    ///         FromRecord = 251,
    ///         LimitRecord = 1000,
    ///     }
    /// );
    /// </code></example>
    public async Task<Dictionary<string, object?>> ExportChargebacksAsync(
        ExportFormat1 format,
        string entry,
        ExportChargebacksRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.ColumnsExport != null)
        {
            _query["columnsExport"] = request.ColumnsExport;
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
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "Export/chargebacks/{0}/{1}",
                        ValueConvert.ToPathParameterString(format),
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
                return JsonUtils.Deserialize<Dictionary<string, object?>>(responseBody)!;
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
    /// Export a list of chargebacks and ACH returns for an organization. Use filters to limit results.
    /// </summary>
    /// <example><code>
    /// await client.Export.ExportChargebacksOrgAsync(
    ///     ExportFormat1.Csv,
    ///     123,
    ///     new ExportChargebacksOrgRequest
    ///     {
    ///         ColumnsExport = "BatchDate:Batch_Date,PaypointName:Legal_name",
    ///         FromRecord = 251,
    ///         LimitRecord = 1000,
    ///     }
    /// );
    /// </code></example>
    public async Task<Dictionary<string, object?>> ExportChargebacksOrgAsync(
        ExportFormat1 format,
        int orgId,
        ExportChargebacksOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.ColumnsExport != null)
        {
            _query["columnsExport"] = request.ColumnsExport;
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
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "Export/chargebacks/{0}/org/{1}",
                        ValueConvert.ToPathParameterString(format),
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
                return JsonUtils.Deserialize<Dictionary<string, object?>>(responseBody)!;
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
    /// Export a list of customers for an entrypoint. Use filters to limit results.
    /// </summary>
    /// <example><code>
    /// await client.Export.ExportCustomersAsync(
    ///     "8cfec329267",
    ///     ExportFormat1.Csv,
    ///     new ExportCustomersRequest
    ///     {
    ///         ColumnsExport = "BatchDate:Batch_Date,PaypointName:Legal_name",
    ///         FromRecord = 251,
    ///         LimitRecord = 1000,
    ///     }
    /// );
    /// </code></example>
    public async Task<Dictionary<string, object?>> ExportCustomersAsync(
        ExportFormat1 format,
        string entry,
        ExportCustomersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.ColumnsExport != null)
        {
            _query["columnsExport"] = request.ColumnsExport;
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
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "Export/customers/{0}/{1}",
                        ValueConvert.ToPathParameterString(format),
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
                return JsonUtils.Deserialize<Dictionary<string, object?>>(responseBody)!;
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
    /// Exports a list of customers for an organization. Use filters to limit results.
    /// </summary>
    /// <example><code>
    /// await client.Export.ExportCustomersOrgAsync(
    ///     ExportFormat1.Csv,
    ///     123,
    ///     new ExportCustomersOrgRequest
    ///     {
    ///         ColumnsExport = "BatchDate:Batch_Date,PaypointName:Legal_name",
    ///         FromRecord = 251,
    ///         LimitRecord = 1000,
    ///     }
    /// );
    /// </code></example>
    public async Task<Dictionary<string, object?>> ExportCustomersOrgAsync(
        ExportFormat1 format,
        int orgId,
        ExportCustomersOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.ColumnsExport != null)
        {
            _query["columnsExport"] = request.ColumnsExport;
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
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "Export/customers/{0}/org/{1}",
                        ValueConvert.ToPathParameterString(format),
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
                return JsonUtils.Deserialize<Dictionary<string, object?>>(responseBody)!;
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
    /// Export list of invoices for an entrypoint. Use filters to limit results.
    /// </summary>
    /// <example><code>
    /// await client.Export.ExportInvoicesAsync(
    ///     "8cfec329267",
    ///     ExportFormat1.Csv,
    ///     new ExportInvoicesRequest
    ///     {
    ///         ColumnsExport = "BatchDate:Batch_Date,PaypointName:Legal_name",
    ///         FromRecord = 251,
    ///         LimitRecord = 1000,
    ///     }
    /// );
    /// </code></example>
    public async Task<Dictionary<string, object?>> ExportInvoicesAsync(
        ExportFormat1 format,
        string entry,
        ExportInvoicesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.ColumnsExport != null)
        {
            _query["columnsExport"] = request.ColumnsExport;
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
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "Export/invoices/{0}/{1}",
                        ValueConvert.ToPathParameterString(format),
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
                return JsonUtils.Deserialize<Dictionary<string, object?>>(responseBody)!;
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
    /// Export a list of invoices for an organization. Use filters to limit results.
    /// </summary>
    /// <example><code>
    /// await client.Export.ExportInvoicesOrgAsync(
    ///     ExportFormat1.Csv,
    ///     123,
    ///     new ExportInvoicesOrgRequest
    ///     {
    ///         ColumnsExport = "BatchDate:Batch_Date,PaypointName:Legal_name",
    ///         FromRecord = 251,
    ///         LimitRecord = 1000,
    ///     }
    /// );
    /// </code></example>
    public async Task<Dictionary<string, object?>> ExportInvoicesOrgAsync(
        ExportFormat1 format,
        int orgId,
        ExportInvoicesOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.ColumnsExport != null)
        {
            _query["columnsExport"] = request.ColumnsExport;
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
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "Export/invoices/{0}/org/{1}",
                        ValueConvert.ToPathParameterString(format),
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
                return JsonUtils.Deserialize<Dictionary<string, object?>>(responseBody)!;
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
    /// Export a list of child organizations (suborganizations) for a parent organization.
    /// </summary>
    /// <example><code>
    /// await client.Export.ExportOrganizationsAsync(
    ///     ExportFormat1.Csv,
    ///     123,
    ///     new ExportOrganizationsRequest
    ///     {
    ///         ColumnsExport = "BatchDate:Batch_Date,PaypointName:Legal_name",
    ///         FromRecord = 251,
    ///         LimitRecord = 1000,
    ///     }
    /// );
    /// </code></example>
    public async Task<Dictionary<string, object?>> ExportOrganizationsAsync(
        ExportFormat1 format,
        int orgId,
        ExportOrganizationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.ColumnsExport != null)
        {
            _query["columnsExport"] = request.ColumnsExport;
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
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "Export/organizations/{0}/org/{1}",
                        ValueConvert.ToPathParameterString(format),
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
                return JsonUtils.Deserialize<Dictionary<string, object?>>(responseBody)!;
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
    /// Export a list of payouts and their statuses for an entrypoint. Use filters to limit results.
    /// </summary>
    /// <example><code>
    /// await client.Export.ExportPayoutAsync(
    ///     "8cfec329267",
    ///     ExportFormat1.Csv,
    ///     new ExportPayoutRequest
    ///     {
    ///         ColumnsExport = "BatchDate:Batch_Date,PaypointName:Legal_name",
    ///         FromRecord = 251,
    ///         LimitRecord = 1000,
    ///     }
    /// );
    /// </code></example>
    public async Task<Dictionary<string, object?>> ExportPayoutAsync(
        ExportFormat1 format,
        string entry,
        ExportPayoutRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.ColumnsExport != null)
        {
            _query["columnsExport"] = request.ColumnsExport;
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
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "Export/payouts/{0}/{1}",
                        ValueConvert.ToPathParameterString(format),
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
                return JsonUtils.Deserialize<Dictionary<string, object?>>(responseBody)!;
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
    /// Export a list of payouts and their details for an organization. Use filters to limit results.
    /// </summary>
    /// <example><code>
    /// await client.Export.ExportPayoutOrgAsync(
    ///     ExportFormat1.Csv,
    ///     123,
    ///     new ExportPayoutOrgRequest
    ///     {
    ///         ColumnsExport = "BatchDate:Batch_Date,PaypointName:Legal_name",
    ///         FromRecord = 251,
    ///         LimitRecord = 1000,
    ///     }
    /// );
    /// </code></example>
    public async Task<Dictionary<string, object?>> ExportPayoutOrgAsync(
        ExportFormat1 format,
        int orgId,
        ExportPayoutOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.ColumnsExport != null)
        {
            _query["columnsExport"] = request.ColumnsExport;
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
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "Export/payouts/{0}/org/{1}",
                        ValueConvert.ToPathParameterString(format),
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
                return JsonUtils.Deserialize<Dictionary<string, object?>>(responseBody)!;
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
    /// Export a list of paypoints in an organization. Use filters to limit results.
    /// </summary>
    /// <example><code>
    /// await client.Export.ExportPaypointsAsync(
    ///     ExportFormat1.Csv,
    ///     123,
    ///     new ExportPaypointsRequest
    ///     {
    ///         ColumnsExport = "BatchDate:Batch_Date,PaypointName:Legal_name",
    ///         FromRecord = 251,
    ///         LimitRecord = 1000,
    ///     }
    /// );
    /// </code></example>
    public async Task<Dictionary<string, object?>> ExportPaypointsAsync(
        ExportFormat1 format,
        int orgId,
        ExportPaypointsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.ColumnsExport != null)
        {
            _query["columnsExport"] = request.ColumnsExport;
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
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "Export/paypoints/{0}/{1}",
                        ValueConvert.ToPathParameterString(format),
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
                return JsonUtils.Deserialize<Dictionary<string, object?>>(responseBody)!;
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
    /// Export a list of settled transactions for an entrypoint. Use filters to limit results.
    /// </summary>
    /// <example><code>
    /// await client.Export.ExportSettlementsAsync(
    ///     "8cfec329267",
    ///     ExportFormat1.Csv,
    ///     new ExportSettlementsRequest
    ///     {
    ///         ColumnsExport = "BatchDate:Batch_Date,PaypointName:Legal_name",
    ///         FromRecord = 251,
    ///         LimitRecord = 1000,
    ///     }
    /// );
    /// </code></example>
    public async Task<Dictionary<string, object?>> ExportSettlementsAsync(
        ExportFormat1 format,
        string entry,
        ExportSettlementsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.ColumnsExport != null)
        {
            _query["columnsExport"] = request.ColumnsExport;
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
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "Export/settlements/{0}/{1}",
                        ValueConvert.ToPathParameterString(format),
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
                return JsonUtils.Deserialize<Dictionary<string, object?>>(responseBody)!;
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
    /// Export a list of settled transactions for an organization. Use filters to limit results.
    /// </summary>
    /// <example><code>
    /// await client.Export.ExportSettlementsOrgAsync(
    ///     ExportFormat1.Csv,
    ///     123,
    ///     new ExportSettlementsOrgRequest
    ///     {
    ///         ColumnsExport = "BatchDate:Batch_Date,PaypointName:Legal_name",
    ///         FromRecord = 251,
    ///         LimitRecord = 1000,
    ///     }
    /// );
    /// </code></example>
    public async Task<Dictionary<string, object?>> ExportSettlementsOrgAsync(
        ExportFormat1 format,
        int orgId,
        ExportSettlementsOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.ColumnsExport != null)
        {
            _query["columnsExport"] = request.ColumnsExport;
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
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "Export/settlements/{0}/org/{1}",
                        ValueConvert.ToPathParameterString(format),
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
                return JsonUtils.Deserialize<Dictionary<string, object?>>(responseBody)!;
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
    /// Export a list of subscriptions for an entrypoint. Use filters to limit results.
    /// </summary>
    /// <example><code>
    /// await client.Export.ExportSubscriptionsAsync(
    ///     "8cfec329267",
    ///     ExportFormat1.Csv,
    ///     new ExportSubscriptionsRequest
    ///     {
    ///         ColumnsExport = "BatchDate:Batch_Date,PaypointName:Legal_name",
    ///         FromRecord = 251,
    ///         LimitRecord = 1000,
    ///     }
    /// );
    /// </code></example>
    public async Task<Dictionary<string, object?>> ExportSubscriptionsAsync(
        ExportFormat1 format,
        string entry,
        ExportSubscriptionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.ColumnsExport != null)
        {
            _query["columnsExport"] = request.ColumnsExport;
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
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "Export/subscriptions/{0}/{1}",
                        ValueConvert.ToPathParameterString(format),
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
                return JsonUtils.Deserialize<Dictionary<string, object?>>(responseBody)!;
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
    /// Export a list of subscriptions for an organization. Use filters to limit results.
    /// </summary>
    /// <example><code>
    /// await client.Export.ExportSubscriptionsOrgAsync(
    ///     ExportFormat1.Csv,
    ///     123,
    ///     new ExportSubscriptionsOrgRequest
    ///     {
    ///         ColumnsExport = "BatchDate:Batch_Date,PaypointName:Legal_name",
    ///         FromRecord = 251,
    ///         LimitRecord = 1000,
    ///     }
    /// );
    /// </code></example>
    public async Task<Dictionary<string, object?>> ExportSubscriptionsOrgAsync(
        ExportFormat1 format,
        int orgId,
        ExportSubscriptionsOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.ColumnsExport != null)
        {
            _query["columnsExport"] = request.ColumnsExport;
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
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "Export/subscriptions/{0}/org/{1}",
                        ValueConvert.ToPathParameterString(format),
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
                return JsonUtils.Deserialize<Dictionary<string, object?>>(responseBody)!;
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
    /// Export a list of transactions for an entrypoint in a file in XLXS or CSV format. Use filters to limit results. If you don't specify a date range in the request, the last two months of data are returned.
    /// </summary>
    /// <example><code>
    /// await client.Export.ExportTransactionsAsync(
    ///     "8cfec329267",
    ///     ExportFormat1.Csv,
    ///     new ExportTransactionsRequest
    ///     {
    ///         ColumnsExport = "BatchDate:Batch_Date,PaypointName:Legal_name",
    ///         FromRecord = 251,
    ///         LimitRecord = 1000,
    ///     }
    /// );
    /// </code></example>
    public async Task<Dictionary<string, object?>> ExportTransactionsAsync(
        ExportFormat1 format,
        string entry,
        ExportTransactionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.ColumnsExport != null)
        {
            _query["columnsExport"] = request.ColumnsExport;
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
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "Export/transactions/{0}/{1}",
                        ValueConvert.ToPathParameterString(format),
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
                return JsonUtils.Deserialize<Dictionary<string, object?>>(responseBody)!;
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
    /// Export a list of transactions for an org in a file in XLSX or CSV format. Use filters to limit results. If you don't specify a date range in the request, the last two months of data are returned.
    /// </summary>
    /// <example><code>
    /// await client.Export.ExportTransactionsOrgAsync(
    ///     ExportFormat1.Csv,
    ///     123,
    ///     new ExportTransactionsOrgRequest
    ///     {
    ///         ColumnsExport = "BatchDate:Batch_Date,PaypointName:Legal_name",
    ///         FromRecord = 251,
    ///         LimitRecord = 1000,
    ///     }
    /// );
    /// </code></example>
    public async Task<Dictionary<string, object?>> ExportTransactionsOrgAsync(
        ExportFormat1 format,
        int orgId,
        ExportTransactionsOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.ColumnsExport != null)
        {
            _query["columnsExport"] = request.ColumnsExport;
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
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "Export/transactions/{0}/org/{1}",
                        ValueConvert.ToPathParameterString(format),
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
                return JsonUtils.Deserialize<Dictionary<string, object?>>(responseBody)!;
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
    /// Export a list of transfer details for an entrypoint. Use filters to limit results.
    /// </summary>
    /// <example><code>
    /// await client.Export.ExportTransferDetailsAsync(
    ///     "8cfec329267",
    ///     ExportFormat1.Csv,
    ///     1000000,
    ///     new ExportTransferDetailsRequest
    ///     {
    ///         ColumnsExport = "BatchDate:Batch_Date,PaypointName:Legal_name",
    ///         FromRecord = 251,
    ///         LimitRecord = 1000,
    ///         SortBy = "desc(field_name)",
    ///     }
    /// );
    /// </code></example>
    public async Task<Dictionary<string, object?>> ExportTransferDetailsAsync(
        ExportFormat1 format,
        string entry,
        long transferId,
        ExportTransferDetailsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.ColumnsExport != null)
        {
            _query["columnsExport"] = request.ColumnsExport;
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
                        "Export/transferDetails/{0}/{1}/{2}",
                        ValueConvert.ToPathParameterString(format),
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
                return JsonUtils.Deserialize<Dictionary<string, object?>>(responseBody)!;
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
    /// Get a list of transfers for an entrypoint. Use filters to limit results.
    /// </summary>
    /// <example><code>
    /// await client.Export.ExportTransfersAsync(
    ///     "8cfec329267",
    ///     new ExportTransfersRequest
    ///     {
    ///         ColumnsExport = "BatchDate:Batch_Date,PaypointName:Legal_name",
    ///         FromRecord = 251,
    ///         LimitRecord = 1000,
    ///         SortBy = "desc(field_name)",
    ///     }
    /// );
    /// </code></example>
    public async Task<Dictionary<string, object?>> ExportTransfersAsync(
        string entry,
        ExportTransfersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.ColumnsExport != null)
        {
            _query["columnsExport"] = request.ColumnsExport;
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
                        "Export/transfers/{0}",
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
                return JsonUtils.Deserialize<Dictionary<string, object?>>(responseBody)!;
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
    /// Export a list of vendors for an entrypoint. Use filters to limit results.
    /// </summary>
    /// <example><code>
    /// await client.Export.ExportVendorsAsync(
    ///     "8cfec329267",
    ///     ExportFormat1.Csv,
    ///     new ExportVendorsRequest
    ///     {
    ///         ColumnsExport = "BatchDate:Batch_Date,PaypointName:Legal_name",
    ///         FromRecord = 251,
    ///         LimitRecord = 1000,
    ///     }
    /// );
    /// </code></example>
    public async Task<Dictionary<string, object?>> ExportVendorsAsync(
        ExportFormat1 format,
        string entry,
        ExportVendorsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.ColumnsExport != null)
        {
            _query["columnsExport"] = request.ColumnsExport;
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
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "Export/vendors/{0}/{1}",
                        ValueConvert.ToPathParameterString(format),
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
                return JsonUtils.Deserialize<Dictionary<string, object?>>(responseBody)!;
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
    /// Export a list of vendors for an organization. Use filters to limit results.
    /// </summary>
    /// <example><code>
    /// await client.Export.ExportVendorsOrgAsync(
    ///     ExportFormat1.Csv,
    ///     123,
    ///     new ExportVendorsOrgRequest
    ///     {
    ///         ColumnsExport = "BatchDate:Batch_Date,PaypointName:Legal_name",
    ///         FromRecord = 251,
    ///         LimitRecord = 1000,
    ///     }
    /// );
    /// </code></example>
    public async Task<Dictionary<string, object?>> ExportVendorsOrgAsync(
        ExportFormat1 format,
        int orgId,
        ExportVendorsOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.ColumnsExport != null)
        {
            _query["columnsExport"] = request.ColumnsExport;
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
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "Export/vendors/{0}/org/{1}",
                        ValueConvert.ToPathParameterString(format),
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
                return JsonUtils.Deserialize<Dictionary<string, object?>>(responseBody)!;
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
}
