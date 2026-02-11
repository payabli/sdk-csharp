using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Event data for an outbound transfer detail.
/// </summary>
[Serializable]
public record TransferOutDetailEvent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Description of the transaction event.
    /// </summary>
    [JsonPropertyName("TransEvent")]
    public string? TransEvent { get; set; }

    /// <summary>
    /// Additional event data.
    /// </summary>
    [JsonPropertyName("EventData")]
    public string? EventData { get; set; }

    /// <summary>
    /// Time the event occurred.
    /// </summary>
    [JsonPropertyName("EventTime")]
    public string? EventTime { get; set; }

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
