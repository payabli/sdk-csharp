namespace PayabliApi;

public partial interface IMoneyOutClient
{
    /// <summary>
    /// Authorizes transaction for payout. Authorized transactions aren't flagged for settlement until captured. Use `referenceId` returned in the response to capture the transaction.
    /// </summary>
    WithRawResponseTask<AuthCapturePayoutResponse> AuthorizeOutAsync(
        MoneyOutTypesRequestOutAuthorize request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Cancels an array of payout transactions.
    /// </summary>
    WithRawResponseTask<CaptureAllOutResponse> CancelAllOutAsync(
        IEnumerable<string> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Cancel a payout transaction by ID.
    /// </summary>
    WithRawResponseTask<PayabliApiResponse0000> CancelOutGetAsync(
        string referenceId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Cancel a payout transaction by ID.
    /// </summary>
    WithRawResponseTask<PayabliApiResponse0000> CancelOutDeleteAsync(
        string referenceId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Captures an array of authorized payout transactions for settlement. The maximum number of transactions that can be captured in a single request is 500.
    /// </summary>
    WithRawResponseTask<CaptureAllOutResponse> CaptureAllOutAsync(
        CaptureAllOutRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Captures a single authorized payout transaction by ID.
    /// </summary>
    WithRawResponseTask<AuthCapturePayoutResponse> CaptureOutAsync(
        string referenceId,
        CaptureOutRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns details for a processed money out transaction.
    /// </summary>
    WithRawResponseTask<BillDetailResponse> PayoutDetailsAsync(
        string transId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves vCard details for a single card in an entrypoint.
    /// </summary>
    WithRawResponseTask<VCardGetResponse> VCardGetAsync(
        string cardToken,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends a virtual card link via email to the vendor associated with the `transId`.
    /// </summary>
    WithRawResponseTask<OperationResult> SendVCardLinkAsync(
        SendVCardLinkRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve the image of a check associated with a processed transaction.
    /// The check image is returned in the response body as a base64-encoded string.
    /// The check image is only available for payouts that have been processed.
    /// </summary>
    WithRawResponseTask<string> GetCheckImageAsync(
        string assetName,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates the status of a processed check payment transaction. This endpoint handles the status transition, updates related bills, creates audit events, and triggers notifications.
    ///
    /// The transaction must meet all of the following criteria:
    /// - **Status**: Must be in Processing or Processed status.
    /// - **Payment method**: Must be a check payment method.
    ///
    /// ### Allowed status values
    ///
    /// | Value | Status | Description |
    /// |-------|--------|-------------|
    /// | `0` | Cancelled/Voided | Cancels the check transaction. Reverts associated bills to their previous state (Approved or Active), creates "Cancelled" events, and sends a `payout_transaction_voidedcancelled` notification if the notification is enabled. |
    /// | `5` | Paid | Marks the check transaction as paid. Updates associated bills to "Paid" status, creates "Paid" events, and sends a `payout_transaction_paid` notification if the notification is enabled. |
    /// </summary>
    WithRawResponseTask<PayabliApiResponse00Responsedatanonobject> UpdateCheckPaymentStatusAsync(
        string transId,
        AllowedCheckPaymentStatus checkPaymentStatus,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
