using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record QueryInvoiceResponseRecordsItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("invoiceId")]
    public required long InvoiceId { get; set; }

    [JsonPropertyName("customerId")]
    public long? CustomerId { get; set; }

    [JsonPropertyName("paypointId")]
    public long? PaypointId { get; set; }

    [JsonPropertyName("invoiceNumber")]
    public string? InvoiceNumber { get; set; }

    /// <summary>
    /// Invoice date in any of the accepted formats: YYYY-MM-DD, MM/DD/YYYY.
    /// </summary>
    [JsonPropertyName("invoiceDate")]
    public DateOnly? InvoiceDate { get; set; }

    /// <summary>
    /// Invoice due date in any of the accepted formats: YYYY-MM-DD, MM/DD/YYYY.
    /// </summary>
    [JsonPropertyName("invoiceDueDate")]
    public DateOnly? InvoiceDueDate { get; set; }

    /// <summary>
    /// Invoice sent date in any of the accepted formats: YYYY-MM-DD, MM/DD/YYYY.
    /// </summary>
    [JsonPropertyName("invoiceSentDate")]
    public DateOnly? InvoiceSentDate { get; set; }

    /// <summary>
    /// The end date for a scheduled invoice cycle (`invoiceType` = 1).
    /// </summary>
    [JsonPropertyName("invoiceEndDate")]
    public DateOnly? InvoiceEndDate { get; set; }

    /// <summary>
    /// Timestamp of last payment.
    /// </summary>
    [JsonPropertyName("lastPaymentDate")]
    public DateTime? LastPaymentDate { get; set; }

    [JsonPropertyName("createdAt")]
    public required DateTime CreatedAt { get; set; }

    [JsonPropertyName("invoiceStatus")]
    public required int InvoiceStatus { get; set; }

    [JsonPropertyName("invoiceType")]
    public required int InvoiceType { get; set; }

    /// <summary>
    /// Frequency of scheduled invoice.
    /// </summary>
    [JsonPropertyName("frequency")]
    public required Frequency Frequency { get; set; }

    [JsonPropertyName("paymentTerms")]
    public string? PaymentTerms { get; set; }

    [JsonPropertyName("termsConditions")]
    public string? TermsConditions { get; set; }

    /// <summary>
    /// Invoice notes.
    /// </summary>
    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    [JsonPropertyName("tax")]
    public double? Tax { get; set; }

    [JsonPropertyName("discount")]
    public double? Discount { get; set; }

    [JsonPropertyName("invoiceAmount")]
    public double? InvoiceAmount { get; set; }

    [JsonPropertyName("invoicePaidAmount")]
    public required double InvoicePaidAmount { get; set; }

    [JsonPropertyName("freightAmount")]
    public double? FreightAmount { get; set; }

    [JsonPropertyName("dutyAmount")]
    public double? DutyAmount { get; set; }

    [JsonPropertyName("purchaseOrder")]
    public string? PurchaseOrder { get; set; }

    /// <summary>
    /// First name of the recipient of the invoice.
    /// </summary>
    [JsonPropertyName("firstName")]
    public required string FirstName { get; set; }

    /// <summary>
    /// Last name of the recipient of the invoice.
    /// </summary>
    [JsonPropertyName("lastName")]
    public required string LastName { get; set; }

    /// <summary>
    /// Company name of the recipient of the invoice.
    /// </summary>
    [JsonPropertyName("company")]
    public string? Company { get; set; }

    [JsonPropertyName("shippingAddress1")]
    public string? ShippingAddress1 { get; set; }

    [JsonPropertyName("shippingAddress2")]
    public string? ShippingAddress2 { get; set; }

    [JsonPropertyName("shippingCity")]
    public required string ShippingCity { get; set; }

    [JsonPropertyName("shippingState")]
    public required string ShippingState { get; set; }

    [JsonPropertyName("shippingZip")]
    public string? ShippingZip { get; set; }

    [JsonPropertyName("shippingFromZip")]
    public required string ShippingFromZip { get; set; }

    [JsonPropertyName("shippingCountry")]
    public required string ShippingCountry { get; set; }

    /// <summary>
    /// Shipping recipient's contact email address.
    /// </summary>
    [JsonPropertyName("shippingEmail")]
    public string? ShippingEmail { get; set; }

    /// <summary>
    /// Recipient phone number.
    /// </summary>
    [JsonPropertyName("shippingPhone")]
    public required string ShippingPhone { get; set; }

    [JsonPropertyName("summaryCommodityCode")]
    public string? SummaryCommodityCode { get; set; }

    /// <summary>
    /// Array of line items included in the invoice.
    /// </summary>
    [JsonPropertyName("items")]
    public IEnumerable<BillItem> Items { get; set; } = new List<BillItem>();

    [JsonPropertyName("Customer")]
    public required PayorDataResponse Customer { get; set; }

    [JsonPropertyName("paylinkId")]
    public required string PaylinkId { get; set; }

    [JsonPropertyName("billEvents")]
    public IEnumerable<GeneralEvents>? BillEvents { get; set; }

    /// <summary>
    /// Object with options for scheduled invoices.
    /// </summary>
    [JsonPropertyName("scheduledOptions")]
    public BillOptions? ScheduledOptions { get; set; }

    /// <summary>
    /// Paypoint's legal name.
    /// </summary>
    [JsonPropertyName("PaypointLegalname")]
    public string? PaypointLegalname { get; set; }

    /// <summary>
    /// Paypoint's DBA name.
    /// </summary>
    [JsonPropertyName("PaypointDbaname")]
    public string? PaypointDbaname { get; set; }

    /// <summary>
    /// Paypoint's entryname.
    /// </summary>
    [JsonPropertyName("PaypointEntryname")]
    public required string PaypointEntryname { get; set; }

    [JsonPropertyName("ParentOrgId")]
    public long? ParentOrgId { get; set; }

    [JsonPropertyName("ParentOrgName")]
    public required string ParentOrgName { get; set; }

    /// <summary>
    /// Custom list of key:value pairs. This field is used to store any data related to the invoice or for your system.
    /// </summary>
    [JsonPropertyName("AdditionalData")]
    public Dictionary<string, object?>? AdditionalData { get; set; }

    /// <summary>
    /// Object containing attachments associated to the invoice.
    /// </summary>
    [JsonPropertyName("DocumentsRef")]
    public DocumentsRef? DocumentsRef { get; set; }

    [JsonPropertyName("externalPaypointID")]
    public string? ExternalPaypointId { get; set; }

    [JsonPropertyName("pageIdentifier")]
    public string? PageIdentifier { get; set; }

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
