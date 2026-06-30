using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// A split funding instruction on a settled transaction, enriched with the batch and transfer that paid out the split when that information is available. Returned by the settlement query endpoints.
/// </summary>
[Serializable]
public record SettlementSplitFundingDetail : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The entrypoint the split was sent to.
    /// </summary>
    [JsonPropertyName("recipientEntryPoint")]
    public string? RecipientEntryPoint { get; set; }

    /// <summary>
    /// The account the split was sent to.
    /// </summary>
    [JsonPropertyName("AccountId")]
    public string? AccountId { get; set; }

    /// <summary>
    /// A description for the split.
    /// </summary>
    [JsonPropertyName("Description")]
    public string? Description { get; set; }

    /// <summary>
    /// The amount of the transaction sent to this recipient as a split.
    /// </summary>
    [JsonPropertyName("Amount")]
    public double? Amount { get; set; }

    /// <summary>
    /// The batch number the split was paid out in. Null when the batch isn't available.
    /// </summary>
    [JsonPropertyName("batchNumber")]
    public string? BatchNumber { get; set; }

    /// <summary>
    /// Identifier of the transfer that carried the split. Null when the transfer isn't available.
    /// </summary>
    [JsonPropertyName("transferId")]
    public long? TransferId { get; set; }

    /// <summary>
    /// The total amount of the transfer that carried this split.
    /// </summary>
    [JsonPropertyName("transferAmount")]
    public double? TransferAmount { get; set; }

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
