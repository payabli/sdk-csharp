using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record BillQueryRecord2 : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("AccountingField1")]
    public string? AccountingField1 { get; set; }

    [JsonPropertyName("AccountingField2")]
    public string? AccountingField2 { get; set; }

    /// <summary>
    /// Additional data associated with the bill.
    /// </summary>
    [JsonPropertyName("AdditionalData")]
    public Dictionary<string, string>? AdditionalData { get; set; }

    /// <summary>
    /// Batch number associated with the bill.
    /// </summary>
    [JsonPropertyName("BatchNumber")]
    public string? BatchNumber { get; set; }

    [JsonPropertyName("billApprovals")]
    public IEnumerable<BillQueryRecord2BillApprovalsItem>? BillApprovals { get; set; }

    /// <summary>
    /// Bill creation date in one of the accepted formats: YYYY-MM-DD, MM/DD/YYYY.
    /// </summary>
    [JsonPropertyName("BillDate")]
    public DateOnly? BillDate { get; set; }

    /// <summary>
    /// Events associated with the bill.
    /// </summary>
    [JsonPropertyName("billEvents")]
    public IEnumerable<GeneralEvents>? BillEvents { get; set; }

    /// <summary>
    /// Array of items included in the bill.
    /// </summary>
    [JsonPropertyName("BillItems")]
    public IEnumerable<BillItem>? BillItems { get; set; }

    /// <summary>
    /// Bill number.
    /// </summary>
    [JsonPropertyName("BillNumber")]
    public string? BillNumber { get; set; }

    /// <summary>
    /// Additional comments on the bill.
    /// </summary>
    [JsonPropertyName("Comments")]
    public string? Comments { get; set; }

    /// <summary>
    /// Timestamp of when bill was created, in UTC.
    /// </summary>
    [JsonPropertyName("CreatedAt")]
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// Discount amount applied to the bill.
    /// </summary>
    [JsonPropertyName("Discount")]
    public double? Discount { get; set; }

    /// <summary>
    /// Reference to documents associated with the bill.
    /// </summary>
    [JsonPropertyName("DocumentsRef")]
    public string? DocumentsRef { get; set; }

    /// <summary>
    /// Bill due date in one of the accepted formats: YYYY-MM-DD, MM/DD/YYYY.
    /// </summary>
    [JsonPropertyName("DueDate")]
    public DateOnly? DueDate { get; set; }

    /// <summary>
    /// End date for the bill.
    /// </summary>
    [JsonPropertyName("EndDate")]
    public DateOnly? EndDate { get; set; }

    /// <summary>
    /// Entity identifier associated with the bill.
    /// </summary>
    [JsonPropertyName("EntityID")]
    public string? EntityId { get; set; }

    [JsonPropertyName("externalPaypointID")]
    public string? ExternalPaypointId { get; set; }

    /// <summary>
    /// Frequency for scheduled bills. Applied only in `Mode` = 1.
    /// </summary>
    [JsonPropertyName("Frequency")]
    public Frequency? Frequency { get; set; }

    /// <summary>
    /// Identifier of the bill.
    /// </summary>
    [JsonPropertyName("IdBill")]
    public long? IdBill { get; set; }

    /// <summary>
    /// Timestamp of when bill was last updated, in UTC.
    /// </summary>
    [JsonPropertyName("LastUpdated")]
    public DateTime? LastUpdated { get; set; }

    /// <summary>
    /// Lot number associated with the bill.
    /// </summary>
    [JsonPropertyName("LotNumber")]
    public string? LotNumber { get; set; }

    /// <summary>
    /// Bill mode: value `0` for single/one-time bills, `1` for scheduled bills.
    /// </summary>
    [JsonPropertyName("Mode")]
    public int? Mode { get; set; }

    /// <summary>
    /// Net amount of the bill.
    /// </summary>
    [JsonPropertyName("NetAmount")]
    public double? NetAmount { get; set; }

    /// <summary>
    /// Parent organization identifier.
    /// </summary>
    [JsonPropertyName("ParentOrgId")]
    public long? ParentOrgId { get; set; }

    [JsonPropertyName("ParentOrgName")]
    public string? ParentOrgName { get; set; }

    /// <summary>
    /// Payment identifier.
    /// </summary>
    [JsonPropertyName("PaymentId")]
    public string? PaymentId { get; set; }

    /// <summary>
    /// Preferred payment method used.
    /// </summary>
    [JsonPropertyName("PaymentMethod")]
    public BillQueryRecord2PaymentMethod? PaymentMethod { get; set; }

    /// <summary>
    /// Paylink identifier associated with the bill.
    /// </summary>
    [JsonPropertyName("paylinkId")]
    public string? PaylinkId { get; set; }

    /// <summary>
    /// The paypoint's DBA name.
    /// </summary>
    [JsonPropertyName("PaypointDbaname")]
    public string? PaypointDbaname { get; set; }

    /// <summary>
    /// Entry name of the paypoint.
    /// </summary>
    [JsonPropertyName("PaypointEntryname")]
    public string? PaypointEntryname { get; set; }

    /// <summary>
    /// The paypoint's legal name.
    /// </summary>
    [JsonPropertyName("PaypointLegalname")]
    public string? PaypointLegalname { get; set; }

    /// <summary>
    /// Source of the bill.
    /// </summary>
    [JsonPropertyName("Source")]
    public string? Source { get; set; }

    [JsonPropertyName("Status")]
    public int? Status { get; set; }

    /// <summary>
    /// The payment terms for invoice. If no terms were defined initially, then response data for this field will default to `N30`.
    /// </summary>
    [JsonPropertyName("Terms")]
    public string? Terms { get; set; }

    /// <summary>
    /// Total amount of the bill including taxes and fees.
    /// </summary>
    [JsonPropertyName("TotalAmount")]
    public double? TotalAmount { get; set; }

    /// <summary>
    /// MoneyOut transaction associated to the bill.
    /// </summary>
    [JsonPropertyName("Transaction")]
    public TransactionOutQueryRecord? Transaction { get; set; }

    [JsonPropertyName("Vendor")]
    public VendorOutData? Vendor { get; set; }

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
