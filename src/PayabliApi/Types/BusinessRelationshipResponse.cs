using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// The business-person relationship returned when a person is created with a
/// `businessRelationship`. Its contact fields are scoped to the relationship and
/// are distinct from the person's own top-level contact fields.
/// </summary>
[Serializable]
public record BusinessRelationshipResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The reference of the linked business.
    /// </summary>
    [JsonPropertyName("businessReference")]
    public required string BusinessReference { get; set; }

    /// <summary>
    /// The person's role on the business, returned in lowercase (for example `owner`).
    /// </summary>
    [JsonPropertyName("personType")]
    public required string PersonType { get; set; }

    /// <summary>
    /// The person's ownership percentage (0 to 100).
    /// </summary>
    [JsonPropertyName("ownershipPercentage")]
    public double? OwnershipPercentage { get; set; }

    /// <summary>
    /// Whether the person qualifies as a beneficial owner. Derived by Payabli, not sent on create.
    /// </summary>
    [JsonPropertyName("beneficialOwner")]
    public required bool BeneficialOwner { get; set; }

    /// <summary>
    /// Whether the person is the business's primary controller.
    /// </summary>
    [JsonPropertyName("isPrimaryController")]
    public required bool IsPrimaryController { get; set; }

    /// <summary>
    /// Whether the person signs the business's boarding applications.
    /// </summary>
    [JsonPropertyName("isSigner")]
    public required bool IsSigner { get; set; }

    /// <summary>
    /// The person's job title at this business.
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
    /// Reference to the stored billing address for the relationship. The address
    /// is sent as an object on create, then stored and returned by ID.
    /// </summary>
    [JsonPropertyName("billingAddressUuid")]
    public string? BillingAddressUuid { get; set; }

    /// <summary>
    /// Reference to the stored mailing address for the relationship. The address
    /// is sent as an object on create, then stored and returned by ID.
    /// </summary>
    [JsonPropertyName("mailingAddressUuid")]
    public string? MailingAddressUuid { get; set; }

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
