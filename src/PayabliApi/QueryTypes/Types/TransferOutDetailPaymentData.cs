using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Payment data for an outbound transfer detail.
/// </summary>
[Serializable]
public record TransferOutDetailPaymentData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Masked account number.
    /// </summary>
    [JsonPropertyName("MaskedAccount")]
    public string? MaskedAccount { get; set; }

    /// <summary>
    /// Type of account.
    /// </summary>
    [JsonPropertyName("AccountType")]
    public string? AccountType { get; set; }

    /// <summary>
    /// Account expiration date.
    /// </summary>
    [JsonPropertyName("AccountExp")]
    public string? AccountExp { get; set; }

    /// <summary>
    /// ZIP code associated with the account.
    /// </summary>
    [JsonPropertyName("AccountZip")]
    public string? AccountZip { get; set; }

    /// <summary>
    /// Name of the account holder.
    /// </summary>
    [JsonPropertyName("HolderName")]
    public string? HolderName { get; set; }

    /// <summary>
    /// ID of the stored payment method.
    /// </summary>
    [JsonPropertyName("StoredId")]
    public string? StoredId { get; set; }

    /// <summary>
    /// Initiator of the payment.
    /// </summary>
    [JsonPropertyName("Initiator")]
    public string? Initiator { get; set; }

    /// <summary>
    /// Usage type for stored method.
    /// </summary>
    [JsonPropertyName("StoredMethodUsageType")]
    public string? StoredMethodUsageType { get; set; }

    /// <summary>
    /// Sequence number.
    /// </summary>
    [JsonPropertyName("Sequence")]
    public string? Sequence { get; set; }

    /// <summary>
    /// Description of the order.
    /// </summary>
    [JsonPropertyName("orderDescription")]
    public string? OrderDescription { get; set; }

    /// <summary>
    /// Cloud signature data.
    /// </summary>
    [JsonPropertyName("cloudSignatureData")]
    public string? CloudSignatureData { get; set; }

    /// <summary>
    /// Format of cloud signature.
    /// </summary>
    [JsonPropertyName("cloudSignatureFormat")]
    public string? CloudSignatureFormat { get; set; }

    /// <summary>
    /// Additional payment details.
    /// </summary>
    [JsonPropertyName("paymentDetails")]
    public object? PaymentDetails { get; set; }

    /// <summary>
    /// Data about the payor.
    /// </summary>
    [JsonPropertyName("payorData")]
    public string? PayorData { get; set; }

    /// <summary>
    /// Account ID.
    /// </summary>
    [JsonPropertyName("accountId")]
    public string? AccountId { get; set; }

    /// <summary>
    /// Bank account information.
    /// </summary>
    [JsonPropertyName("bankAccount")]
    public string? BankAccount { get; set; }

    /// <summary>
    /// Gateway connector used.
    /// </summary>
    [JsonPropertyName("gatewayConnector")]
    public string? GatewayConnector { get; set; }

    /// <summary>
    /// BIN data for the card.
    /// </summary>
    [JsonPropertyName("binData")]
    public object? BinData { get; set; }

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
