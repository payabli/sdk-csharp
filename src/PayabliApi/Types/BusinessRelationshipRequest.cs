using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Links the person to a business as part of a person-create request. The
/// contact fields here are scoped to the business-person relationship and are
/// distinct from the person's own top-level `primaryEmail`, `primaryPhoneNumber`,
/// and so on.
/// </summary>
[Serializable]
public record BusinessRelationshipRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The reference of the business to link the person to.
    /// </summary>
    [JsonPropertyName("businessReference")]
    public required string BusinessReference { get; set; }

    /// <summary>
    /// The person's role on the business.
    /// </summary>
    [JsonPropertyName("personType")]
    public PersonType? PersonType { get; set; }

    /// <summary>
    /// The person's ownership percentage (0 to 100). Required when `personType`
    /// is `Owner`, and must be omitted for every other role. If linking the
    /// owner would push the business over 100% total ownership, the person is
    /// still created but the link doesn't complete. The response has `success`
    /// set to `false`, omits `businessRelationship` from the person, and
    /// returns a `LINK_OWNERSHIP_EXCEEDED` entry in `warnings`.
    /// </summary>
    [JsonPropertyName("ownershipPercentage")]
    public double? OwnershipPercentage { get; set; }

    /// <summary>
    /// Whether the person is the business's primary controller.
    /// </summary>
    [JsonPropertyName("isPrimaryController")]
    public bool? IsPrimaryController { get; set; }

    /// <summary>
    /// Whether the person signs the business's boarding applications. Only an
    /// owner can be the signer. Setting `isSigner` to `true` on a person with
    /// another `personType` returns `400` with the message
    /// `Only an owner can be the signer.` A business has one signer. Setting
    /// `isSigner` to `true` on one person removes it from every other person
    /// linked to the business.
    /// </summary>
    [JsonPropertyName("isSigner")]
    public bool? IsSigner { get; set; }

    /// <summary>
    /// The person's job title at this business, such as `CEO` or
    /// `Managing Member`, from 1 to 100 characters. A person linked to more than
    /// one business can have a different title at each one. A blank value is
    /// treated as not sent.
    /// </summary>
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    /// <summary>
    /// The relationship's primary email address.
    /// </summary>
    [JsonPropertyName("primaryEmail")]
    public string? PrimaryEmail { get; set; }

    /// <summary>
    /// The relationship's secondary email address.
    /// </summary>
    [JsonPropertyName("secondaryEmail")]
    public string? SecondaryEmail { get; set; }

    /// <summary>
    /// The relationship's primary phone number.
    /// </summary>
    [JsonPropertyName("primaryPhoneNumber")]
    public string? PrimaryPhoneNumber { get; set; }

    /// <summary>
    /// The relationship's secondary phone number.
    /// </summary>
    [JsonPropertyName("secondaryPhoneNumber")]
    public string? SecondaryPhoneNumber { get; set; }

    /// <summary>
    /// The billing address for the relationship.
    /// </summary>
    [JsonPropertyName("billingAddress")]
    public PersonAddressRequest? BillingAddress { get; set; }

    /// <summary>
    /// The mailing address for the relationship.
    /// </summary>
    [JsonPropertyName("mailingAddress")]
    public PersonAddressRequest? MailingAddress { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
