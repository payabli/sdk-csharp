namespace PayabliApi;

public partial interface IBusinessesClient
{
    /// <summary>
    /// Lists businesses with optional filtering and pagination.
    /// </summary>
    WithRawResponseTask<ListBusinessesEnvelope> ListBusinessesAsync(
        ListBusinessesBusinessesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a business, the legal entity behind a paypoint. New businesses
    /// start in `Draft`. Set `parentReference` to the organization
    /// the business belongs to, or omit it to use the organization your
    /// credential belongs to.
    /// </summary>
    WithRawResponseTask<BusinessCreatedEnvelope> CreateBusinessAsync(
        CreateBusinessRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a business by reference. Sensitive fields such as `taxReference` are masked.
    /// </summary>
    WithRawResponseTask<BusinessDetailEnvelope> GetBusinessAsync(
        string businessReference,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deactivates a business. This is a soft delete: the business moves to
    /// `Deactivated` and the record is kept.
    /// </summary>
    WithRawResponseTask<BusinessDeactivatedEnvelope> DeactivateBusinessAsync(
        string businessReference,
        DeactivateBusinessRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Applies a partial update to a business. Send only the fields you want to change.
    /// </summary>
    WithRawResponseTask<BusinessUpdatedEnvelope> UpdateBusinessAsync(
        string businessReference,
        UpdateBusinessRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a business by reference with sensitive fields unmasked.
    /// </summary>
    WithRawResponseTask<BusinessDetailEnvelope> GetBusinessUnmaskedAsync(
        string businessReference,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Lists the addresses on a business. Each address is identified by its `businessAddressReference`.
    /// </summary>
    WithRawResponseTask<BusinessAddressListEnvelope> ListBusinessAddressesAsync(
        string businessReference,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Adds an address to a business. Returns the new address and its `businessAddressReference`.
    /// </summary>
    WithRawResponseTask<BusinessAddressEnvelope> CreateBusinessAddressAsync(
        string businessReference,
        CreateBusinessAddressRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a single business address by its `businessAddressReference`.
    /// </summary>
    WithRawResponseTask<BusinessAddressEnvelope> GetBusinessAddressAsync(
        string businessReference,
        string businessAddressReference,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Removes an address from a business.
    /// </summary>
    WithRawResponseTask<BusinessAddressDeletedEnvelope> DeleteBusinessAddressAsync(
        string businessReference,
        string businessAddressReference,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Applies a partial update to a business address. Send only the fields you want to change; omitted fields are kept.
    /// </summary>
    WithRawResponseTask<BusinessAddressEnvelope> UpdateBusinessAddressAsync(
        string businessReference,
        string businessAddressReference,
        UpdateBusinessAddressRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Lists the people linked to a business, each with the relationship's role, ownership, and relationship-scoped contact details.
    /// </summary>
    WithRawResponseTask<BusinessPersonListEnvelope> ListBusinessPeopleAsync(
        string businessReference,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Links an existing person to a business, setting the relationship's role, ownership, primary-controller flag, contact fields, and addresses.
    /// </summary>
    WithRawResponseTask<BusinessPersonEnvelope> LinkBusinessPersonAsync(
        string businessReference,
        LinkBusinessPersonRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a single business-person link by the person's reference.
    /// </summary>
    WithRawResponseTask<BusinessPersonEnvelope> GetBusinessPersonAsync(
        string businessReference,
        string personReference,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Removes the link between a person and a business. The person record itself isn't deleted.
    /// </summary>
    WithRawResponseTask UnlinkBusinessPersonAsync(
        string businessReference,
        string personReference,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Applies a partial update to a business-person link. Send only the fields you want to change; omitted fields are kept.
    /// </summary>
    WithRawResponseTask<BusinessPersonEnvelope> UpdateBusinessPersonAsync(
        string businessReference,
        string personReference,
        UpdateBusinessPersonRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
