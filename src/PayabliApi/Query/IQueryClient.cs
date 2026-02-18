namespace PayabliApi;

public partial interface IQueryClient
{
    /// <summary>
    /// Retrieve a list of batches and their details, including settled and
    /// unsettled transactions for a paypoint. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
    /// </summary>
    WithRawResponseTask<QueryBatchesDetailResponse> ListBatchDetailsAsync(
        string entry,
        ListBatchDetailsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a list of batches and their details, including settled and unsettled transactions for an organization. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
    /// </summary>
    WithRawResponseTask<QueryResponseSettlements> ListBatchDetailsOrgAsync(
        int orgId,
        ListBatchDetailsOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a list of batches for a paypoint. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
    /// </summary>
    WithRawResponseTask<QueryBatchesResponse> ListBatchesAsync(
        string entry,
        ListBatchesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a list of batches for an org. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
    /// </summary>
    WithRawResponseTask<QueryBatchesResponse> ListBatchesOrgAsync(
        int orgId,
        ListBatchesOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a list of MoneyOut batches for a paypoint. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
    /// </summary>
    WithRawResponseTask<QueryBatchesOutResponse> ListBatchesOutAsync(
        string entry,
        ListBatchesOutRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a list of MoneyOut batches for an org. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
    /// </summary>
    WithRawResponseTask<QueryBatchesOutResponse> ListBatchesOutOrgAsync(
        int orgId,
        ListBatchesOutOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a list of chargebacks and returned transactions for a paypoint. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
    /// </summary>
    WithRawResponseTask<QueryChargebacksResponse> ListChargebacksAsync(
        string entry,
        ListChargebacksRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a list of chargebacks and returned transactions for an org. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
    /// </summary>
    WithRawResponseTask<QueryChargebacksResponse> ListChargebacksOrgAsync(
        int orgId,
        ListChargebacksOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a list of customers for a paypoint. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
    /// </summary>
    WithRawResponseTask<QueryCustomerResponse> ListCustomersAsync(
        string entry,
        ListCustomersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a list of customers for an org. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
    /// </summary>
    WithRawResponseTask<QueryCustomerResponse> ListCustomersOrgAsync(
        int orgId,
        ListCustomersOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a list of all reports generated in the last 60 days for a single entrypoint. Use filters to limit results.
    /// </summary>
    WithRawResponseTask<QueryResponseNotificationReports> ListNotificationReportsAsync(
        string entry,
        ListNotificationReportsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a list of all reports generated in the last 60 days for an organization. Use filters to limit results.
    /// </summary>
    WithRawResponseTask<QueryResponseNotificationReports> ListNotificationReportsOrgAsync(
        int orgId,
        ListNotificationReportsOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a list of notifications for an entrypoint. Use filters to limit results.
    /// </summary>
    WithRawResponseTask<QueryResponseNotifications> ListNotificationsAsync(
        string entry,
        ListNotificationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Return a list of notifications for an organization. Use filters to limit results.
    /// </summary>
    WithRawResponseTask<QueryResponseNotifications> ListNotificationsOrgAsync(
        int orgId,
        ListNotificationsOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a list of an organization's suborganizations and their full details such as orgId, users, and settings. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
    /// </summary>
    WithRawResponseTask<ListOrganizationsResponse> ListOrganizationsAsync(
        int orgId,
        ListOrganizationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a list of money out transactions (payouts) for a paypoint. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
    /// </summary>
    WithRawResponseTask<QueryPayoutTransaction> ListPayoutAsync(
        string entry,
        ListPayoutRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a list of money out transactions (payouts) for an organization. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
    /// </summary>
    WithRawResponseTask<QueryPayoutTransaction> ListPayoutOrgAsync(
        int orgId,
        ListPayoutOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a list of paypoints in an organization. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
    /// </summary>
    WithRawResponseTask<QueryEntrypointResponse> ListPaypointsAsync(
        int orgId,
        ListPaypointsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a list of settled transactions for a paypoint. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
    /// </summary>
    WithRawResponseTask<QueryResponseSettlements> ListSettlementsAsync(
        string entry,
        ListSettlementsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a list of settled transactions for an organization. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
    /// </summary>
    WithRawResponseTask<QueryResponseSettlements> ListSettlementsOrgAsync(
        int orgId,
        ListSettlementsOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a list of subscriptions for a single paypoint. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
    /// </summary>
    WithRawResponseTask<QuerySubscriptionResponse> ListSubscriptionsAsync(
        string entry,
        ListSubscriptionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a list of subscriptions for a single org. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
    /// </summary>
    WithRawResponseTask<QuerySubscriptionResponse> ListSubscriptionsOrgAsync(
        int orgId,
        ListSubscriptionsOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

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
    WithRawResponseTask<QueryResponseTransactions> ListTransactionsAsync(
        string entry,
        ListTransactionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

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
    WithRawResponseTask<QueryResponseTransactions> ListTransactionsOrgAsync(
        int orgId,
        ListTransactionsOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a list of transfer details records for a paypoint. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
    /// </summary>
    WithRawResponseTask<QueryTransferDetailResponse> ListTransferDetailsAsync(
        string entry,
        int transferId,
        ListTransfersPaypointRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a list of transfers for a paypoint. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
    /// </summary>
    WithRawResponseTask<TransferQueryResponse> ListTransfersAsync(
        string entry,
        ListTransfersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a list of transfers for an org. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
    /// </summary>
    WithRawResponseTask<TransferQueryResponse> ListTransfersOrgAsync(
        ListTransfersRequestOrg request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a list of outbound transfers for an organization. Use filters to limit results.
    /// </summary>
    WithRawResponseTask<TransferOutQueryResponse> ListTransfersOutOrgAsync(
        int orgId,
        ListTransfersOutOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a list of outbound transfers for a paypoint. Use filters to limit results.
    /// </summary>
    WithRawResponseTask<TransferOutQueryResponse> ListTransfersOutPaypointAsync(
        string entry,
        ListTransfersOutPaypointRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve details for a specific outbound transfer. Use filters to limit results.
    /// </summary>
    WithRawResponseTask<TransferOutDetailQueryResponse> ListTransferDetailsOutAsync(
        string entry,
        int transferId,
        ListTransferDetailsOutRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get list of users for an org. Use filters to limit results.
    /// </summary>
    WithRawResponseTask<QueryUserResponse> ListUsersOrgAsync(
        int orgId,
        ListUsersOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get list of users for a paypoint. Use filters to limit results.
    /// </summary>
    WithRawResponseTask<QueryUserResponse> ListUsersPaypointAsync(
        string entry,
        ListUsersPaypointRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a list of vendors for an entrypoint. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
    /// </summary>
    WithRawResponseTask<QueryResponseVendors> ListVendorsAsync(
        string entry,
        ListVendorsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a list of vendors for an organization. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
    /// </summary>
    WithRawResponseTask<QueryResponseVendors> ListVendorsOrgAsync(
        int orgId,
        ListVendorsOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a list of vcards (virtual credit cards) issued for an entrypoint. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
    /// </summary>
    WithRawResponseTask<VCardQueryResponse> ListVcardsAsync(
        string entry,
        ListVcardsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a list of vcards (virtual credit cards) issued for an organization. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
    /// </summary>
    WithRawResponseTask<VCardQueryResponse> ListVcardsOrgAsync(
        int orgId,
        ListVcardsOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
