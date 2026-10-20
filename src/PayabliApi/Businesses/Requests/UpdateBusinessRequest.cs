using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record UpdateBusinessRequest
{
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
    /// The business's legal structure. Accepts the same values as create, and normalizes to a canonical value on read.
    /// </summary>
    [JsonPropertyName("legalStructure")]
    public UpdateBusinessRequestLegalStructure? LegalStructure { get; set; }

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
    public IEnumerable<UpdateBusinessRequestOperatingSeasonsItem>? OperatingSeasons { get; set; }

    /// <summary>
    /// A non-empty `addressDetails` is rejected on update. Manage a business's
    /// addresses through the `/v2/businesses/{businessReference}/addresses`
    /// endpoints instead. An omitted field or an empty array is accepted as
    /// "no address change requested."
    /// </summary>
    [JsonPropertyName("addressDetails")]
    public IEnumerable<BusinessAddress>? AddressDetails { get; set; }

    /// <summary>
    /// The bank accounts and cards attached to the business.
    /// </summary>
    [JsonPropertyName("paymentMethods")]
    public IEnumerable<BusinessPaymentMethod>? PaymentMethods { get; set; }

    /// <summary>
    /// Key-value data to merge into the business's stored `customData`.
    /// Payabli stores the applicant's answers to a boarding template's
    /// custom questions under the `templateAnswers` key.
    ///
    /// When you update a business, Payabli merges `customData` into the
    /// stored value, following JSON Merge Patch (RFC 7396). Keys you
    /// don't send are kept at every depth, and nested objects merge key
    /// by key. Strings, numbers, Boolean values, and arrays replace the
    /// stored value, and arrays aren't merged. Send a key as `null` to
    /// delete it, such as `{"crmId": null}`. A `customData` that isn't
    /// an object, such as an array, replaces the stored value whole.
    /// Leave out `customData` to keep it as is.
    ///
    /// The `customData` you send can be up to 65,536 bytes serialized.
    /// The limit applies to the request, not to the merged result.
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

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
