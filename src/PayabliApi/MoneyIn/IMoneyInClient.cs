namespace PayabliApi;

public partial interface IMoneyInClient
{
    /// <summary>
    /// &lt;Warning&gt;
    ///   This endpoint is deprecated. New integrations should use the [Authorize endpoint](/developers/api-reference/moneyinV2/authorize-a-transaction), then capture, void, or refund the resulting transaction with the corresponding endpoints. Transactions created with this legacy endpoint must be managed with the legacy lifecycle endpoints — they aren't interchangeable with the current ones.
    /// &lt;/Warning&gt;
    ///
    ///
    /// Authorize a card transaction. This returns an authorization code and reserves funds for the merchant. Authorized transactions aren't flagged for settlement until [captured](/developers/api-reference/moneyin/capture-an-authorized-transaction).
    ///
    /// Only card transactions can be authorized. This endpoint can't be used for ACH transactions.
    /// </summary>
    WithRawResponseTask<AuthResponse> AuthorizeAsync(
        RequestPaymentAuthorize request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// &lt;Warning&gt;
    ///   This endpoint is deprecated. Use [POST `/capture/{transId}`](/developers/api-reference/moneyin/capture-an-authorized-transaction) instead, which supports partial captures and service fee adjustments.
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
    /// &lt;Warning&gt;
    ///   This endpoint is deprecated. Use it only to capture transactions originally authorized with the legacy [Authorize endpoint](/developers/api-reference/moneyin/authorize-a-transaction). New integrations should use the [Capture endpoint](/developers/api-reference/moneyinV2/capture-an-authorized-transaction), which only works on transactions authorized with the current [Authorize endpoint](/developers/api-reference/moneyinV2/authorize-a-transaction).
    /// &lt;/Warning&gt;
    ///
    /// Capture an [authorized transaction](/developers/api-reference/moneyin/authorize-a-transaction) to complete the transaction and move funds from the customer to merchant account.
    ///
    /// You can use this endpoint to capture both full and partial amounts of the original authorized transaction. See [Capture an authorized transaction](/developers/developer-guides/pay-in-auth-and-capture) for more information about this endpoint.
    /// </summary>
    WithRawResponseTask<CaptureResponse> CaptureAuthAsync(
        string transId,
        CaptureRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Make a temporary microdeposit in a customer account to verify the customer's ownership and access to the target account. Reverse the microdeposit with `reverseCredit`. Payabli doesn't automatically make microdeposits when you add a bank account, you must manually make the requests.
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
    /// &lt;Warning&gt;
    ///   This endpoint is deprecated. New integrations should use the [Make a transaction endpoint](/developers/api-reference/moneyinV2/make-a-transaction) and manage the resulting transaction with the corresponding void or refund endpoints. Transactions created with this legacy endpoint must be managed with the legacy lifecycle endpoints — they aren't interchangeable with the current ones.
    /// &lt;/Warning&gt;
    ///
    /// Make a single transaction. This method authorizes and captures a payment in one step.
    /// </summary>
    WithRawResponseTask<PayabliApiResponseGetPaid> GetpaidAsync(
        RequestPayment request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// &lt;Warning&gt;
    ///   This endpoint is deprecated and only works on transactions created with the legacy endpoints. There's no equivalent in the current endpoints. For transactions created with [Make a transaction](/developers/api-reference/moneyinV2/make-a-transaction) or [Authorize](/developers/api-reference/moneyinV2/authorize-a-transaction), check the transaction's settlement status and call [Void](/developers/api-reference/moneyinV2/void-a-transaction) or [Refund](/developers/api-reference/moneyinV2/refund-a-settled-transaction) based on the result.
    /// &lt;/Warning&gt;
    ///
    /// A reversal either refunds or voids a transaction independent of the transaction's settlement status. Send a reversal request for a transaction, and Payabli automatically determines whether it's a refund or void. You don't need to know whether the transaction is settled or not. This endpoint only works on transactions made with the legacy endpoints. For transactions made with the current endpoints, check the transaction's settlement status and call void or refund based on the result.
    /// </summary>
    WithRawResponseTask<ReverseResponse> ReverseAsync(
        string transId,
        double amount,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// &lt;Warning&gt;
    ///   This endpoint is deprecated. Use it only to refund transactions originally created with the legacy endpoints. New integrations should use the [Refund endpoint](/developers/api-reference/moneyinV2/refund-a-settled-transaction), which only works on transactions created with [Make a transaction](/developers/api-reference/moneyinV2/make-a-transaction) or [Authorize](/developers/api-reference/moneyinV2/authorize-a-transaction).
    /// &lt;/Warning&gt;
    ///
    /// Refund a transaction that has settled and send money back to the account holder. If a transaction hasn't been settled, void it instead.
    /// </summary>
    WithRawResponseTask<RefundResponse> RefundAsync(
        string transId,
        double amount,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// &lt;Warning&gt;
    ///   This endpoint is deprecated. Use it only to refund transactions originally created with the legacy endpoints. To refund a split-funded transaction created with [Make a transaction](/developers/api-reference/moneyinV2/make-a-transaction) or [Authorize](/developers/api-reference/moneyinV2/authorize-a-transaction), use the [Refund endpoint](/developers/api-reference/moneyinV2/refund-a-settled-transaction) with split instructions in the request body.
    /// &lt;/Warning&gt;
    ///
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
    /// &lt;Warning&gt;
    ///   This endpoint is deprecated. Use it only to void transactions originally created with the legacy endpoints. New integrations should use the [Void endpoint](/developers/api-reference/moneyinV2/void-a-transaction), which only works on transactions created with [Make a transaction](/developers/api-reference/moneyinV2/make-a-transaction) or [Authorize](/developers/api-reference/moneyinV2/authorize-a-transaction).
    /// &lt;/Warning&gt;
    ///
    /// Cancel a transaction that hasn't been settled yet. Voiding non-captured authorizations prevents future captures. If a transaction has been settled, refund it instead.
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
    /// Give a full refund for a transaction that has settled and send money back to the account holder. To perform a partial refund, see [Partially refund a transaction](/developers/api-reference/moneyinV2/partial-refund-a-settled-transaction).
    ///
    /// This is the v2 version of the refund endpoint, and returns the unified response format. See [Pay In unified response codes reference](/guides/pay-in-unified-response-codes-reference) for more information.
    ///
    /// &lt;Note&gt;
    ///   To refund a split-funded transaction, include split instructions in the request body. Omit the body for a standard refund.
    /// &lt;/Note&gt;
    /// </summary>
    WithRawResponseTask<V2TransactionResponseWrapper> Refundv2Async(
        string transId,
        RefundV2Request request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Refund a transaction that has settled and send money back to the account holder. If `amount` is set to 0, performs a full refund. When a non-zero `amount` is provided, this endpoint performs a partial refund.
    ///
    /// This is the v2 version of the refund endpoint, and returns the unified response format. See [Pay In unified response codes reference](/guides/pay-in-unified-response-codes-reference) for more information.
    ///
    /// &lt;Note&gt;
    ///   To refund a split-funded transaction, include split instructions in the request body. Omit the body for a standard refund.
    /// &lt;/Note&gt;
    /// </summary>
    WithRawResponseTask<V2TransactionResponseWrapper> Refundv2AmountAsync(
        string transId,
        double amount,
        RefundV2Request request,
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
