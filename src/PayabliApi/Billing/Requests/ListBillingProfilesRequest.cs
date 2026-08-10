using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record ListBillingProfilesRequest
{
    /// <summary>
    /// Filter to profiles whose name contains this string.
    /// </summary>
    [JsonIgnore]
    public string? ProfileName { get; set; }

    /// <summary>
    /// Filter by fee type. Repeatable to match more than one. Send the enum
    /// value (`1` Flat, `2` ICP).
    /// </summary>
    [JsonIgnore]
    public IEnumerable<int> FeeType { get; set; } = new List<int>();

    /// <summary>
    /// Filter by billing vertical. Repeatable to match more than one. Send
    /// the enum value (`1` PayIn, `2` PayOut, `3` PayOps).
    /// </summary>
    [JsonIgnore]
    public IEnumerable<int> ServiceVertical { get; set; } = new List<int>();

    /// <summary>
    /// Filter to a single profile by its identifier.
    /// </summary>
    [JsonIgnore]
    public long? ProfileId { get; set; }

    /// <summary>
    /// Page size. Defaults to `20`. Passing `0` returns no records — use a
    /// positive value to page through results.
    /// </summary>
    [JsonIgnore]
    public long? LimitRecord { get; set; }

    /// <summary>
    /// Zero-based offset into the result set. Defaults to `0`.
    /// </summary>
    [JsonIgnore]
    public long? FromRecord { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
