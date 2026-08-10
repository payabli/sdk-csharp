namespace PayabliApi;

public partial interface IBillingClient
{
    /// <summary>
    /// Returns every billing profile that belongs to an organization. This is
    /// the data behind the Profile Library table in the Payabli Portal.
    ///
    /// Requires a token with the `billing_profile_read` permission; a token
    /// without it gets `403 Forbidden`.
    /// </summary>
    WithRawResponseTask<BillingProfileQueryResponse> ListProfilesAsync(
        long orgId,
        ListBillingProfilesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the billing profile currently assigned to an entity, including
    /// its billable events and fee schedules. Use it to read the pricing terms
    /// in effect for an organization, paypoint, template, or application.
    ///
    /// Requires a token with the `billing_profile_read` permission and access
    /// to the requested entity; otherwise the call gets `403 Forbidden`.
    ///
    /// If the entity exists but has no profile assigned, the call returns
    /// `404 Not Found`.
    /// </summary>
    WithRawResponseTask<BillingProfileResponse> GetProfileAsync(
        GetProfileBillingRequestServiceGroup serviceGroup,
        GetProfileBillingRequestEntityType entityType,
        long entityId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
