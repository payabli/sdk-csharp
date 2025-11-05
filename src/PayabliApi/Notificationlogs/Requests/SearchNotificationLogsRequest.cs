using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record SearchNotificationLogsRequest
{
    [JsonIgnore]
    public int? PageSize { get; set; }

    /// <summary>
    /// The page number to retrieve. Defaults to 1 if not provided.
    /// </summary>
    [JsonIgnore]
    public int? Page { get; set; }

    [JsonIgnore]
    public required NotificationLogSearchRequest Body { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
