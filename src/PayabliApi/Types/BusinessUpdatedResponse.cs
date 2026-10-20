using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// The reference and updated timestamp after a business update.
/// </summary>
[Serializable]
public record BusinessUpdatedResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The business reference.
    /// </summary>
    [JsonPropertyName("businessUuid")]
    public required string BusinessUuid { get; set; }

    /// <summary>
    /// When the business was last updated.
    /// </summary>
    [JsonPropertyName("lastUpdated")]
    public required DateTime LastUpdated { get; set; }

    /// <summary>
    /// Hypermedia links for the business resource.
    /// </summary>
    [JsonPropertyName("_links")]
    public required BusinessLinks Links { get; set; }

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
