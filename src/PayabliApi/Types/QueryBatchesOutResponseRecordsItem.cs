using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record QueryBatchesOutResponseRecordsItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("AchAmount")]
    public double? AchAmount { get; set; }

    [JsonPropertyName("AchRecords")]
    public int? AchRecords { get; set; }

    [JsonPropertyName("AchStatus")]
    public int? AchStatus { get; set; }

    [JsonPropertyName("AchStatusText")]
    public string? AchStatusText { get; set; }

    /// <summary>
    /// The amount of the batch.
    /// </summary>
    [JsonPropertyName("BatchAmount")]
    public double? BatchAmount { get; set; }

    [JsonPropertyName("BatchCancelledAmount")]
    public double? BatchCancelledAmount { get; set; }

    [JsonPropertyName("BatchCancelledRecords")]
    public int? BatchCancelledRecords { get; set; }

    /// <summary>
    /// The batch date.
    /// </summary>
    [JsonPropertyName("BatchDate")]
    public DateTime? BatchDate { get; set; }

    [JsonPropertyName("BatchNumber")]
    public string? BatchNumber { get; set; }

    [JsonPropertyName("BatchPaidAmount")]
    public double? BatchPaidAmount { get; set; }

    [JsonPropertyName("BatchPaidRecords")]
    public int? BatchPaidRecords { get; set; }

    [JsonPropertyName("BatchProcessedAmount")]
    public double? BatchProcessedAmount { get; set; }

    [JsonPropertyName("BatchProcessedRecords")]
    public int? BatchProcessedRecords { get; set; }

    [JsonPropertyName("BatchProcessingAmount")]
    public double? BatchProcessingAmount { get; set; }

    [JsonPropertyName("BatchProcessingRecords")]
    public int? BatchProcessingRecords { get; set; }

    /// <summary>
    /// The number of records in the batch.
    /// </summary>
    [JsonPropertyName("BatchRecords")]
    public int? BatchRecords { get; set; }

    /// <summary>
    /// The batch status. See [Batch Status](/developers/references/money-out-statuses#batch-statuses) for more.
    /// </summary>
    [JsonPropertyName("BatchStatus")]
    public int? BatchStatus { get; set; }

    /// <summary>
    /// A text description of the batch status.
    /// </summary>
    [JsonPropertyName("BatchStatusText")]
    public string? BatchStatusText { get; set; }

    [JsonPropertyName("CardAmount")]
    public double? CardAmount { get; set; }

    [JsonPropertyName("CardRecords")]
    public int? CardRecords { get; set; }

    [JsonPropertyName("CardStatus")]
    public int? CardStatus { get; set; }

    [JsonPropertyName("CardStatusText")]
    public string? CardStatusText { get; set; }

    [JsonPropertyName("CheckAmount")]
    public double? CheckAmount { get; set; }

    [JsonPropertyName("CheckRecords")]
    public int? CheckRecords { get; set; }

    [JsonPropertyName("CheckStatus")]
    public int? CheckStatus { get; set; }

    [JsonPropertyName("CheckStatusText")]
    public string? CheckStatusText { get; set; }

    [JsonPropertyName("EntryName")]
    public string? EntryName { get; set; }

    [JsonPropertyName("externalPaypointID")]
    public string? ExternalPaypointId { get; set; }

    /// <summary>
    /// The batch ID.
    /// </summary>
    [JsonPropertyName("IdBatch")]
    public int? IdBatch { get; set; }

    /// <summary>
    /// The entrypoint's parent org.
    /// </summary>
    [JsonPropertyName("ParentOrgName")]
    public string? ParentOrgName { get; set; }

    /// <summary>
    /// Paypoint DBA name.
    /// </summary>
    [JsonPropertyName("PaypointDba")]
    public string? PaypointDba { get; set; }

    /// <summary>
    /// Paypoint ID.
    /// </summary>
    [JsonPropertyName("PaypointId")]
    public int? PaypointId { get; set; }

    /// <summary>
    /// Paypoint legal name.
    /// </summary>
    [JsonPropertyName("PaypointName")]
    public string? PaypointName { get; set; }

    [JsonPropertyName("VcardAmount")]
    public double? VcardAmount { get; set; }

    [JsonPropertyName("VcardRecords")]
    public int? VcardRecords { get; set; }

    [JsonPropertyName("VcardStatus")]
    public int? VcardStatus { get; set; }

    [JsonPropertyName("VcardStatusText")]
    public string? VcardStatusText { get; set; }

    [JsonPropertyName("WireAmount")]
    public double? WireAmount { get; set; }

    [JsonPropertyName("WireRecords")]
    public int? WireRecords { get; set; }

    [JsonPropertyName("WireStatus")]
    public int? WireStatus { get; set; }

    [JsonPropertyName("WireStatusText")]
    public string? WireStatusText { get; set; }

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
