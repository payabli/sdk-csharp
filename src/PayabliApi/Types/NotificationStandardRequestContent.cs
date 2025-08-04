using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record NotificationStandardRequestContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The notification's event name.
    /// </summary>
    [JsonPropertyName("eventType")]
    public NotificationStandardRequestContentEventType? EventType { get; set; }

    /// <summary>
    /// Array of pairs key:value to insert in request body to target in **method** = *web*.
    /// </summary>
    [JsonPropertyName("internalData")]
    public IEnumerable<KeyValueDuo>? InternalData { get; set; }

    /// <summary>
    /// Used internally to reference the entity or object generating the event.
    /// </summary>
    [JsonPropertyName("transactionId")]
    public string? TransactionId { get; set; }

    /// <summary>
    /// Array of pairs key:value to insert in header of request to target in **method** = *web*.
    /// </summary>
    [JsonPropertyName("webHeaderParameters")]
    public IEnumerable<KeyValueDuo>? WebHeaderParameters { get; set; }

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
