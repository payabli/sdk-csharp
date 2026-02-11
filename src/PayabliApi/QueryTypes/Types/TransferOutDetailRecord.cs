using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// A record representing an outbound transfer detail.
/// </summary>
[Serializable]
public record TransferOutDetailRecord : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Unique identifier for the transfer detail.
    /// </summary>
    [JsonPropertyName("transferDetailId")]
    public int? TransferDetailId { get; set; }

    /// <summary>
    /// The ID of the transfer this detail belongs to.
    /// </summary>
    [JsonPropertyName("transferId")]
    public int? TransferId { get; set; }

    /// <summary>
    /// The transaction ID in Payabli's system.
    /// </summary>
    [JsonPropertyName("transactionId")]
    public string? TransactionId { get; set; }

    /// <summary>
    /// The outbound transaction ID.
    /// </summary>
    [JsonPropertyName("IdOut")]
    public int? IdOut { get; set; }

    /// <summary>
    /// Payment method used.
    /// </summary>
    [JsonPropertyName("method")]
    public string? Method { get; set; }

    /// <summary>
    /// The transaction type (credit or debit).
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// Category of the transaction detail.
    /// </summary>
    [JsonPropertyName("category")]
    public string? Category { get; set; }

    /// <summary>
    /// The gross amount of the transaction.
    /// </summary>
    [JsonPropertyName("grossAmount")]
    public double? GrossAmount { get; set; }

    /// <summary>
    /// Amount returned.
    /// </summary>
    [JsonPropertyName("returnedAmount")]
    public double? ReturnedAmount { get; set; }

    /// <summary>
    /// Amount refunded.
    /// </summary>
    [JsonPropertyName("refundAmount")]
    public double? RefundAmount { get; set; }

    /// <summary>
    /// Amount being held.
    /// </summary>
    [JsonPropertyName("holdAmount")]
    public double? HoldAmount { get; set; }

    /// <summary>
    /// Amount released.
    /// </summary>
    [JsonPropertyName("releasedAmount")]
    public double? ReleasedAmount { get; set; }

    /// <summary>
    /// Billing fees amount.
    /// </summary>
    [JsonPropertyName("billingFeesAmount")]
    public double? BillingFeesAmount { get; set; }

    /// <summary>
    /// Adjustments amount.
    /// </summary>
    [JsonPropertyName("adjustmentsAmount")]
    public double? AdjustmentsAmount { get; set; }

    /// <summary>
    /// Net transfer amount after deductions.
    /// </summary>
    [JsonPropertyName("netTransferAmount")]
    public double? NetTransferAmount { get; set; }

    /// <summary>
    /// Detailed breakdown of billing fees.
    /// </summary>
    [JsonPropertyName("billingFeesDetails")]
    public IEnumerable<BillingFeeDetail>? BillingFeesDetails { get; set; }

    /// <summary>
    /// Date and time the record was created.
    /// </summary>
    [JsonPropertyName("CreatedAt")]
    public string? CreatedAt { get; set; }

    /// <summary>
    /// Comments on the transfer detail.
    /// </summary>
    [JsonPropertyName("Comments")]
    public string? Comments { get; set; }

    /// <summary>
    /// Vendor information.
    /// </summary>
    [JsonPropertyName("Vendor")]
    public TransferOutDetailVendor? Vendor { get; set; }

    /// <summary>
    /// DBA name of the paypoint.
    /// </summary>
    [JsonPropertyName("PaypointDbaname")]
    public string? PaypointDbaname { get; set; }

    /// <summary>
    /// Legal name of the paypoint.
    /// </summary>
    [JsonPropertyName("PaypointLegalname")]
    public string? PaypointLegalname { get; set; }

    /// <summary>
    /// ID of the paypoint.
    /// </summary>
    [JsonPropertyName("PaypointId")]
    public int? PaypointId { get; set; }

    /// <summary>
    /// Status of the transfer detail.
    /// </summary>
    [JsonPropertyName("Status")]
    public int? Status { get; set; }

    /// <summary>
    /// Payment ID.
    /// </summary>
    [JsonPropertyName("PaymentId")]
    public string? PaymentId { get; set; }

    /// <summary>
    /// Transaction ID.
    /// </summary>
    [JsonPropertyName("TransId")]
    public string? TransId { get; set; }

    /// <summary>
    /// Transaction status.
    /// </summary>
    [JsonPropertyName("TransStatus")]
    public int? TransStatus { get; set; }

    /// <summary>
    /// Detailed transaction status.
    /// </summary>
    [JsonPropertyName("TransStatusDetail")]
    public string? TransStatusDetail { get; set; }

    /// <summary>
    /// Name of the transaction status.
    /// </summary>
    [JsonPropertyName("TransStatusName")]
    public string? TransStatusName { get; set; }

    /// <summary>
    /// Category of the transaction status.
    /// </summary>
    [JsonPropertyName("TransStatusCategory")]
    public string? TransStatusCategory { get; set; }

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    [JsonPropertyName("LastUpdated")]
    public string? LastUpdated { get; set; }

    /// <summary>
    /// Total amount of the transaction.
    /// </summary>
    [JsonPropertyName("TotalAmount")]
    public double? TotalAmount { get; set; }

    /// <summary>
    /// Net amount of the transaction.
    /// </summary>
    [JsonPropertyName("NetAmount")]
    public double? NetAmount { get; set; }

    /// <summary>
    /// Fee amount for the transaction.
    /// </summary>
    [JsonPropertyName("FeeAmount")]
    public double? FeeAmount { get; set; }

    /// <summary>
    /// Source of the transaction.
    /// </summary>
    [JsonPropertyName("Source")]
    public string? Source { get; set; }

    /// <summary>
    /// Name of the parent organization.
    /// </summary>
    [JsonPropertyName("ParentOrgName")]
    public string? ParentOrgName { get; set; }

    /// <summary>
    /// ID of the parent organization.
    /// </summary>
    [JsonPropertyName("ParentOrgId")]
    public int? ParentOrgId { get; set; }

    /// <summary>
    /// Batch number for the transfer.
    /// </summary>
    [JsonPropertyName("BatchNumber")]
    public string? BatchNumber { get; set; }

    /// <summary>
    /// Status of the payment.
    /// </summary>
    [JsonPropertyName("PaymentStatus")]
    public string? PaymentStatus { get; set; }

    /// <summary>
    /// Payment method used.
    /// </summary>
    [JsonPropertyName("PaymentMethod")]
    public string? PaymentMethod { get; set; }

    /// <summary>
    /// Token for the card used.
    /// </summary>
    [JsonPropertyName("CardToken")]
    public string? CardToken { get; set; }

    /// <summary>
    /// Check number if paid by check.
    /// </summary>
    [JsonPropertyName("CheckNumber")]
    public string? CheckNumber { get; set; }

    /// <summary>
    /// Check data if paid by check.
    /// </summary>
    [JsonPropertyName("CheckData")]
    public TransferOutDetailCheckData? CheckData { get; set; }

    /// <summary>
    /// Payment data for the transaction.
    /// </summary>
    [JsonPropertyName("PaymentData")]
    public TransferOutDetailPaymentData? PaymentData { get; set; }

    /// <summary>
    /// Bills associated with the transfer.
    /// </summary>
    [JsonPropertyName("Bills")]
    public IEnumerable<TransferOutDetailBill>? Bills { get; set; }

    /// <summary>
    /// Events associated with the transfer.
    /// </summary>
    [JsonPropertyName("Events")]
    public IEnumerable<TransferOutDetailEvent>? Events { get; set; }

    /// <summary>
    /// External paypoint ID.
    /// </summary>
    [JsonPropertyName("externalPaypointID")]
    public string? ExternalPaypointId { get; set; }

    /// <summary>
    /// Entry name for the paypoint.
    /// </summary>
    [JsonPropertyName("EntryName")]
    public string? EntryName { get; set; }

    /// <summary>
    /// Gateway used for the transaction.
    /// </summary>
    [JsonPropertyName("Gateway")]
    public string? Gateway { get; set; }

    /// <summary>
    /// ID of the batch.
    /// </summary>
    [JsonPropertyName("BatchId")]
    public int? BatchId { get; set; }

    /// <summary>
    /// Whether the transfer has virtual card transactions.
    /// </summary>
    [JsonPropertyName("HasVcardTransactions")]
    public bool? HasVcardTransactions { get; set; }

    /// <summary>
    /// Whether this is a same-day ACH transaction.
    /// </summary>
    [JsonPropertyName("IsSameDayACH")]
    public bool? IsSameDayAch { get; set; }

    /// <summary>
    /// ID of the schedule if applicable.
    /// </summary>
    [JsonPropertyName("ScheduleId")]
    public int? ScheduleId { get; set; }

    /// <summary>
    /// Settlement status.
    /// </summary>
    [JsonPropertyName("SettlementStatus")]
    public string? SettlementStatus { get; set; }

    /// <summary>
    /// Name of the settlement status.
    /// </summary>
    [JsonPropertyName("SettlementStatusName")]
    public string? SettlementStatusName { get; set; }

    /// <summary>
    /// Date of settlement.
    /// </summary>
    [JsonPropertyName("SettlementDate")]
    public string? SettlementDate { get; set; }

    /// <summary>
    /// Whether the transaction was flagged for risk.
    /// </summary>
    [JsonPropertyName("RiskFlagged")]
    public bool? RiskFlagged { get; set; }

    /// <summary>
    /// Date and time the transaction was flagged.
    /// </summary>
    [JsonPropertyName("RiskFlaggedOn")]
    public string? RiskFlaggedOn { get; set; }

    /// <summary>
    /// Risk status of the transaction.
    /// </summary>
    [JsonPropertyName("RiskStatus")]
    public string? RiskStatus { get; set; }

    /// <summary>
    /// Reason for the risk flag.
    /// </summary>
    [JsonPropertyName("RiskReason")]
    public string? RiskReason { get; set; }

    /// <summary>
    /// Action taken for risk.
    /// </summary>
    [JsonPropertyName("RiskAction")]
    public string? RiskAction { get; set; }

    /// <summary>
    /// Code for the risk action.
    /// </summary>
    [JsonPropertyName("RiskActionCode")]
    public int? RiskActionCode { get; set; }

    /// <summary>
    /// Payout program used.
    /// </summary>
    [JsonPropertyName("PayoutProgram")]
    public string? PayoutProgram { get; set; }

    /// <summary>
    /// ACH trace number.
    /// </summary>
    [JsonPropertyName("AchTraceNumber")]
    public string? AchTraceNumber { get; set; }

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
