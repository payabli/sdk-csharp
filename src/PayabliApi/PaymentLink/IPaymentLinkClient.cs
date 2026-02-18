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
    /// Generates a payment link for a bill from the bill ID.
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
}
