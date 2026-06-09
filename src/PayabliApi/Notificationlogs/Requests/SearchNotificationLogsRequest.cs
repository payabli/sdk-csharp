using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record SearchNotificationLogsRequest
{
    /// <summary>
    /// Number of records on each response page.
    /// </summary>
    [JsonIgnore]
    public int? PageSize { get; set; }

    /// <summary>
    /// The page number to retrieve. Defaults to 1 if not provided.
    /// </summary>
    [JsonIgnore]
    public int? Page { get; set; }

    /// <summary>
    /// The start date for the search.
    /// </summary>
    [JsonPropertyName("startDate")]
    public required DateTime StartDate { get; set; }

    /// <summary>
    /// The end date for the search.
    /// </summary>
    [JsonPropertyName("endDate")]
    public required DateTime EndDate { get; set; }

    /// <summary>
    /// The type of notification event to filter by.
    /// </summary>
    [JsonPropertyName("notificationEvent")]
    public string? NotificationEvent { get; set; }

    /// <summary>
    /// Indicates whether the notification was successful.
    /// </summary>
    [JsonPropertyName("succeeded")]
    public bool? Succeeded { get; set; }

    /// <summary>
    /// The ID of the organization to filter by.
    /// </summary>
    [JsonPropertyName("orgId")]
    public long? OrgId { get; set; }

    /// <summary>
    /// The ID of the paypoint to filter by.
    /// </summary>
    [JsonPropertyName("paypointId")]
    public long? PaypointId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
