using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record UpdateBusinessPersonRequest
{
    /// <summary>
    /// The person's role on the business.
    /// </summary>
    [JsonPropertyName("personType")]
    public PersonType? PersonType { get; set; }

    /// <summary>
    /// The person's ownership percentage (0 to 100).
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
    /// `Only an owner can be the signer.` Changing the signer's `personType`
    /// away from `Owner` returns the same error. Setting it to `true` removes
    /// it from every other person linked to the business. Setting it to
    /// `false` leaves the business with no signer until you set another one.
    /// </summary>
    [JsonPropertyName("isSigner")]
    public bool? IsSigner { get; set; }

    /// <summary>
    /// The person's job title at this business, from 1 to 100 characters. Updating it changes the title
    /// for this business only. Omitting it, or sending `null` or a blank value,
    /// keeps the stored title. You can replace a title, but you can't clear it.
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
