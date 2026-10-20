using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// A single identity match returned by a search.
/// </summary>
[Serializable]
public record PeopleSearchResultResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The person reference of the matching existing person. Null when `isFromVendor` is `true`.
    /// </summary>
    [JsonPropertyName("personReference")]
    public string? PersonReference { get; set; }

    /// <summary>
    /// The matched first name.
    /// </summary>
    [JsonPropertyName("firstName")]
    public string? FirstName { get; set; }

    /// <summary>
    /// The matched last name.
    /// </summary>
    [JsonPropertyName("lastName")]
    public string? LastName { get; set; }

    /// <summary>
    /// The matched date of birth. The standard search masks it (for example `****-**-14`), and the unmasked search returns the full `YYYY-MM-DD` value.
    /// </summary>
    [JsonPropertyName("dateOfBirth")]
    public string? DateOfBirth { get; set; }

    /// <summary>
    /// The matched primary email address.
    /// </summary>
    [JsonPropertyName("primaryEmail")]
    public string? PrimaryEmail { get; set; }

    /// <summary>
    /// The matched primary phone number.
    /// </summary>
    [JsonPropertyName("primaryPhone")]
    public string? PrimaryPhone { get; set; }

    /// <summary>
    /// The risk decision for the match.
    /// </summary>
    [JsonPropertyName("riskDecision")]
    public string? RiskDecision { get; set; }

    /// <summary>
    /// How closely the record matches the search criteria.
    /// </summary>
    [JsonPropertyName("matchScore")]
    public double? MatchScore { get; set; }

    /// <summary>
    /// Whether this is the highest-scoring match.
    /// </summary>
    [JsonPropertyName("isTopMatch")]
    public bool? IsTopMatch { get; set; }

    /// <summary>
    /// When `true`, no existing person matched, and this result comes only from the identity vendor. A vendor result has no `personReference`.
    /// </summary>
    [JsonPropertyName("isFromVendor")]
    public bool? IsFromVendor { get; set; }

    /// <summary>
    /// The person's phone numbers.
    /// </summary>
    [JsonPropertyName("phones")]
    public IEnumerable<string>? Phones { get; set; }

    /// <summary>
    /// The person's email addresses.
    /// </summary>
    [JsonPropertyName("emails")]
    public IEnumerable<string>? Emails { get; set; }

    /// <summary>
    /// The number of addresses on file for the person.
    /// </summary>
    [JsonPropertyName("addressCount")]
    public int? AddressCount { get; set; }

    /// <summary>
    /// The number of phone numbers on file for the person.
    /// </summary>
    [JsonPropertyName("phoneCount")]
    public int? PhoneCount { get; set; }

    /// <summary>
    /// The number of email addresses on file for the person.
    /// </summary>
    [JsonPropertyName("emailCount")]
    public int? EmailCount { get; set; }

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
