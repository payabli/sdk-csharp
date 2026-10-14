using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Payment method details for the payout subscription.
/// </summary>
[Serializable]
public record PayoutSubscriptionPaymentData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("accountExp")]
    public string? AccountExp { get; set; }

    [JsonPropertyName("accountId")]
    public string? AccountId { get; set; }

    [JsonPropertyName("accountType")]
    public string? AccountType { get; set; }

    [JsonPropertyName("accountZip")]
    public string? AccountZip { get; set; }

    /// <summary>
    /// Card information. Always `null` on this endpoint.
    /// </summary>
    [JsonPropertyName("binData")]
    public BinData? BinData { get; set; }

    [JsonPropertyName("holderName")]
    public string? HolderName { get; set; }

    /// <summary>
    /// The transaction's initiator. Always `null` on this endpoint.
    /// </summary>
    [JsonPropertyName("initiator")]
    public string? Initiator { get; set; }

    [JsonPropertyName("maskedAccount")]
    public string? MaskedAccount { get; set; }

    [JsonPropertyName("orderDescription")]
    public string? OrderDescription { get; set; }

    [JsonPropertyName("paymentDetails")]
    public PayoutSubscriptionPaymentDetails? PaymentDetails { get; set; }

    /// <summary>
    /// Signature captured on a card-present device. Always `null` for payout subscriptions.
    /// </summary>
    [JsonPropertyName("payorSignature")]
    public PayoutSubscriptionPaymentDataPayorSignature? PayorSignature { get; set; }

    /// <summary>
    /// The order of the transaction for cardholder-initiated and merchant-initiated transaction purposes. Always `null` on this endpoint.
    /// </summary>
    [JsonPropertyName("sequence")]
    public string? Sequence { get; set; }

    [JsonPropertyName("signatureData")]
    public string? SignatureData { get; set; }

    /// <summary>
    /// Digital wallet type if applicable. Always `null` on this endpoint.
    /// </summary>
    [JsonPropertyName("walletType")]
    public string? WalletType { get; set; }

    /// <summary>
    /// Identifier of stored payment method used in transaction.
    /// </summary>
    [JsonPropertyName("storedId")]
    public string? StoredId { get; set; }

    /// <summary>
    /// The usage type for the stored method. Always `null` on this endpoint.
    /// </summary>
    [JsonPropertyName("storedMethodUsageType")]
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
