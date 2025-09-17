using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record VCardRecord : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// When `true`, the vCard has been sent.
    /// </summary>
    [JsonPropertyName("vcardSent")]
    public bool? VcardSent { get; set; }

    [JsonPropertyName("cardToken")]
    public string? CardToken { get; set; }

    /// <summary>
    /// The vCard number.
    /// </summary>
    [JsonPropertyName("cardNumber")]
    public string? CardNumber { get; set; }

    /// <summary>
    /// The vCard CVC number.
    /// </summary>
    [JsonPropertyName("cvc")]
    public string? Cvc { get; set; }

    /// <summary>
    /// Expiration date in format YYYY-MM-DD. The minimum time to expire is 3 months, maximum is 3 years. If not provided, the default is 6 months.
    /// </summary>
    [JsonPropertyName("expirationDate")]
    public string? ExpirationDate { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>
    /// The vCard amount.
    /// </summary>
    [JsonPropertyName("amount")]
    public double? Amount { get; set; }

    /// <summary>
    /// The vCard's current balance.
    /// </summary>
    [JsonPropertyName("currentBalance")]
    public double? CurrentBalance { get; set; }

    [JsonPropertyName("expenseLimit")]
    public double? ExpenseLimit { get; set; }

    [JsonPropertyName("expenseLimitPeriod")]
    public string? ExpenseLimitPeriod { get; set; }

    [JsonPropertyName("maxNumberOfUses")]
    public int? MaxNumberOfUses { get; set; }

    [JsonPropertyName("currentNumberOfUses")]
    public int? CurrentNumberOfUses { get; set; }

    [JsonPropertyName("exactAmount")]
    public bool? ExactAmount { get; set; }

    /// <summary>
    /// MCC assigned to vCard.
    /// </summary>
    [JsonPropertyName("mcc")]
    public string? Mcc { get; set; }

    /// <summary>
    /// TCC assigned to vCard.
    /// </summary>
    [JsonPropertyName("tcc")]
    public string? Tcc { get; set; }

    /// <summary>
    /// Custom field 1.
    /// </summary>
    [JsonPropertyName("misc1")]
    public string? Misc1 { get; set; }

    /// <summary>
    /// Custom field 2.
    /// </summary>
    [JsonPropertyName("misc2")]
    public string? Misc2 { get; set; }

    [JsonPropertyName("dateCreated")]
    public DateTime? DateCreated { get; set; }

    [JsonPropertyName("dateModified")]
    public DateTime? DateModified { get; set; }

    [JsonPropertyName("associatedVendor")]
    public AssociatedVendor? AssociatedVendor { get; set; }

    [JsonPropertyName("associatedCustomer")]
    public CustomerData? AssociatedCustomer { get; set; }

    [JsonPropertyName("ParentOrgName")]
    public string? ParentOrgName { get; set; }

    /// <summary>
    /// The paypoint's DBA name.
    /// </summary>
    [JsonPropertyName("PaypointDbaname")]
    public string? PaypointDbaname { get; set; }

    /// <summary>
    /// The paypoint's legal name.
    /// </summary>
    [JsonPropertyName("PaypointLegalname")]
    public string? PaypointLegalname { get; set; }

    /// <summary>
    /// The paypoint's entry name (entrypoint).
    /// </summary>
    [JsonPropertyName("PaypointEntryname")]
    public string? PaypointEntryname { get; set; }

    [JsonPropertyName("externalPaypointID")]
    public string? ExternalPaypointId { get; set; }

    /// <summary>
    /// The paypoint's unique identifier.
    /// </summary>
    [JsonPropertyName("paypointId")]
    public int? PaypointId { get; set; }

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
