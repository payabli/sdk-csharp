using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record GetInvoiceRecord : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("invoiceId")]
    public required long InvoiceId { get; set; }

    [JsonPropertyName("customerId")]
    public required long CustomerId { get; set; }

    [JsonPropertyName("paypointId")]
    public required long PaypointId { get; set; }

    [JsonPropertyName("invoiceNumber")]
    public required string InvoiceNumber { get; set; }

    [JsonPropertyName("invoiceDate")]
    public DateOnly? InvoiceDate { get; set; }

    [JsonPropertyName("invoiceDueDate")]
    public DateOnly? InvoiceDueDate { get; set; }

    [JsonPropertyName("invoiceSentDate")]
    public DateTime? InvoiceSentDate { get; set; }

    [JsonPropertyName("invoiceEndDate")]
    public DateOnly? InvoiceEndDate { get; set; }

    [JsonPropertyName("lastPaymentDate")]
    public DateTime? LastPaymentDate { get; set; }

    [JsonPropertyName("createdAt")]
    public required DateTime CreatedAt { get; set; }

    [JsonPropertyName("invoiceStatus")]
    public required int InvoiceStatus { get; set; }

    [JsonPropertyName("invoiceType")]
    public required int InvoiceType { get; set; }

    [JsonPropertyName("frequency")]
    public required Frequency Frequency { get; set; }

    [JsonPropertyName("paymentTerms")]
    public required string PaymentTerms { get; set; }

    [JsonPropertyName("termsConditions")]
    public string? TermsConditions { get; set; }

    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    [JsonPropertyName("tax")]
    public double? Tax { get; set; }

    [JsonPropertyName("discount")]
    public double? Discount { get; set; }

    [JsonPropertyName("invoiceAmount")]
    public required double InvoiceAmount { get; set; }

    [JsonPropertyName("invoicePaidAmount")]
    public required double InvoicePaidAmount { get; set; }

    [JsonPropertyName("freightAmount")]
    public double? FreightAmount { get; set; }

    [JsonPropertyName("dutyAmount")]
    public double? DutyAmount { get; set; }

    [JsonPropertyName("purchaseOrder")]
    public required string PurchaseOrder { get; set; }

    /// <summary>
    /// First name of the recipient of the invoice.
    /// </summary>
    [JsonPropertyName("firstName")]
    public string? FirstName { get; set; }

    /// <summary>
    /// Last name of the recipient of the invoice.
    /// </summary>
    [JsonPropertyName("lastName")]
    public string? LastName { get; set; }

    /// <summary>
    /// Company name of the recipient of the invoice.
    /// </summary>
    [JsonPropertyName("company")]
    public string? Company { get; set; }

    [JsonPropertyName("shippingAddress1")]
    public required string ShippingAddress1 { get; set; }

    [JsonPropertyName("shippingAddress2")]
    public required string ShippingAddress2 { get; set; }

    [JsonPropertyName("shippingCity")]
    public required string ShippingCity { get; set; }

    [JsonPropertyName("shippingState")]
    public required string ShippingState { get; set; }

    [JsonPropertyName("shippingZip")]
    public required string ShippingZip { get; set; }

    [JsonPropertyName("shippingFromZip")]
    public required string ShippingFromZip { get; set; }

    [JsonPropertyName("shippingCountry")]
    public required string ShippingCountry { get; set; }

    [JsonPropertyName("shippingEmail")]
    public required string ShippingEmail { get; set; }

    [JsonPropertyName("shippingPhone")]
    public required string ShippingPhone { get; set; }

    [JsonPropertyName("summaryCommodityCode")]
    public required string SummaryCommodityCode { get; set; }

    [JsonPropertyName("items")]
    public IEnumerable<BillItem> Items { get; set; } = new List<BillItem>();

    [JsonPropertyName("Customer")]
    public required PayorDataResponse Customer { get; set; }

    [JsonPropertyName("paylinkId")]
    public required string PaylinkId { get; set; }

    [JsonPropertyName("billEvents")]
    public IEnumerable<GeneralEvents>? BillEvents { get; set; }

    [JsonPropertyName("scheduledOptions")]
    public required BillOptions ScheduledOptions { get; set; }

    [JsonPropertyName("PaypointLegalname")]
    public required string PaypointLegalname { get; set; }

    [JsonPropertyName("PaypointDbaname")]
    public required string PaypointDbaname { get; set; }

    [JsonPropertyName("PaypointEntryname")]
    public required string PaypointEntryname { get; set; }

    [JsonPropertyName("ParentOrgName")]
    public required string ParentOrgName { get; set; }

    [JsonPropertyName("AdditionalData")]
    public string? AdditionalData { get; set; }

    [JsonPropertyName("DocumentsRef")]
    public required DocumentsRef DocumentsRef { get; set; }

    [JsonPropertyName("externalPaypointID")]
    public string? ExternalPaypointId { get; set; }

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
