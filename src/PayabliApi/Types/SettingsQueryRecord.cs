using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record SettingsQueryRecord : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Any custom fields defined for the org.
    /// </summary>
    [JsonPropertyName("customFields")]
    public IEnumerable<KeyValue>? CustomFields { get; set; }

    [JsonPropertyName("forInvoices")]
    public IEnumerable<KeyValue>? ForInvoices { get; set; }

    [JsonPropertyName("forPayOuts")]
    public IEnumerable<KeyValue>? ForPayOuts { get; set; }

    /// <summary>
    /// Information about digital wallet settings for the entity. Available values are `isApplePayEnabled` and `isGooglePayEnabled`.
    /// </summary>
    [JsonPropertyName("forWallets")]
    public IEnumerable<KeyValue>? ForWallets { get; set; }

    [JsonPropertyName("general")]
    public IEnumerable<KeyValue>? General { get; set; }

    [JsonPropertyName("identifiers")]
    public IEnumerable<KeyValue>? Identifiers { get; set; }

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
