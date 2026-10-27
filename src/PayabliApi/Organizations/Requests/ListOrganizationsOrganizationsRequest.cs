using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record ListOrganizationsOrganizationsRequest
{
    /// <summary>
    /// Filter by the business the organization belongs to.
    /// </summary>
    [JsonIgnore]
    public string? BusinessReference { get; set; }

    /// <summary>
    /// Filter by organization status. One of `active`, `inactive`, `suspended`, or `closed`. Any other value returns `400`.
    /// </summary>
    [JsonIgnore]
    public string? Status { get; set; }

    /// <summary>
    /// Free-text search across organizations.
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
