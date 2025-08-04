using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record QueryPaymentData : IJsonOnDeserialized
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
    public PaymentDetail? PaymentDetails { get; set; }

    [JsonPropertyName("Sequence")]
    public string? Sequence { get; set; }

    [JsonPropertyName("SignatureData")]
    public string? SignatureData { get; set; }

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
