namespace PayabliApi;

public partial interface IPaymentLinkClient
{
    /// <summary>
    /// Generates a payment link for an invoice from the invoice ID.
    /// </summary>
    WithRawResponseTask<PayabliApiResponsePaymentLinks> AddPayLinkFromInvoiceAsync(
        int idInvoice,
        PayLinkDataInvoice request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Generates a payment link for a bill from the bill ID. The vendor receives a secure page where they can select their preferred payment method (ACH, virtual card, or check) and complete the payment.
    /// </summary>
    WithRawResponseTask<PayabliApiResponsePaymentLinks> AddPayLinkFromBillAsync(
        int billId,
        PayLinkDataBill request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes a payment link by ID.
    /// </summary>
    WithRawResponseTask<PayabliApiResponsePaymentLinks> DeletePayLinkFromIdAsync(
        string payLinkId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a payment link by ID.
    /// </summary>
    WithRawResponseTask<GetPayLinkFromIdResponse> GetPayLinkFromIdAsync(
        string paylinkId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Send a payment link to the specified email addresses or phone numbers.
    /// </summary>
    WithRawResponseTask<PayabliApiResponsePaymentLinks> PushPayLinkFromIdAsync(
        string payLinkId,
        PushPayLinkRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Refresh a payment link's content after an update.
    /// </summary>
    WithRawResponseTask<PayabliApiResponsePaymentLinks> RefreshPayLinkFromIdAsync(
        string payLinkId,
        RefreshPayLinkFromIdRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends a payment link to the specified email addresses.
    /// </summary>
    WithRawResponseTask<PayabliApiResponsePaymentLinks> SendPayLinkFromIdAsync(
        string payLinkId,
        SendPayLinkFromIdRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates a payment link's details.
    /// </summary>
    WithRawResponseTask<PayabliApiResponsePaymentLinks> UpdatePayLinkFromIdAsync(
        string payLinkId,
        PayLinkUpdateData request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Generates a vendor payment link for a specific bill lot number. This allows you to pay all bills with the same lot number for a vendor with a single payment link.
    /// </summary>
    WithRawResponseTask<PayabliApiResponsePaymentLinks> AddPayLinkFromBillLotNumberAsync(
        string lotNumber,
        PayLinkDataOut request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Partially updates a Pay Out payment link's content, expiration date, and/or status. Use this to modify the payment page configuration, extend or change the expiration, or cancel a link. Updating the expiration date of an expired link reactivates it to Active status.
    /// </summary>
    WithRawResponseTask<PayabliApiResponsePaymentLinks> PatchOutPaymentLinkAsync(
        string paylinkId,
        PatchOutPaymentLinkRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates the payment page content for a Pay Out payment link. Use this to change the branding, messaging, payment methods offered, or other page configuration.
    /// </summary>
    WithRawResponseTask<PayabliApiResponsePaymentLinks> UpdatePayLinkOutFromIdAsync(
        string paylinkId,
        PaymentPageRequestBodyOut request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
