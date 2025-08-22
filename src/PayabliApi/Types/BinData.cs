using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Object containing information related to the card. This object is `null`
/// unless the payment method is card. If the payment method is Apple Pay, the
/// binData will be related to the DPAN (device primary account number), not
/// the card connected to Apple Pay.
/// </summary>
[Serializable]
public record BinData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The number of characters from the beginning of the card number that
    /// were matched against a Bank Identification Number (BIN) or the Card
    /// Range table.
    /// </summary>
    [JsonPropertyName("binMatchedLength")]
    public string? BinMatchedLength { get; set; }

    /// <summary>
    /// The card brand. For example, Visa, Mastercard, American Express,
    /// Discover.
    /// </summary>
    [JsonPropertyName("binCardBrand")]
    public string? BinCardBrand { get; set; }

    /// <summary>
    /// The type of card: Credit or Debit.
    /// </summary>
    [JsonPropertyName("binCardType")]
    public string? BinCardType { get; set; }

    /// <summary>
    /// The category of the card, which indicates the card product. For example: Standard, Gold, Platinum, etc. The binCardCategory for prepaid cards is marked `PREPAID`.
    /// </summary>
    [JsonPropertyName("binCardCategory")]
    public string? BinCardCategory { get; set; }

    /// <summary>
    /// The name of the financial institution that issued the card.
    /// </summary>
    [JsonPropertyName("binCardIssuer")]
    public string? BinCardIssuer { get; set; }

    /// <summary>
    /// The issuing financial institution's country name.
    /// </summary>
    [JsonPropertyName("binCardIssuerCountry")]
    public string? BinCardIssuerCountry { get; set; }

    /// <summary>
    /// The issuing financial institution's two-character ISO country code. See [this resource](https://www.iso.org/obp/ui/#search) for a list of codes.
    /// </summary>
    [JsonPropertyName("binCardIssuerCountryCodeA2")]
    public string? BinCardIssuerCountryCodeA2 { get; set; }

    /// <summary>
    /// The issuing financial institution's ISO standard numeric country code. See [this resource](https://www.iso.org/obp/ui/#search) for a list of codes.
    /// </summary>
    [JsonPropertyName("binCardIssuerCountryNumber")]
    public string? BinCardIssuerCountryNumber { get; set; }

    /// <summary>
    /// Indicates whether the card is regulated.
    /// </summary>
    [JsonPropertyName("binCardIsRegulated")]
    public string? BinCardIsRegulated { get; set; }

    /// <summary>
    /// The use category classification for the card.
    /// </summary>
    [JsonPropertyName("binCardUseCategory")]
    public string? BinCardUseCategory { get; set; }

    /// <summary>
    /// The issuing financial institution's three-character ISO country code.
    /// See [this resource](https://www.iso.org/obp/ui/#search) for a list of
    /// codes.
    /// </summary>
    [JsonPropertyName("binCardIssuerCountryCodeA3")]
    public string? BinCardIssuerCountryCodeA3 { get; set; }

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
