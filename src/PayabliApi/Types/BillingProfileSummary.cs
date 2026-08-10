using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Pagination summary for the profile list.
/// </summary>
[Serializable]
public record BillingProfileSummary : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Opaque identifier for the returned page.
    /// </summary>
    [JsonPropertyName("pageIdentifier")]
    public required string PageIdentifier { get; set; }

    /// <summary>
    /// Maximum number of records per page.
    /// </summary>
    [JsonPropertyName("pageSize")]
    public required int PageSize { get; set; }

    /// <summary>
    /// Total number of pages available.
    /// </summary>
    [JsonPropertyName("totalPages")]
    public required int TotalPages { get; set; }

    /// <summary>
    /// Total number of profiles matching the query.
    /// </summary>
    [JsonPropertyName("totalRecords")]
    public required int TotalRecords { get; set; }

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
