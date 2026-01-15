using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record BillResponseData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("IdBill")]
    public long? IdBill { get; set; }

    /// <summary>
    /// Unique identifier for the bill.
    /// </summary>
    [JsonPropertyName("BillNumber")]
    public string? BillNumber { get; set; }

    /// <summary>
    /// Net amount owed in bill.
    /// </summary>
    [JsonPropertyName("NetAmount")]
    public double? NetAmount { get; set; }

    /// <summary>
    /// Bill discount amount.
    /// </summary>
    [JsonPropertyName("Discount")]
    public double? Discount { get; set; }

    /// <summary>
    /// Total amount for the bill.
    /// </summary>
    [JsonPropertyName("TotalAmount")]
    public double? TotalAmount { get; set; }

    /// <summary>
    /// Date of bill. Accepted formats: YYYY-MM-DD, MM/DD/YYYY
    /// </summary>
    [JsonPropertyName("BillDate")]
    public DateOnly? BillDate { get; set; }

    /// <summary>
    /// Due Date of bill. Accepted formats: YYYY-MM-DD, MM/DD/YYYY
    /// </summary>
    [JsonPropertyName("DueDate")]
    public DateOnly? DueDate { get; set; }

    /// <summary>
    /// Comments associated with the bill. For managed payables, the character limit is 200. For on demand payouts, the characters limit is 250.
    /// </summary>
    [JsonPropertyName("Comments")]
    public string? Comments { get; set; }

    /// <summary>
    /// The batch number that the bill belongs to.
    /// </summary>
    [JsonPropertyName("BatchNumber")]
    public string? BatchNumber { get; set; }

    /// <summary>
    /// Array of `LineItems` contained in bill.
    /// </summary>
    [JsonPropertyName("BillItems")]
    public IEnumerable<BillItem>? BillItems { get; set; }

    /// <summary>
    /// Bill mode: value `0` for single/one-time bills, `1` for scheduled bills.
    /// </summary>
    [JsonPropertyName("Mode")]
    public int? Mode { get; set; }

    /// <summary>
    /// Payment method used for the bill.
    /// </summary>
    [JsonPropertyName("PaymentMethod")]
    public string? PaymentMethod { get; set; }

    /// <summary>
    /// Payment ID associated with the bill.
    /// </summary>
    [JsonPropertyName("PaymentId")]
    public string? PaymentId { get; set; }

    [JsonPropertyName("AccountingField1")]
    public string? AccountingField1 { get; set; }

    [JsonPropertyName("AccountingField2")]
    public string? AccountingField2 { get; set; }

    [JsonPropertyName("Terms")]
    public string? Terms { get; set; }

    /// <summary>
    /// The source of the bill, such as "API" or "UI".
    /// </summary>
    [JsonPropertyName("Source")]
    public string? Source { get; set; }

    [JsonPropertyName("AdditionalData")]
    public string? AdditionalData { get; set; }

    [JsonPropertyName("Vendor")]
    public VendorDataResponse? Vendor { get; set; }

    [JsonPropertyName("Status")]
    public int? Status { get; set; }

    [JsonPropertyName("CreatedAt")]
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// End date for scheduled bills. Applied only in `Mode` = 1.
    /// </summary>
    [JsonPropertyName("EndDate")]
    public DateOnly? EndDate { get; set; }

    [JsonPropertyName("LastUpdated")]
    public DateTime? LastUpdated { get; set; }

    /// <summary>
    /// Frequency for scheduled bills. Applied only in `Mode` = 1.
    /// </summary>
    [JsonPropertyName("Frequency")]
    public Frequency? Frequency { get; set; }

    /// <summary>
    /// MoneyOut transaction associated to the bill
    /// </summary>
    [JsonPropertyName("Transaction")]
    public TransactionOutQueryRecord? Transaction { get; set; }

    [JsonPropertyName("billEvents")]
    public IEnumerable<GeneralEvents>? BillEvents { get; set; }

    [JsonPropertyName("billApprovals")]
    public IEnumerable<BillQueryRecord2BillApprovalsItem>? BillApprovals { get; set; }

    [JsonPropertyName("PaypointLegalname")]
    public string? PaypointLegalname { get; set; }

    [JsonPropertyName("PaypointDbaname")]
    public string? PaypointDbaname { get; set; }

    [JsonPropertyName("ParentOrgId")]
    public long? ParentOrgId { get; set; }

    [JsonPropertyName("ParentOrgName")]
    public string? ParentOrgName { get; set; }

    [JsonPropertyName("PaypointEntryname")]
    public string? PaypointEntryname { get; set; }

    [JsonPropertyName("paylinkId")]
    public string? PaylinkId { get; set; }

    /// <summary>
    /// Object with the attached documents.
    /// </summary>
    [JsonPropertyName("DocumentsRef")]
    public DocumentsRef? DocumentsRef { get; set; }

    [JsonPropertyName("externalPaypointID")]
    public string? ExternalPaypointId { get; set; }

    /// <summary>
    /// Lot number of the bill.
    /// </summary>
    [JsonPropertyName("LotNumber")]
    public string? LotNumber { get; set; }

    [JsonPropertyName("EntityID")]
    public long? EntityId { get; set; }

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
