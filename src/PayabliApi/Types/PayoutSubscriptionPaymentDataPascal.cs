using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Payment method details for the payout subscription, as returned by the list payout subscriptions endpoint.
/// </summary>
[Serializable]
public record PayoutSubscriptionPaymentDataPascal : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("AccountExp")]
    public string? AccountExp { get; set; }

    [JsonPropertyName("accountId")]
    public string? AccountId { get; set; }

    [JsonPropertyName("AccountType")]
    public string? AccountType { get; set; }

    [JsonPropertyName("AccountZip")]
    public string? AccountZip { get; set; }

    [JsonPropertyName("binData")]
    public BinData? BinData { get; set; }

    [JsonPropertyName("HolderName")]
    public string? HolderName { get; set; }

    [JsonPropertyName("Initiator")]
    public string? Initiator { get; set; }

    [JsonPropertyName("MaskedAccount")]
    public string? MaskedAccount { get; set; }

    [JsonPropertyName("orderDescription")]
    public string? OrderDescription { get; set; }

    [JsonPropertyName("paymentDetails")]
    public PayoutSubscriptionPaymentDetailsPascal? PaymentDetails { get; set; }

    /// <summary>
    /// Signature captured on a card-present device. Always `null` for payout subscriptions.
    /// </summary>
    [JsonPropertyName("payorSignature")]
    public PayoutSubscriptionPaymentDataPascalPayorSignature? PayorSignature { get; set; }

    [JsonPropertyName("Sequence")]
    public string? Sequence { get; set; }

    [JsonPropertyName("SignatureData")]
    public string? SignatureData { get; set; }

    /// <summary>
    /// Digital wallet type if applicable.
    /// </summary>
    [JsonPropertyName("WalletType")]
    public string? WalletType { get; set; }

    /// <summary>
    /// Identifier of stored payment method used in transaction.
    /// </summary>
    [JsonPropertyName("StoredId")]
    public string? StoredId { get; set; }

    [JsonPropertyName("StoredMethodUsageType")]
    public string? StoredMethodUsageType { get; set; }

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
