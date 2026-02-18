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
    /// Retrieves a vendor's details.
    /// </summary>
    WithRawResponseTask<VendorQueryRecord> GetVendorAsync(
        int idVendor,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
