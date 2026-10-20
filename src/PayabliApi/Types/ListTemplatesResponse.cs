using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// A page of boarding templates.
/// </summary>
[Serializable]
public record ListTemplatesResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Pagination metadata for the result set.
    /// </summary>
    [JsonPropertyName("Summary")]
    public required TemplatesSummary Summary { get; set; }

    /// <summary>
    /// The templates on this page.
    /// </summary>
    [JsonPropertyName("Records")]
    public IEnumerable<Template> Records { get; set; } = new List<Template>();

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
