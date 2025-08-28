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

    /// <summary>
    /// The batch ID.
    /// </summary>
    [JsonPropertyName("IdBatch")]
    public int? IdBatch { get; set; }

    [JsonPropertyName("BatchNumber")]
    public string? BatchNumber { get; set; }

    [JsonPropertyName("TransferIdentifier")]
    public string? TransferIdentifier { get; set; }

    /// <summary>
    /// Events associated with the batch.
    /// </summary>
    [JsonPropertyName("EventsData")]
    public IEnumerable<GeneralEvents>? EventsData { get; set; }

    [JsonPropertyName("ConnectorName")]
    public string? ConnectorName { get; set; }

    /// <summary>
    /// The batch date.
    /// </summary>
    [JsonPropertyName("BatchDate")]
    public DateTime? BatchDate { get; set; }

    /// <summary>
    /// The amount of the batch.
    /// </summary>
    [JsonPropertyName("BatchAmount")]
    public double? BatchAmount { get; set; }

    /// <summary>
    /// The total of fees in the batch.
    /// </summary>
    [JsonPropertyName("BatchFeesAmount")]
    public double? BatchFeesAmount { get; set; }

    [JsonPropertyName("BatchAuthAmount")]
    public double? BatchAuthAmount { get; set; }

    /// <summary>
    /// Previously held funds that have been released after a risk review.
    /// </summary>
    [JsonPropertyName("BatchReleasedAmount")]
    public double? BatchReleasedAmount { get; set; }

    /// <summary>
    /// The total amount of the batch that's being held for fraud or risk concerns.
    /// </summary>
    [JsonPropertyName("BatchHoldAmount")]
    public double? BatchHoldAmount { get; set; }

    /// <summary>
    /// Total amount of ACH returns deducted from batch.
    /// </summary>
    [JsonPropertyName("BatchReturnedAmount")]
    public double? BatchReturnedAmount { get; set; }

    /// <summary>
    /// The total amount of refunds deducted from batch.
    /// </summary>
    [JsonPropertyName("BatchRefundAmount")]
    public double? BatchRefundAmount { get; set; }

    /// <summary>
    /// Total of split transactions that included split funding instructions at the time of authorization.
    /// </summary>
    [JsonPropertyName("BatchSplitAmount")]
    public double? BatchSplitAmount { get; set; }

    /// <summary>
    /// The batch status. See [Batch Status](/developers/references/money-in-statuses#batch-status) for more.
    /// </summary>
    [JsonPropertyName("BatchStatus")]
    public required int BatchStatus { get; set; }

    /// <summary>
    /// The number of records in the batch.
    /// </summary>
    [JsonPropertyName("BatchRecords")]
    public required int BatchRecords { get; set; }

    [JsonPropertyName("PaypointId")]
    public long? PaypointId { get; set; }

    [JsonPropertyName("PaypointName")]
    public string? PaypointName { get; set; }

    [JsonPropertyName("PaypointDba")]
    public string? PaypointDba { get; set; }

    /// <summary>
    /// The entrypoint's parent org.
    /// </summary>
    [JsonPropertyName("ParentOrgName")]
    public required string ParentOrgName { get; set; }

    /// <summary>
    /// The parent organization ID.
    /// </summary>
    [JsonPropertyName("ParentOrgId")]
    public required int ParentOrgId { get; set; }

    [JsonPropertyName("externalPaypointID")]
    public string? ExternalPaypointId { get; set; }

    [JsonPropertyName("EntryName")]
    public required string EntryName { get; set; }

    /// <summary>
    /// The bank name.
    /// </summary>
    [JsonPropertyName("BankName")]
    public string? BankName { get; set; }

    /// <summary>
    /// The batch type.
    /// </summary>
    [JsonPropertyName("BatchType")]
    public int? BatchType { get; set; }

    /// <summary>
    /// The payment method used.
    /// </summary>
    [JsonPropertyName("Method")]
    public string? Method { get; set; }

    [JsonPropertyName("ExpectedDepositDate")]
    public DateTime? ExpectedDepositDate { get; set; }

    [JsonPropertyName("DepositDate")]
    public DateTime? DepositDate { get; set; }

    /// <summary>
    /// The batch transfer date.
    /// </summary>
    [JsonPropertyName("TransferDate")]
    public DateTime? TransferDate { get; set; }

    /// <summary>
    /// Transfer details for the batch.
    /// </summary>
    [JsonPropertyName("Transfer")]
    public QueryBatchesTransfer? Transfer { get; set; }

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
