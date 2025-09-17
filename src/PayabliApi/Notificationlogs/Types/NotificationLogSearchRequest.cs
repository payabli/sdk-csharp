using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record NotificationLogSearchRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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
