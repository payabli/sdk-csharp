using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Summary information for outbound transfer queries.
/// </summary>
[Serializable]
public record TransferOutSummary : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Number of pages in the response.
    /// </summary>
    [JsonPropertyName("totalPages")]
    public int? TotalPages { get; set; }

    /// <summary>
    /// Number of records in the response.
    /// </summary>
    [JsonPropertyName("totalRecords")]
    public int? TotalRecords { get; set; }

    /// <summary>
    /// Number of records per page.
    /// </summary>
    [JsonPropertyName("pageSize")]
    public int? PageSize { get; set; }

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
