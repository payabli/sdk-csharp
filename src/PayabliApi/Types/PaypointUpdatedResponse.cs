using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// The reference and updated timestamp after a paypoint update.
/// </summary>
[Serializable]
public record PaypointUpdatedResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The paypoint reference.
    /// </summary>
    [JsonPropertyName("paypointReference")]
    public required string PaypointReference { get; set; }

    /// <summary>
    /// When the paypoint was last updated.
    /// </summary>
    [JsonPropertyName("updatedAt")]
    public required DateTime UpdatedAt { get; set; }

    /// <summary>
    /// Hypermedia links for the paypoint resource.
    /// </summary>
    [JsonPropertyName("_links")]
    public required PaypointLinks Links { get; set; }

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
