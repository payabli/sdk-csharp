using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record ListMessagesCaseManagementRequest
{
    /// <summary>
    /// The maximum number of notes to return (default 50, max 200).
    /// </summary>
    [JsonIgnore]
    public int? Limit { get; set; }

    /// <summary>
    /// An opaque cursor for the next page.
    /// </summary>
    [JsonIgnore]
    public string? Cursor { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
