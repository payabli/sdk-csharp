using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Bill information for an outbound transfer detail.
/// </summary>
[Serializable]
public record TransferOutDetailBill : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Unique identifier for the bill.
    /// </summary>
    [JsonPropertyName("billId")]
    public int? BillId { get; set; }

    /// <summary>
    /// Lot number.
    /// </summary>
    [JsonPropertyName("LotNumber")]
    public string? LotNumber { get; set; }

    /// <summary>
    /// Accounting field 1.
    /// </summary>
    [JsonPropertyName("AccountingField1")]
    public string? AccountingField1 { get; set; }

    /// <summary>
    /// Accounting field 2.
    /// </summary>
    [JsonPropertyName("AccountingField2")]
    public string? AccountingField2 { get; set; }

    /// <summary>
    /// Payment terms.
    /// </summary>
    [JsonPropertyName("Terms")]
    public string? Terms { get; set; }

    /// <summary>
    /// Additional data for the bill.
    /// </summary>
    [JsonPropertyName("AdditionalData")]
    public Dictionary<string, object?>? AdditionalData { get; set; }

    /// <summary>
    /// Attachments for the bill.
    /// </summary>
    [JsonPropertyName("attachments")]
    public IEnumerable<TransferOutDetailBillAttachment>? Attachments { get; set; }

    /// <summary>
    /// Invoice number.
    /// </summary>
    [JsonPropertyName("invoiceNumber")]
    public string? InvoiceNumber { get; set; }

    /// <summary>
    /// Net amount of the bill.
    /// </summary>
    [JsonPropertyName("netAmount")]
    public string? NetAmount { get; set; }

    /// <summary>
    /// Date of the invoice.
    /// </summary>
    [JsonPropertyName("invoiceDate")]
    public string? InvoiceDate { get; set; }

    /// <summary>
    /// Due date for the bill.
    /// </summary>
    [JsonPropertyName("dueDate")]
    public string? DueDate { get; set; }

    /// <summary>
    /// Comments on the bill.
    /// </summary>
    [JsonPropertyName("comments")]
    public string? Comments { get; set; }

    /// <summary>
    /// Identifier for the bill.
    /// </summary>
    [JsonPropertyName("identifier")]
    public string? Identifier { get; set; }

    /// <summary>
    /// Discount applied.
    /// </summary>
    [JsonPropertyName("discount")]
    public double? Discount { get; set; }

    /// <summary>
    /// Total amount of the bill.
    /// </summary>
    [JsonPropertyName("totalAmount")]
    public double? TotalAmount { get; set; }

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
