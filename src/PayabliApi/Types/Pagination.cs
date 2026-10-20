using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Pagination metadata for a list response.
/// </summary>
[Serializable]
public record Pagination : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The current page number.
    /// </summary>
    [JsonPropertyName("page")]
    public int? Page { get; set; }

    /// <summary>
    /// The total number of pages available.
    /// </summary>
    [JsonPropertyName("totalPages")]
    public int? TotalPages { get; set; }

    /// <summary>
    /// The total number of records across all pages.
    /// </summary>
    [JsonPropertyName("totalRecords")]
    public int? TotalRecords { get; set; }

    /// <summary>
    /// The number of records per page.
    /// </summary>
    [JsonPropertyName("pageSize")]
    public int? PageSize { get; set; }

    /// <summary>
    /// Whether a next page is available.
    /// </summary>
    [JsonPropertyName("hasNext")]
    public bool? HasNext { get; set; }

    /// <summary>
    /// Whether a previous page is available.
    /// </summary>
    [JsonPropertyName("hasPrevious")]
    public bool? HasPrevious { get; set; }

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
