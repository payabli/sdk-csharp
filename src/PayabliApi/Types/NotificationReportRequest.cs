using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Information about the report notification configuration (report-email, report-web).
/// </summary>
[Serializable]
public record NotificationReportRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("content")]
    public required NotificationReportRequestContent Content { get; set; }

    [JsonPropertyName("frequency")]
    public required NotificationReportRequestFrequency Frequency { get; set; }

    /// <summary>
    /// Automated reporting lets you gather critical reports without manually filtering and exporting the data. Get automated daily, weekly, and monthly report for daily sales, ACH returns, settlements, and more. You can send these reports via email or via webhook. See [Automated Reports](/developers/developer-guides/notifications-and-webhooks-overview#automated-reports) for more.
    /// </summary>
    [JsonPropertyName("method")]
    public required NotificationReportRequestMethod Method { get; set; }

    [JsonPropertyName("ownerId")]
    public string? OwnerId { get; set; }

    [JsonPropertyName("ownerType")]
    public required int OwnerType { get; set; }

    [JsonPropertyName("status")]
    public int? Status { get; set; }

    /// <summary>
    /// Specify the notification target.
    ///
    /// For method=report-email the expected value is a list of email addresses separated by semicolon.
    ///
    /// For method=report-web the expected value is a valid and complete URL. Webhooks support only standard HTTP ports: 80, 443, 8080, or 4443.
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
