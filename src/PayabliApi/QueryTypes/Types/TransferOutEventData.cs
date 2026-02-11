using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Event data associated with an outbound transfer.
/// </summary>
[Serializable]
public record TransferOutEventData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Description of the event.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// The time the event occurred.
    /// </summary>
    [JsonPropertyName("eventTime")]
    public string? EventTime { get; set; }

    /// <summary>
    /// Reference data for the event.
    /// </summary>
    [JsonPropertyName("refData")]
    public string? RefData { get; set; }

    /// <summary>
    /// Additional event data, which may contain detailed transaction information.
    /// </summary>
    [JsonPropertyName("extraData")]
    public object? ExtraData { get; set; }

    /// <summary>
    /// The source of the event.
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
