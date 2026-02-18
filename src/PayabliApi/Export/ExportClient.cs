using System.Text.Json;
using PayabliApi.Core;

namespace PayabliApi;

public partial class ExportClient : IExportClient
{
    private RawClient _client;

    internal ExportClient(RawClient client)
    {
        _client = client;
    }

    private async Task<WithRawResponse<Dictionary<string, object?>>> ExportApplicationsAsyncCore(
        ExportFormat1 format,
        int orgId,
        ExportApplicationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new PayabliApi.Core.QueryStringBuilder.Builder(capacity: 4)
            .Add("columnsExport", request.ColumnsExport)
            .Add("fromRecord", request.FromRecord)
            .Add("limitRecord", request.LimitRecord)
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
                        "Export/boarding/{0}/{1}",
                        ValueConvert.ToPathParameterString(format),
                        ValueConvert.ToPathParameterString(orgId)
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
                var responseData = JsonUtils.Deserialize<Dictionary<string, object?>>(
                    responseBody
                )!;
                return new WithRawResponse<Dictionary<string, object?>>()
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

    private async Task<WithRawResponse<Dictionary<string, object?>>> ExportBatchDetailsAsyncCore(
        ExportFormat1 format,
        string entry,
        ExportBatchDetailsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new PayabliApi.Core.QueryStringBuilder.Builder(capacity: 4)
            .Add("columnsExport", request.ColumnsExport)
            .Add("fromRecord", request.FromRecord)
            .Add("limitRecord", request.LimitRecord)
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
                        "Export/batchDetails/{0}/{1}",
                        ValueConvert.ToPathParameterString(format),
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
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                var responseData = JsonUtils.Deserialize<Dictionary<string, object?>>(
                    responseBody
                )!;
                return new WithRawResponse<Dictionary<string, object?>>()
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

    private async Task<WithRawResponse<Dictionary<string, object?>>> ExportBatchDetailsOrgAsyncCore(
        ExportFormat1 format,
        int orgId,
        ExportBatchDetailsOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new PayabliApi.Core.QueryStringBuilder.Builder(capacity: 4)
            .Add("columnsExport", request.ColumnsExport)
            .Add("fromRecord", request.FromRecord)
            .Add("limitRecord", request.LimitRecord)
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
                        "Export/batchDetails/{0}/org/{1}",
                        ValueConvert.ToPathParameterString(format),
                        ValueConvert.ToPathParameterString(orgId)
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
                var responseData = JsonUtils.Deserialize<Dictionary<string, object?>>(
                    responseBody
                )!;
                return new WithRawResponse<Dictionary<string, object?>>()
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

    private async Task<WithRawResponse<Dictionary<string, object?>>> ExportBatchesAsyncCore(
        ExportFormat1 format,
        string entry,
        ExportBatchesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new PayabliApi.Core.QueryStringBuilder.Builder(capacity: 4)
            .Add("columnsExport", request.ColumnsExport)
            .Add("fromRecord", request.FromRecord)
            .Add("limitRecord", request.LimitRecord)
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
                        "Export/batches/{0}/{1}",
                        ValueConvert.ToPathParameterString(format),
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
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                var responseData = JsonUtils.Deserialize<Dictionary<string, object?>>(
                    responseBody
                )!;
                return new WithRawResponse<Dictionary<string, object?>>()
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

    private async Task<WithRawResponse<Dictionary<string, object?>>> ExportBatchesOrgAsyncCore(
        ExportFormat1 format,
        int orgId,
        ExportBatchesOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new PayabliApi.Core.QueryStringBuilder.Builder(capacity: 4)
            .Add("columnsExport", request.ColumnsExport)
            .Add("fromRecord", request.FromRecord)
            .Add("limitRecord", request.LimitRecord)
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
                        "Export/batches/{0}/org/{1}",
                        ValueConvert.ToPathParameterString(format),
                        ValueConvert.ToPathParameterString(orgId)
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
                var responseData = JsonUtils.Deserialize<Dictionary<string, object?>>(
                    responseBody
                )!;
                return new WithRawResponse<Dictionary<string, object?>>()
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

    private async Task<WithRawResponse<Dictionary<string, object?>>> ExportBatchesOutAsyncCore(
        ExportFormat1 format,
        string entry,
        ExportBatchesOutRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new PayabliApi.Core.QueryStringBuilder.Builder(capacity: 4)
            .Add("columnsExport", request.ColumnsExport)
            .Add("fromRecord", request.FromRecord)
            .Add("limitRecord", request.LimitRecord)
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
                        "Export/batchesOut/{0}/{1}",
                        ValueConvert.ToPathParameterString(format),
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
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                var responseData = JsonUtils.Deserialize<Dictionary<string, object?>>(
                    responseBody
                )!;
                return new WithRawResponse<Dictionary<string, object?>>()
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

    private async Task<WithRawResponse<Dictionary<string, object?>>> ExportBatchesOutOrgAsyncCore(
        ExportFormat1 format,
        int orgId,
        ExportBatchesOutOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new PayabliApi.Core.QueryStringBuilder.Builder(capacity: 4)
            .Add("columnsExport", request.ColumnsExport)
            .Add("fromRecord", request.FromRecord)
            .Add("limitRecord", request.LimitRecord)
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
                        "Export/batchesOut/{0}/org/{1}",
                        ValueConvert.ToPathParameterString(format),
                        ValueConvert.ToPathParameterString(orgId)
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
                var responseData = JsonUtils.Deserialize<Dictionary<string, object?>>(
                    responseBody
                )!;
                return new WithRawResponse<Dictionary<string, object?>>()
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

    private async Task<WithRawResponse<Dictionary<string, object?>>> ExportBillsAsyncCore(
        ExportFormat1 format,
        string entry,
        ExportBillsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new PayabliApi.Core.QueryStringBuilder.Builder(capacity: 4)
            .Add("columnsExport", request.ColumnsExport)
            .Add("fromRecord", request.FromRecord)
            .Add("limitRecord", request.LimitRecord)
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
                        "Export/bills/{0}/{1}",
                        ValueConvert.ToPathParameterString(format),
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
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                var responseData = JsonUtils.Deserialize<Dictionary<string, object?>>(
                    responseBody
                )!;
                return new WithRawResponse<Dictionary<string, object?>>()
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

    private async Task<WithRawResponse<Dictionary<string, object?>>> ExportBillsOrgAsyncCore(
        ExportFormat1 format,
        int orgId,
        ExportBillsOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new PayabliApi.Core.QueryStringBuilder.Builder(capacity: 4)
            .Add("columnsExport", request.ColumnsExport)
            .Add("fromRecord", request.FromRecord)
            .Add("limitRecord", request.LimitRecord)
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
                        "Export/bills/{0}/org/{1}",
                        ValueConvert.ToPathParameterString(format),
                        ValueConvert.ToPathParameterString(orgId)
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
                var responseData = JsonUtils.Deserialize<Dictionary<string, object?>>(
                    responseBody
                )!;
                return new WithRawResponse<Dictionary<string, object?>>()
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

    private async Task<WithRawResponse<Dictionary<string, object?>>> ExportChargebacksAsyncCore(
        ExportFormat1 format,
        string entry,
        ExportChargebacksRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new PayabliApi.Core.QueryStringBuilder.Builder(capacity: 4)
            .Add("columnsExport", request.ColumnsExport)
            .Add("fromRecord", request.FromRecord)
            .Add("limitRecord", request.LimitRecord)
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
                        "Export/chargebacks/{0}/{1}",
                        ValueConvert.ToPathParameterString(format),
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
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                var responseData = JsonUtils.Deserialize<Dictionary<string, object?>>(
                    responseBody
                )!;
                return new WithRawResponse<Dictionary<string, object?>>()
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

    private async Task<WithRawResponse<Dictionary<string, object?>>> ExportChargebacksOrgAsyncCore(
        ExportFormat1 format,
        int orgId,
        ExportChargebacksOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new PayabliApi.Core.QueryStringBuilder.Builder(capacity: 4)
            .Add("columnsExport", request.ColumnsExport)
            .Add("fromRecord", request.FromRecord)
            .Add("limitRecord", request.LimitRecord)
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
                        "Export/chargebacks/{0}/org/{1}",
                        ValueConvert.ToPathParameterString(format),
                        ValueConvert.ToPathParameterString(orgId)
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
                var responseData = JsonUtils.Deserialize<Dictionary<string, object?>>(
                    responseBody
                )!;
                return new WithRawResponse<Dictionary<string, object?>>()
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

    private async Task<WithRawResponse<Dictionary<string, object?>>> ExportCustomersAsyncCore(
        ExportFormat1 format,
        string entry,
        ExportCustomersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new PayabliApi.Core.QueryStringBuilder.Builder(capacity: 4)
            .Add("columnsExport", request.ColumnsExport)
            .Add("fromRecord", request.FromRecord)
            .Add("limitRecord", request.LimitRecord)
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
                        "Export/customers/{0}/{1}",
                        ValueConvert.ToPathParameterString(format),
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
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                var responseData = JsonUtils.Deserialize<Dictionary<string, object?>>(
                    responseBody
                )!;
                return new WithRawResponse<Dictionary<string, object?>>()
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

    private async Task<WithRawResponse<Dictionary<string, object?>>> ExportCustomersOrgAsyncCore(
        ExportFormat1 format,
        int orgId,
        ExportCustomersOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new PayabliApi.Core.QueryStringBuilder.Builder(capacity: 4)
            .Add("columnsExport", request.ColumnsExport)
            .Add("fromRecord", request.FromRecord)
            .Add("limitRecord", request.LimitRecord)
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
                        "Export/customers/{0}/org/{1}",
                        ValueConvert.ToPathParameterString(format),
                        ValueConvert.ToPathParameterString(orgId)
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
                var responseData = JsonUtils.Deserialize<Dictionary<string, object?>>(
                    responseBody
                )!;
                return new WithRawResponse<Dictionary<string, object?>>()
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

    private async Task<WithRawResponse<Dictionary<string, object?>>> ExportInvoicesAsyncCore(
        ExportFormat1 format,
        string entry,
        ExportInvoicesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new PayabliApi.Core.QueryStringBuilder.Builder(capacity: 4)
            .Add("columnsExport", request.ColumnsExport)
            .Add("fromRecord", request.FromRecord)
            .Add("limitRecord", request.LimitRecord)
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
                        "Export/invoices/{0}/{1}",
                        ValueConvert.ToPathParameterString(format),
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
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                var responseData = JsonUtils.Deserialize<Dictionary<string, object?>>(
                    responseBody
                )!;
                return new WithRawResponse<Dictionary<string, object?>>()
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

    private async Task<WithRawResponse<Dictionary<string, object?>>> ExportInvoicesOrgAsyncCore(
        ExportFormat1 format,
        int orgId,
        ExportInvoicesOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new PayabliApi.Core.QueryStringBuilder.Builder(capacity: 4)
            .Add("columnsExport", request.ColumnsExport)
            .Add("fromRecord", request.FromRecord)
            .Add("limitRecord", request.LimitRecord)
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
                        "Export/invoices/{0}/org/{1}",
                        ValueConvert.ToPathParameterString(format),
                        ValueConvert.ToPathParameterString(orgId)
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
                var responseData = JsonUtils.Deserialize<Dictionary<string, object?>>(
                    responseBody
                )!;
                return new WithRawResponse<Dictionary<string, object?>>()
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

    private async Task<WithRawResponse<Dictionary<string, object?>>> ExportOrganizationsAsyncCore(
        ExportFormat1 format,
        int orgId,
        ExportOrganizationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new PayabliApi.Core.QueryStringBuilder.Builder(capacity: 4)
            .Add("columnsExport", request.ColumnsExport)
            .Add("fromRecord", request.FromRecord)
            .Add("limitRecord", request.LimitRecord)
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
                        "Export/organizations/{0}/org/{1}",
                        ValueConvert.ToPathParameterString(format),
                        ValueConvert.ToPathParameterString(orgId)
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
                var responseData = JsonUtils.Deserialize<Dictionary<string, object?>>(
                    responseBody
                )!;
                return new WithRawResponse<Dictionary<string, object?>>()
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

    private async Task<WithRawResponse<Dictionary<string, object?>>> ExportPayoutAsyncCore(
        ExportFormat1 format,
        string entry,
        ExportPayoutRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new PayabliApi.Core.QueryStringBuilder.Builder(capacity: 4)
            .Add("columnsExport", request.ColumnsExport)
            .Add("fromRecord", request.FromRecord)
            .Add("limitRecord", request.LimitRecord)
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
                        "Export/payouts/{0}/{1}",
                        ValueConvert.ToPathParameterString(format),
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
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                var responseData = JsonUtils.Deserialize<Dictionary<string, object?>>(
                    responseBody
                )!;
                return new WithRawResponse<Dictionary<string, object?>>()
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

    private async Task<WithRawResponse<Dictionary<string, object?>>> ExportPayoutOrgAsyncCore(
        ExportFormat1 format,
        int orgId,
        ExportPayoutOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new PayabliApi.Core.QueryStringBuilder.Builder(capacity: 4)
            .Add("columnsExport", request.ColumnsExport)
            .Add("fromRecord", request.FromRecord)
            .Add("limitRecord", request.LimitRecord)
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
                        "Export/payouts/{0}/org/{1}",
                        ValueConvert.ToPathParameterString(format),
                        ValueConvert.ToPathParameterString(orgId)
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
                var responseData = JsonUtils.Deserialize<Dictionary<string, object?>>(
                    responseBody
                )!;
                return new WithRawResponse<Dictionary<string, object?>>()
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

    private async Task<WithRawResponse<Dictionary<string, object?>>> ExportPaypointsAsyncCore(
        ExportFormat1 format,
        int orgId,
        ExportPaypointsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new PayabliApi.Core.QueryStringBuilder.Builder(capacity: 4)
            .Add("columnsExport", request.ColumnsExport)
            .Add("fromRecord", request.FromRecord)
            .Add("limitRecord", request.LimitRecord)
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
                        "Export/paypoints/{0}/{1}",
                        ValueConvert.ToPathParameterString(format),
                        ValueConvert.ToPathParameterString(orgId)
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
                var responseData = JsonUtils.Deserialize<Dictionary<string, object?>>(
                    responseBody
                )!;
                return new WithRawResponse<Dictionary<string, object?>>()
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

    private async Task<WithRawResponse<Dictionary<string, object?>>> ExportSettlementsAsyncCore(
        ExportFormat1 format,
        string entry,
        ExportSettlementsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new PayabliApi.Core.QueryStringBuilder.Builder(capacity: 4)
            .Add("columnsExport", request.ColumnsExport)
            .Add("fromRecord", request.FromRecord)
            .Add("limitRecord", request.LimitRecord)
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
                        "Export/settlements/{0}/{1}",
                        ValueConvert.ToPathParameterString(format),
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
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                var responseData = JsonUtils.Deserialize<Dictionary<string, object?>>(
                    responseBody
                )!;
                return new WithRawResponse<Dictionary<string, object?>>()
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

    private async Task<WithRawResponse<Dictionary<string, object?>>> ExportSettlementsOrgAsyncCore(
        ExportFormat1 format,
        int orgId,
        ExportSettlementsOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new PayabliApi.Core.QueryStringBuilder.Builder(capacity: 4)
            .Add("columnsExport", request.ColumnsExport)
            .Add("fromRecord", request.FromRecord)
            .Add("limitRecord", request.LimitRecord)
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
                        "Export/settlements/{0}/org/{1}",
                        ValueConvert.ToPathParameterString(format),
                        ValueConvert.ToPathParameterString(orgId)
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
                var responseData = JsonUtils.Deserialize<Dictionary<string, object?>>(
                    responseBody
                )!;
                return new WithRawResponse<Dictionary<string, object?>>()
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

    private async Task<WithRawResponse<Dictionary<string, object?>>> ExportSubscriptionsAsyncCore(
        ExportFormat1 format,
        string entry,
        ExportSubscriptionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new PayabliApi.Core.QueryStringBuilder.Builder(capacity: 4)
            .Add("columnsExport", request.ColumnsExport)
            .Add("fromRecord", request.FromRecord)
            .Add("limitRecord", request.LimitRecord)
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
                        "Export/subscriptions/{0}/{1}",
                        ValueConvert.ToPathParameterString(format),
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
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                var responseData = JsonUtils.Deserialize<Dictionary<string, object?>>(
                    responseBody
                )!;
                return new WithRawResponse<Dictionary<string, object?>>()
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
        WithRawResponse<Dictionary<string, object?>>
    > ExportSubscriptionsOrgAsyncCore(
        ExportFormat1 format,
        int orgId,
        ExportSubscriptionsOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new PayabliApi.Core.QueryStringBuilder.Builder(capacity: 4)
            .Add("columnsExport", request.ColumnsExport)
            .Add("fromRecord", request.FromRecord)
            .Add("limitRecord", request.LimitRecord)
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
                        "Export/subscriptions/{0}/org/{1}",
                        ValueConvert.ToPathParameterString(format),
                        ValueConvert.ToPathParameterString(orgId)
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
                var responseData = JsonUtils.Deserialize<Dictionary<string, object?>>(
                    responseBody
                )!;
                return new WithRawResponse<Dictionary<string, object?>>()
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

    private async Task<WithRawResponse<Dictionary<string, object?>>> ExportTransactionsAsyncCore(
        ExportFormat1 format,
        string entry,
        ExportTransactionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new PayabliApi.Core.QueryStringBuilder.Builder(capacity: 4)
            .Add("columnsExport", request.ColumnsExport)
            .Add("fromRecord", request.FromRecord)
            .Add("limitRecord", request.LimitRecord)
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
                        "Export/transactions/{0}/{1}",
                        ValueConvert.ToPathParameterString(format),
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
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                var responseData = JsonUtils.Deserialize<Dictionary<string, object?>>(
                    responseBody
                )!;
                return new WithRawResponse<Dictionary<string, object?>>()
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

    private async Task<WithRawResponse<Dictionary<string, object?>>> ExportTransactionsOrgAsyncCore(
        ExportFormat1 format,
        int orgId,
        ExportTransactionsOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new PayabliApi.Core.QueryStringBuilder.Builder(capacity: 4)
            .Add("columnsExport", request.ColumnsExport)
            .Add("fromRecord", request.FromRecord)
            .Add("limitRecord", request.LimitRecord)
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
                        "Export/transactions/{0}/org/{1}",
                        ValueConvert.ToPathParameterString(format),
                        ValueConvert.ToPathParameterString(orgId)
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
                var responseData = JsonUtils.Deserialize<Dictionary<string, object?>>(
                    responseBody
                )!;
                return new WithRawResponse<Dictionary<string, object?>>()
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

    private async Task<WithRawResponse<Dictionary<string, object?>>> ExportTransferDetailsAsyncCore(
        ExportFormat1 format,
        string entry,
        long transferId,
        ExportTransferDetailsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new PayabliApi.Core.QueryStringBuilder.Builder(capacity: 5)
            .Add("columnsExport", request.ColumnsExport)
            .Add("fromRecord", request.FromRecord)
            .Add("limitRecord", request.LimitRecord)
            .Add("parameters", request.Parameters)
            .Add("sortBy", request.SortBy)
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
                        "Export/transferDetails/{0}/{1}/{2}",
                        ValueConvert.ToPathParameterString(format),
                        ValueConvert.ToPathParameterString(entry),
                        ValueConvert.ToPathParameterString(transferId)
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
                var responseData = JsonUtils.Deserialize<Dictionary<string, object?>>(
                    responseBody
                )!;
                return new WithRawResponse<Dictionary<string, object?>>()
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

    private async Task<WithRawResponse<Dictionary<string, object?>>> ExportTransfersAsyncCore(
        string entry,
        ExportTransfersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new PayabliApi.Core.QueryStringBuilder.Builder(capacity: 5)
            .Add("columnsExport", request.ColumnsExport)
            .Add("fromRecord", request.FromRecord)
            .Add("limitRecord", request.LimitRecord)
            .Add("parameters", request.Parameters)
            .Add("sortBy", request.SortBy)
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
                        "Export/transfers/{0}",
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
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                var responseData = JsonUtils.Deserialize<Dictionary<string, object?>>(
                    responseBody
                )!;
                return new WithRawResponse<Dictionary<string, object?>>()
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

    private async Task<WithRawResponse<Dictionary<string, object?>>> ExportVendorsAsyncCore(
        ExportFormat1 format,
        string entry,
        ExportVendorsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new PayabliApi.Core.QueryStringBuilder.Builder(capacity: 4)
            .Add("columnsExport", request.ColumnsExport)
            .Add("fromRecord", request.FromRecord)
            .Add("limitRecord", request.LimitRecord)
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
                        "Export/vendors/{0}/{1}",
                        ValueConvert.ToPathParameterString(format),
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
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                var responseData = JsonUtils.Deserialize<Dictionary<string, object?>>(
                    responseBody
                )!;
                return new WithRawResponse<Dictionary<string, object?>>()
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

    private async Task<WithRawResponse<Dictionary<string, object?>>> ExportVendorsOrgAsyncCore(
        ExportFormat1 format,
        int orgId,
        ExportVendorsOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new PayabliApi.Core.QueryStringBuilder.Builder(capacity: 4)
            .Add("columnsExport", request.ColumnsExport)
            .Add("fromRecord", request.FromRecord)
            .Add("limitRecord", request.LimitRecord)
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
                        "Export/vendors/{0}/org/{1}",
                        ValueConvert.ToPathParameterString(format),
                        ValueConvert.ToPathParameterString(orgId)
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
                var responseData = JsonUtils.Deserialize<Dictionary<string, object?>>(
                    responseBody
                )!;
                return new WithRawResponse<Dictionary<string, object?>>()
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
    public WithRawResponseTask<Dictionary<string, object?>> ExportApplicationsAsync(
        ExportFormat1 format,
        int orgId,
        ExportApplicationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<Dictionary<string, object?>>(
            ExportApplicationsAsyncCore(format, orgId, request, options, cancellationToken)
        );
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
    public WithRawResponseTask<Dictionary<string, object?>> ExportBatchDetailsAsync(
        ExportFormat1 format,
        string entry,
        ExportBatchDetailsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<Dictionary<string, object?>>(
            ExportBatchDetailsAsyncCore(format, entry, request, options, cancellationToken)
        );
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
    public WithRawResponseTask<Dictionary<string, object?>> ExportBatchDetailsOrgAsync(
        ExportFormat1 format,
        int orgId,
        ExportBatchDetailsOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<Dictionary<string, object?>>(
            ExportBatchDetailsOrgAsyncCore(format, orgId, request, options, cancellationToken)
        );
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
    public WithRawResponseTask<Dictionary<string, object?>> ExportBatchesAsync(
        ExportFormat1 format,
        string entry,
        ExportBatchesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<Dictionary<string, object?>>(
            ExportBatchesAsyncCore(format, entry, request, options, cancellationToken)
        );
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
    public WithRawResponseTask<Dictionary<string, object?>> ExportBatchesOrgAsync(
        ExportFormat1 format,
        int orgId,
        ExportBatchesOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<Dictionary<string, object?>>(
            ExportBatchesOrgAsyncCore(format, orgId, request, options, cancellationToken)
        );
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
    public WithRawResponseTask<Dictionary<string, object?>> ExportBatchesOutAsync(
        ExportFormat1 format,
        string entry,
        ExportBatchesOutRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<Dictionary<string, object?>>(
            ExportBatchesOutAsyncCore(format, entry, request, options, cancellationToken)
        );
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
    public WithRawResponseTask<Dictionary<string, object?>> ExportBatchesOutOrgAsync(
        ExportFormat1 format,
        int orgId,
        ExportBatchesOutOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<Dictionary<string, object?>>(
            ExportBatchesOutOrgAsyncCore(format, orgId, request, options, cancellationToken)
        );
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
    public WithRawResponseTask<Dictionary<string, object?>> ExportBillsAsync(
        ExportFormat1 format,
        string entry,
        ExportBillsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<Dictionary<string, object?>>(
            ExportBillsAsyncCore(format, entry, request, options, cancellationToken)
        );
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
    public WithRawResponseTask<Dictionary<string, object?>> ExportBillsOrgAsync(
        ExportFormat1 format,
        int orgId,
        ExportBillsOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<Dictionary<string, object?>>(
            ExportBillsOrgAsyncCore(format, orgId, request, options, cancellationToken)
        );
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
    public WithRawResponseTask<Dictionary<string, object?>> ExportChargebacksAsync(
        ExportFormat1 format,
        string entry,
        ExportChargebacksRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<Dictionary<string, object?>>(
            ExportChargebacksAsyncCore(format, entry, request, options, cancellationToken)
        );
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
    public WithRawResponseTask<Dictionary<string, object?>> ExportChargebacksOrgAsync(
        ExportFormat1 format,
        int orgId,
        ExportChargebacksOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<Dictionary<string, object?>>(
            ExportChargebacksOrgAsyncCore(format, orgId, request, options, cancellationToken)
        );
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
    public WithRawResponseTask<Dictionary<string, object?>> ExportCustomersAsync(
        ExportFormat1 format,
        string entry,
        ExportCustomersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<Dictionary<string, object?>>(
            ExportCustomersAsyncCore(format, entry, request, options, cancellationToken)
        );
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
    public WithRawResponseTask<Dictionary<string, object?>> ExportCustomersOrgAsync(
        ExportFormat1 format,
        int orgId,
        ExportCustomersOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<Dictionary<string, object?>>(
            ExportCustomersOrgAsyncCore(format, orgId, request, options, cancellationToken)
        );
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
    public WithRawResponseTask<Dictionary<string, object?>> ExportInvoicesAsync(
        ExportFormat1 format,
        string entry,
        ExportInvoicesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<Dictionary<string, object?>>(
            ExportInvoicesAsyncCore(format, entry, request, options, cancellationToken)
        );
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
    public WithRawResponseTask<Dictionary<string, object?>> ExportInvoicesOrgAsync(
        ExportFormat1 format,
        int orgId,
        ExportInvoicesOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<Dictionary<string, object?>>(
            ExportInvoicesOrgAsyncCore(format, orgId, request, options, cancellationToken)
        );
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
    public WithRawResponseTask<Dictionary<string, object?>> ExportOrganizationsAsync(
        ExportFormat1 format,
        int orgId,
        ExportOrganizationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<Dictionary<string, object?>>(
            ExportOrganizationsAsyncCore(format, orgId, request, options, cancellationToken)
        );
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
    public WithRawResponseTask<Dictionary<string, object?>> ExportPayoutAsync(
        ExportFormat1 format,
        string entry,
        ExportPayoutRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<Dictionary<string, object?>>(
            ExportPayoutAsyncCore(format, entry, request, options, cancellationToken)
        );
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
    public WithRawResponseTask<Dictionary<string, object?>> ExportPayoutOrgAsync(
        ExportFormat1 format,
        int orgId,
        ExportPayoutOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<Dictionary<string, object?>>(
            ExportPayoutOrgAsyncCore(format, orgId, request, options, cancellationToken)
        );
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
    public WithRawResponseTask<Dictionary<string, object?>> ExportPaypointsAsync(
        ExportFormat1 format,
        int orgId,
        ExportPaypointsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<Dictionary<string, object?>>(
            ExportPaypointsAsyncCore(format, orgId, request, options, cancellationToken)
        );
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
    public WithRawResponseTask<Dictionary<string, object?>> ExportSettlementsAsync(
        ExportFormat1 format,
        string entry,
        ExportSettlementsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<Dictionary<string, object?>>(
            ExportSettlementsAsyncCore(format, entry, request, options, cancellationToken)
        );
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
    public WithRawResponseTask<Dictionary<string, object?>> ExportSettlementsOrgAsync(
        ExportFormat1 format,
        int orgId,
        ExportSettlementsOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<Dictionary<string, object?>>(
            ExportSettlementsOrgAsyncCore(format, orgId, request, options, cancellationToken)
        );
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
    public WithRawResponseTask<Dictionary<string, object?>> ExportSubscriptionsAsync(
        ExportFormat1 format,
        string entry,
        ExportSubscriptionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<Dictionary<string, object?>>(
            ExportSubscriptionsAsyncCore(format, entry, request, options, cancellationToken)
        );
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
    public WithRawResponseTask<Dictionary<string, object?>> ExportSubscriptionsOrgAsync(
        ExportFormat1 format,
        int orgId,
        ExportSubscriptionsOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<Dictionary<string, object?>>(
            ExportSubscriptionsOrgAsyncCore(format, orgId, request, options, cancellationToken)
        );
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
    public WithRawResponseTask<Dictionary<string, object?>> ExportTransactionsAsync(
        ExportFormat1 format,
        string entry,
        ExportTransactionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<Dictionary<string, object?>>(
            ExportTransactionsAsyncCore(format, entry, request, options, cancellationToken)
        );
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
    public WithRawResponseTask<Dictionary<string, object?>> ExportTransactionsOrgAsync(
        ExportFormat1 format,
        int orgId,
        ExportTransactionsOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<Dictionary<string, object?>>(
            ExportTransactionsOrgAsyncCore(format, orgId, request, options, cancellationToken)
        );
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
    public WithRawResponseTask<Dictionary<string, object?>> ExportTransferDetailsAsync(
        ExportFormat1 format,
        string entry,
        long transferId,
        ExportTransferDetailsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<Dictionary<string, object?>>(
            ExportTransferDetailsAsyncCore(
                format,
                entry,
                transferId,
                request,
                options,
                cancellationToken
            )
        );
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
    public WithRawResponseTask<Dictionary<string, object?>> ExportTransfersAsync(
        string entry,
        ExportTransfersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<Dictionary<string, object?>>(
            ExportTransfersAsyncCore(entry, request, options, cancellationToken)
        );
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
    public WithRawResponseTask<Dictionary<string, object?>> ExportVendorsAsync(
        ExportFormat1 format,
        string entry,
        ExportVendorsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<Dictionary<string, object?>>(
            ExportVendorsAsyncCore(format, entry, request, options, cancellationToken)
        );
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
    public WithRawResponseTask<Dictionary<string, object?>> ExportVendorsOrgAsync(
        ExportFormat1 format,
        int orgId,
        ExportVendorsOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<Dictionary<string, object?>>(
            ExportVendorsOrgAsyncCore(format, orgId, request, options, cancellationToken)
        );
    }
}
