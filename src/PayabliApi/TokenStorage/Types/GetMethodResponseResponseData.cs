using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record GetMethodResponseResponseData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Bank routing number
    /// </summary>
    [JsonPropertyName("aba")]
    public string? Aba { get; set; }

    [JsonPropertyName("achHolderType")]
    public AchHolderType? AchHolderType { get; set; }

    [JsonPropertyName("achSecCode")]
    public string? AchSecCode { get; set; }

    /// <summary>
    /// The bank identification number (BIN)
    /// </summary>
    [JsonPropertyName("bin")]
    public string? Bin { get; set; }

    [JsonPropertyName("binData")]
    public BinData? BinData { get; set; }

    [JsonPropertyName("customers")]
    public IEnumerable<GetMethodResponseResponseDataCustomersItem>? Customers { get; set; }

    [JsonPropertyName("descriptor")]
    public string? Descriptor { get; set; }

    /// <summary>
    /// Expiration date for card in stored method in format MM/YY
    /// </summary>
    [JsonPropertyName("expDate")]
    public string? ExpDate { get; set; }

    /// <summary>
    /// Account holder name in stored method
    /// </summary>
    [JsonPropertyName("holderName")]
    public string? HolderName { get; set; }

    /// <summary>
    /// The stored payment method's identifier in Payabli
    /// </summary>
    [JsonPropertyName("idPmethod")]
    public string? IdPmethod { get; set; }

    /// <summary>
    /// Timestamp for last update of stored method, in UTC
    /// </summary>
    [JsonPropertyName("lastUpdated")]
    public DateTime? LastUpdated { get; set; }

    [JsonPropertyName("maskedAccount")]
    public string? MaskedAccount { get; set; }

    /// <summary>
    /// The saved method's type: `card` or `ach`.
    /// </summary>
    [JsonPropertyName("method")]
    public string? Method { get; set; }

    /// <summary>
    /// The payment method's token type
    /// </summary>
    [JsonPropertyName("methodType")]
    public string? MethodType { get; set; }

    /// <summary>
    /// The payment method postal code
    /// </summary>
    [JsonPropertyName("postalCode")]
    public string? PostalCode { get; set; }

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
