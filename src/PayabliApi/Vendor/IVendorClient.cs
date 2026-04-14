namespace PayabliApi;

public partial interface IVendorClient
{
    /// <summary>
    /// Creates a vendor in an entrypoint.
    /// </summary>
    WithRawResponseTask<PayabliApiResponseVendors> AddVendorAsync(
        string entry,
        VendorData request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a vendor.
    /// </summary>
    WithRawResponseTask<PayabliApiResponseVendors> DeleteVendorAsync(
        int idVendor,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates a vendor's information. Send only the fields you need to update.
    /// </summary>
    WithRawResponseTask<PayabliApiResponseVendors> EditVendorAsync(
        int idVendor,
        VendorData request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a vendor's details, including enrichment status and payment acceptance info when available.
    /// </summary>
    WithRawResponseTask<VendorQueryRecord> GetVendorAsync(
        int idVendor,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Triggers AI-powered vendor enrichment for an existing vendor. Runs one or more enrichment stages (invoice scan, web search) based on the `scope` parameter. Can automatically apply extracted payment acceptance info and vendor contact information to the vendor record, or return raw results for manual review. Contact Payabli to enable this feature.
    /// </summary>
    WithRawResponseTask<VendorEnrichResponse> EnrichVendorAsync(
        string entry,
        VendorEnrichRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
