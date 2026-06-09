using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// A virtual card transaction record returned by the query.
/// </summary>
[Serializable]
public record VCardTransactionRecord : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Unique identifier for the transaction.
    /// </summary>
    [JsonPropertyName("Identifier")]
    public string? Identifier { get; set; }

    /// <summary>
    /// Token of the virtual card associated with the transaction.
    /// </summary>
    [JsonPropertyName("CardToken")]
    public string? CardToken { get; set; }

    /// <summary>
    /// Last four digits of the masked virtual card number.
    /// </summary>
    [JsonPropertyName("LastFour")]
    public string? LastFour { get; set; }

    /// <summary>
    /// Expiration date of the virtual card used for the transaction.
    /// </summary>
    [JsonPropertyName("ExpirationDate")]
    public string? ExpirationDate { get; set; }

    [JsonPropertyName("Mcc")]
    public string? Mcc { get; set; }

    /// <summary>
    /// Identifier of the payout linked to this transaction.
    /// </summary>
    [JsonPropertyName("PayoutId")]
    public long? PayoutId { get; set; }

    /// <summary>
    /// Identifier of the customer linked to this transaction.
    /// </summary>
    [JsonPropertyName("CustomerId")]
    public long? CustomerId { get; set; }

    /// <summary>
    /// Identifier of the vendor linked to this transaction.
    /// </summary>
    [JsonPropertyName("VendorId")]
    public long? VendorId { get; set; }

    /// <summary>
    /// Custom field 1 from the virtual card.
    /// </summary>
    [JsonPropertyName("MiscData1")]
    public string? MiscData1 { get; set; }

    /// <summary>
    /// Custom field 2 from the virtual card.
    /// </summary>
    [JsonPropertyName("MiscData2")]
    public string? MiscData2 { get; set; }

    /// <summary>
    /// Number of times the virtual card has been used.
    /// </summary>
    [JsonPropertyName("CurrentUses")]
    public int? CurrentUses { get; set; }

    /// <summary>
    /// Authorized amount on the virtual card.
    /// </summary>
    [JsonPropertyName("Amount")]
    public double? Amount { get; set; }

    /// <summary>
    /// Current balance remaining on the virtual card.
    /// </summary>
    [JsonPropertyName("Balance")]
    public double? Balance { get; set; }

    /// <summary>
    /// Numeric identifier of the paypoint that issued the virtual card.
    /// </summary>
    [JsonPropertyName("PaypointId")]
    public long? PaypointId { get; set; }

    [JsonPropertyName("PaypointLegal")]
    public string? PaypointLegal { get; set; }

    [JsonPropertyName("PaypointDba")]
    public string? PaypointDba { get; set; }

    [JsonPropertyName("ExternalPaypointID")]
    public string? ExternalPaypointId { get; set; }

    [JsonPropertyName("OrgName")]
    public string? OrgName { get; set; }

    /// <summary>
    /// Transaction type, such as `AUTHORIZATION`.
    /// </summary>
    [JsonPropertyName("Type")]
    public string? Type { get; set; }

    /// <summary>
    /// Transaction status, such as `AUTHORIZATION`.
    /// </summary>
    [JsonPropertyName("Status")]
    public string? Status { get; set; }

    /// <summary>
    /// Date and time the transaction was created. Format: `YYYY-MM-DD HH:MM:SS.ffffff`.
    /// </summary>
    [JsonPropertyName("CreatedOn")]
    public string? CreatedOn { get; set; }

    /// <summary>
    /// Amount of the transaction, as a string value.
    /// </summary>
    [JsonPropertyName("TransactionAmount")]
    public string? TransactionAmount { get; set; }

    /// <summary>
    /// Posted amount of the transaction, as a string value.
    /// </summary>
    [JsonPropertyName("PostedAmount")]
    public string? PostedAmount { get; set; }

    /// <summary>
    /// Date and time the transaction was posted, in format `YYYY-MM-DD HH:MM:SS.ffffff`. Null when the transaction hasn't posted yet.
    /// </summary>
    [JsonPropertyName("PostedOn")]
    public string? PostedOn { get; set; }

    /// <summary>
    /// Name of the merchant where the virtual card was used.
    /// </summary>
    [JsonPropertyName("MerchantName")]
    public string? MerchantName { get; set; }

    /// <summary>
    /// Authorization status of the transaction.
    /// </summary>
    [JsonPropertyName("AuthorizationStatus")]
    public string? AuthorizationStatus { get; set; }

    /// <summary>
    /// Reason the transaction was declined, when applicable.
    /// </summary>
    [JsonPropertyName("ReasonToDecline")]
    public string? ReasonToDecline { get; set; }

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
