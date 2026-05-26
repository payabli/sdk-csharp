using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record MethodQueryRecords : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The stored payment method's identifier in Payabli.
    /// </summary>
    [JsonPropertyName("IdPmethod")]
    public string? IdPmethod { get; set; }

    /// <summary>
    /// Type of payment vehicle: `ach` or `card`
    /// </summary>
    [JsonPropertyName("Method")]
    public string? Method { get; set; }

    [JsonPropertyName("Descriptor")]
    public string? Descriptor { get; set; }

    [JsonPropertyName("MaskedAccount")]
    public string? MaskedAccount { get; set; }

    /// <summary>
    /// Expiration date for the card in format MMYY. Null for ACH methods.
    /// </summary>
    [JsonPropertyName("ExpDate")]
    public string? ExpDate { get; set; }

    [JsonPropertyName("HolderName")]
    public string? HolderName { get; set; }

    /// <summary>
    /// ACH Standard Entry Class code (for example, `WEB`, `PPD`, `CCD`). Null for non-ACH methods.
    /// </summary>
    [JsonPropertyName("AchSecCode")]
    public string? AchSecCode { get; set; }

    /// <summary>
    /// Classification of the ACH account holder. Possible values include `personal`, `business`. Null for non-ACH methods.
    /// </summary>
    [JsonPropertyName("AchHolderType")]
    public string? AchHolderType { get; set; }

    /// <summary>
    /// Whether the ACH account has been validated. Null for non-ACH methods.
    /// </summary>
    [JsonPropertyName("IsValidatedACH")]
    public bool? IsValidatedAch { get; set; }

    /// <summary>
    /// The bank identification number (BIN). Null for ACH methods.
    /// </summary>
    [JsonPropertyName("BIN")]
    public string? Bin { get; set; }

    [JsonPropertyName("binData")]
    public BinData? BinData { get; set; }

    /// <summary>
    /// Bank routing number for ACH payment methods. Null for non-ACH methods.
    /// </summary>
    [JsonPropertyName("ABA")]
    public string? Aba { get; set; }

    /// <summary>
    /// Billing postal code associated with the stored payment method, when available.
    /// </summary>
    [JsonPropertyName("PostalCode")]
    public string? PostalCode { get; set; }

    /// <summary>
    /// Token type for the stored method (for example, `Single Merchant` or `Multiple Universal`).
    /// </summary>
    [JsonPropertyName("MethodType")]
    public string? MethodType { get; set; }

    /// <summary>
    /// Digital wallet source for the stored payment method. Possible values include `apple_pay`, `google_pay`. Null for non-wallet methods.
    /// </summary>
    [JsonPropertyName("WalletType")]
    public string? WalletType { get; set; }

    /// <summary>
    /// Date and time of last update.
    /// </summary>
    [JsonPropertyName("LastUpdated")]
    public DateTime? LastUpdated { get; set; }

    /// <summary>
    /// Date and time the card was last updated.
    /// </summary>
    [JsonPropertyName("CardUpdatedOn")]
    public DateTime? CardUpdatedOn { get; set; }

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
