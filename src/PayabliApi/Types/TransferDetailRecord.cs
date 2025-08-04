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
    public required int TransferDetailId { get; set; }

    /// <summary>
    /// The ID of the transfer this detail belongs to
    /// </summary>
    [JsonPropertyName("transferId")]
    public required int TransferId { get; set; }

    /// <summary>
    /// The transaction ID in Payabli's system
    /// </summary>
    [JsonPropertyName("transactionId")]
    public required string TransactionId { get; set; }

    /// <summary>
    /// External transaction reference number
    /// </summary>
    [JsonPropertyName("transactionNumber")]
    public string? TransactionNumber { get; set; }

    /// <summary>
    /// The ID of the paypoint this transaction belongs to
    /// </summary>
    [JsonPropertyName("paypointId")]
    public required long PaypointId { get; set; }

    /// <summary>
    /// The transaction type (credit or debit)
    /// </summary>
    [JsonPropertyName("type")]
    public required string Type { get; set; }

    /// <summary>
    /// A field used to categorize the transaction details. Values include: auth, decline, refund, adj, cb, split
    /// </summary>
    [JsonPropertyName("category")]
    public string? Category { get; set; }

    /// <summary>
    /// The gross amount of the transaction
    /// </summary>
    [JsonPropertyName("grossAmount")]
    public required double GrossAmount { get; set; }

    /// <summary>
    /// Chargeback amount deducted from transaction
    /// </summary>
    [JsonPropertyName("chargeBackAmount")]
    public required double ChargeBackAmount { get; set; }

    /// <summary>
    /// ACH return amount deducted from transaction
    /// </summary>
    [JsonPropertyName("returnedAmount")]
    public required double ReturnedAmount { get; set; }

    /// <summary>
    /// Refund amount deducted from transaction
    /// </summary>
    [JsonPropertyName("refundAmount")]
    public required double RefundAmount { get; set; }

    /// <summary>
    /// Amount being held for fraud or risk concerns
    /// </summary>
    [JsonPropertyName("holdAmount")]
    public required double HoldAmount { get; set; }

    /// <summary>
    /// Previously held funds that have been released after a risk review
    /// </summary>
    [JsonPropertyName("releasedAmount")]
    public required double ReleasedAmount { get; set; }

    /// <summary>
    /// Charges applied for transactions and services
    /// </summary>
    [JsonPropertyName("billingFeesAmount")]
    public required double BillingFeesAmount { get; set; }

    /// <summary>
    /// Payments captured in the batch cycle that are deposited separately. For example,  checks or cash payments recorded in the batch but not deposited via Payabli,  or card brands making a direct transfer in certain situations.
    /// </summary>
    [JsonPropertyName("thirdPartyPaidAmount")]
    public required double ThirdPartyPaidAmount { get; set; }

    /// <summary>
    /// Corrections applied to Billing & Fees charges
    /// </summary>
    [JsonPropertyName("adjustmentsAmount")]
    public required double AdjustmentsAmount { get; set; }

    /// <summary>
    /// The net amount after all deductions
    /// </summary>
    [JsonPropertyName("netTransferAmount")]
    public required double NetTransferAmount { get; set; }

    /// <summary>
    /// Total amount directed to split funding destinations
    /// </summary>
    [JsonPropertyName("splitFundingAmount")]
    public required double SplitFundingAmount { get; set; }

    /// <summary>
    /// Detailed breakdown of billing fees applied to the transaction
    /// </summary>
    [JsonPropertyName("billingFeesDetails")]
    public IEnumerable<BillingFeeDetail>? BillingFeesDetails { get; set; }

    /// <summary>
    /// The name of the parent organization
    /// </summary>
    [JsonPropertyName("ParentOrgName")]
    public string? ParentOrgName { get; set; }

    /// <summary>
    /// The paypoint's DBA name
    /// </summary>
    [JsonPropertyName("PaypointDbaname")]
    public string? PaypointDbaname { get; set; }

    /// <summary>
    /// The paypoint's legal name
    /// </summary>
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

    /// <summary>
    /// Processor information, used for troubleshooting and reporting. This field contains a value when the API key used to make the request has management permissions.
    /// </summary>
    [JsonPropertyName("ExternalProcessorInformation")]
    public string? ExternalProcessorInformation { get; set; }

    /// <summary>
    /// Internal identifier used for processing
    /// </summary>
    [JsonPropertyName("GatewayTransId")]
    public string? GatewayTransId { get; set; }

    /// <summary>
    /// Custom identifier for the transaction
    /// </summary>
    [JsonPropertyName("OrderId")]
    public string? OrderId { get; set; }

    /// <summary>
    /// Payment method used: card, ach, or wallet
    /// </summary>
    [JsonPropertyName("Method")]
    public string? Method { get; set; }

    /// <summary>
    /// The batch number the transaction was included in
    /// </summary>
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

    /// <summary>
    /// Details about the payment method and transaction
    /// </summary>
    [JsonPropertyName("PaymentData")]
    public QueryPaymentData? PaymentData { get; set; }

    /// <summary>
    /// Status of transaction. See [the docs](/developers/references/money-in-statuses#money-in-transaction-status) for a full reference.
    /// </summary>
    [JsonPropertyName("TransStatus")]
    public int? TransStatus { get; set; }

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

    /// <summary>
    /// Service fee or sub-charge applied
    /// </summary>
    [JsonPropertyName("FeeAmount")]
    public double? FeeAmount { get; set; }

    /// <summary>
    /// Settlement status for transaction. See [the docs](/developers/references/money-in-statuses#payment-funding-status) for a full reference.
    /// </summary>
    [JsonPropertyName("SettlementStatus")]
    public int? SettlementStatus { get; set; }

    /// <summary>
    /// The transaction's operation
    /// </summary>
    [JsonPropertyName("Operation")]
    public string? Operation { get; set; }

    /// <summary>
    /// Details about the transaction response
    /// </summary>
    [JsonPropertyName("ResponseData")]
    public QueryResponseData? ResponseData { get; set; }

    /// <summary>
    /// Custom identifier to indicate the transaction or request source
    /// </summary>
    [JsonPropertyName("Source")]
    public string? Source { get; set; }

    /// <summary>
    /// Reference to the subscription or schedule that originated the transaction
    /// </summary>
    [JsonPropertyName("ScheduleReference")]
    public int? ScheduleReference { get; set; }

    /// <summary>
    /// ID of immediate parent organization
    /// </summary>
    [JsonPropertyName("OrgId")]
    public long? OrgId { get; set; }

    /// <summary>
    /// Identifier of refund transaction linked to this payment
    /// </summary>
    [JsonPropertyName("RefundId")]
    public long? RefundId { get; set; }

    /// <summary>
    /// Identifier of return/chargeback transaction linked to this payment
    /// </summary>
    [JsonPropertyName("ReturnedId")]
    public long? ReturnedId { get; set; }

    /// <summary>
    /// Identifier of chargeback transaction
    /// </summary>
    [JsonPropertyName("ChargebackId")]
    public long? ChargebackId { get; set; }

    /// <summary>
    /// Identifier of retrieval request
    /// </summary>
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

    /// <summary>
    /// Internal reference ID to the payment page capturing the payment
    /// </summary>
    [JsonPropertyName("EntrypageId")]
    public long? EntrypageId { get; set; }

    /// <summary>
    /// A custom identifier for the paypoint
    /// </summary>
    [JsonPropertyName("externalPaypointID")]
    public string? ExternalPaypointId { get; set; }

    /// <summary>
    /// Transaction date and time, in UTC
    /// </summary>
    [JsonPropertyName("TransactionTime")]
    public DateTime? TransactionTime { get; set; }

    /// <summary>
    /// Customer information associated with the transaction
    /// </summary>
    [JsonPropertyName("Customer")]
    public QueryTransactionPayorData? Customer { get; set; }

    /// <summary>
    /// Split funding instructions for the transaction
    /// </summary>
    [JsonPropertyName("splitFundingInstructions")]
    public IEnumerable<SplitFundingContent>? SplitFundingInstructions { get; set; }

    /// <summary>
    /// Service Fee or sub-charge transactions associated to the main transaction
    /// </summary>
    [JsonPropertyName("CfeeTransactions")]
    public IEnumerable<QueryCFeeTransaction>? CfeeTransactions { get; set; }

    /// <summary>
    /// Events associated with this transaction
    /// </summary>
    [JsonPropertyName("TransactionEvents")]
    public IEnumerable<QueryTransactionEvents>? TransactionEvents { get; set; }

    /// <summary>
    /// Pending fee amount for the transaction
    /// </summary>
    [JsonPropertyName("PendingFeeAmount")]
    public double? PendingFeeAmount { get; set; }

    /// <summary>
    /// Indicates if the transaction was flagged for risk
    /// </summary>
    [JsonPropertyName("RiskFlagged")]
    public bool? RiskFlagged { get; set; }

    /// <summary>
    /// Timestamp when the transaction was flagged for risk
    /// </summary>
    [JsonPropertyName("RiskFlaggedOn")]
    public DateTime? RiskFlaggedOn { get; set; }

    /// <summary>
    /// Current risk status of the transaction
    /// </summary>
    [JsonPropertyName("RiskStatus")]
    public string? RiskStatus { get; set; }

    /// <summary>
    /// Reason for risk flagging
    /// </summary>
    [JsonPropertyName("RiskReason")]
    public string? RiskReason { get; set; }

    /// <summary>
    /// Action taken due to risk assessment
    /// </summary>
    [JsonPropertyName("RiskAction")]
    public string? RiskAction { get; set; }

    /// <summary>
    /// Numeric code representing the risk action
    /// </summary>
    [JsonPropertyName("RiskActionCode")]
    public int? RiskActionCode { get; set; }

    /// <summary>
    /// Identifier of registered cloud device used in the transaction
    /// </summary>
    [JsonPropertyName("DeviceId")]
    public string? DeviceId { get; set; }

    /// <summary>
    /// Standard Entry Class (SEC) code for ACH transactions
    /// </summary>
    [JsonPropertyName("AchSecCode")]
    public string? AchSecCode { get; set; }

    /// <summary>
    /// Type of ACH account holder (personal or business)
    /// </summary>
    [JsonPropertyName("AchHolderType")]
    public AchHolderType? AchHolderType { get; set; }

    /// <summary>
    /// IP address of the transaction source
    /// </summary>
    [JsonPropertyName("IPAddress")]
    public string? IpAddress { get; set; }

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
