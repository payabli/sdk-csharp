using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// The validation result for one section of the application.
/// </summary>
[Serializable]
public record ValidationSection : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Whether the section has no missing or invalid fields.
    /// </summary>
    [JsonPropertyName("complete")]
    public required bool Complete { get; set; }

    /// <summary>
    /// The fields that are missing or invalid in this section. Empty when the section is complete.
    /// </summary>
    [JsonPropertyName("missingFields")]
    public IEnumerable<ValidationMissingField> MissingFields { get; set; } =
        new List<ValidationMissingField>();

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
