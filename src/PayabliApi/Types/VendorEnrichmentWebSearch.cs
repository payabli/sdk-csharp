using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Vendor contact information and payment acceptance info found through web search.
/// </summary>
[Serializable]
public record VendorEnrichmentWebSearch : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Phone number found through web search. Format isn't guaranteed.
    /// </summary>
    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    /// <summary>
    /// Phone classification. Values are `main`, `billing`, or `customer_service`.
    /// </summary>
    [JsonPropertyName("phoneType")]
    public string? PhoneType { get; set; }

    /// <summary>
    /// Email address.
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>
    /// Email classification. Values are `billing`, `general`, or `customer_service`.
    /// </summary>
    [JsonPropertyName("emailType")]
    public string? EmailType { get; set; }

    /// <summary>
    /// Street address.
    /// </summary>
    [JsonPropertyName("street")]
    public string? Street { get; set; }

    /// <summary>
    /// City.
    /// </summary>
    [JsonPropertyName("city")]
    public string? City { get; set; }

    /// <summary>
    /// State (two-letter abbreviation).
    /// </summary>
    [JsonPropertyName("state")]
    public string? State { get; set; }

    /// <summary>
    /// ZIP code.
    /// </summary>
    [JsonPropertyName("zipCode")]
    public string? ZipCode { get; set; }

    /// <summary>
    /// Country code.
    /// </summary>
    [JsonPropertyName("country")]
    public string? Country { get; set; }

    /// <summary>
    /// Address classification. Values are `business`, `headquarters`, or `mailing`.
    /// </summary>
    [JsonPropertyName("addressType")]
    public string? AddressType { get; set; }

    /// <summary>
    /// Payment portal URL.
    /// </summary>
    [JsonPropertyName("paymentLink")]
    public string? PaymentLink { get; set; }

    /// <summary>
    /// Link classification. Values are `payment_portal`, `billing_page`, or `general_website`.
    /// </summary>
    [JsonPropertyName("paymentLinkType")]
    public string? PaymentLinkType { get; set; }

    /// <summary>
    /// Whether the vendor accepts card payments. Values are `yes`, `no`, or `unable to determine`.
    /// </summary>
    [JsonPropertyName("cardAccepted")]
    public string? CardAccepted { get; set; }

    /// <summary>
    /// Whether the vendor accepts ACH payments. Values are `yes`, `no`, or `unable to determine`.
    /// </summary>
    [JsonPropertyName("achAccepted")]
    public string? AchAccepted { get; set; }

    /// <summary>
    /// Whether the vendor accepts check payments. Values are `yes`, `no`, or `unable to determine`.
    /// </summary>
    [JsonPropertyName("checkAccepted")]
    public string? CheckAccepted { get; set; }

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
