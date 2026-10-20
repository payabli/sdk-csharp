using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record ListPeoplePeopleRequest
{
    /// <summary>
    /// Filter by name (partial match).
    /// </summary>
    [JsonIgnore]
    public string? Name { get; set; }

    /// <summary>
    /// Filter by email (partial match).
    /// </summary>
    [JsonIgnore]
    public string? Email { get; set; }

    /// <summary>
    /// Comma-separated verification status filter.
    /// </summary>
    [JsonIgnore]
    public string? VerificationStatus { get; set; }

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

    /// <summary>
    /// Field to sort by.
    /// </summary>
    [JsonIgnore]
    public string? SortBy { get; set; }

    /// <summary>
    /// Sort direction.
    /// </summary>
    [JsonIgnore]
    public string? SortOrder { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
