using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Whether the application's stored records meet the requirements for the services it requests.
/// </summary>
[Serializable]
public record ValidationResult : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Whether nothing is missing or invalid in any section.
    /// </summary>
    [JsonPropertyName("valid")]
    public required bool Valid { get; set; }

    /// <summary>
    /// The requirement groups that validation checked, named with Payabli's internal service names (for example, `payInCard` for the `Card` Pay In service).
    /// </summary>
    [JsonPropertyName("servicesEvaluated")]
    public IEnumerable<string> ServicesEvaluated { get; set; } = new List<string>();

    [JsonPropertyName("sections")]
    public required ValidationSections Sections { get; set; }

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
