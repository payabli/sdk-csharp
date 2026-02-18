using System.Text.Json;
using PayabliApi.Core;

namespace PayabliApi;

public partial class BillClient : IBillClient
{
    private RawClient _client;

    internal BillClient(RawClient client)
    {
        _client = client;
    }

    private async Task<WithRawResponse<BillResponse>> AddBillAsyncCore(
        string entry,
        AddBillRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _headers = await new PayabliApi.Core.HeadersBuilder.Builder()
            .Add("idempotencyKey", request.IdempotencyKey)
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
                    Path = string.Format(
                        "Bill/single/{0}",
                        ValueConvert.ToPathParameterString(entry)
                    ),
                    Body = request.Body,
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
                var responseData = JsonUtils.Deserialize<BillResponse>(responseBody)!;
                return new WithRawResponse<BillResponse>()
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

    private async Task<WithRawResponse<BillResponse>> DeleteAttachedFromBillAsyncCore(
        int idBill,
        string filename,
        DeleteAttachedFromBillRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new PayabliApi.Core.QueryStringBuilder.Builder(capacity: 1)
            .Add("returnObject", request.ReturnObject)
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
                    Method = HttpMethod.Delete,
                    Path = string.Format(
                        "Bill/attachedFileFromBill/{0}/{1}",
                        ValueConvert.ToPathParameterString(idBill),
                        ValueConvert.ToPathParameterString(filename)
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
                var responseData = JsonUtils.Deserialize<BillResponse>(responseBody)!;
                return new WithRawResponse<BillResponse>()
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

    private async Task<WithRawResponse<BillResponse>> DeleteBillAsyncCore(
        int idBill,
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
                    Method = HttpMethod.Delete,
                    Path = string.Format("Bill/{0}", ValueConvert.ToPathParameterString(idBill)),
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
                var responseData = JsonUtils.Deserialize<BillResponse>(responseBody)!;
                return new WithRawResponse<BillResponse>()
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

    private async Task<WithRawResponse<EditBillResponse>> EditBillAsyncCore(
        int idBill,
        BillOutData request,
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
                    Method = HttpMethod.Put,
                    Path = string.Format("Bill/{0}", ValueConvert.ToPathParameterString(idBill)),
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
                var responseData = JsonUtils.Deserialize<EditBillResponse>(responseBody)!;
                return new WithRawResponse<EditBillResponse>()
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

    private async Task<WithRawResponse<FileContent>> GetAttachedFromBillAsyncCore(
        int idBill,
        string filename,
        GetAttachedFromBillRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new PayabliApi.Core.QueryStringBuilder.Builder(capacity: 1)
            .Add("returnObject", request.ReturnObject)
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
                        "Bill/attachedFileFromBill/{0}/{1}",
                        ValueConvert.ToPathParameterString(idBill),
                        ValueConvert.ToPathParameterString(filename)
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
                var responseData = JsonUtils.Deserialize<FileContent>(responseBody)!;
                return new WithRawResponse<FileContent>()
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

    private async Task<WithRawResponse<GetBillResponse>> GetBillAsyncCore(
        int idBill,
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
                    Method = HttpMethod.Get,
                    Path = string.Format("Bill/{0}", ValueConvert.ToPathParameterString(idBill)),
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
                var responseData = JsonUtils.Deserialize<GetBillResponse>(responseBody)!;
                return new WithRawResponse<GetBillResponse>()
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

    private async Task<WithRawResponse<BillQueryResponse>> ListBillsAsyncCore(
        string entry,
        ListBillsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new PayabliApi.Core.QueryStringBuilder.Builder(capacity: 5)
            .Add("exportFormat", request.ExportFormat)
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
                        "Query/bills/{0}",
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
                var responseData = JsonUtils.Deserialize<BillQueryResponse>(responseBody)!;
                return new WithRawResponse<BillQueryResponse>()
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

    private async Task<WithRawResponse<BillQueryResponse>> ListBillsOrgAsyncCore(
        int orgId,
        ListBillsOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new PayabliApi.Core.QueryStringBuilder.Builder(capacity: 5)
            .Add("exportFormat", request.ExportFormat)
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
                        "Query/bills/org/{0}",
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
                var responseData = JsonUtils.Deserialize<BillQueryResponse>(responseBody)!;
                return new WithRawResponse<BillQueryResponse>()
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

    private async Task<WithRawResponse<ModifyApprovalBillResponse>> ModifyApprovalBillAsyncCore(
        int idBill,
        IEnumerable<string> request,
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
                    Method = HttpMethod.Put,
                    Path = string.Format(
                        "Bill/approval/{0}",
                        ValueConvert.ToPathParameterString(idBill)
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
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                var responseData = JsonUtils.Deserialize<ModifyApprovalBillResponse>(responseBody)!;
                return new WithRawResponse<ModifyApprovalBillResponse>()
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

    private async Task<WithRawResponse<BillResponse>> SendToApprovalBillAsyncCore(
        int idBill,
        SendToApprovalBillRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new PayabliApi.Core.QueryStringBuilder.Builder(capacity: 1)
            .Add("autocreateUser", request.AutocreateUser)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new PayabliApi.Core.HeadersBuilder.Builder()
            .Add("idempotencyKey", request.IdempotencyKey)
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
                    Path = string.Format(
                        "Bill/approval/{0}",
                        ValueConvert.ToPathParameterString(idBill)
                    ),
                    Body = request.Body,
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
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                var responseData = JsonUtils.Deserialize<BillResponse>(responseBody)!;
                return new WithRawResponse<BillResponse>()
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

    private async Task<WithRawResponse<SetApprovedBillResponse>> SetApprovedBillAsyncCore(
        int idBill,
        string approved,
        SetApprovedBillRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new PayabliApi.Core.QueryStringBuilder.Builder(capacity: 1)
            .Add("email", request.Email)
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
                        "Bill/approval/{0}/{1}",
                        ValueConvert.ToPathParameterString(idBill),
                        ValueConvert.ToPathParameterString(approved)
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
                var responseData = JsonUtils.Deserialize<SetApprovedBillResponse>(responseBody)!;
                return new WithRawResponse<SetApprovedBillResponse>()
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

    /// <summary>
    /// Creates a bill in an entrypoint.
    /// </summary>
    /// <example><code>
    /// await client.Bill.AddBillAsync(
    ///     "8cfec329267",
    ///     new AddBillRequest
    ///     {
    ///         Body = new BillOutData
    ///         {
    ///             BillNumber = "ABC-123",
    ///             NetAmount = 3762.87,
    ///             BillDate = new DateOnly(2024, 7, 1),
    ///             DueDate = new DateOnly(2024, 7, 1),
    ///             Comments = "Deposit for materials",
    ///             BillItems = new List&lt;BillItem&gt;()
    ///             {
    ///                 new BillItem
    ///                 {
    ///                     ItemProductCode = "M-DEPOSIT",
    ///                     ItemProductName = "Materials deposit",
    ///                     ItemDescription = "Deposit for materials",
    ///                     ItemCommodityCode = "010",
    ///                     ItemUnitOfMeasure = "SqFt",
    ///                     ItemCost = 5,
    ///                     ItemQty = 1,
    ///                     ItemMode = 0,
    ///                     ItemCategories = new List&lt;string&gt;() { "deposits" },
    ///                     ItemTotalAmount = 123,
    ///                     ItemTaxAmount = 7,
    ///                     ItemTaxRate = 0.075,
    ///                 },
    ///             },
    ///             Mode = 0,
    ///             AccountingField1 = "MyInternalId",
    ///             Vendor = new VendorData { VendorNumber = "1234-A" },
    ///             EndDate = new DateOnly(2024, 7, 1),
    ///             Frequency = Frequency.Monthly,
    ///             Terms = "NET30",
    ///             Status = -99,
    ///             Attachments = new List&lt;FileContent&gt;()
    ///             {
    ///                 new FileContent
    ///                 {
    ///                     Ftype = FileContentFtype.Pdf,
    ///                     Filename = "my-doc.pdf",
    ///                     Furl = "https://mysite.com/my-doc.pdf",
    ///                 },
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<BillResponse> AddBillAsync(
        string entry,
        AddBillRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<BillResponse>(
            AddBillAsyncCore(entry, request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Delete a file attached to a bill.
    /// </summary>
    /// <example><code>
    /// await client.Bill.DeleteAttachedFromBillAsync(
    ///     "0_Bill.pdf",
    ///     285,
    ///     new DeleteAttachedFromBillRequest()
    /// );
    /// </code></example>
    public WithRawResponseTask<BillResponse> DeleteAttachedFromBillAsync(
        int idBill,
        string filename,
        DeleteAttachedFromBillRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<BillResponse>(
            DeleteAttachedFromBillAsyncCore(idBill, filename, request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Deletes a bill by ID.
    /// </summary>
    /// <example><code>
    /// await client.Bill.DeleteBillAsync(285);
    /// </code></example>
    public WithRawResponseTask<BillResponse> DeleteBillAsync(
        int idBill,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<BillResponse>(
            DeleteBillAsyncCore(idBill, options, cancellationToken)
        );
    }

    /// <summary>
    /// Updates a bill by ID.
    /// </summary>
    /// <example><code>
    /// await client.Bill.EditBillAsync(
    ///     285,
    ///     new BillOutData { NetAmount = 3762.87, BillDate = new DateOnly(2025, 7, 1) }
    /// );
    /// </code></example>
    public WithRawResponseTask<EditBillResponse> EditBillAsync(
        int idBill,
        BillOutData request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<EditBillResponse>(
            EditBillAsyncCore(idBill, request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Retrieves a file attached to a bill, either as a binary file or as a Base64-encoded string.
    /// </summary>
    /// <example><code>
    /// await client.Bill.GetAttachedFromBillAsync(
    ///     "0_Bill.pdf",
    ///     285,
    ///     new GetAttachedFromBillRequest { ReturnObject = true }
    /// );
    /// </code></example>
    public WithRawResponseTask<FileContent> GetAttachedFromBillAsync(
        int idBill,
        string filename,
        GetAttachedFromBillRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<FileContent>(
            GetAttachedFromBillAsyncCore(idBill, filename, request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Retrieves a bill by ID from an entrypoint.
    /// </summary>
    /// <example><code>
    /// await client.Bill.GetBillAsync(285);
    /// </code></example>
    public WithRawResponseTask<GetBillResponse> GetBillAsync(
        int idBill,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GetBillResponse>(
            GetBillAsyncCore(idBill, options, cancellationToken)
        );
    }

    /// <summary>
    /// Retrieve a list of bills for an entrypoint. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
    /// </summary>
    /// <example><code>
    /// await client.Bill.ListBillsAsync(
    ///     "8cfec329267",
    ///     new ListBillsRequest
    ///     {
    ///         FromRecord = 251,
    ///         LimitRecord = 0,
    ///         SortBy = "desc(field_name)",
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<BillQueryResponse> ListBillsAsync(
        string entry,
        ListBillsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<BillQueryResponse>(
            ListBillsAsyncCore(entry, request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Retrieve a list of bills for an organization. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
    /// </summary>
    /// <example><code>
    /// await client.Bill.ListBillsOrgAsync(
    ///     123,
    ///     new ListBillsOrgRequest
    ///     {
    ///         FromRecord = 251,
    ///         LimitRecord = 0,
    ///         SortBy = "desc(field_name)",
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<BillQueryResponse> ListBillsOrgAsync(
        int orgId,
        ListBillsOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<BillQueryResponse>(
            ListBillsOrgAsyncCore(orgId, request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Modify the list of users the bill is sent to for approval.
    /// </summary>
    /// <example><code>
    /// await client.Bill.ModifyApprovalBillAsync(285, new List&lt;string&gt;() { "string" });
    /// </code></example>
    public WithRawResponseTask<ModifyApprovalBillResponse> ModifyApprovalBillAsync(
        int idBill,
        IEnumerable<string> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ModifyApprovalBillResponse>(
            ModifyApprovalBillAsyncCore(idBill, request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Send a bill to a user or list of users to approve.
    /// </summary>
    /// <example><code>
    /// await client.Bill.SendToApprovalBillAsync(
    ///     285,
    ///     new SendToApprovalBillRequest
    ///     {
    ///         IdempotencyKey = "6B29FC40-CA47-1067-B31D-00DD010662DA",
    ///         Body = new List&lt;string&gt;() { "string" },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<BillResponse> SendToApprovalBillAsync(
        int idBill,
        SendToApprovalBillRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<BillResponse>(
            SendToApprovalBillAsyncCore(idBill, request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Approve or disapprove a bill by ID.
    /// </summary>
    /// <example><code>
    /// await client.Bill.SetApprovedBillAsync("true", 285, new SetApprovedBillRequest());
    /// </code></example>
    public WithRawResponseTask<SetApprovedBillResponse> SetApprovedBillAsync(
        int idBill,
        string approved,
        SetApprovedBillRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<SetApprovedBillResponse>(
            SetApprovedBillAsyncCore(idBill, approved, request, options, cancellationToken)
        );
    }
}
