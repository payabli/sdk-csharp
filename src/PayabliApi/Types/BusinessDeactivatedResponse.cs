using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// The result of deactivating a business.
/// </summary>
[Serializable]
public record BusinessDeactivatedResponse : IJsonOnDeserialized
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
    /// The business status after deactivation (Deactivated).
    /// </summary>
    [JsonPropertyName("businessStatus")]
    public required string BusinessStatus { get; set; }

    /// <summary>
    /// When the business was deactivated.
    /// </summary>
    [JsonPropertyName("deactivatedAt")]
    public required DateTime DeactivatedAt { get; set; }

    /// <summary>
    /// The reason recorded for the deactivation.
    /// </summary>
    [JsonPropertyName("reason")]
    public string? Reason { get; set; }

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
