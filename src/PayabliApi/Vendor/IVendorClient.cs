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
    /// Retrieves a vendor's details, including enrichment status and payment acceptance info when available.
    /// </summary>
    WithRawResponseTask<VendorQueryRecord> GetVendorAsync(
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
    /// Delete a vendor.
    /// </summary>
    WithRawResponseTask<PayabliApiResponseVendors> DeleteVendorAsync(
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

    /// <summary>
    /// Schedules an AI outreach call to a vendor to collect their preferred payment method and contact email. This is the third enrichment stage. Calls are scheduled for the next business day at around 9 AM in the vendor's timezone, with retries on no-answer and a fallback payment method applied when retries are exhausted. This feature is opt-in at the org level. Contact your Payabli representative to enable it, provision a phone number, and discuss pricing.
    /// </summary>
    WithRawResponseTask<VendorScheduleCallResponse> ScheduleEnrichmentCallAsync(
        string entry,
        ScheduleEnrichmentCallRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the latest AI outreach call activity for a vendor. The response is a composite object with a `state` discriminator (`none`, `scheduled`, `successful`, or `failed`); the block that matches the current state is populated. When the vendor has no call activity, `state` is `none` and the response returns HTTP 200.
    /// </summary>
    WithRawResponseTask<VendorCallStatusResponse> GetEnrichmentCallStatusAsync(
        long idVendor,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
