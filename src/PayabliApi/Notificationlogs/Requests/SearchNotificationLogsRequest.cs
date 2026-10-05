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
    /// The start date for the search. Can't be more than 30 days before `endDate`.
    /// </summary>
    [JsonPropertyName("startDate")]
    public required DateTime StartDate { get; set; }

    /// <summary>
    /// The end date for the search. Can't be more than 30 days after `startDate`.
    /// </summary>
    [JsonPropertyName("endDate")]
    public required DateTime EndDate { get; set; }

    /// <summary>
    /// The event to filter by, such as `approvedpayment`. Case-insensitive.
    /// </summary>
    [JsonPropertyName("notificationEvent")]
    public string? NotificationEvent { get; set; }

    /// <summary>
    /// Filter by delivery outcome. Set to `false` to return only failed notifications.
    /// </summary>
    [JsonPropertyName("succeeded")]
    public bool? Succeeded { get; set; }

    /// <summary>
    /// The ID of the organization to filter by. Either `orgId` or `paypointId` is required.
    /// </summary>
    [JsonPropertyName("orgId")]
    public long? OrgId { get; set; }

    /// <summary>
    /// The ID of the paypoint to filter by. Either `orgId` or `paypointId` is required.
    /// </summary>
    [JsonPropertyName("paypointId")]
    public long? PaypointId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
