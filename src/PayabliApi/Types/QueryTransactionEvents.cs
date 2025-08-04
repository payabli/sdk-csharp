using System.Text.Json;
using System.Text.Json.Serialization;
using OneOf;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record QueryTransactionEvents : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Any data associated to the event received from processor. Contents vary by event type.
    /// </summary>
    [JsonPropertyName("EventData")]
    public OneOf<Dictionary<string, object?>, string>? EventData { get; set; }

    /// <summary>
    /// Date and time of event.
    /// </summary>
    [JsonPropertyName("EventTime")]
    public DateTime? EventTime { get; set; }

    /// <summary>
    /// Event descriptor. See [TransEvent Reference](/developers/references/transevents) for more details.
    /// </summary>
    [JsonPropertyName("TransEvent")]
    public string? TransEvent { get; set; }

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
