using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record LineItemQueryRecord : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Timestamp of when line item was created, in UTC.
    /// </summary>
    [JsonPropertyName("createdAt")]
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// Identifier of line item.
    /// </summary>
    [JsonPropertyName("id")]
    public long? Id { get; set; }

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
    /// Internal class of item or product: value '0' is only for invoices , '1' for bills, and '2' common for both.
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

    /// <summary>
    /// Timestamp of when the line item was updated, in UTC.
    /// </summary>
    [JsonPropertyName("lastUpdated")]
    public DateTime? LastUpdated { get; set; }

    [JsonPropertyName("pageidentifier")]
    public string? Pageidentifier { get; set; }

    /// <summary>
    /// The name of the paypoint's parent organization.
    /// </summary>
    [JsonPropertyName("ParentOrgName")]
    public string? ParentOrgName { get; set; }

    /// <summary>
    /// The paypoint's DBA name.
    /// </summary>
    [JsonPropertyName("PaypointDbaname")]
    public string? PaypointDbaname { get; set; }

    /// <summary>
    /// The paypoint's entryname (entrypoint) value.
    /// </summary>
    [JsonPropertyName("PaypointEntryname")]
    public string? PaypointEntryname { get; set; }

    /// <summary>
    /// The paypoint's legal name.
    /// </summary>
    [JsonPropertyName("PaypointLegalname")]
    public string? PaypointLegalname { get; set; }

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
