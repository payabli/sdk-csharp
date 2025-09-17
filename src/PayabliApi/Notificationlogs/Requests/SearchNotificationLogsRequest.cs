using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record SearchNotificationLogsRequest
{
    [JsonIgnore]
    public int? PageSize { get; set; }

    /// <summary>
    /// The number of records to skip before starting to collect the result set.
    /// </summary>
    [JsonIgnore]
    public int? Skip { get; set; }

    [JsonIgnore]
    public required NotificationLogSearchRequest Body { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
