using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// A reference to the paypoint the case applies to.
/// </summary>
[Serializable]
public record PaypointRef : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The paypoint's numeric identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public required long Id { get; set; }

    /// <summary>
    /// The paypoint's DBA name.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

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
