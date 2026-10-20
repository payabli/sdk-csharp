using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record LinkBusinessPersonRequest
{
    /// <summary>
    /// The reference of the person to link.
    /// </summary>
    [JsonPropertyName("personReference")]
    public required string PersonReference { get; set; }

    /// <summary>
    /// The person's role on the business.
    /// </summary>
    [JsonPropertyName("personType")]
    public PersonType? PersonType { get; set; }

    /// <summary>
    /// The person's ownership percentage (0 to 100). Required when `personType` is `Owner`, and must be omitted for every other role. If the combined ownership would exceed 100%, the link is rejected with a `400`.
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

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
