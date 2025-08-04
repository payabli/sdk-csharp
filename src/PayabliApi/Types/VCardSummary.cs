using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record VCardSummary : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("totalPages")]
    public required int TotalPages { get; set; }

    [JsonPropertyName("totalRecords")]
    public required int TotalRecords { get; set; }

    /// <summary>
    /// Total amount for the records.
    /// </summary>
    [JsonPropertyName("totalAmount")]
    public required double TotalAmount { get; set; }

    /// <summary>
    /// Total number of active vCards.
    /// </summary>
    [JsonPropertyName("totalactive")]
    public required int Totalactive { get; set; }

    /// <summary>
    /// Total amount of active vCards.
    /// </summary>
    [JsonPropertyName("totalamounteactive")]
    public required double Totalamounteactive { get; set; }

    /// <summary>
    /// Total balance of active vCards.
    /// </summary>
    [JsonPropertyName("totalbalanceactive")]
    public required double Totalbalanceactive { get; set; }

    [JsonPropertyName("pageIdentifier")]
    public string? PageIdentifier { get; set; }

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
