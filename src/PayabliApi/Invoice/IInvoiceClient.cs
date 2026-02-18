namespace PayabliApi;

public partial interface IInvoiceClient
{
    /// <summary>
    /// Creates an invoice in an entrypoint.
    /// </summary>
    WithRawResponseTask<InvoiceResponseWithoutData> AddInvoiceAsync(
        string entry,
        AddInvoiceRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes an invoice that's attached to a file.
    /// </summary>
    WithRawResponseTask<InvoiceResponseWithoutData> DeleteAttachedFromInvoiceAsync(
        int idInvoice,
        string filename,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes a single invoice from an entrypoint.
    /// </summary>
    WithRawResponseTask<InvoiceResponseWithoutData> DeleteInvoiceAsync(
        int idInvoice,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates details for a single invoice in an entrypoint.
    /// </summary>
    WithRawResponseTask<InvoiceResponseWithoutData> EditInvoiceAsync(
        int idInvoice,
        EditInvoiceRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a file attached to an invoice.
    /// </summary>
    WithRawResponseTask<FileContent> GetAttachedFileFromInvoiceAsync(
        int idInvoice,
        string filename,
        GetAttachedFileFromInvoiceRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a single invoice by ID.
    /// </summary>
    WithRawResponseTask<GetInvoiceRecord> GetInvoiceAsync(
        int idInvoice,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves the next available invoice number for a paypoint.
    /// </summary>
    WithRawResponseTask<InvoiceNumberResponse> GetInvoiceNumberAsync(
        string entry,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a list of invoices for an entrypoint. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
    /// </summary>
    WithRawResponseTask<QueryInvoiceResponse> ListInvoicesAsync(
        string entry,
        ListInvoicesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a list of invoices for an org. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
    /// </summary>
    WithRawResponseTask<QueryInvoiceResponse> ListInvoicesOrgAsync(
        int orgId,
        ListInvoicesOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends an invoice from an entrypoint via email.
    /// </summary>
    WithRawResponseTask<SendInvoiceResponse> SendInvoiceAsync(
        int idInvoice,
        SendInvoiceRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Export a single invoice in PDF format.
    /// </summary>
    WithRawResponseTask<Dictionary<string, object?>> GetInvoicePdfAsync(
        int idInvoice,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
