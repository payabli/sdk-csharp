using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Complete transaction details including payment information, customer data, and processing metadata. This is returned when includeDetails=true.
/// </summary>
[Serializable]
public record TransactionDetailRecord : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("parentOrgName")]
    public required string ParentOrgName { get; set; }

    [JsonPropertyName("paypointDbaname")]
    public required string PaypointDbaname { get; set; }

    [JsonPropertyName("paypointLegalname")]
    public required string PaypointLegalname { get; set; }

    [JsonPropertyName("paypointEntryname")]
    public required string PaypointEntryname { get; set; }

    [JsonPropertyName("paymentTransId")]
    public required string PaymentTransId { get; set; }

    [JsonPropertyName("connectorName")]
    public required string ConnectorName { get; set; }

    [JsonPropertyName("externalProcessorInformation")]
    public required string ExternalProcessorInformation { get; set; }

    [JsonPropertyName("gatewayTransId")]
    public required string GatewayTransId { get; set; }

    [JsonPropertyName("orderId")]
    public string? OrderId { get; set; }

    [JsonPropertyName("method")]
    public required TransactionDetailRecordMethod Method { get; set; }

    [JsonPropertyName("batchNumber")]
    public required string BatchNumber { get; set; }

    [JsonPropertyName("batchAmount")]
    public required double BatchAmount { get; set; }

    [JsonPropertyName("payorId")]
    public required long PayorId { get; set; }

    [JsonPropertyName("paymentData")]
    public required TransactionDetailPaymentData PaymentData { get; set; }

    [JsonPropertyName("transStatus")]
    public required int TransStatus { get; set; }

    [JsonPropertyName("paypointId")]
    public required long PaypointId { get; set; }

    [JsonPropertyName("totalAmount")]
    public required double TotalAmount { get; set; }

    [JsonPropertyName("netAmount")]
    public required double NetAmount { get; set; }

    [JsonPropertyName("feeAmount")]
    public required double FeeAmount { get; set; }

    [JsonPropertyName("settlementStatus")]
    public required int SettlementStatus { get; set; }

    [JsonPropertyName("operation")]
    public required string Operation { get; set; }

    [JsonPropertyName("responseData")]
    public required TransactionDetailResponseData ResponseData { get; set; }

    [JsonPropertyName("source")]
    public required string Source { get; set; }

    [JsonPropertyName("scheduleReference")]
    public required long ScheduleReference { get; set; }

    [JsonPropertyName("orgId")]
    public required long OrgId { get; set; }

    [JsonPropertyName("refundId")]
    public required long RefundId { get; set; }

    [JsonPropertyName("returnedId")]
    public required long ReturnedId { get; set; }

    [JsonPropertyName("chargebackId")]
    public required long ChargebackId { get; set; }

    [JsonPropertyName("retrievalId")]
    public required long RetrievalId { get; set; }

    [JsonPropertyName("transAdditionalData")]
    public object? TransAdditionalData { get; set; }

    [JsonPropertyName("invoiceData")]
    public required TransactionDetailInvoiceData InvoiceData { get; set; }

    [JsonPropertyName("entrypageId")]
    public required long EntrypageId { get; set; }

    [JsonPropertyName("externalPaypointID")]
    public required string ExternalPaypointId { get; set; }

    [JsonPropertyName("isValidatedACH")]
    public required bool IsValidatedAch { get; set; }

    [JsonPropertyName("transactionTime")]
    public required string TransactionTime { get; set; }

    [JsonPropertyName("customer")]
    public required TransactionDetailCustomer Customer { get; set; }

    [JsonPropertyName("splitFundingInstructions")]
    public IEnumerable<SplitFundingContent>? SplitFundingInstructions { get; set; }

    [JsonPropertyName("cfeeTransactions")]
    public IEnumerable<QueryCFeeTransaction> CfeeTransactions { get; set; } =
        new List<QueryCFeeTransaction>();

    [JsonPropertyName("transactionEvents")]
    public IEnumerable<TransactionDetailEvent> TransactionEvents { get; set; } =
        new List<TransactionDetailEvent>();

    [JsonPropertyName("pendingFeeAmount")]
    public double? PendingFeeAmount { get; set; }

    [JsonPropertyName("riskFlagged")]
    public bool? RiskFlagged { get; set; }

    [JsonPropertyName("riskFlaggedOn")]
    public DateTime? RiskFlaggedOn { get; set; }

    [JsonPropertyName("riskStatus")]
    public required string RiskStatus { get; set; }

    [JsonPropertyName("riskReason")]
    public required string RiskReason { get; set; }

    [JsonPropertyName("riskAction")]
    public required string RiskAction { get; set; }

    [JsonPropertyName("riskActionCode")]
    public int? RiskActionCode { get; set; }

    [JsonPropertyName("deviceId")]
    public required string DeviceId { get; set; }

    [JsonPropertyName("achSecCode")]
    public required string AchSecCode { get; set; }

    [JsonPropertyName("achHolderType")]
    public required AchHolderType AchHolderType { get; set; }

    [JsonPropertyName("ipAddress")]
    public required string IpAddress { get; set; }

    [JsonPropertyName("isSameDayACH")]
    public required bool IsSameDayAch { get; set; }

    [JsonPropertyName("walletType")]
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
