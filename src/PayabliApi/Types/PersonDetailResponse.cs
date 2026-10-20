using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// The full detail of a person. Sensitive fields are masked unless read from the unmasked endpoint.
/// </summary>
[Serializable]
public record PersonDetailResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The person reference.
    /// </summary>
    [JsonPropertyName("personReference")]
    public required string PersonReference { get; set; }

    /// <summary>
    /// Your own identifier for the person.
    /// </summary>
    [JsonPropertyName("externalId")]
    public string? ExternalId { get; set; }

    /// <summary>
    /// The person's first name.
    /// </summary>
    [JsonPropertyName("firstName")]
    public string? FirstName { get; set; }

    /// <summary>
    /// The person's middle name.
    /// </summary>
    [JsonPropertyName("middleName")]
    public string? MiddleName { get; set; }

    /// <summary>
    /// The person's last name.
    /// </summary>
    [JsonPropertyName("lastName")]
    public string? LastName { get; set; }

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
    /// The person's date of birth. Masked on standard reads (for example `****-**-14`); read the unmasked endpoint for the raw value.
    /// </summary>
    [JsonPropertyName("dateOfBirth")]
    public string? DateOfBirth { get; set; }

    /// <summary>
    /// The person's US Social Security Number. Populated when `nationality` is `US`, otherwise null. Masked on standard reads (for example `***-**-9021`); read the unmasked endpoint for the raw value.
    /// </summary>
    [JsonPropertyName("ssn")]
    public string? Ssn { get; set; }

    /// <summary>
    /// The person's nationality, as a two-letter ISO 3166-1 alpha-2 country code. Not masked. When `US`, `ssn` is populated and the national ID fields are null; for any other value, `nationalIdNumber` and `nationalIdIssuer` are populated and `ssn` is null.
    /// </summary>
    [JsonPropertyName("nationality")]
    public string? Nationality { get; set; }

    /// <summary>
    /// The person's national identification number. Populated when `nationality` is not `US`, otherwise null. Masked on standard reads; read the unmasked endpoint for the raw value.
    /// </summary>
    [JsonPropertyName("nationalIdNumber")]
    public string? NationalIdNumber { get; set; }

    /// <summary>
    /// The authority that issued the national ID, for example the two-letter country code. Populated when `nationality` is not `US`, otherwise null.
    /// </summary>
    [JsonPropertyName("nationalIdIssuer")]
    public string? NationalIdIssuer { get; set; }

    /// <summary>
    /// The person's driver's license number. Masked on standard reads (for example `D1***567`); read the unmasked endpoint for the raw value.
    /// </summary>
    [JsonPropertyName("driversLicenseNumber")]
    public string? DriversLicenseNumber { get; set; }

    /// <summary>
    /// The two-letter state code for the driver's license.
    /// </summary>
    [JsonPropertyName("driversLicenseState")]
    public string? DriversLicenseState { get; set; }

    /// <summary>
    /// Arbitrary key-value data attached to the person. When present,
    /// `templateAnswers` holds this owner's answers to a boarding
    /// template's person-scoped custom questions, meaning questions
    /// whose field path starts with `person.`, such as
    /// `person.backgroundCheck`. Payabli saves them on each owner. It's
    /// an object keyed by field path, and each answer is a string. A
    /// multi-select answer is one comma-separated string.
    ///
    /// Payabli saves the answers when an application is submitted
    /// through the hosted boarding application. Submitting an
    /// application with the API
    /// (`POST /v2/requests/{requestsReference}/submit`) doesn't save them.
    /// Only answers to custom questions are saved, and blank answers,
    /// standard-field answers, and document uploads aren't. A later
    /// hosted submit replaces the answer to the same question and keeps
    /// every other answer, including answers from other applications.
    /// Leaving a question blank on a later submit doesn't remove the
    /// stored answer.
    /// </summary>
    [JsonPropertyName("customData")]
    public Dictionary<string, object?>? CustomData { get; set; }

    /// <summary>
    /// The person's identity verification status, for example `not_started`.
    /// </summary>
    [JsonPropertyName("verificationStatus")]
    public required string VerificationStatus { get; set; }

    /// <summary>
    /// Postal addresses associated with the person.
    /// </summary>
    [JsonPropertyName("addresses")]
    public IEnumerable<PersonAddressResponse>? Addresses { get; set; }

    /// <summary>
    /// Government-issued identification documents for the person.
    /// </summary>
    [JsonPropertyName("identificationDocuments")]
    public IEnumerable<IdentificationDocumentResponse>? IdentificationDocuments { get; set; }

    /// <summary>
    /// The business link created with the person, present when the person was
    /// created with a `businessRelationship`. Null on a standalone person read,
    /// since the relationship is scoped to the business rather than the shared
    /// person.
    /// </summary>
    [JsonPropertyName("businessRelationship")]
    public BusinessRelationshipResponse? BusinessRelationship { get; set; }

    /// <summary>
    /// When the person was created.
    /// </summary>
    [JsonPropertyName("createdAt")]
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// When the person was last updated.
    /// </summary>
    [JsonPropertyName("lastUpdated")]
    public required DateTime LastUpdated { get; set; }

    /// <summary>
    /// Hypermedia links for the person resource.
    /// </summary>
    [JsonPropertyName("_links")]
    public required PersonLinks Links { get; set; }

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
