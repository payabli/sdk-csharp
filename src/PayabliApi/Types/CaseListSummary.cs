using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Pagination and totals for a case list response.
/// </summary>
[Serializable]
public record CaseListSummary : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The total number of matching cases.
    /// </summary>
    [JsonPropertyName("totalRecords")]
    public required int TotalRecords { get; set; }

    /// <summary>
    /// Not used for cases; returned as part of the shared list envelope.
    /// </summary>
    [JsonPropertyName("totalAmount")]
    public required double TotalAmount { get; set; }

    /// <summary>
    /// Not used for cases; returned as part of the shared list envelope.
    /// </summary>
    [JsonPropertyName("totalNetAmount")]
    public required double TotalNetAmount { get; set; }

    /// <summary>
    /// The total number of pages.
    /// </summary>
    [JsonPropertyName("totalPages")]
    public required int TotalPages { get; set; }

    /// <summary>
    /// The number of records per page.
    /// </summary>
    [JsonPropertyName("pageSize")]
    public required int PageSize { get; set; }

    /// <summary>
    /// An opaque page identifier, when present.
    /// </summary>
    [JsonPropertyName("pageidentifier")]
    public string? Pageidentifier { get; set; }

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
