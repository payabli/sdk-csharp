using OneOf;

namespace PayabliApi;

public partial interface IOrganizationsClient
{
    /// <summary>
    /// Lists organizations with optional filtering and pagination. Only
    /// organizations are returned. Other paypoints never appear in this list.
    /// </summary>
    WithRawResponseTask<ListPaypointsEnvelope> ListOrganizationsAsync(
        ListOrganizationsOrganizationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates an organization. Provide exactly one of `business` (to create
    /// the business inline, recommended) or `businessReference` (an existing
    /// business). In intelligent boarding, an organization is a kind of paypoint, so the
    /// request takes the paypoint create fields except `paypointType`. Payabli
    /// sets the organization type itself. An organization isn't underwritten,
    /// so only the fields needed to create the records are required. New
    /// organizations start in `pending`. If you don't set
    /// `parentPaypointReference`, the organization nests under the
    /// organization your credential belongs to. Returns `409` if an
    /// organization with the same `externalId` already exists.
    /// </summary>
    WithRawResponseTask<PaypointCreatedEnvelope> CreateOrganizationAsync(
        OneOf<
            CreateOrganizationWithInlineBusiness,
            CreateOrganizationWithBusinessReference,
            CreateOrganizationAllFields
        > request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves an organization by reference.
    /// </summary>
    WithRawResponseTask<PaypointDetailEnvelope> GetOrganizationAsync(
        string organizationReference,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Applies a partial update to an organization. Send only the fields you want to change. You can't change an organization's type. If you send `paypointType`, the request ignores it and doesn't return an error.
    /// </summary>
    WithRawResponseTask<PaypointUpdatedEnvelope> UpdateOrganizationAsync(
        string organizationReference,
        UpdateOrganizationRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
