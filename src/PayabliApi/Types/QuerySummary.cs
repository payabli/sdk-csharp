using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record QuerySummary : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Pagination token for retrieving the next page of results. Returns `null` when there's no additional page.
    /// </summary>
    [JsonPropertyName("pageidentifier")]
    public string? PageIdentifier { get; set; }

    [JsonPropertyName("pageSize")]
    public int? PageSize { get; set; }

    /// <summary>
    /// Total amount for the records.
    /// </summary>
    [JsonPropertyName("totalAmount")]
    public double? TotalAmount { get; set; }

    /// <summary>
    /// Total net amount for the records.
    /// </summary>
    [JsonPropertyName("totalNetAmount")]
    public double? TotalNetAmount { get; set; }

    [JsonPropertyName("totalPages")]
    public int? TotalPages { get; set; }

    [JsonPropertyName("totalRecords")]
    public int? TotalRecords { get; set; }

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
