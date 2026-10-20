using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record ListPaypointsPaypointsRequest
{
    /// <summary>
    /// Filter by the business the paypoint belongs to.
    /// </summary>
    [JsonIgnore]
    public string? BusinessReference { get; set; }

    /// <summary>
    /// Filter by paypoint status.
    /// </summary>
    [JsonIgnore]
    public string? Status { get; set; }

    /// <summary>
    /// Free-text search across paypoints.
    /// </summary>
    [JsonIgnore]
    public string? Search { get; set; }

    /// <summary>
    /// Number of results per page.
    /// </summary>
    [JsonIgnore]
    public int? Limit { get; set; }

    /// <summary>
    /// Page number to return.
    /// </summary>
    [JsonIgnore]
    public int? Page { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
