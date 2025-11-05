using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Payment method and transaction details
/// </summary>
[Serializable]
public record TransactionDetailPaymentData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("maskedAccount")]
    public required string MaskedAccount { get; set; }

    [JsonPropertyName("accountType")]
    public required string AccountType { get; set; }

    [JsonPropertyName("accountExp")]
    public string? AccountExp { get; set; }

    [JsonPropertyName("holderName")]
    public required string HolderName { get; set; }

    [JsonPropertyName("storedId")]
    public string? StoredId { get; set; }

    [JsonPropertyName("initiator")]
    public string? Initiator { get; set; }

    [JsonPropertyName("storedMethodUsageType")]
    public string? StoredMethodUsageType { get; set; }

    [JsonPropertyName("sequence")]
    public string? Sequence { get; set; }

    [JsonPropertyName("orderDescription")]
    public required string OrderDescription { get; set; }

    [JsonPropertyName("accountId")]
    public string? AccountId { get; set; }

    [JsonPropertyName("signatureData")]
    public string? SignatureData { get; set; }

    [JsonPropertyName("binData")]
    public BinData? BinData { get; set; }

    [JsonPropertyName("paymentDetails")]
    public required TransactionDetailPaymentDetails PaymentDetails { get; set; }

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
