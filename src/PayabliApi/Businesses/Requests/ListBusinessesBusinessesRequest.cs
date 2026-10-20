using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record ListBusinessesBusinessesRequest
{
    /// <summary>
    /// Filter by business status.
    /// </summary>
    [JsonIgnore]
    public string? Status { get; set; }

    /// <summary>
    /// Filter by legal name.
    /// </summary>
    [JsonIgnore]
    public string? Name { get; set; }

    /// <summary>
    /// Filter by merchant category code.
    /// </summary>
    [JsonIgnore]
    public string? MerchantCatCode { get; set; }

    /// <summary>
    /// Filter by legal structure.
    /// </summary>
    [JsonIgnore]
    public string? LegalStructure { get; set; }

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
