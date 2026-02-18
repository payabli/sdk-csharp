namespace PayabliApi;

public partial interface IPaypointClient
{
    /// <summary>
    /// Gets the basic details for a paypoint.
    /// </summary>
    WithRawResponseTask<GetBasicEntryResponse> GetBasicEntryAsync(
        string entry,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves the basic details for a paypoint by ID.
    /// </summary>
    WithRawResponseTask<GetBasicEntryByIdResponse> GetBasicEntryByIdAsync(
        string idPaypoint,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Gets the details for a single paypoint.
    /// </summary>
    WithRawResponseTask<GetEntryConfigResponse> GetEntryConfigAsync(
        string entry,
        GetEntryConfigRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Gets the details for single payment page for a paypoint.
    /// </summary>
    WithRawResponseTask<PayabliPages> GetPageAsync(
        string entry,
        string subdomain,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes a payment page in a paypoint.
    /// </summary>
    WithRawResponseTask<PayabliApiResponseGeneric2Part> RemovePageAsync(
        string entry,
        string subdomain,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates a paypoint logo.
    /// </summary>
    WithRawResponseTask<PayabliApiResponse00Responsedatanonobject> SaveLogoAsync(
        string entry,
        FileContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves an paypoint's basic settings like custom fields, identifiers, and invoicing settings.
    /// </summary>
    WithRawResponseTask<SettingsQueryRecord> SettingsPageAsync(
        string entry,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Migrates a paypoint to a new parent organization.
    /// </summary>
    WithRawResponseTask<MigratePaypointResponse> MigrateAsync(
        PaypointMoveRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
