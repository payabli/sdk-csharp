using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Invoice information if transaction is associated with an invoice
/// </summary>
[Serializable]
public record TransactionDetailInvoiceData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("invoiceNumber")]
    public string? InvoiceNumber { get; set; }

    [JsonPropertyName("invoiceDate")]
    public DateOnly? InvoiceDate { get; set; }

    [JsonPropertyName("invoiceDueDate")]
    public DateOnly? InvoiceDueDate { get; set; }

    [JsonPropertyName("invoiceEndDate")]
    public DateOnly? InvoiceEndDate { get; set; }

    [JsonPropertyName("invoiceStatus")]
    public int? InvoiceStatus { get; set; }

    [JsonPropertyName("invoiceType")]
    public int? InvoiceType { get; set; }

    [JsonPropertyName("frequency")]
    public Frequency? Frequency { get; set; }

    [JsonPropertyName("paymentTerms")]
    public string? PaymentTerms { get; set; }

    [JsonPropertyName("termsConditions")]
    public string? TermsConditions { get; set; }

    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    [JsonPropertyName("tax")]
    public double? Tax { get; set; }

    [JsonPropertyName("discount")]
    public double? Discount { get; set; }

    [JsonPropertyName("invoiceAmount")]
    public double? InvoiceAmount { get; set; }

    [JsonPropertyName("freightAmount")]
    public double? FreightAmount { get; set; }

    [JsonPropertyName("dutyAmount")]
    public double? DutyAmount { get; set; }

    [JsonPropertyName("purchaseOrder")]
    public string? PurchaseOrder { get; set; }

    [JsonPropertyName("firstName")]
    public string? FirstName { get; set; }

    [JsonPropertyName("lastName")]
    public string? LastName { get; set; }

    [JsonPropertyName("company")]
    public string? Company { get; set; }

    [JsonPropertyName("shippingAddress1")]
    public string? ShippingAddress1 { get; set; }

    [JsonPropertyName("shippingAddress2")]
    public string? ShippingAddress2 { get; set; }

    [JsonPropertyName("shippingCity")]
    public string? ShippingCity { get; set; }

    [JsonPropertyName("shippingState")]
    public string? ShippingState { get; set; }

    [JsonPropertyName("shippingZip")]
    public string? ShippingZip { get; set; }

    [JsonPropertyName("shippingCountry")]
    public string? ShippingCountry { get; set; }

    [JsonPropertyName("shippingEmail")]
    public string? ShippingEmail { get; set; }

    [JsonPropertyName("shippingPhone")]
    public string? ShippingPhone { get; set; }

    [JsonPropertyName("shippingFromZip")]
    public string? ShippingFromZip { get; set; }

    [JsonPropertyName("summaryCommodityCode")]
    public string? SummaryCommodityCode { get; set; }

    [JsonPropertyName("items")]
    public IEnumerable<BillItem>? Items { get; set; }

    [JsonPropertyName("attachments")]
    public IEnumerable<FileContent>? Attachments { get; set; }

    [JsonPropertyName("additionalData")]
    public string? AdditionalData { get; set; }

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
