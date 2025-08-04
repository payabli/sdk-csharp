using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record LineItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Array of tags classifying item or product.
    /// </summary>
    [JsonPropertyName("itemCategories")]
    public IEnumerable<string>? ItemCategories { get; set; }

    [JsonPropertyName("itemCommodityCode")]
    public string? ItemCommodityCode { get; set; }

    /// <summary>
    /// Item or product price per unit.
    /// </summary>
    [JsonPropertyName("itemCost")]
    public required double ItemCost { get; set; }

    [JsonPropertyName("itemDescription")]
    public string? ItemDescription { get; set; }

    /// <summary>
    /// Internal class of item or product: value '0' is only for invoices, '1' for bills, and '2' is common for both.
    /// </summary>
    [JsonPropertyName("itemMode")]
    public int? ItemMode { get; set; }

    [JsonPropertyName("itemProductCode")]
    public string? ItemProductCode { get; set; }

    [JsonPropertyName("itemProductName")]
    public string? ItemProductName { get; set; }

    /// <summary>
    /// Quantity of item or product.
    /// </summary>
    [JsonPropertyName("itemQty")]
    public required int ItemQty { get; set; }

    [JsonPropertyName("itemUnitOfMeasure")]
    public string? ItemUnitOfMeasure { get; set; }

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
