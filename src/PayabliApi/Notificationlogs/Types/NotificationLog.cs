using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record NotificationLog : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The unique identifier for the notification.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The ID of the organization that the notification belongs to.
    /// </summary>
    [JsonPropertyName("orgId")]
    public long? OrgId { get; set; }

    /// <summary>
    /// The ID of the paypoint that the notification is related to.
    /// </summary>
    [JsonPropertyName("paypointId")]
    public long? PaypointId { get; set; }

    /// <summary>
    /// The event that triggered the notification.
    /// </summary>
    [JsonPropertyName("notificationEvent")]
    public string? NotificationEvent { get; set; }

    /// <summary>
    /// The target URL for the notification.
    /// </summary>
    [JsonPropertyName("target")]
    public string? Target { get; set; }

    /// <summary>
    /// The HTTP response status of the notification.
    /// </summary>
    [JsonPropertyName("responseStatus")]
    public string? ResponseStatus { get; set; }

    /// <summary>
    /// Indicates whether the notification was successful.
    /// </summary>
    [JsonPropertyName("success")]
    public required bool Success { get; set; }

    /// <summary>
    /// Contains the body of the notification.
    /// </summary>
    [JsonPropertyName("jobData")]
    public string? JobData { get; set; }

    /// <summary>
    /// The date and time when the notification was created.
    /// </summary>
    [JsonPropertyName("createdDate")]
    public required DateTime CreatedDate { get; set; }

    /// <summary>
    /// The date and time when the notification was successfully delivered.
    /// </summary>
    [JsonPropertyName("successDate")]
    public DateTime? SuccessDate { get; set; }

    /// <summary>
    /// The date and time when the notification last failed.
    /// </summary>
    [JsonPropertyName("lastFailedDate")]
    public DateTime? LastFailedDate { get; set; }

    /// <summary>
    /// Indicates whether the notification is currently in progress.
    /// </summary>
    [JsonPropertyName("isInProgress")]
    public required bool IsInProgress { get; set; }

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
