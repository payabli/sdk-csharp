using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Fields shared by the search and detail responses for a notification log entry.
/// </summary>
[Serializable]
public record NotificationLogBase : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The name of the organization the notification belongs to.
    /// </summary>
    [JsonPropertyName("organizationName")]
    public required string OrganizationName { get; set; }

    /// <summary>
    /// The name of the paypoint the notification is related to. Empty for organization-level notifications.
    /// </summary>
    [JsonPropertyName("paypointName")]
    public required string PaypointName { get; set; }

    /// <summary>
    /// The identifier for the delivery request.
    /// </summary>
    [JsonPropertyName("requestId")]
    public required string RequestId { get; set; }

    /// <summary>
    /// The unique identifier for the notification.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The ID of the organization the notification belongs to.
    /// </summary>
    [JsonPropertyName("orgId")]
    public long? OrgId { get; set; }

    /// <summary>
    /// The ID of the paypoint the notification is related to. Null for organization-level notifications.
    /// </summary>
    [JsonPropertyName("paypointId")]
    public long? PaypointId { get; set; }

    /// <summary>
    /// The event that triggered the notification, such as `approvedpayment`.
    /// </summary>
    [JsonPropertyName("notificationEvent")]
    public string? NotificationEvent { get; set; }

    /// <summary>
    /// The target the notification was delivered to, such as a webhook URL, email address, or phone number.
    /// </summary>
    [JsonPropertyName("target")]
    public string? Target { get; set; }

    /// <summary>
    /// The HTTP status code the target returned, such as `200`. Returns `0` when the target sent no response.
    /// </summary>
    [JsonPropertyName("responseStatusCode")]
    public required int ResponseStatusCode { get; set; }

    /// <summary>
    /// The delivery status message, such as `OK` when the notification succeeded, `Dropped` when it failed, or `No response received from server.` when the target sent no response.
    /// </summary>
    [JsonPropertyName("responseStatus")]
    public required string ResponseStatus { get; set; }

    /// <summary>
    /// Indicates whether the notification was delivered successfully.
    /// </summary>
    [JsonPropertyName("success")]
    public required bool Success { get; set; }

    /// <summary>
    /// The body of the notification.
    /// </summary>
    [JsonPropertyName("jobData")]
    public string? JobData { get; set; }

    /// <summary>
    /// The date and time when the notification was created.
    /// </summary>
    [JsonPropertyName("createdDate")]
    public required DateTime CreatedDate { get; set; }

    /// <summary>
    /// The date and time when the notification was delivered successfully. Null if it hasn't succeeded.
    /// </summary>
    [JsonPropertyName("successDate")]
    public DateTime? SuccessDate { get; set; }

    /// <summary>
    /// The date and time when the notification last failed. Null if it hasn't failed.
    /// </summary>
    [JsonPropertyName("lastFailedDate")]
    public DateTime? LastFailedDate { get; set; }

    /// <summary>
    /// Indicates whether the notification is currently being sent.
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
