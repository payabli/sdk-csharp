using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record NotificationRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Complete HTTP URL receiving the notification
    /// </summary>
    [JsonPropertyName("notificationUrl")]
    public required string NotificationUrl { get; set; }

    /// <summary>
    /// A dictionary of key-value pairs to be inserted in the header when the notification request is submitted
    /// </summary>
    [JsonPropertyName("webHeaderParameters")]
    public IEnumerable<WebHeaderParameter>? WebHeaderParameters { get; set; }

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
