using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record UserQueryRecord : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("Access")]
    public IEnumerable<UsrAccess>? Access { get; set; }

    [JsonPropertyName("AdditionalData")]
    public string? AdditionalData { get; set; }

    /// <summary>
    /// The timestamp for the user's creation, in UTC.
    /// </summary>
    [JsonPropertyName("createdAt")]
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// The user's email address.
    /// </summary>
    [JsonPropertyName("Email")]
    public string? Email { get; set; }

    [JsonPropertyName("language")]
    public string? Language { get; set; }

    /// <summary>
    /// The timestamp for the user's last activity, in UTC.
    /// </summary>
    [JsonPropertyName("lastAccess")]
    public DateTime? LastAccess { get; set; }

    [JsonPropertyName("Name")]
    public string? Name { get; set; }

    /// <summary>
    /// The user's phone number.
    /// </summary>
    [JsonPropertyName("Phone")]
    public string? Phone { get; set; }

    [JsonPropertyName("Scope")]
    public IEnumerable<OrgXScope>? Scope { get; set; }

    /// <summary>
    /// Additional data provided by the social network related to the customer.
    /// </summary>
    [JsonPropertyName("snData")]
    public string? SnData { get; set; }

    /// <summary>
    /// Identifier or token for customer in linked social network.
    /// </summary>
    [JsonPropertyName("snIdentifier")]
    public string? SnIdentifier { get; set; }

    /// <summary>
    /// Social network linked to customer. Possible values: facebook, google, twitter, microsoft.
    /// </summary>
    [JsonPropertyName("snProvider")]
    public string? SnProvider { get; set; }

    [JsonPropertyName("timeZone")]
    public int? TimeZone { get; set; }

    /// <summary>
    /// The user's ID in Payabli.
    /// </summary>
    [JsonPropertyName("userId")]
    public long? UserId { get; set; }

    [JsonPropertyName("UsrMFA")]
    public bool? UsrMfa { get; set; }

    [JsonPropertyName("UsrMFAMode")]
    public int? UsrMfaMode { get; set; }

    [JsonPropertyName("UsrStatus")]
    public int? UsrStatus { get; set; }

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
