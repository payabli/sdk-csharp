using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record CreatePersonRequest
{
    /// <summary>
    /// The person's first name.
    /// </summary>
    [JsonPropertyName("firstName")]
    public required string FirstName { get; set; }

    /// <summary>
    /// The person's middle name.
    /// </summary>
    [JsonPropertyName("middleName")]
    public string? MiddleName { get; set; }

    /// <summary>
    /// The person's last name.
    /// </summary>
    [JsonPropertyName("lastName")]
    public required string LastName { get; set; }

    /// <summary>
    /// The person's primary email address.
    /// </summary>
    [JsonPropertyName("primaryEmail")]
    public string? PrimaryEmail { get; set; }

    /// <summary>
    /// The person's secondary email address.
    /// </summary>
    [JsonPropertyName("secondaryEmail")]
    public string? SecondaryEmail { get; set; }

    /// <summary>
    /// The person's primary phone number.
    /// </summary>
    [JsonPropertyName("primaryPhoneNumber")]
    public string? PrimaryPhoneNumber { get; set; }

    /// <summary>
    /// The person's secondary phone number.
    /// </summary>
    [JsonPropertyName("secondaryPhoneNumber")]
    public string? SecondaryPhoneNumber { get; set; }

    /// <summary>
    /// The person's date of birth (`YYYY-MM-DD`).
    /// </summary>
    [JsonPropertyName("dateOfBirth")]
    public string? DateOfBirth { get; set; }

    /// <summary>
    /// The person's US Social Security Number, in `XXX-XX-XXXX` or `XXXXXXXXX` format. Applies when `nationality` is `US`, and needed to validate a US owner. Create doesn't enforce it. For any other nationality, send `nationalIdNumber` and `nationalIdIssuer` instead.
    /// </summary>
    [JsonPropertyName("ssn")]
    public string? Ssn { get; set; }

    /// <summary>
    /// The person's nationality, as a two-letter ISO 3166-1 alpha-2 country code. Needed to validate an owner, but create doesn't enforce it. Nationality selects which identity number applies. `US` uses `ssn`, and any other value uses `nationalIdNumber` and `nationalIdIssuer`.
    /// </summary>
    [JsonPropertyName("nationality")]
    public string? Nationality { get; set; }

    /// <summary>
    /// The person's national identification number, for an individual whose `nationality` is not `US`. Send it with `nationalIdIssuer` when `nationality` is non-US. Create doesn't enforce it.
    /// </summary>
    [JsonPropertyName("nationalIdNumber")]
    public string? NationalIdNumber { get; set; }

    /// <summary>
    /// The authority that issued the national ID, for example the two-letter country code. Send it with `nationalIdNumber` when `nationality` is non-US. Create doesn't enforce it.
    /// </summary>
    [JsonPropertyName("nationalIdIssuer")]
    public string? NationalIdIssuer { get; set; }

    /// <summary>
    /// The person's driver's license number.
    /// </summary>
    [JsonPropertyName("driversLicenseNumber")]
    public string? DriversLicenseNumber { get; set; }

    /// <summary>
    /// The two-letter state code for the driver's license.
    /// </summary>
    [JsonPropertyName("driversLicenseState")]
    public string? DriversLicenseState { get; set; }

    /// <summary>
    /// Your own identifier for the person.
    /// </summary>
    [JsonPropertyName("externalId")]
    public string? ExternalId { get; set; }

    /// <summary>
    /// Arbitrary key-value data you attach to the person. Payabli
    /// stores an owner's answers to a boarding template's custom
    /// questions under the `templateAnswers` key.
    /// </summary>
    [JsonPropertyName("customData")]
    public Dictionary<string, object?>? CustomData { get; set; }

    /// <summary>
    /// Postal addresses associated with the person.
    /// </summary>
    [JsonPropertyName("addresses")]
    public IEnumerable<PersonAddressRequest>? Addresses { get; set; }

    /// <summary>
    /// Government-issued identification documents for the person.
    /// </summary>
    [JsonPropertyName("identificationDocuments")]
    public IEnumerable<IdentificationDocumentRequest>? IdentificationDocuments { get; set; }

    /// <summary>
    /// Links the person to a business as you create them. The link's role,
    /// ownership, primary-controller flag, contact fields, and addresses go here.
    /// These relationship contact fields are separate from the person's own
    /// top-level contact fields above.
    /// </summary>
    [JsonPropertyName("businessRelationship")]
    public BusinessRelationshipRequest? BusinessRelationship { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
