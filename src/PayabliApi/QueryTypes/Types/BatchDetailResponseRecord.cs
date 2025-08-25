using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record BatchDetailResponseRecord : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("Id")]
    public required int Id { get; set; }

    [JsonPropertyName("Method")]
    public required string Method { get; set; }

    [JsonPropertyName("WalletType")]
    public string? WalletType { get; set; }

    [JsonPropertyName("SettledAmount")]
    public required double SettledAmount { get; set; }

    [JsonPropertyName("Type")]
    public required string Type { get; set; }

    [JsonPropertyName("BatchNumber")]
    public required string BatchNumber { get; set; }

    [JsonPropertyName("BatchAmount")]
    public required double BatchAmount { get; set; }

    [JsonPropertyName("PaymentTransId")]
    public required string PaymentTransId { get; set; }

    [JsonPropertyName("PaymentTransStatus")]
    public required int PaymentTransStatus { get; set; }

    [JsonPropertyName("ScheduleReference")]
    public required int ScheduleReference { get; set; }

    [JsonPropertyName("GatewayTransId")]
    public required string GatewayTransId { get; set; }

    [JsonPropertyName("OrderId")]
    public required string OrderId { get; set; }

    [JsonPropertyName("TransMethod")]
    public required string TransMethod { get; set; }

    [JsonPropertyName("PaymentData")]
    public QueryPaymentData? PaymentData { get; set; }

    [JsonPropertyName("NetAmount")]
    public double? NetAmount { get; set; }

    [JsonPropertyName("Operation")]
    public required string Operation { get; set; }

    [JsonPropertyName("Category")]
    public required string Category { get; set; }

    [JsonPropertyName("Source")]
    public string? Source { get; set; }

    [JsonPropertyName("Status")]
    public required int Status { get; set; }

    [JsonPropertyName("TransactionTime")]
    public required DateTime TransactionTime { get; set; }

    [JsonPropertyName("Customer")]
    public QueryTransactionPayorData? Customer { get; set; }

    [JsonPropertyName("SettlementDate")]
    public required DateTime SettlementDate { get; set; }

    [JsonPropertyName("PaymentSettlementStatus")]
    public required int PaymentSettlementStatus { get; set; }

    [JsonPropertyName("BatchStatus")]
    public required int BatchStatus { get; set; }

    [JsonPropertyName("DepositDate")]
    public required DateTime DepositDate { get; set; }

    [JsonPropertyName("ExpectedDepositDate")]
    public required DateTime ExpectedDepositDate { get; set; }

    [JsonPropertyName("MaskedAccount")]
    public required string MaskedAccount { get; set; }

    [JsonPropertyName("CreatedAt")]
    public required DateTime CreatedAt { get; set; }

    [JsonPropertyName("PaypointLegalname")]
    public required string PaypointLegalname { get; set; }

    [JsonPropertyName("ResponseData")]
    public QueryResponseData? ResponseData { get; set; }

    [JsonPropertyName("PaypointDbaname")]
    public required string PaypointDbaname { get; set; }

    [JsonPropertyName("ParentOrgName")]
    public required string ParentOrgName { get; set; }

    [JsonPropertyName("ParentOrgId")]
    public required int ParentOrgId { get; set; }

    [JsonPropertyName("PaypointEntryname")]
    public required string PaypointEntryname { get; set; }

    [JsonPropertyName("DeviceId")]
    public string? DeviceId { get; set; }

    [JsonPropertyName("RetrievalId")]
    public required long RetrievalId { get; set; }

    [JsonPropertyName("ChargebackId")]
    public long? ChargebackId { get; set; }

    [JsonPropertyName("AchHolderType")]
    public required AchHolderType AchHolderType { get; set; }

    [JsonPropertyName("AchSecCode")]
    public required string AchSecCode { get; set; }

    [JsonPropertyName("ConnectorName")]
    public required string ConnectorName { get; set; }

    [JsonPropertyName("EntrypageId")]
    public long? EntrypageId { get; set; }

    [JsonPropertyName("FeeAmount")]
    public required double FeeAmount { get; set; }

    [JsonPropertyName("OrgId")]
    public long? OrgId { get; set; }

    [JsonPropertyName("PayorId")]
    public long? PayorId { get; set; }

    [JsonPropertyName("PaypointId")]
    public long? PaypointId { get; set; }

    [JsonPropertyName("PendingFeeAmount")]
    public double? PendingFeeAmount { get; set; }

    [JsonPropertyName("RefundId")]
    public long? RefundId { get; set; }

    [JsonPropertyName("ReturnedId")]
    public required long ReturnedId { get; set; }

    [JsonPropertyName("splitFundingInstructions")]
    public IEnumerable<SplitFundingContent>? SplitFundingInstructions { get; set; }

    [JsonPropertyName("TotalAmount")]
    public required double TotalAmount { get; set; }

    [JsonPropertyName("CfeeTransactions")]
    public IEnumerable<QueryCFeeTransaction> CfeeTransactions { get; set; } =
        new List<QueryCFeeTransaction>();

    [JsonPropertyName("invoiceData")]
    public BillData? InvoiceData { get; set; }

    [JsonPropertyName("TransactionEvents")]
    public IEnumerable<QueryTransactionEvents> TransactionEvents { get; set; } =
        new List<QueryTransactionEvents>();

    [JsonPropertyName("externalPaypointID")]
    public required string ExternalPaypointId { get; set; }

    [JsonPropertyName("isHold")]
    public required int IsHold { get; set; }

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
