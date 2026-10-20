using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// The full detail of a business. Sensitive fields are masked unless read from the unmasked endpoint.
/// </summary>
[Serializable]
public record BusinessDetailResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The business reference.
    /// </summary>
    [JsonPropertyName("businessUuid")]
    public required string BusinessUuid { get; set; }

    /// <summary>
    /// Your own identifier for the business.
    /// </summary>
    [JsonPropertyName("externalId")]
    public string? ExternalId { get; set; }

    /// <summary>
    /// The registered legal name of the business.
    /// </summary>
    [JsonPropertyName("legalName")]
    public string? LegalName { get; set; }

    /// <summary>
    /// A free-text description of the business.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// The business's legal structure, normalized to a canonical value on read.
    /// </summary>
    [JsonPropertyName("legalStructure")]
    public BusinessDetailResponseLegalStructure? LegalStructure { get; set; }

    /// <summary>
    /// The stock ticker symbol, if publicly traded.
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
    /// The merchant category code (MCC).
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
    public IEnumerable<BusinessDetailResponseOperatingSeasonsItem>? OperatingSeasons { get; set; }

    /// <summary>
    /// The business's addresses.
    /// </summary>
    [JsonPropertyName("addressDetails")]
    public IEnumerable<BusinessAddress>? AddressDetails { get; set; }

    /// <summary>
    /// The bank accounts and cards attached to the business.
    /// </summary>
    [JsonPropertyName("paymentMethods")]
    public IEnumerable<BusinessPaymentMethod>? PaymentMethods { get; set; }

    /// <summary>
    /// Arbitrary key-value data attached to the business. When present,
    /// `templateAnswers` holds the applicant's answers to a boarding
    /// template's business-level custom questions, meaning questions
    /// whose field path doesn't start with `person.`. It's an object
    /// keyed by each question's field path, such as
    /// `business.custom_referralSource`, and each answer is a string. A
    /// multi-select answer is one comma-separated string, such as
    /// `quickbooks,stripe`.
    ///
    /// Payabli saves the answers when an application is submitted
    /// through the hosted boarding application. Submitting an
    /// application with the API
    /// (`POST /v2/requests/{requestsReference}/submit`) doesn't save them.
    /// Only answers to custom questions are saved, and blank answers,
    /// standard-field answers, and document uploads aren't. A later
    /// hosted submit replaces the answer to the same question and keeps
    /// every other answer, including answers from other applications.
    /// Leaving a question blank on a later submit doesn't remove the
    /// stored answer.
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

    /// <summary>
    /// Expected Pay In processing profile.
    /// </summary>
    [JsonPropertyName("processingMetrics")]
    public ProcessingMetrics? ProcessingMetrics { get; set; }

    /// <summary>
    /// Expected Pay Out profile.
    /// </summary>
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
    /// The business tax identifier. Masked on standard reads (only the last four digits are shown, for example `****8993`); read the unmasked endpoint for the raw value.
    /// </summary>
    [JsonPropertyName("taxReference")]
    public string? TaxReference { get; set; }

    /// <summary>
    /// The business's current status.
    /// </summary>
    [JsonPropertyName("businessStatus")]
    public required string BusinessStatus { get; set; }

    /// <summary>
    /// The organization entrypoint the business belongs to.
    /// </summary>
    [JsonPropertyName("parentReference")]
    public string? ParentReference { get; set; }

    /// <summary>
    /// Certifications held by the business.
    /// </summary>
    [JsonPropertyName("certificationDetails")]
    public IEnumerable<CertificationDetail>? CertificationDetails { get; set; }

    /// <summary>
    /// When the business was created.
    /// </summary>
    [JsonPropertyName("createdAt")]
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// When the business was last updated.
    /// </summary>
    [JsonPropertyName("lastUpdated")]
    public required DateTime LastUpdated { get; set; }

    /// <summary>
    /// Hypermedia links for the business resource.
    /// </summary>
    [JsonPropertyName("_links")]
    public required BusinessLinks Links { get; set; }

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
