using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record VCardGetResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Indicates if the virtual card was sent.
    /// </summary>
    [JsonPropertyName("vcardSent")]
    public bool? VcardSent { get; set; }

    /// <summary>
    /// A unique token identifier for the card.
    /// </summary>
    [JsonPropertyName("cardToken")]
    public string? CardToken { get; set; }

    /// <summary>
    /// The masked number of the card.
    /// </summary>
    [JsonPropertyName("cardNumber")]
    public string? CardNumber { get; set; }

    /// <summary>
    /// Masked Card Verification Code.
    /// </summary>
    [JsonPropertyName("cvc")]
    public string? Cvc { get; set; }

    /// <summary>
    /// The expiration date of the card.
    /// </summary>
    [JsonPropertyName("expirationDate")]
    public string? ExpirationDate { get; set; }

    /// <summary>
    /// The current status of the card.
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>
    /// The initial amount loaded on the card.
    /// </summary>
    [JsonPropertyName("amount")]
    public double? Amount { get; set; }

    /// <summary>
    /// The current balance available on the card.
    /// </summary>
    [JsonPropertyName("currentBalance")]
    public double? CurrentBalance { get; set; }

    /// <summary>
    /// The set limit for expenses.
    /// </summary>
    [JsonPropertyName("expenseLimit")]
    public double? ExpenseLimit { get; set; }

    /// <summary>
    /// The period for the expense limit.
    /// </summary>
    [JsonPropertyName("expenseLimitPeriod")]
    public string? ExpenseLimitPeriod { get; set; }

    /// <summary>
    /// Maximum number of uses allowed for the card.
    /// </summary>
    [JsonPropertyName("maxNumberOfUses")]
    public int? MaxNumberOfUses { get; set; }

    /// <summary>
    /// The current number of times the card has been used.
    /// </summary>
    [JsonPropertyName("currentNumberOfUses")]
    public int? CurrentNumberOfUses { get; set; }

    /// <summary>
    /// Indicates if only the exact amount is allowed for transactions.
    /// </summary>
    [JsonPropertyName("exactAmount")]
    public bool? ExactAmount { get; set; }

    /// <summary>
    /// Merchant Category Code, if applicable.
    /// </summary>
    [JsonPropertyName("mcc")]
    public string? Mcc { get; set; }

    /// <summary>
    /// Transaction Category Code, if applicable.
    /// </summary>
    [JsonPropertyName("tcc")]
    public string? Tcc { get; set; }

    /// <summary>
    /// A miscellaneous field for additional information.
    /// </summary>
    [JsonPropertyName("misc1")]
    public string? Misc1 { get; set; }

    /// <summary>
    /// Another miscellaneous field for extra information.
    /// </summary>
    [JsonPropertyName("misc2")]
    public string? Misc2 { get; set; }

    /// <summary>
    /// The creation date of the record.
    /// </summary>
    [JsonPropertyName("dateCreated")]
    public string? DateCreated { get; set; }

    /// <summary>
    /// The last modified date of the record.
    /// </summary>
    [JsonPropertyName("dateModified")]
    public string? DateModified { get; set; }

    /// <summary>
    /// Information about the associated vendor.
    /// </summary>
    [JsonPropertyName("associatedVendor")]
    public VCardGetResponseAssociatedVendor? AssociatedVendor { get; set; }

    /// <summary>
    /// Information about the associated customer, if applicable.
    /// </summary>
    [JsonPropertyName("associatedCustomer")]
    public string? AssociatedCustomer { get; set; }

    /// <summary>
    /// Name of the parent organization.
    /// </summary>
    [JsonPropertyName("ParentOrgName")]
    public string? ParentOrgName { get; set; }

    /// <summary>
    /// The 'Doing Business As' name of the Paypoint.
    /// </summary>
    [JsonPropertyName("PaypointDbaname")]
    public string? PaypointDbaname { get; set; }

    /// <summary>
    /// The legal name of the Paypoint.
    /// </summary>
    [JsonPropertyName("PaypointLegalname")]
    public string? PaypointLegalname { get; set; }

    /// <summary>
    /// Entry name for the Paypoint, if applicable.
    /// </summary>
    [JsonPropertyName("PaypointEntryname")]
    public string? PaypointEntryname { get; set; }

    [JsonPropertyName("externalPaypointID")]
    public string? ExternalPaypointId { get; set; }

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
