using System.Text.Json;
using PayabliApi.Core;

namespace PayabliApi;

public partial class NotificationlogsClient : INotificationlogsClient
{
    private RawClient _client;

    internal NotificationlogsClient(RawClient client)
    {
        _client = client;
    }

    private async Task<
        WithRawResponse<IEnumerable<NotificationLog>>
    > SearchNotificationLogsAsyncCore(
        SearchNotificationLogsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new PayabliApi.Core.QueryStringBuilder.Builder(capacity: 2)
            .Add("PageSize", request.PageSize)
            .Add("Page", request.Page)
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
                    Method = HttpMethod.Post,
                    Path = "/v2/notificationlogs",
                    Body = request.Body,
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
                var responseData = JsonUtils.Deserialize<IEnumerable<NotificationLog>>(
                    responseBody
                )!;
                return new WithRawResponse<IEnumerable<NotificationLog>>()
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

    private async Task<WithRawResponse<NotificationLogDetail>> GetNotificationLogAsyncCore(
        string uuid,
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
                    Path = string.Format(
                        "/v2/notificationlogs/{0}",
                        ValueConvert.ToPathParameterString(uuid)
                    ),
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
                var responseData = JsonUtils.Deserialize<NotificationLogDetail>(responseBody)!;
                return new WithRawResponse<NotificationLogDetail>()
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

    private async Task<WithRawResponse<NotificationLogDetail>> RetryNotificationLogAsyncCore(
        string uuid,
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
                    Path = string.Format(
                        "/v2/notificationlogs/{0}/retry",
                        ValueConvert.ToPathParameterString(uuid)
                    ),
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
                var responseData = JsonUtils.Deserialize<NotificationLogDetail>(responseBody)!;
                return new WithRawResponse<NotificationLogDetail>()
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
    /// Search notification logs with filtering and pagination.
    ///   - Start date and end date cannot be more than 30 days apart
    ///   - Either `orgId` or `paypointId` must be provided
    ///
    /// This endpoint requires the `notifications_create` OR `notifications_read` permission.
    /// </summary>
    /// <example><code>
    /// await client.Notificationlogs.SearchNotificationLogsAsync(
    ///     new SearchNotificationLogsRequest
    ///     {
    ///         PageSize = 20,
    ///         Body = new NotificationLogSearchRequest
    ///         {
    ///             StartDate = new DateTime(2024, 01, 01, 00, 00, 00, 000),
    ///             EndDate = new DateTime(2024, 01, 31, 23, 59, 59, 000),
    ///             OrgId = 12345,
    ///             NotificationEvent = "ActivatedMerchant",
    ///             Succeeded = true,
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<IEnumerable<NotificationLog>> SearchNotificationLogsAsync(
        SearchNotificationLogsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<IEnumerable<NotificationLog>>(
            SearchNotificationLogsAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Get detailed information for a specific notification log entry.
    /// This endpoint requires the `notifications_create` OR `notifications_read` permission.
    /// </summary>
    /// <example><code>
    /// await client.Notificationlogs.GetNotificationLogAsync("550e8400-e29b-41d4-a716-446655440000");
    /// </code></example>
    public WithRawResponseTask<NotificationLogDetail> GetNotificationLogAsync(
        string uuid,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<NotificationLogDetail>(
            GetNotificationLogAsyncCore(uuid, options, cancellationToken)
        );
    }

    /// <summary>
    /// Retry sending a specific notification.
    ///
    /// **Permissions:** notifications_create
    /// </summary>
    /// <example><code>
    /// await client.Notificationlogs.RetryNotificationLogAsync("550e8400-e29b-41d4-a716-446655440000");
    /// </code></example>
    public WithRawResponseTask<NotificationLogDetail> RetryNotificationLogAsync(
        string uuid,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<NotificationLogDetail>(
            RetryNotificationLogAsyncCore(uuid, options, cancellationToken)
        );
    }

    /// <summary>
    /// Retry sending multiple notifications (maximum 50 IDs).
    /// This is an async process, so use the search endpoint again to check the notification status.
    ///
    /// This endpoint requires the `notifications_create` permission.
    /// </summary>
    /// <example><code>
    /// await client.Notificationlogs.BulkRetryNotificationLogsAsync(
    ///     new List&lt;string&gt;()
    ///     {
    ///         "550e8400-e29b-41d4-a716-446655440000",
    ///         "550e8400-e29b-41d4-a716-446655440001",
    ///         "550e8400-e29b-41d4-a716-446655440002",
    ///     }
    /// );
    /// </code></example>
    public async Task BulkRetryNotificationLogsAsync(
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
                    Method = HttpMethod.Post,
                    Path = "/v2/notificationlogs/retry",
                    Body = request,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            return;
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
