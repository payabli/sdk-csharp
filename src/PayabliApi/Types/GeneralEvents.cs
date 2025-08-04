using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record GeneralEvents : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Event description.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Event timestamp, in UTC.
    /// </summary>
    [JsonPropertyName("eventTime")]
    public DateTime? EventTime { get; set; }

    /// <summary>
    /// Extra data.
    /// </summary>
    [JsonPropertyName("extraData")]
    public Dictionary<string, object?>? ExtraData { get; set; }

    /// <summary>
    /// Reference data.
    /// </summary>
    [JsonPropertyName("refData")]
    public string? RefData { get; set; }

    /// <summary>
    /// The event source.
    /// </summary>
    [JsonPropertyName("source")]
    public string? Source { get; set; }

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
