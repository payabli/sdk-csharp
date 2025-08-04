using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record Transfer : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The transfer ID.
    /// </summary>
    [JsonPropertyName("transferId")]
    public required int TransferId { get; set; }

    /// <summary>
    /// The ID of the paypoint the transfer belongs to.
    /// </summary>
    [JsonPropertyName("paypointId")]
    public required int PaypointId { get; set; }

    /// <summary>
    /// The batch number associated with the transfer.
    /// </summary>
    [JsonPropertyName("batchNumber")]
    public required string BatchNumber { get; set; }

    /// <summary>
    /// Unique identifier for the transfer.
    /// </summary>
    [JsonPropertyName("transferIdentifier")]
    public required string TransferIdentifier { get; set; }

    /// <summary>
    /// The ID of the batch the transfer belongs to.
    /// </summary>
    [JsonPropertyName("batchId")]
    public required int BatchId { get; set; }

    /// <summary>
    /// Date when the transfer occurred.
    /// </summary>
    [JsonPropertyName("transferDate")]
    public required string TransferDate { get; set; }

    /// <summary>
    /// The payment processor used for the transfer.
    /// </summary>
    [JsonPropertyName("processor")]
    public required string Processor { get; set; }

    /// <summary>
    /// The current status of the transfer.
    /// </summary>
    [JsonPropertyName("transferStatus")]
    public required int TransferStatus { get; set; }

    /// <summary>
    /// Gross batch is the total amount of the payments grouped in the batch. This amount includes service fees.
    /// </summary>
    [JsonPropertyName("grossAmount")]
    public required double GrossAmount { get; set; }

    /// <summary>
    /// Amount of chargebacks to be deducted from batch.
    /// </summary>
    [JsonPropertyName("chargeBackAmount")]
    public required double ChargeBackAmount { get; set; }

    /// <summary>
    /// Amount of ACH returns to be deducted from batch.
    /// </summary>
    [JsonPropertyName("returnedAmount")]
    public required double ReturnedAmount { get; set; }

    /// <summary>
    /// Amount being held for fraud or risk concerns.
    /// </summary>
    [JsonPropertyName("holdAmount")]
    public required double HoldAmount { get; set; }

    /// <summary>
    /// Amount of previously held funds that have been released after a risk review.
    /// </summary>
    [JsonPropertyName("releasedAmount")]
    public required double ReleasedAmount { get; set; }

    /// <summary>
    /// Amount of charges and fees applied for services and transactions.
    /// </summary>
    [JsonPropertyName("billingFeesAmount")]
    public required double BillingFeesAmount { get; set; }

    /// <summary>
    /// Amount of payments captured in the batch cycle that are deposited separately. For example, checks or cash payments recorded in the batch but not deposited via Payabli, or card brands making a direct transfer in certain situations.
    /// </summary>
    [JsonPropertyName("thirdPartyPaidAmount")]
    public required double ThirdPartyPaidAmount { get; set; }

    /// <summary>
    /// Amount of corrections applied to Billing & Fees charges.
    /// </summary>
    [JsonPropertyName("adjustmentsAmount")]
    public required double AdjustmentsAmount { get; set; }

    /// <summary>
    /// The net transfer amount after all deductions and additions.
    /// </summary>
    [JsonPropertyName("netTransferAmount")]
    public required double NetTransferAmount { get; set; }

    /// <summary>
    /// List of events associated with the transfer.
    /// </summary>
    [JsonPropertyName("eventsData")]
    public IEnumerable<TransferEvent> EventsData { get; set; } = new List<TransferEvent>();

    /// <summary>
    /// List of messages related to the transfer.
    /// </summary>
    [JsonPropertyName("messages")]
    public IEnumerable<string> Messages { get; set; } = new List<string>();

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
