using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record QueryResponseNotificationsRecordsItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Notification content.
    /// </summary>
    [JsonPropertyName("content")]
    public NotificationContent? Content { get; set; }

    /// <summary>
    /// Timestamp of when notification was created, in UTC.
    /// </summary>
    [JsonPropertyName("createdAt")]
    public DateTime? CreatedAt { get; set; }

    [JsonPropertyName("frequency")]
    public Frequencynotification? Frequency { get; set; }

    /// <summary>
    /// Timestamp of when notification was last updated, in UTC.
    /// </summary>
    [JsonPropertyName("lastUpdated")]
    public DateTime? LastUpdated { get; set; }

    [JsonPropertyName("method")]
    public Methodnotification? Method { get; set; }

    [JsonPropertyName("notificationId")]
    public long? NotificationId { get; set; }

    [JsonPropertyName("ownerId")]
    public string? OwnerId { get; set; }

    /// <summary>
    /// Name of entity owner of notification.
    /// </summary>
    [JsonPropertyName("ownerName")]
    public string? OwnerName { get; set; }

    [JsonPropertyName("ownerType")]
    public int? OwnerType { get; set; }

    /// <summary>
    /// Custom descriptor of source of notification.
    /// </summary>
    [JsonPropertyName("source")]
    public string? Source { get; set; }

    [JsonPropertyName("status")]
    public int? Status { get; set; }

    [JsonPropertyName("target")]
    public string? Target { get; set; }

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
