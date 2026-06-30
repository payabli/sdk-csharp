namespace PayabliApi;

public partial interface IMoneyOutClient
{
    /// <summary>
    /// Authorizes a transaction for payout.
    ///
    /// If you don't pass `autoCapture` with a value of `true`, authorized transactions aren't flagged for settlement until captured. Use the `referenceId` returned in the response to capture the transaction.
    ///
    /// When `autoCapture` is `true`, Payabli captures the transaction asynchronously after authorization. The response confirms only that the transaction was authorized; it doesn't confirm that capture succeeded. To confirm capture, listen for the [`payout_transaction_approvedcaptured`](/developers/webhooks/payout-transaction-approved-captured) webhook event.
    ///
    /// If a velocity fraud alert is triggered, the endpoint returns a `202` response with `responseCode` `9051`, and the authorization is held for risk review rather than rejected. If a risk policy blocks the transaction, the endpoint returns a `422` response with `responseCode` `9005`, a terminal rejection.
    /// </summary>
    WithRawResponseTask<AuthCapturePayoutResponse> AuthorizeOutAsync(
        RequestOutAuthorize request,
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
    /// Captures a single authorized payout transaction by ID. If the transaction was authorized with `autoCapture` set to `true`, you don't need to call this endpoint to capture the transaction for processing.
    ///
    /// If a velocity fraud alert is triggered, the endpoint returns a `202` response with `responseCode` `9051`, and the capture is held for risk review rather than rejected. If a risk policy blocks the transaction, the endpoint returns a `422` response with `responseCode` `9005`, a terminal rejection.
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
    /// Renews an expired or expiring virtual card by extending its expiration date to a future month.
    ///
    /// The card must be a virtual card that hasn't been fully used. The new expiration date must be in `MM-YYYY` or `MM/YYYY` format and no more than 2 years and 363 days in the future. The card expires on the last day of the month you specify.
    ///
    /// On success, `referenceId` holds the renewed card's token (the card processor may issue a new token). The response reuses the standard payout result object, so the payment-transaction fields it carries don't apply to renewal and always return `null`.
    /// </summary>
    WithRawResponseTask<RenewVCardResponse> RenewVCardAsync(
        string cardToken,
        RenewVCardRequest request,
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

    /// <summary>
    /// Reissues a payout transaction with a new payment method. This creates a new transaction linked to the original and marks the original transaction as reissued.
    ///
    /// The original transaction must be in **Processing** or **Processed** status. The payment method in the request body is used directly. The endpoint doesn't fall back to vendor-managed payment methods.
    ///
    /// The new transaction goes through the standard authorize-and-capture flow automatically. Both the original and new transactions are linked through their event histories for audit purposes.
    /// </summary>
    WithRawResponseTask<ReissuePayoutResponse> ReissueOutAsync(
        ReissueOutRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
