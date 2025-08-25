using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record TransferDetailRecord : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Unique identifier for the transfer detail record
    /// </summary>
    [JsonPropertyName("transferDetailId")]
    public int? TransferDetailId { get; set; }

    /// <summary>
    /// The ID of the transfer this detail belongs to
    /// </summary>
    [JsonPropertyName("transferId")]
    public int? TransferId { get; set; }

    /// <summary>
    /// The transaction ID in Payabli's system
    /// </summary>
    [JsonPropertyName("transactionId")]
    public string? TransactionId { get; set; }

    /// <summary>
    /// External transaction reference number
    /// </summary>
    [JsonPropertyName("transactionNumber")]
    public string? TransactionNumber { get; set; }

    /// <summary>
    /// The transaction type (credit or debit)
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// A field used to categorize the transaction details. Values include: auth, decline, refund, adj, cb, split
    /// </summary>
    [JsonPropertyName("category")]
    public string? Category { get; set; }

    /// <summary>
    /// The gross amount of the transaction
    /// </summary>
    [JsonPropertyName("grossAmount")]
    public double? GrossAmount { get; set; }

    /// <summary>
    /// Chargeback amount deducted from transaction
    /// </summary>
    [JsonPropertyName("chargeBackAmount")]
    public double? ChargeBackAmount { get; set; }

    /// <summary>
    /// ACH return amount deducted from transaction
    /// </summary>
    [JsonPropertyName("returnedAmount")]
    public double? ReturnedAmount { get; set; }

    /// <summary>
    /// Refund amount deducted from transaction
    /// </summary>
    [JsonPropertyName("refundAmount")]
    public double? RefundAmount { get; set; }

    /// <summary>
    /// Amount being held for fraud or risk concerns
    /// </summary>
    [JsonPropertyName("holdAmount")]
    public double? HoldAmount { get; set; }

    /// <summary>
    /// Previously held funds that have been released after a risk review
    /// </summary>
    [JsonPropertyName("releasedAmount")]
    public double? ReleasedAmount { get; set; }

    /// <summary>
    /// Charges applied for transactions and services
    /// </summary>
    [JsonPropertyName("billingFeesAmount")]
    public double? BillingFeesAmount { get; set; }

    /// <summary>
    /// Payments captured in the batch cycle that are deposited separately. For example,  checks or cash payments recorded in the batch but not deposited via Payabli,  or card brands making a direct transfer in certain situations.
    /// </summary>
    [JsonPropertyName("thirdPartyPaidAmount")]
    public double? ThirdPartyPaidAmount { get; set; }

    /// <summary>
    /// Corrections applied to Billing & Fees charges
    /// </summary>
    [JsonPropertyName("adjustmentsAmount")]
    public double? AdjustmentsAmount { get; set; }

    /// <summary>
    /// The net amount after all deductions
    /// </summary>
    [JsonPropertyName("netTransferAmount")]
    public double? NetTransferAmount { get; set; }

    /// <summary>
    /// Total amount directed to split funding destinations
    /// </summary>
    [JsonPropertyName("splitFundingAmount")]
    public double? SplitFundingAmount { get; set; }

    [JsonPropertyName("billingFeesDetails")]
    public IEnumerable<BillingFeeDetail>? BillingFeesDetails { get; set; }

    [JsonPropertyName("ParentOrgName")]
    public string? ParentOrgName { get; set; }

    [JsonPropertyName("PaypointDbaname")]
    public string? PaypointDbaname { get; set; }

    [JsonPropertyName("PaypointLegalname")]
    public string? PaypointLegalname { get; set; }

    /// <summary>
    /// The paypoint's entryname
    /// </summary>
    [JsonPropertyName("PaypointEntryname")]
    public string? PaypointEntryname { get; set; }

    /// <summary>
    /// The transaction ID for the payment
    /// </summary>
    [JsonPropertyName("PaymentTransId")]
    public string? PaymentTransId { get; set; }

    /// <summary>
    /// The payment connector used to process the transaction
    /// </summary>
    [JsonPropertyName("ConnectorName")]
    public string? ConnectorName { get; set; }

    [JsonPropertyName("ExternalProcessorInformation")]
    public string? ExternalProcessorInformation { get; set; }

    /// <summary>
    /// Internal identifier used for processing
    /// </summary>
    [JsonPropertyName("GatewayTransId")]
    public string? GatewayTransId { get; set; }

    [JsonPropertyName("OrderId")]
    public string? OrderId { get; set; }

    /// <summary>
    /// Payment method used: card, ach, or wallet
    /// </summary>
    [JsonPropertyName("Method")]
    public string? Method { get; set; }

    [JsonPropertyName("BatchNumber")]
    public string? BatchNumber { get; set; }

    /// <summary>
    /// The amount of the batch
    /// </summary>
    [JsonPropertyName("BatchAmount")]
    public double? BatchAmount { get; set; }

    /// <summary>
    /// Unique ID for customer linked to the transaction
    /// </summary>
    [JsonPropertyName("PayorId")]
    public long? PayorId { get; set; }

    [JsonPropertyName("PaymentData")]
    public QueryPaymentData? PaymentData { get; set; }

    /// <summary>
    /// Status of transaction. See [the
    /// docs](/developers/references/money-in-statuses#money-in-transaction-status) for a
    /// full reference.
    /// </summary>
    [JsonPropertyName("TransStatus")]
    public int? TransStatus { get; set; }

    [JsonPropertyName("PaypointId")]
    public long? PaypointId { get; set; }

    /// <summary>
    /// Transaction total amount (including service fee or sub-charge)
    /// </summary>
    [JsonPropertyName("TotalAmount")]
    public double? TotalAmount { get; set; }

    /// <summary>
    /// Net amount paid
    /// </summary>
    [JsonPropertyName("NetAmount")]
    public double? NetAmount { get; set; }

    [JsonPropertyName("FeeAmount")]
    public double? FeeAmount { get; set; }

    /// <summary>
    /// Settlement status for transaction. See [the docs](/developers/references/money-in-statuses#payment-funding-status) for a full reference.
    /// </summary>
    [JsonPropertyName("SettlementStatus")]
    public int? SettlementStatus { get; set; }

    [JsonPropertyName("Operation")]
    public string? Operation { get; set; }

    [JsonPropertyName("ResponseData")]
    public QueryResponseData? ResponseData { get; set; }

    [JsonPropertyName("Source")]
    public string? Source { get; set; }

    /// <summary>
    /// Reference to the subscription or schedule that originated the transaction
    /// </summary>
    [JsonPropertyName("ScheduleReference")]
    public int? ScheduleReference { get; set; }

    [JsonPropertyName("OrgId")]
    public long? OrgId { get; set; }

    [JsonPropertyName("RefundId")]
    public long? RefundId { get; set; }

    [JsonPropertyName("ReturnedId")]
    public long? ReturnedId { get; set; }

    [JsonPropertyName("ChargebackId")]
    public long? ChargebackId { get; set; }

    [JsonPropertyName("RetrievalId")]
    public long? RetrievalId { get; set; }

    /// <summary>
    /// Additional transaction data
    /// </summary>
    [JsonPropertyName("TransAdditionalData")]
    public object? TransAdditionalData { get; set; }

    /// <summary>
    /// Associated invoice data
    /// </summary>
    [JsonPropertyName("invoiceData")]
    public BillData? InvoiceData { get; set; }

    [JsonPropertyName("EntrypageId")]
    public long? EntrypageId { get; set; }

    [JsonPropertyName("externalPaypointID")]
    public string? ExternalPaypointId { get; set; }

    /// <summary>
    /// Indicates whether the ACH account has been validated
    /// </summary>
    [JsonPropertyName("IsValidatedACH")]
    public bool? IsValidatedAch { get; set; }

    /// <summary>
    /// Transaction date and time, in UTC
    /// </summary>
    [JsonPropertyName("TransactionTime")]
    public DateTime? TransactionTime { get; set; }

    [JsonPropertyName("Customer")]
    public QueryTransactionPayorData? Customer { get; set; }

    [JsonPropertyName("splitFundingInstructions")]
    public IEnumerable<SplitFundingContent>? SplitFundingInstructions { get; set; }

    [JsonPropertyName("CfeeTransactions")]
    public IEnumerable<QueryCFeeTransaction>? CfeeTransactions { get; set; }

    [JsonPropertyName("TransactionEvents")]
    public IEnumerable<QueryTransactionEvents>? TransactionEvents { get; set; }

    [JsonPropertyName("PendingFeeAmount")]
    public double? PendingFeeAmount { get; set; }

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

    [JsonPropertyName("DeviceId")]
    public string? DeviceId { get; set; }

    [JsonPropertyName("AchSecCode")]
    public string? AchSecCode { get; set; }

    [JsonPropertyName("AchHolderType")]
    public AchHolderType? AchHolderType { get; set; }

    [JsonPropertyName("IpAddress")]
    public string? IpAddress { get; set; }

    /// <summary>
    /// Indicates if this was a same-day ACH transaction.
    /// </summary>
    [JsonPropertyName("IsSameDayACH")]
    public bool? IsSameDayAch { get; set; }

    /// <summary>
    /// Type of wallet used for the transaction (if applicable)
    /// </summary>
    [JsonPropertyName("WalletType")]
    public string? WalletType { get; set; }

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
