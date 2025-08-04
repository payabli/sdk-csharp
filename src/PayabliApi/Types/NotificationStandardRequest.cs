using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Information about the standard notification configuration (email, sms, web).
/// </summary>
[Serializable]
public record NotificationStandardRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("content")]
    public NotificationStandardRequestContent? Content { get; set; }

    [JsonPropertyName("frequency")]
    public required NotificationStandardRequestFrequency Frequency { get; set; }

    /// <summary>
    /// Get near-instant notifications via email, SMS, or webhooks for important events like new payment disputes, merchant activations, fraud alerts, approved transactions, settlement history, vendor payouts, and more. Use webhooks with notifications to get real-time updates and automate operations based on key those key events. See [Notifications](/developers/developer-guides/notifications-and-webhooks-overview#notifications) for more.
    /// </summary>
    [JsonPropertyName("method")]
    public required NotificationStandardRequestMethod Method { get; set; }

    [JsonPropertyName("ownerId")]
    public string? OwnerId { get; set; }

    [JsonPropertyName("ownerType")]
    public required int OwnerType { get; set; }

    [JsonPropertyName("status")]
    public int? Status { get; set; }

    /// <summary>
    /// Specify the notification target.
    ///
    /// - For method=email the expected value is a list of email addresses separated by semicolon.
    /// - For method=sms the expected value is a list of phone numbers separated by semicolon.
    /// - For method=web the expected value is a valid and complete URL. Webhooks support only standard HTTP ports: 80, 443, 8080, or 4443.
    /// </summary>
    [JsonPropertyName("target")]
    public required string Target { get; set; }

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
