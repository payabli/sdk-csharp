using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record QueryBatchesResponseRecordsItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("AchHolderType")]
    public AchHolderType? AchHolderType { get; set; }

    [JsonPropertyName("AchSecCode")]
    public string? AchSecCode { get; set; }

    /// <summary>
    /// The amount of the batch.
    /// </summary>
    [JsonPropertyName("BatchAmount")]
    public double? BatchAmount { get; set; }

    [JsonPropertyName("BatchAuthAmount")]
    public double? BatchAuthAmount { get; set; }

    /// <summary>
    /// The batch date.
    /// </summary>
    [JsonPropertyName("BatchDate")]
    public DateTime? BatchDate { get; set; }

    /// <summary>
    /// The total of fees in the batch.
    /// </summary>
    [JsonPropertyName("BatchFeesAmount")]
    public double? BatchFeesAmount { get; set; }

    /// <summary>
    /// The total amount of the batch that's being held for fraud or risk concerns.
    /// </summary>
    [JsonPropertyName("BatchHoldAmount")]
    public double? BatchHoldAmount { get; set; }

    [JsonPropertyName("BatchNumber")]
    public string? BatchNumber { get; set; }

    /// <summary>
    /// The number of records in the batch.
    /// </summary>
    [JsonPropertyName("BatchRecords")]
    public int? BatchRecords { get; set; }

    /// <summary>
    /// The total amount of refunds deducted from batch.
    /// </summary>
    [JsonPropertyName("BatchRefundAmount")]
    public double? BatchRefundAmount { get; set; }

    /// <summary>
    /// Previously held funds that have been released after a risk review.
    /// </summary>
    [JsonPropertyName("BatchReleasedAmount")]
    public double? BatchReleasedAmount { get; set; }

    /// <summary>
    /// Total amount of ACH returns deducted from batch.
    /// </summary>
    [JsonPropertyName("BatchReturnedAmount")]
    public double? BatchReturnedAmount { get; set; }

    /// <summary>
    /// Total of split transactions that included split funding instructions at the time of authorization.
    /// </summary>
    [JsonPropertyName("BatchSplitAmount")]
    public double? BatchSplitAmount { get; set; }

    /// <summary>
    /// The batch status. See [Batch Status](/developers/references/money-in-statuses#batch-status) for more.
    /// </summary>
    [JsonPropertyName("BatchStatus")]
    public int? BatchStatus { get; set; }

    [JsonPropertyName("ChargebackId")]
    public long? ChargebackId { get; set; }

    /// <summary>
    /// Service Fee or sub-charge transaction associated to the main
    /// transaction.
    /// </summary>
    [JsonPropertyName("CfeeTransactions")]
    public IEnumerable<QueryCFeeTransaction>? CfeeTransactions { get; set; }

    [JsonPropertyName("ConnectorName")]
    public string? ConnectorName { get; set; }

    [JsonPropertyName("DepositDate")]
    public DateTime? DepositDate { get; set; }

    [JsonPropertyName("DeviceId")]
    public string? DeviceId { get; set; }

    [JsonPropertyName("EntryName")]
    public string? EntryName { get; set; }

    [JsonPropertyName("EntryPageid")]
    public long? EntryPageid { get; set; }

    [JsonPropertyName("ExpectedDepositDate")]
    public DateTime? ExpectedDepositDate { get; set; }

    [JsonPropertyName("externalPaypointID")]
    public string? ExternalPaypointId { get; set; }

    [JsonPropertyName("FeeAmount")]
    public double? FeeAmount { get; set; }

    /// <summary>
    /// The batch ID.
    /// </summary>
    [JsonPropertyName("IdBatch")]
    public int? IdBatch { get; set; }

    /// <summary>
    /// The payment method used.
    /// </summary>
    [JsonPropertyName("Method")]
    public string? Method { get; set; }

    [JsonPropertyName("OrgId")]
    public long? OrgId { get; set; }

    /// <summary>
    /// The entrypoint's parent org.
    /// </summary>
    [JsonPropertyName("ParentOrgName")]
    public string? ParentOrgName { get; set; }

    /// <summary>
    /// The payment's settlement status.
    /// </summary>
    [JsonPropertyName("PaymentSettlementStatus")]
    public int? PaymentSettlementStatus { get; set; }

    [JsonPropertyName("PayorId")]
    public long? PayorId { get; set; }

    /// <summary>
    /// Paypoint DBA name.
    /// </summary>
    [JsonPropertyName("PaypointDba")]
    public string? PaypointDba { get; set; }

    [JsonPropertyName("PaypointId")]
    public long? PaypointId { get; set; }

    [JsonPropertyName("PaypointName")]
    public string? PaypointName { get; set; }

    [JsonPropertyName("PendingFeeAmount")]
    public double? PendingFeeAmount { get; set; }

    [JsonPropertyName("RefundId")]
    public long? RefundId { get; set; }

    [JsonPropertyName("RetrievalId")]
    public long? RetrievalId { get; set; }

    [JsonPropertyName("ReturnedId")]
    public long? ReturnedId { get; set; }

    /// <summary>
    /// Split funding instructions for the transaction
    /// </summary>
    [JsonPropertyName("splitFundingInstructions")]
    public IEnumerable<SplitFundingContent>? SplitFundingInstructions { get; set; }

    /// <summary>
    /// Total amount of the batch.
    /// </summary>
    [JsonPropertyName("TotalAmount")]
    public double? TotalAmount { get; set; }

    [JsonPropertyName("Transfer")]
    public string? Transfer { get; set; }

    /// <summary>
    /// The batch transfer date.
    /// </summary>
    [JsonPropertyName("TransferDate")]
    public DateTime? TransferDate { get; set; }

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
