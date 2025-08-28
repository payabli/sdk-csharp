using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Transfer details within a batch response.
/// </summary>
[Serializable]
public record QueryBatchesTransfer : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The transfer ID.
    /// </summary>
    [JsonPropertyName("TransferId")]
    public int? TransferId { get; set; }

    /// <summary>
    /// The transfer date.
    /// </summary>
    [JsonPropertyName("TransferDate")]
    public DateTime? TransferDate { get; set; }

    /// <summary>
    /// The processor used for the transfer.
    /// </summary>
    [JsonPropertyName("Processor")]
    public string? Processor { get; set; }

    /// <summary>
    /// The transfer status.
    /// </summary>
    [JsonPropertyName("TransferStatus")]
    public int? TransferStatus { get; set; }

    /// <summary>
    /// The gross amount of the transfer.
    /// </summary>
    [JsonPropertyName("GrossAmount")]
    public double? GrossAmount { get; set; }

    /// <summary>
    /// The chargeback amount.
    /// </summary>
    [JsonPropertyName("ChargeBackAmount")]
    public double? ChargeBackAmount { get; set; }

    /// <summary>
    /// The returned amount.
    /// </summary>
    [JsonPropertyName("ReturnedAmount")]
    public double? ReturnedAmount { get; set; }

    /// <summary>
    /// The refund amount.
    /// </summary>
    [JsonPropertyName("RefundAmount")]
    public double? RefundAmount { get; set; }

    /// <summary>
    /// The amount being held.
    /// </summary>
    [JsonPropertyName("HoldAmount")]
    public double? HoldAmount { get; set; }

    /// <summary>
    /// The amount that has been released.
    /// </summary>
    [JsonPropertyName("ReleasedAmount")]
    public double? ReleasedAmount { get; set; }

    /// <summary>
    /// The billing fees amount.
    /// </summary>
    [JsonPropertyName("BillingFeesAmount")]
    public double? BillingFeesAmount { get; set; }

    /// <summary>
    /// The third party paid amount.
    /// </summary>
    [JsonPropertyName("ThirdPartyPaidAmount")]
    public double? ThirdPartyPaidAmount { get; set; }

    /// <summary>
    /// The adjustments amount.
    /// </summary>
    [JsonPropertyName("AdjustmentsAmount")]
    public double? AdjustmentsAmount { get; set; }

    /// <summary>
    /// The net funded amount.
    /// </summary>
    [JsonPropertyName("NetFundedAmount")]
    public double? NetFundedAmount { get; set; }

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
