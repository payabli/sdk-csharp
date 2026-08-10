using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Counts of entities the profile is assigned to. Any non-zero count locks the
/// profile from deletion in the Payabli Portal.
/// </summary>
[Serializable]
public record EntitiesAssigned : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Number of organizations the profile is assigned to.
    /// </summary>
    [JsonPropertyName("organizations")]
    public required int Organizations { get; set; }

    /// <summary>
    /// Number of paypoints the profile is assigned to.
    /// </summary>
    [JsonPropertyName("paypoints")]
    public required int Paypoints { get; set; }

    /// <summary>
    /// Number of boarding templates the profile is assigned to.
    /// </summary>
    [JsonPropertyName("templates")]
    public required int Templates { get; set; }

    /// <summary>
    /// Number of boarding applications the profile is assigned to.
    /// </summary>
    [JsonPropertyName("applications")]
    public required int Applications { get; set; }

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
