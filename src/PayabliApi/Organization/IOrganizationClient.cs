namespace PayabliApi;

public partial interface IOrganizationClient
{
    /// <summary>
    /// Creates an organization under a parent organization. This is also referred to as a suborganization.
    /// </summary>
    WithRawResponseTask<AddOrganizationResponse> AddOrganizationAsync(
        AddOrganizationRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete an organization by ID.
    /// </summary>
    WithRawResponseTask<DeleteOrganizationResponse> DeleteOrganizationAsync(
        int orgId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates an organization's details by ID.
    /// </summary>
    WithRawResponseTask<EditOrganizationResponse> EditOrganizationAsync(
        int orgId,
        OrganizationData request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Gets an organization's basic information by entry name (entrypoint identifier).
    /// </summary>
    WithRawResponseTask<OrganizationQueryRecord> GetBasicOrganizationAsync(
        string entry,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Gets an organizations basic details by org ID.
    /// </summary>
    WithRawResponseTask<OrganizationQueryRecord> GetBasicOrganizationByIdAsync(
        int orgId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves details for an organization by ID.
    /// </summary>
    WithRawResponseTask<OrganizationQueryRecord> GetOrganizationAsync(
        int orgId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves an organization's settings.
    /// </summary>
    WithRawResponseTask<SettingsQueryRecord> GetSettingsOrganizationAsync(
        int orgId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
