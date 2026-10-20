using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Request body to create a business.
/// </summary>
[Serializable]
public record CreateBusinessRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Your own identifier for the business.
    /// </summary>
    [JsonPropertyName("externalId")]
    public string? ExternalId { get; set; }

    /// <summary>
    /// The registered legal name of the business.
    /// </summary>
    [JsonPropertyName("legalName")]
    public required string LegalName { get; set; }

    /// <summary>
    /// A free-text description of the business.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// The business's legal structure. Case-insensitive, and several inputs normalize to the same canonical value on read (for example, `llc` and `limited-liability-company` both read back as `LimitedLiabilityCompany`).
    /// </summary>
    [JsonPropertyName("legalStructure")]
    public CreateBusinessRequestLegalStructure? LegalStructure { get; set; }

    /// <summary>
    /// The stock ticker symbol, if the business is publicly traded.
    /// </summary>
    [JsonPropertyName("stockSymbol")]
    public string? StockSymbol { get; set; }

    /// <summary>
    /// The state where the business is incorporated.
    /// </summary>
    [JsonPropertyName("incorporationState")]
    public string? IncorporationState { get; set; }

    /// <summary>
    /// The country that issued the business's tax identifier.
    /// </summary>
    [JsonPropertyName("taxIdCountry")]
    public string? TaxIdCountry { get; set; }

    /// <summary>
    /// The date the business was established.
    /// </summary>
    [JsonPropertyName("establishedDate")]
    public DateTime? EstablishedDate { get; set; }

    /// <summary>
    /// The number of employees.
    /// </summary>
    [JsonPropertyName("numberOfEmployees")]
    public int? NumberOfEmployees { get; set; }

    /// <summary>
    /// The business's annual revenue.
    /// </summary>
    [JsonPropertyName("annualRevenue")]
    public double? AnnualRevenue { get; set; }

    /// <summary>
    /// The business's website URL.
    /// </summary>
    [JsonPropertyName("website")]
    public string? Website { get; set; }

    /// <summary>
    /// The merchant category code (MCC) that classifies the business.
    /// </summary>
    [JsonPropertyName("merchantCatCode")]
    public string? MerchantCatCode { get; set; }

    /// <summary>
    /// The business's time zone.
    /// </summary>
    [JsonPropertyName("timezone")]
    public string? Timezone { get; set; }

    /// <summary>
    /// Phone numbers for the business.
    /// </summary>
    [JsonPropertyName("phone")]
    public IEnumerable<string>? Phone { get; set; }

    /// <summary>
    /// Email addresses for the business.
    /// </summary>
    [JsonPropertyName("emails")]
    public IEnumerable<string>? Emails { get; set; }

    /// <summary>
    /// The seasons the business operates in. Values are case-insensitive on input and returned capitalized.
    /// </summary>
    [JsonPropertyName("operatingSeasons")]
    public IEnumerable<CreateBusinessRequestOperatingSeasonsItem>? OperatingSeasons { get; set; }

    /// <summary>
    /// The business's addresses.
    /// </summary>
    [JsonPropertyName("addressDetails")]
    public IEnumerable<BusinessAddressCreate>? AddressDetails { get; set; }

    /// <summary>
    /// The bank accounts and cards attached to the business.
    /// </summary>
    [JsonPropertyName("paymentMethods")]
    public IEnumerable<BusinessPaymentMethod>? PaymentMethods { get; set; }

    /// <summary>
    /// Arbitrary key-value data you attach to the business. Payabli
    /// stores the applicant's answers to a boarding template's custom
    /// questions under the `templateAnswers` key.
    /// </summary>
    [JsonPropertyName("customData")]
    public Dictionary<string, object?>? CustomData { get; set; }

    /// <summary>
    /// Whether the business is foreign-owned.
    /// </summary>
    [JsonPropertyName("isForeignOwned")]
    public bool? IsForeignOwned { get; set; }

    /// <summary>
    /// Whether the business is tax-exempt.
    /// </summary>
    [JsonPropertyName("isTaxExempt")]
    public bool? IsTaxExempt { get; set; }

    /// <summary>
    /// The business's tax-exempt classification, such as `501(c)(3)`.
    /// </summary>
    [JsonPropertyName("taxExemptClassification")]
    public string? TaxExemptClassification { get; set; }

    [JsonPropertyName("processingMetrics")]
    public ProcessingMetrics? ProcessingMetrics { get; set; }

    [JsonPropertyName("payoutMetrics")]
    public PayoutMetrics? PayoutMetrics { get; set; }

    /// <summary>
    /// The business's license number.
    /// </summary>
    [JsonPropertyName("license")]
    public string? License { get; set; }

    /// <summary>
    /// The state that issued the business's license.
    /// </summary>
    [JsonPropertyName("licenseState")]
    public string? LicenseState { get; set; }

    /// <summary>
    /// The business tax identifier, for example an EIN.
    /// </summary>
    [JsonPropertyName("taxReference")]
    public string? TaxReference { get; set; }

    /// <summary>
    /// The organization entrypoint the business belongs to. Omit to use the organization your credential belongs to.
    /// </summary>
    [JsonPropertyName("parentReference")]
    public string? ParentReference { get; set; }

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
