using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record QueryPayoutTransactionRecordsItemPaymentData : IJsonOnDeserialized
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

    [JsonPropertyName("bankAccount")]
    public string? BankAccount { get; set; }

    [JsonPropertyName("cloudSignatureData")]
    public string? CloudSignatureData { get; set; }

    [JsonPropertyName("cloudSignatureFormat")]
    public string? CloudSignatureFormat { get; set; }

    /// <summary>
    /// Card or bank account holder name.
    /// </summary>
    [JsonPropertyName("HolderName")]
    public string? HolderName { get; set; }

    [JsonPropertyName("MaskedAccount")]
    public string? MaskedAccount { get; set; }

    [JsonPropertyName("orderDescription")]
    public string? OrderDescription { get; set; }

    [JsonPropertyName("paymentDetails")]
    public PaymentDetail? PaymentDetails { get; set; }

    [JsonPropertyName("payorData")]
    public string? PayorData { get; set; }

    /// <summary>
    /// Identifier of stored payment method used in transaction.
    /// </summary>
    [JsonPropertyName("StoredId")]
    public string? StoredId { get; set; }

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
