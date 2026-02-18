namespace PayabliApi;

public partial interface IExportClient
{
    /// <summary>
    /// Export a list of boarding applications for an organization. Use filters to limit results.
    /// </summary>
    WithRawResponseTask<Dictionary<string, object?>> ExportApplicationsAsync(
        ExportFormat1 format,
        int orgId,
        ExportApplicationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint is deprecated. Export batch details for a paypoint. Use filters to limit results.
    /// </summary>
    WithRawResponseTask<Dictionary<string, object?>> ExportBatchDetailsAsync(
        ExportFormat1 format,
        string entry,
        ExportBatchDetailsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint is deprecated. Export batch details for an organization. Use filters to limit results.
    /// </summary>
    WithRawResponseTask<Dictionary<string, object?>> ExportBatchDetailsOrgAsync(
        ExportFormat1 format,
        int orgId,
        ExportBatchDetailsOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Export a list of batches for an entrypoint. Use filters to limit results.
    /// </summary>
    WithRawResponseTask<Dictionary<string, object?>> ExportBatchesAsync(
        ExportFormat1 format,
        string entry,
        ExportBatchesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Export a list of batches for an organization. Use filters to limit results.
    /// </summary>
    WithRawResponseTask<Dictionary<string, object?>> ExportBatchesOrgAsync(
        ExportFormat1 format,
        int orgId,
        ExportBatchesOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Export a list of money out batches for a paypoint. Use filters to limit results.
    /// </summary>
    WithRawResponseTask<Dictionary<string, object?>> ExportBatchesOutAsync(
        ExportFormat1 format,
        string entry,
        ExportBatchesOutRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Export a list of money out batches for an organization. Use filters to limit results.
    /// </summary>
    WithRawResponseTask<Dictionary<string, object?>> ExportBatchesOutOrgAsync(
        ExportFormat1 format,
        int orgId,
        ExportBatchesOutOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Export a list of bills for an entrypoint. Use filters to limit results.
    /// </summary>
    WithRawResponseTask<Dictionary<string, object?>> ExportBillsAsync(
        ExportFormat1 format,
        string entry,
        ExportBillsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Export a list of bills for an organization. Use filters to limit results.
    /// </summary>
    WithRawResponseTask<Dictionary<string, object?>> ExportBillsOrgAsync(
        ExportFormat1 format,
        int orgId,
        ExportBillsOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Export a list of chargebacks and ACH returns for an entrypoint. Use filters to limit results.
    /// </summary>
    WithRawResponseTask<Dictionary<string, object?>> ExportChargebacksAsync(
        ExportFormat1 format,
        string entry,
        ExportChargebacksRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Export a list of chargebacks and ACH returns for an organization. Use filters to limit results.
    /// </summary>
    WithRawResponseTask<Dictionary<string, object?>> ExportChargebacksOrgAsync(
        ExportFormat1 format,
        int orgId,
        ExportChargebacksOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Export a list of customers for an entrypoint. Use filters to limit results.
    /// </summary>
    WithRawResponseTask<Dictionary<string, object?>> ExportCustomersAsync(
        ExportFormat1 format,
        string entry,
        ExportCustomersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Exports a list of customers for an organization. Use filters to limit results.
    /// </summary>
    WithRawResponseTask<Dictionary<string, object?>> ExportCustomersOrgAsync(
        ExportFormat1 format,
        int orgId,
        ExportCustomersOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Export list of invoices for an entrypoint. Use filters to limit results.
    /// </summary>
    WithRawResponseTask<Dictionary<string, object?>> ExportInvoicesAsync(
        ExportFormat1 format,
        string entry,
        ExportInvoicesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Export a list of invoices for an organization. Use filters to limit results.
    /// </summary>
    WithRawResponseTask<Dictionary<string, object?>> ExportInvoicesOrgAsync(
        ExportFormat1 format,
        int orgId,
        ExportInvoicesOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Export a list of child organizations (suborganizations) for a parent organization.
    /// </summary>
    WithRawResponseTask<Dictionary<string, object?>> ExportOrganizationsAsync(
        ExportFormat1 format,
        int orgId,
        ExportOrganizationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Export a list of payouts and their statuses for an entrypoint. Use filters to limit results.
    /// </summary>
    WithRawResponseTask<Dictionary<string, object?>> ExportPayoutAsync(
        ExportFormat1 format,
        string entry,
        ExportPayoutRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Export a list of payouts and their details for an organization. Use filters to limit results.
    /// </summary>
    WithRawResponseTask<Dictionary<string, object?>> ExportPayoutOrgAsync(
        ExportFormat1 format,
        int orgId,
        ExportPayoutOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Export a list of paypoints in an organization. Use filters to limit results.
    /// </summary>
    WithRawResponseTask<Dictionary<string, object?>> ExportPaypointsAsync(
        ExportFormat1 format,
        int orgId,
        ExportPaypointsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Export a list of settled transactions for an entrypoint. Use filters to limit results.
    /// </summary>
    WithRawResponseTask<Dictionary<string, object?>> ExportSettlementsAsync(
        ExportFormat1 format,
        string entry,
        ExportSettlementsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Export a list of settled transactions for an organization. Use filters to limit results.
    /// </summary>
    WithRawResponseTask<Dictionary<string, object?>> ExportSettlementsOrgAsync(
        ExportFormat1 format,
        int orgId,
        ExportSettlementsOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Export a list of subscriptions for an entrypoint. Use filters to limit results.
    /// </summary>
    WithRawResponseTask<Dictionary<string, object?>> ExportSubscriptionsAsync(
        ExportFormat1 format,
        string entry,
        ExportSubscriptionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Export a list of subscriptions for an organization. Use filters to limit results.
    /// </summary>
    WithRawResponseTask<Dictionary<string, object?>> ExportSubscriptionsOrgAsync(
        ExportFormat1 format,
        int orgId,
        ExportSubscriptionsOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Export a list of transactions for an entrypoint in a file in XLXS or CSV format. Use filters to limit results. If you don't specify a date range in the request, the last two months of data are returned.
    /// </summary>
    WithRawResponseTask<Dictionary<string, object?>> ExportTransactionsAsync(
        ExportFormat1 format,
        string entry,
        ExportTransactionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Export a list of transactions for an org in a file in XLSX or CSV format. Use filters to limit results. If you don't specify a date range in the request, the last two months of data are returned.
    /// </summary>
    WithRawResponseTask<Dictionary<string, object?>> ExportTransactionsOrgAsync(
        ExportFormat1 format,
        int orgId,
        ExportTransactionsOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Export a list of transfer details for an entrypoint. Use filters to limit results.
    /// </summary>
    WithRawResponseTask<Dictionary<string, object?>> ExportTransferDetailsAsync(
        ExportFormat1 format,
        string entry,
        long transferId,
        ExportTransferDetailsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a list of transfers for an entrypoint. Use filters to limit results.
    /// </summary>
    WithRawResponseTask<Dictionary<string, object?>> ExportTransfersAsync(
        string entry,
        ExportTransfersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Export a list of vendors for an entrypoint. Use filters to limit results.
    /// </summary>
    WithRawResponseTask<Dictionary<string, object?>> ExportVendorsAsync(
        ExportFormat1 format,
        string entry,
        ExportVendorsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Export a list of vendors for an organization. Use filters to limit results.
    /// </summary>
    WithRawResponseTask<Dictionary<string, object?>> ExportVendorsOrgAsync(
        ExportFormat1 format,
        int orgId,
        ExportVendorsOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
