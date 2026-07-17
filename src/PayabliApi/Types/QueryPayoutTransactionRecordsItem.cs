using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record QueryPayoutTransactionRecordsItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Identifier of payout transaction.
    /// </summary>
    [JsonPropertyName("IdOut")]
    public long? IdOut { get; set; }

    /// <summary>
    /// Timestamp when the payment was created, in UTC.
    /// </summary>
    [JsonPropertyName("CreatedAt")]
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// Any comment or description for payout transaction.
    /// </summary>
    [JsonPropertyName("Comments")]
    public string? Comments { get; set; }

    /// <summary>
    /// Vendor related to the payout transaction.
    /// </summary>
    [JsonPropertyName("Vendor")]
    public VendorQueryRecord? Vendor { get; set; }

    [JsonPropertyName("PaypointDbaname")]
    public string? PaypointDbaname { get; set; }

    /// <summary>
    /// Paypoint legal name.
    /// </summary>
    [JsonPropertyName("PaypointLegalname")]
    public string? PaypointLegalname { get; set; }

    [JsonPropertyName("PaypointId")]
    public long? PaypointId { get; set; }

    /// <summary>
    /// Internal status of transaction.
    /// </summary>
    [JsonPropertyName("Status")]
    public int? Status { get; set; }

    [JsonPropertyName("PaymentId")]
    public string? PaymentId { get; set; }

    /// <summary>
    /// ID of the transaction linked to this payout, when applicable.
    /// </summary>
    [JsonPropertyName("TransId")]
    public string? TransId { get; set; }

    /// <summary>
    /// Status of the linked transaction.
    /// </summary>
    [JsonPropertyName("TransStatus")]
    public int? TransStatus { get; set; }

    /// <summary>
    /// Detailed status of the linked transaction.
    /// </summary>
    [JsonPropertyName("TransStatusDetail")]
    public string? TransStatusDetail { get; set; }

    /// <summary>
    /// Name of the linked transaction's status.
    /// </summary>
    [JsonPropertyName("TransStatusName")]
    public string? TransStatusName { get; set; }

    /// <summary>
    /// Category of the linked transaction's status.
    /// </summary>
    [JsonPropertyName("TransStatusCategory")]
    public string? TransStatusCategory { get; set; }

    /// <summary>
    /// Timestamp when payment record was updated.
    /// </summary>
    [JsonPropertyName("LastUpdated")]
    public DateTime? LastUpdated { get; set; }

    /// <summary>
    /// Transaction total amount (including service fee or sub-charge).
    /// </summary>
    [JsonPropertyName("TotalAmount")]
    public double? TotalAmount { get; set; }

    /// <summary>
    /// Net amount paid.
    /// </summary>
    [JsonPropertyName("NetAmount")]
    public double? NetAmount { get; set; }

    [JsonPropertyName("FeeAmount")]
    public double? FeeAmount { get; set; }

    [JsonPropertyName("Source")]
    public string? Source { get; set; }

    [JsonPropertyName("ParentOrgName")]
    public string? ParentOrgName { get; set; }

    [JsonPropertyName("ParentOrgId")]
    public long? ParentOrgId { get; set; }

    [JsonPropertyName("BatchNumber")]
    public string? BatchNumber { get; set; }

    /// <summary>
    /// Status of payout transaction. See [Payout Transaction Statuses](/guides/pay-out-status-reference#payout-transaction-statuses) for a full reference.
    /// </summary>
    [JsonPropertyName("PaymentStatus")]
    public string? PaymentStatus { get; set; }

    /// <summary>
    /// The payment method for the transaction.
    /// </summary>
    [JsonPropertyName("PaymentMethod")]
    public string? PaymentMethod { get; set; }

    [JsonPropertyName("CardToken")]
    public string? CardToken { get; set; }

    /// <summary>
    /// Paper check number related to payout transaction.
    /// </summary>
    [JsonPropertyName("CheckNumber")]
    public string? CheckNumber { get; set; }

    /// <summary>
    /// Object referencing paper check image.
    /// </summary>
    [JsonPropertyName("CheckData")]
    public FileContent? CheckData { get; set; }

    [JsonPropertyName("PaymentData")]
    public QueryPayoutTransactionRecordsItemPaymentData? PaymentData { get; set; }

    /// <summary>
    /// Bills associated with this transaction.
    /// </summary>
    [JsonPropertyName("Bills")]
    public IEnumerable<BillPayOutData>? Bills { get; set; }

    /// <summary>
    /// Events associated with this transaction.
    /// </summary>
    [JsonPropertyName("Events")]
    public IEnumerable<QueryTransactionEvents>? Events { get; set; }

    [JsonPropertyName("externalPaypointID")]
    public string? ExternalPaypointId { get; set; }

    [JsonPropertyName("EntryName")]
    public string? EntryName { get; set; }

    [JsonPropertyName("Gateway")]
    public string? Gateway { get; set; }

    /// <summary>
    /// Identifier of the batch associated with payout transaction.
    /// </summary>
    [JsonPropertyName("BatchId")]
    public int? BatchId { get; set; }

    [JsonPropertyName("HasVcardTransactions")]
    public bool? HasVcardTransactions { get; set; }

    [JsonPropertyName("IsSameDayACH")]
    public bool? IsSameDayAch { get; set; }

    [JsonPropertyName("ScheduleId")]
    public long? ScheduleId { get; set; }

    [JsonPropertyName("SettlementStatus")]
    public string? SettlementStatus { get; set; }

    [JsonPropertyName("SettlementStatusName")]
    public string? SettlementStatusName { get; set; }

    /// <summary>
    /// Date the payout settled, in UTC. Null until the payout settles.
    /// </summary>
    [JsonPropertyName("SettlementDate")]
    public DateTime? SettlementDate { get; set; }

    [JsonPropertyName("RiskFlagged")]
    public bool? RiskFlagged { get; set; }

    [JsonPropertyName("RiskFlaggedOn")]
    public DateTime? RiskFlaggedOn { get; set; }

    [JsonPropertyName("RiskStatus")]
    public string? RiskStatus { get; set; }

    [JsonPropertyName("RiskReason")]
    public string? RiskReason { get; set; }

    [JsonPropertyName("RiskAction")]
    public string? RiskAction { get; set; }

    [JsonPropertyName("RiskActionCode")]
    public int? RiskActionCode { get; set; }

    [JsonPropertyName("PayoutProgram")]
    public string? PayoutProgram { get; set; }

    /// <summary>
    /// ACH trace number for the payout, when available.
    /// </summary>
    [JsonPropertyName("AchTraceNumber")]
    public string? AchTraceNumber { get; set; }

    /// <summary>
    /// Unique identifier (ULID) of the payout transaction.
    /// </summary>
    [JsonPropertyName("EntityId")]
    public string? EntityId { get; set; }

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
