using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record ListCasesCaseManagementRequest
{
    /// <summary>
    /// The zero-based index of the first record to return.
    /// </summary>
    [JsonIgnore]
    public int? FromRecord { get; set; }

    /// <summary>
    /// The maximum number of records to return (1 to 200).
    /// </summary>
    [JsonIgnore]
    public int? LimitRecord { get; set; }

    /// <summary>
    /// Sort expression, such as `desc(createdAt)` or `asc(state)`. Defaults to `desc(createdAt)`.
    /// </summary>
    [JsonIgnore]
    public string? SortBy { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
