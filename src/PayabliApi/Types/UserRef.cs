using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// A reference to a user, with the display name resolved when available.
/// </summary>
[Serializable]
public record UserRef : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The user's numeric identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public required long Id { get; set; }

    /// <summary>
    /// The user's display name. Null when the name can't be resolved.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

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
