using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record BillData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("AdditionalData")]
    public Dictionary<string, string>? AdditionalData { get; set; }

    [JsonPropertyName("attachments")]
    public IEnumerable<FileContent>? Attachments { get; set; }

    /// <summary>
    /// Company name of the recipient of the invoice.
    /// </summary>
    [JsonPropertyName("company")]
    public string? Company { get; set; }

    [JsonPropertyName("discount")]
    public double? Discount { get; set; }

    [JsonPropertyName("dutyAmount")]
    public double? DutyAmount { get; set; }

    /// <summary>
    /// First name of the recipient of the invoice.
    /// </summary>
    [JsonPropertyName("firstName")]
    public string? FirstName { get; set; }

    [JsonPropertyName("freightAmount")]
    public double? FreightAmount { get; set; }

    /// <summary>
    /// Frequency of scheduled invoice.
    /// </summary>
    [JsonPropertyName("frequency")]
    public Frequency? Frequency { get; set; }

    [JsonPropertyName("invoiceAmount")]
    public double? InvoiceAmount { get; set; }

    /// <summary>
    /// Invoice date in any of the accepted formats: YYYY-MM-DD, MM/DD/YYYY.
    /// </summary>
    [JsonPropertyName("invoiceDate")]
    public DateOnly? InvoiceDate { get; set; }

    /// <summary>
    /// Invoice due date in one of the accepted formats: YYYY-MM-DD, MM/DD/YYYY.
    /// </summary>
    [JsonPropertyName("invoiceDueDate")]
    public DateOnly? InvoiceDueDate { get; set; }

    /// <summary>
    /// Indicate the date to finish a scheduled invoice cycle (`invoiceType`` = 1) in any of the accepted formats: YYYY-MM-DD, MM/DD/YYYY.
    /// </summary>
    [JsonPropertyName("invoiceEndDate")]
    public DateOnly? InvoiceEndDate { get; set; }

    /// <summary>
    /// Invoice number. Identifies the invoice under a paypoint.
    /// </summary>
    [JsonPropertyName("invoiceNumber")]
    public string? InvoiceNumber { get; set; }

    [JsonPropertyName("invoiceStatus")]
    public int? InvoiceStatus { get; set; }

    [JsonPropertyName("invoiceType")]
    public int? InvoiceType { get; set; }

    /// <summary>
    /// Array of line items included in the invoice.
    /// </summary>
    [JsonPropertyName("items")]
    public IEnumerable<BillItem>? Items { get; set; }

    /// <summary>
    /// Last name of the recipient of the invoice.
    /// </summary>
    [JsonPropertyName("lastName")]
    public string? LastName { get; set; }

    /// <summary>
    /// Notes included in the invoice.
    /// </summary>
    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    [JsonPropertyName("paymentTerms")]
    public BillDataPaymentTerms? PaymentTerms { get; set; }

    [JsonPropertyName("purchaseOrder")]
    public string? PurchaseOrder { get; set; }

    [JsonPropertyName("shippingAddress1")]
    public string? ShippingAddress1 { get; set; }

    [JsonPropertyName("shippingAddress2")]
    public string? ShippingAddress2 { get; set; }

    [JsonPropertyName("shippingCity")]
    public string? ShippingCity { get; set; }

    [JsonPropertyName("shippingCountry")]
    public string? ShippingCountry { get; set; }

    /// <summary>
    /// Shipping recipient's contact email address.
    /// </summary>
    [JsonPropertyName("shippingEmail")]
    public string? ShippingEmail { get; set; }

    [JsonPropertyName("shippingFromZip")]
    public string? ShippingFromZip { get; set; }

    /// <summary>
    /// Recipient phone number.
    /// </summary>
    [JsonPropertyName("shippingPhone")]
    public string? ShippingPhone { get; set; }

    [JsonPropertyName("shippingState")]
    public string? ShippingState { get; set; }

    [JsonPropertyName("shippingZip")]
    public string? ShippingZip { get; set; }

    [JsonPropertyName("summaryCommodityCode")]
    public string? SummaryCommodityCode { get; set; }

    [JsonPropertyName("tax")]
    public double? Tax { get; set; }

    [JsonPropertyName("termsConditions")]
    public string? TermsConditions { get; set; }

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
