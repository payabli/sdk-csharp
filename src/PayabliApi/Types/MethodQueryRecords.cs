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
    /// Method internal ID
    /// </summary>
    [JsonPropertyName("IdPmethod")]
    public string? IdPmethod { get; set; }

    /// <summary>
    /// Type of payment vehicle: **ach** or **card**
    /// </summary>
    [JsonPropertyName("Method")]
    public string? Method { get; set; }

    [JsonPropertyName("Descriptor")]
    public string? Descriptor { get; set; }

    [JsonPropertyName("MaskedAccount")]
    public string? MaskedAccount { get; set; }

    /// <summary>
    /// Expiration date associated to the method (only for card) in format MMYY.
    /// </summary>
    [JsonPropertyName("ExpDate")]
    public string? ExpDate { get; set; }

    [JsonPropertyName("HolderName")]
    public string? HolderName { get; set; }

    /// <summary>
    /// Standard Entry Class (SEC) code for the ACH transaction.
    /// </summary>
    [JsonPropertyName("AchSecCode")]
    public string? AchSecCode { get; set; }

    /// <summary>
    /// Bank accountholder type: `personal` or `business`.
    /// </summary>
    [JsonPropertyName("AchHolderType")]
    public string? AchHolderType { get; set; }

    /// <summary>
    /// Whether the ACH account has been validated.
    /// </summary>
    [JsonPropertyName("IsValidatedACH")]
    public bool? IsValidatedAch { get; set; }

    /// <summary>
    /// The bank identification number (BIN). Null when method is ACH.
    /// </summary>
    [JsonPropertyName("BIN")]
    public string? Bin { get; set; }

    [JsonPropertyName("binData")]
    public BinData? BinData { get; set; }

    /// <summary>
    /// Bank routing number.
    /// </summary>
    [JsonPropertyName("ABA")]
    public string? Aba { get; set; }

    /// <summary>
    /// The payment method postal code.
    /// </summary>
    [JsonPropertyName("PostalCode")]
    public string? PostalCode { get; set; }

    /// <summary>
    /// The payment method's token type.
    /// </summary>
    [JsonPropertyName("MethodType")]
    public string? MethodType { get; set; }

    /// <summary>
    /// Digital wallet type if applicable.
    /// </summary>
    [JsonPropertyName("WalletType")]
    public string? WalletType { get; set; }

    /// <summary>
    /// Date of last update
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
