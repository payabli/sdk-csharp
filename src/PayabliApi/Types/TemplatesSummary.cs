using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Pagination metadata for a template list response.
/// </summary>
[Serializable]
public record TemplatesSummary : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The total number of pages available.
    /// </summary>
    [JsonPropertyName("totalPages")]
    public required int TotalPages { get; set; }

    /// <summary>
    /// The total number of templates across all pages.
    /// </summary>
    [JsonPropertyName("totalRecords")]
    public required int TotalRecords { get; set; }

    /// <summary>
    /// The number of templates per page.
    /// </summary>
    [JsonPropertyName("pageSize")]
    public required int PageSize { get; set; }

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
