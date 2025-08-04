using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record TransferEvent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Description of the transfer event.
    /// </summary>
    [JsonPropertyName("description")]
    public required string Description { get; set; }

    /// <summary>
    /// Date and time when the transfer event occurred.
    /// </summary>
    [JsonPropertyName("eventTime")]
    public required DateTime EventTime { get; set; }

    /// <summary>
    /// Reference data associated with the transfer event.
    /// </summary>
    [JsonPropertyName("refData")]
    public required string RefData { get; set; }

    /// <summary>
    /// Additional data associated with the transfer event.
    /// </summary>
    [JsonPropertyName("extraData")]
    public required string ExtraData { get; set; }

    /// <summary>
    /// Source of the transfer event.
    /// </summary>
    [JsonPropertyName("source")]
    public required string Source { get; set; }

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
