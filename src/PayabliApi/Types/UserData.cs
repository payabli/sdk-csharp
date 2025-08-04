using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record UserData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("access")]
    public IEnumerable<UsrAccess>? Access { get; set; }

    [JsonPropertyName("additionalData")]
    public Dictionary<string, Dictionary<string, object?>?>? AdditionalData { get; set; }

    /// <summary>
    /// The user's email address.
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("language")]
    public string? Language { get; set; }

    [JsonPropertyName("mfaData")]
    public MfaData? MfaData { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The user's phone number.
    /// </summary>
    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    [JsonPropertyName("pwd")]
    public string? Pwd { get; set; }

    [JsonPropertyName("scope")]
    public IEnumerable<OrgScope>? Scope { get; set; }

    [JsonPropertyName("timeZone")]
    public int? TimeZone { get; set; }

    [JsonPropertyName("usrStatus")]
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
