using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record TransactionQueryRecordsCustomer : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("AchHolderType")]
    public AchHolderType? AchHolderType { get; set; }

    [JsonPropertyName("AchSecCode")]
    public string? AchSecCode { get; set; }

    /// <summary>
    /// Batch amount.
    /// </summary>
    [JsonPropertyName("BatchAmount")]
    public double? BatchAmount { get; set; }

    [JsonPropertyName("BatchNumber")]
    public string? BatchNumber { get; set; }

    /// <summary>
    /// Service Fee or sub-charge transaction associated to the main transaction.
    /// </summary>
    [JsonPropertyName("CfeeTransactions")]
    public IEnumerable<QueryCFeeTransaction>? CfeeTransactions { get; set; }

    /// <summary>
    /// Connector used for transaction.
    /// </summary>
    [JsonPropertyName("ConnectorName")]
    public string? ConnectorName { get; set; }

    [JsonPropertyName("Customer")]
    public QueryTransactionPayorDataCustomer? Customer { get; set; }

    [JsonPropertyName("DeviceId")]
    public string? DeviceId { get; set; }

    [JsonPropertyName("EntrypageId")]
    public long? EntrypageId { get; set; }

    [JsonPropertyName("ExternalProcessorInformation")]
    public string? ExternalProcessorInformation { get; set; }

    [JsonPropertyName("FeeAmount")]
    public double? FeeAmount { get; set; }

    /// <summary>
    /// Internal identifier used for processing.
    /// </summary>
    [JsonPropertyName("GatewayTransId")]
    public string? GatewayTransId { get; set; }

    [JsonPropertyName("InvoiceData")]
    public BillData? InvoiceData { get; set; }

    /// <summary>
    /// Payment method used: card, ach, or wallet.
    /// </summary>
    [JsonPropertyName("Method")]
    public string? Method { get; set; }

    /// <summary>
    /// Net amount paid.
    /// </summary>
    [JsonPropertyName("NetAmount")]
    public double? NetAmount { get; set; }

    [JsonPropertyName("Operation")]
    public string? Operation { get; set; }

    [JsonPropertyName("OrderId")]
    public string? OrderId { get; set; }

    /// <summary>
    /// ID of immediate parent organization.
    /// </summary>
    [JsonPropertyName("OrgId")]
    public long? OrgId { get; set; }

    [JsonPropertyName("ParentOrgName")]
    public string? ParentOrgName { get; set; }

    [JsonPropertyName("PaymentData")]
    public QueryPaymentData? PaymentData { get; set; }

    /// <summary>
    /// Unique Transaction ID.
    /// </summary>
    [JsonPropertyName("PaymentTransId")]
    public string? PaymentTransId { get; set; }

    [JsonPropertyName("PayorId")]
    public long? PayorId { get; set; }

    /// <summary>
    /// Paypoint's DBA name.
    /// </summary>
    [JsonPropertyName("PaypointDbaname")]
    public string? PaypointDbaname { get; set; }

    /// <summary>
    /// Paypoint's entryname.
    /// </summary>
    [JsonPropertyName("PaypointEntryname")]
    public string? PaypointEntryname { get; set; }

    /// <summary>
    /// InternalId for paypoint.
    /// </summary>
    [JsonPropertyName("PaypointId")]
    public long? PaypointId { get; set; }

    /// <summary>
    /// Paypoint's legal name.
    /// </summary>
    [JsonPropertyName("PaypointLegalname")]
    public string? PaypointLegalname { get; set; }

    [JsonPropertyName("PendingFeeAmount")]
    public double? PendingFeeAmount { get; set; }

    [JsonPropertyName("RefundId")]
    public long? RefundId { get; set; }

    [JsonPropertyName("ResponseData")]
    public QueryResponseData? ResponseData { get; set; }

    [JsonPropertyName("ReturnedId")]
    public long? ReturnedId { get; set; }

    /// <summary>
    /// Reference to the subscription that originated the transaction.
    /// </summary>
    [JsonPropertyName("ScheduleReference")]
    public long? ScheduleReference { get; set; }

    /// <summary>
    /// Settlement status for transaction. See [the docs](/developers/references/money-in-statuses#payment-funding-status) for a full reference.
    /// </summary>
    [JsonPropertyName("SettlementStatus")]
    public int? SettlementStatus { get; set; }

    [JsonPropertyName("Source")]
    public string? Source { get; set; }

    [JsonPropertyName("splitFundingInstructions")]
    public IEnumerable<SplitFundingContent>? SplitFundingInstructions { get; set; }

    /// <summary>
    /// Transaction total amount (including service fee or sub-charge)
    /// </summary>
    [JsonPropertyName("TotalAmount")]
    public double? TotalAmount { get; set; }

    /// <summary>
    /// Events associated with this transaction.
    /// </summary>
    [JsonPropertyName("TransactionEvents")]
    public IEnumerable<QueryTransactionEvents>? TransactionEvents { get; set; }

    /// <summary>
    /// Transaction date and time, in UTC.
    /// </summary>
    [JsonPropertyName("TransactionTime")]
    public DateTime? TransactionTime { get; set; }

    [JsonPropertyName("TransAdditionalData")]
    public object? TransAdditionalData { get; set; }

    /// <summary>
    /// Status of transaction. See [the docs](/developers/references/money-in-statuses#money-in-transaction-status) for a full reference.
    /// </summary>
    [JsonPropertyName("TransStatus")]
    public int? TransStatus { get; set; }

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
