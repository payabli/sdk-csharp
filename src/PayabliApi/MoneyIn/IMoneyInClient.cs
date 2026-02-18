namespace PayabliApi;

public partial interface IMoneyInClient
{
    /// <summary>
    /// Authorize a card transaction. This returns an authorization code and reserves funds for the merchant. Authorized transactions aren't flagged for settlement until [captured](/developers/api-reference/moneyin/capture-an-authorized-transaction).
    /// Only card transactions can be authorized. This endpoint can't be used for ACH transactions.
    /// &lt;Tip&gt;
    ///   Consider migrating to the [v2 Authorize endpoint](/developers/api-reference/moneyinV2/authorize-a-transaction) to take advantage of unified response codes and improved response consistency.
    /// &lt;/Tip&gt;
    /// </summary>
    WithRawResponseTask<AuthResponse> AuthorizeAsync(
        RequestPaymentAuthorize request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// &lt;Warning&gt;
    ///   This endpoint is deprecated and will be sunset on November 24, 2025. Migrate to [POST `/capture/{transId}`](/developers/api-reference/moneyin/capture-an-authorized-transaction)`.
    /// &lt;/Warning&gt;
    ///
    ///   Capture an [authorized
    /// transaction](/developers/api-reference/moneyin/authorize-a-transaction) to complete the transaction and move funds from the customer to merchant account.
    /// </summary>
    WithRawResponseTask<CaptureResponse> CaptureAsync(
        string transId,
        double amount,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Capture an [authorized transaction](/developers/api-reference/moneyin/authorize-a-transaction) to complete the transaction and move funds from the customer to merchant account.
    ///
    /// You can use this endpoint to capture both full and partial amounts of the original authorized transaction. See [Capture an authorized transaction](/developers/developer-guides/pay-in-auth-and-capture) for more information about this endpoint.
    ///
    /// &lt;Tip&gt;
    /// Consider migrating to the [v2 Capture endpoint](/developers/api-reference/moneyinV2/capture-an-authorized-transaction) to take advantage of unified response codes and improved response consistency.
    /// &lt;/Tip&gt;
    /// </summary>
    WithRawResponseTask<CaptureResponse> CaptureAuthAsync(
        string transId,
        CaptureRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Make a temporary microdeposit in a customer account to verify the customer's ownership and access to the target account. Reverse the microdeposit with `reverseCredit`.
    ///
    /// This feature must be enabled by Payabli on a per-merchant basis. Contact support for help.
    /// </summary>
    WithRawResponseTask<PayabliApiResponse0> CreditAsync(
        RequestCredit request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a processed transaction's details.
    /// </summary>
    WithRawResponseTask<TransactionQueryRecordsCustomer> DetailsAsync(
        string transId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Make a single transaction. This method authorizes and captures a payment in one step.
    ///
    ///   &lt;Tip&gt;
    ///   Consider migrating to the [v2 Make a transaction endpoint](/developers/api-reference/moneyinV2/make-a-transaction) to take advantage of unified response codes and improved response consistency.
    ///   &lt;/Tip&gt;
    /// </summary>
    WithRawResponseTask<PayabliApiResponseGetPaid> GetpaidAsync(
        RequestPayment request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// A reversal either refunds or voids a transaction independent of the transaction's settlement status. Send a reversal request for a transaction, and Payabli automatically determines whether it's a refund or void. You don't need to know whether the transaction is settled or not.
    /// </summary>
    WithRawResponseTask<ReverseResponse> ReverseAsync(
        string transId,
        double amount,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Refund a transaction that has settled and send money back to the account holder. If a transaction hasn't been settled, void it instead.
    ///
    ///   &lt;Tip&gt;
    ///   Consider migrating to the [v2 Refund endpoint](/developers/api-reference/moneyinV2/refund-a-settled-transaction) to take advantage of unified response codes and improved response consistency.
    ///   &lt;/Tip&gt;
    /// </summary>
    WithRawResponseTask<RefundResponse> RefundAsync(
        string transId,
        double amount,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Refunds a settled transaction with split instructions.
    /// </summary>
    WithRawResponseTask<RefundWithInstructionsResponse> RefundWithInstructionsAsync(
        string transId,
        RequestRefund request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Reverse microdeposits that are used to verify customer account ownership and access. The `transId` value is returned in the success response for the original credit transaction made with `api/MoneyIn/makecredit`.
    /// </summary>
    WithRawResponseTask<PayabliApiResponse> ReverseCreditAsync(
        string transId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Send a payment receipt for a transaction.
    /// </summary>
    WithRawResponseTask<ReceiptResponse> SendReceipt2TransAsync(
        string transId,
        SendReceipt2TransRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Validates a card number without running a transaction or authorizing a charge.
    /// </summary>
    WithRawResponseTask<ValidateResponse> ValidateAsync(
        RequestPaymentValidate request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Cancel a transaction that hasn't been settled yet. Voiding non-captured authorizations prevents future captures. If a transaction has been settled, refund it instead.
    ///
    ///   &lt;Tip&gt;
    ///   Consider migrating to the [v2 Void endpoint](/developers/api-reference/moneyinV2/void-a-transaction) to take advantage of unified response codes and improved response consistency.
    ///   &lt;/Tip&gt;
    /// </summary>
    WithRawResponseTask<VoidResponse> VoidAsync(
        string transId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Make a single transaction. This method authorizes and captures a payment in one step. This is the v2 version of the `api/MoneyIn/getpaid` endpoint, and returns the unified response format. See [Pay In unified response codes reference](/guides/pay-in-unified-response-codes-reference) for more information.
    /// </summary>
    WithRawResponseTask<V2TransactionResponseWrapper> Getpaidv2Async(
        RequestPaymentV2 request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Authorize a card transaction. This returns an authorization code and reserves funds for the merchant. Authorized transactions aren't flagged for settlement until captured. This is the v2 version of the `api/MoneyIn/authorize` endpoint, and returns the unified response format. See [Pay In unified response codes reference](/guides/pay-in-unified-response-codes-reference) for more information.
    ///
    /// **Note**: Only card transactions can be authorized. This endpoint can't be used for ACH transactions.
    /// </summary>
    WithRawResponseTask<V2TransactionResponseWrapper> Authorizev2Async(
        RequestPaymentAuthorizeV2 request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Capture an authorized transaction to complete the transaction and move funds from the customer to merchant account. This is the v2 version of the `api/MoneyIn/capture/{transId}` endpoint, and returns the unified response format. See [Pay In unified response codes reference](/guides/pay-in-unified-response-codes-reference) for more information.
    /// </summary>
    WithRawResponseTask<V2TransactionResponseWrapper> Capturev2Async(
        string transId,
        CaptureRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Give a full refund for a transaction that has settled and send money back to the account holder. To perform a partial refund, see [Partially refund a transaction](developers/api-reference/moneyinV2/partial-refund-a-settled-transaction).
    ///
    /// This is the v2 version of the refund endpoint, and returns the unified response format. See [Pay In unified response codes reference](/guides/pay-in-unified-response-codes-reference) for more information.
    /// </summary>
    WithRawResponseTask<V2TransactionResponseWrapper> Refundv2Async(
        string transId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Refund a transaction that has settled and send money back to the account holder. If `amount` is omitted or set to 0, performs a full refund. When a non-zero `amount` is provided, this endpoint performs a partial refund.
    ///
    /// This is the v2 version of the refund endpoint, and returns the unified response format. See [Pay In unified response codes reference](/guides/pay-in-unified-response-codes-reference) for more information.
    /// </summary>
    WithRawResponseTask<V2TransactionResponseWrapper> Refundv2AmountAsync(
        string transId,
        double amount,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Cancel a transaction that hasn't been settled yet. Voiding non-captured authorizations prevents future captures. This is the v2 version of the `api/MoneyIn/void/{transId}` endpoint, and returns the unified response format. See [Pay In unified response codes reference](/guides/pay-in-unified-response-codes-reference) for more information.
    /// </summary>
    WithRawResponseTask<V2TransactionResponseWrapper> Voidv2Async(
        string transId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
