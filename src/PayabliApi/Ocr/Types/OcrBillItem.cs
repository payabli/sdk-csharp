using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record OcrBillItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("itemTotalAmount")]
    public double? ItemTotalAmount { get; set; }

    [JsonPropertyName("itemTaxAmount")]
    public double? ItemTaxAmount { get; set; }

    [JsonPropertyName("itemTaxRate")]
    public double? ItemTaxRate { get; set; }

    [JsonPropertyName("itemProductCode")]
    public string? ItemProductCode { get; set; }

    [JsonPropertyName("itemProductName")]
    public string? ItemProductName { get; set; }

    [JsonPropertyName("itemDescription")]
    public string? ItemDescription { get; set; }

    [JsonPropertyName("itemCommodityCode")]
    public string? ItemCommodityCode { get; set; }

    [JsonPropertyName("itemUnitOfMeasure")]
    public string? ItemUnitOfMeasure { get; set; }

    [JsonPropertyName("itemCost")]
    public double? ItemCost { get; set; }

    [JsonPropertyName("itemQty")]
    public int? ItemQty { get; set; }

    [JsonPropertyName("itemMode")]
    public int? ItemMode { get; set; }

    [JsonPropertyName("itemCategories")]
    public IEnumerable<string>? ItemCategories { get; set; }

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
