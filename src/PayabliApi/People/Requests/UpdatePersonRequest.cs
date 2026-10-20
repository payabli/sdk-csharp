using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record UpdatePersonRequest
{
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
    /// The person's nationality, as a two-letter ISO 3166-1 alpha-2 country code. Nationality selects which identity number applies — `US` uses `ssn`, and any other value uses `nationalIdNumber` and `nationalIdIssuer`.
    /// </summary>
    [JsonPropertyName("nationality")]
    public string? Nationality { get; set; }

    /// <summary>
    /// The authority that issued the national ID, used when `nationality` is not `US`.
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
    /// Key-value data to merge into the person's stored `customData`.
    /// Payabli stores an owner's answers to a boarding template's
    /// custom questions under the `templateAnswers` key.
    ///
    /// When you update a person, Payabli merges `customData` into the
    /// stored value, following JSON Merge Patch (RFC 7396). Keys you
    /// don't send are kept at every depth, and nested objects merge key
    /// by key. Strings, numbers, Boolean values, and arrays replace the
    /// stored value, and arrays aren't merged. Send a key as `null` to
    /// delete it, such as `{"crmId": null}`. A `customData` that isn't
    /// an object, such as an array, replaces the stored value whole.
    /// Leave out `customData` to keep it as is.
    ///
    /// The `customData` you send can be up to 65,536 bytes serialized.
    /// The limit applies to the request, not to the merged result.
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

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
