using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// A record representing an outbound transfer.
/// </summary>
[Serializable]
public record TransferOutRecord : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Unique identifier for the transfer.
    /// </summary>
    [JsonPropertyName("transferId")]
    public int? TransferId { get; set; }

    /// <summary>
    /// The ID of the paypoint associated with the transfer.
    /// </summary>
    [JsonPropertyName("paypointId")]
    public int? PaypointId { get; set; }

    /// <summary>
    /// The batch number for the transfer.
    /// </summary>
    [JsonPropertyName("batchNumber")]
    public string? BatchNumber { get; set; }

    /// <summary>
    /// The currency of the batch.
    /// </summary>
    [JsonPropertyName("batchCurrency")]
    public string? BatchCurrency { get; set; }

    /// <summary>
    /// The number of records in the batch.
    /// </summary>
    [JsonPropertyName("batchRecords")]
    public int? BatchRecords { get; set; }

    /// <summary>
    /// An identifier for the transfer.
    /// </summary>
    [JsonPropertyName("transferIdentifier")]
    public string? TransferIdentifier { get; set; }

    /// <summary>
    /// The ID of the batch.
    /// </summary>
    [JsonPropertyName("batchId")]
    public int? BatchId { get; set; }

    /// <summary>
    /// The net amount of the batch.
    /// </summary>
    [JsonPropertyName("batchNetAmount")]
    public double? BatchNetAmount { get; set; }

    /// <summary>
    /// The status of the batch.
    /// </summary>
    [JsonPropertyName("batchStatus")]
    public int? BatchStatus { get; set; }

    /// <summary>
    /// The entry name for the paypoint.
    /// </summary>
    [JsonPropertyName("paypointEntryName")]
    public string? PaypointEntryName { get; set; }

    /// <summary>
    /// The legal name of the paypoint.
    /// </summary>
    [JsonPropertyName("paypointLegalName")]
    public string? PaypointLegalName { get; set; }

    /// <summary>
    /// The DBA name of the paypoint.
    /// </summary>
    [JsonPropertyName("paypointDbaName")]
    public string? PaypointDbaName { get; set; }

    /// <summary>
    /// URL to the paypoint's logo.
    /// </summary>
    [JsonPropertyName("paypointLogo")]
    public string? PaypointLogo { get; set; }

    /// <summary>
    /// The name of the parent organization.
    /// </summary>
    [JsonPropertyName("parentOrgName")]
    public string? ParentOrgName { get; set; }

    /// <summary>
    /// The ID of the parent organization.
    /// </summary>
    [JsonPropertyName("parentOrgId")]
    public int? ParentOrgId { get; set; }

    /// <summary>
    /// URL to the parent organization's logo.
    /// </summary>
    [JsonPropertyName("parentOrgLogo")]
    public string? ParentOrgLogo { get; set; }

    /// <summary>
    /// The entry name for the parent organization.
    /// </summary>
    [JsonPropertyName("parentOrgEntryName")]
    public string? ParentOrgEntryName { get; set; }

    /// <summary>
    /// External identifier for the paypoint.
    /// </summary>
    [JsonPropertyName("externalPaypointID")]
    public string? ExternalPaypointId { get; set; }

    /// <summary>
    /// Bank account information for the transfer.
    /// </summary>
    [JsonPropertyName("bankAccount")]
    public TransferOutBankAccount? BankAccount { get; set; }

    /// <summary>
    /// The date of the transfer.
    /// </summary>
    [JsonPropertyName("transferDate")]
    public DateTime? TransferDate { get; set; }

    /// <summary>
    /// The processor used for the transfer.
    /// </summary>
    [JsonPropertyName("processor")]
    public string? Processor { get; set; }

    /// <summary>
    /// The status of the transfer.
    /// </summary>
    [JsonPropertyName("transferStatus")]
    public int? TransferStatus { get; set; }

    /// <summary>
    /// The gross amount of the transfer.
    /// </summary>
    [JsonPropertyName("grossAmount")]
    public double? GrossAmount { get; set; }

    /// <summary>
    /// The chargeback amount deducted from the transfer.
    /// </summary>
    [JsonPropertyName("chargeBackAmount")]
    public double? ChargeBackAmount { get; set; }

    /// <summary>
    /// The returned amount deducted from the transfer.
    /// </summary>
    [JsonPropertyName("returnedAmount")]
    public double? ReturnedAmount { get; set; }

    /// <summary>
    /// The amount being held.
    /// </summary>
    [JsonPropertyName("holdAmount")]
    public double? HoldAmount { get; set; }

    /// <summary>
    /// The amount that has been released.
    /// </summary>
    [JsonPropertyName("releasedAmount")]
    public double? ReleasedAmount { get; set; }

    /// <summary>
    /// The billing fees amount.
    /// </summary>
    [JsonPropertyName("billingFeesAmount")]
    public double? BillingFeesAmount { get; set; }

    /// <summary>
    /// The third party paid amount.
    /// </summary>
    [JsonPropertyName("thirdPartyPaidAmount")]
    public double? ThirdPartyPaidAmount { get; set; }

    /// <summary>
    /// The adjustments amount.
    /// </summary>
    [JsonPropertyName("adjustmentsAmount")]
    public double? AdjustmentsAmount { get; set; }

    /// <summary>
    /// The net transfer amount after all deductions.
    /// </summary>
    [JsonPropertyName("netTransferAmount")]
    public double? NetTransferAmount { get; set; }

    /// <summary>
    /// The split funding amount.
    /// </summary>
    [JsonPropertyName("splitAmount")]
    public double? SplitAmount { get; set; }

    /// <summary>
    /// List of events associated with the transfer.
    /// </summary>
    [JsonPropertyName("eventsData")]
    public IEnumerable<TransferOutEventData>? EventsData { get; set; }

    /// <summary>
    /// List of messages associated with the transfer.
    /// </summary>
    [JsonPropertyName("messages")]
    public IEnumerable<TransferOutMessage>? Messages { get; set; }

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
