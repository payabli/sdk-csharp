namespace PayabliApi;

public partial interface INotificationlogsClient
{
    /// <summary>
    /// Search notification logs with filtering and pagination.
    ///   - Start date and end date cannot be more than 30 days apart
    ///   - Either `orgId` or `paypointId` must be provided
    ///
    /// This endpoint requires the `notifications_create` OR `notifications_read` permission.
    /// </summary>
    WithRawResponseTask<IEnumerable<NotificationLog>> SearchNotificationLogsAsync(
        SearchNotificationLogsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get detailed information for a specific notification log entry.
    /// This endpoint requires the `notifications_create` OR `notifications_read` permission.
    /// </summary>
    WithRawResponseTask<NotificationLogDetail> GetNotificationLogAsync(
        string uuid,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retry sending a specific notification.
    ///
    /// **Permissions:** notifications_create
    /// </summary>
    WithRawResponseTask<NotificationLogDetail> RetryNotificationLogAsync(
        string uuid,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retry sending multiple notifications (maximum 50 IDs).
    /// This is an async process, so use the search endpoint again to check the notification status.
    ///
    /// This endpoint requires the `notifications_create` permission.
    /// </summary>
    Task BulkRetryNotificationLogsAsync(
        IEnumerable<string> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
