using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// The customer record that owns the stored payment method.
/// </summary>
[Serializable]
public record GetMethodResponseResponseDataCustomersItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// List of additional custom fields in format key:value.
    /// </summary>
    [JsonPropertyName("additionalFields")]
    public Dictionary<string, string>? AdditionalFields { get; set; }

    /// <summary>
    /// Customer address.
    /// </summary>
    [JsonPropertyName("address")]
    public string? Address { get; set; }

    /// <summary>
    /// Additional line for customer address.
    /// </summary>
    [JsonPropertyName("address1")]
    public string? Address1 { get; set; }

    /// <summary>
    /// Customer's current balance
    /// </summary>
    [JsonPropertyName("balance")]
    public float? Balance { get; set; }

    /// <summary>
    /// Customer city.
    /// </summary>
    [JsonPropertyName("city")]
    public string? City { get; set; }

    /// <summary>
    /// Company name.
    /// </summary>
    [JsonPropertyName("company")]
    public string? Company { get; set; }

    /// <summary>
    /// Customer country.
    /// </summary>
    [JsonPropertyName("country")]
    public string? Country { get; set; }

    /// <summary>
    /// Creation timestamp
    /// </summary>
    [JsonPropertyName("created")]
    public DateTime? Created { get; set; }

    /// <summary>
    /// Customer consent information
    /// </summary>
    [JsonPropertyName("customerConsent")]
    public Dictionary<string, object?>? CustomerConsent { get; set; }

    /// <summary>
    /// Events recorded for the customer.
    /// </summary>
    [JsonPropertyName("customerEvents")]
    public IEnumerable<object>? CustomerEvents { get; set; }

    [JsonPropertyName("customerId")]
    public long? CustomerId { get; set; }

    [JsonPropertyName("customerNumber")]
    public string? CustomerNumber { get; set; }

    [JsonPropertyName("customerPortal")]
    public string? CustomerPortal { get; set; }

    /// <summary>
    /// Status code for the customer
    /// </summary>
    [JsonPropertyName("customerStatus")]
    public int? CustomerStatus { get; set; }

    [JsonPropertyName("customerSummary")]
    public CustomerSummaryRecord? CustomerSummary { get; set; }

    /// <summary>
    /// Username of the customer
    /// </summary>
    [JsonPropertyName("customerUsername")]
    public string? CustomerUsername { get; set; }

    /// <summary>
    /// Customer email address.
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("externalPaypointID")]
    public string? ExternalPaypointId { get; set; }

    /// <summary>
    /// Customer first name.
    /// </summary>
    [JsonPropertyName("firstname")]
    public string? Firstname { get; set; }

    [JsonPropertyName("identifierFields")]
    public IEnumerable<string>? IdentifierFields { get; set; }

    /// <summary>
    /// Customer last name.
    /// </summary>
    [JsonPropertyName("lastname")]
    public string? Lastname { get; set; }

    /// <summary>
    /// Last update timestamp
    /// </summary>
    [JsonPropertyName("lastUpdated")]
    public DateTime? LastUpdated { get; set; }

    /// <summary>
    /// Multi-factor authentication status
    /// </summary>
    [JsonPropertyName("mfa")]
    public bool? Mfa { get; set; }

    /// <summary>
    /// MFA mode setting
    /// </summary>
    [JsonPropertyName("mfaMode")]
    public int? MfaMode { get; set; }

    [JsonPropertyName("pageindentifier")]
    public string? Pageindentifier { get; set; }

    /// <summary>
    /// Parent organization ID
    /// </summary>
    [JsonPropertyName("parentOrgId")]
    public int? ParentOrgId { get; set; }

    [JsonPropertyName("parentOrgName")]
    public string? ParentOrgName { get; set; }

    [JsonPropertyName("paypointDbaname")]
    public string? PaypointDbaname { get; set; }

    /// <summary>
    /// The paypoint entryname the customer is associated with
    /// </summary>
    [JsonPropertyName("paypointEntryname")]
    public string? PaypointEntryname { get; set; }

    [JsonPropertyName("paypointLegalname")]
    public string? PaypointLegalname { get; set; }

    /// <summary>
    /// Customer phone number.
    /// </summary>
    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    [JsonPropertyName("shippingAddress")]
    public string? ShippingAddress { get; set; }

    [JsonPropertyName("shippingAddress1")]
    public string? ShippingAddress1 { get; set; }

    [JsonPropertyName("shippingCity")]
    public string? ShippingCity { get; set; }

    [JsonPropertyName("shippingCountry")]
    public string? ShippingCountry { get; set; }

    [JsonPropertyName("shippingState")]
    public string? ShippingState { get; set; }

    [JsonPropertyName("shippingZip")]
    public string? ShippingZip { get; set; }

    /// <summary>
    /// Social network data
    /// </summary>
    [JsonPropertyName("snData")]
    public Dictionary<string, object?>? SnData { get; set; }

    /// <summary>
    /// Social network identifier
    /// </summary>
    [JsonPropertyName("snIdentifier")]
    public string? SnIdentifier { get; set; }

    /// <summary>
    /// Social network provider
    /// </summary>
    [JsonPropertyName("snProvider")]
    public string? SnProvider { get; set; }

    /// <summary>
    /// Customer state.
    /// </summary>
    [JsonPropertyName("state")]
    public string? State { get; set; }

    /// <summary>
    /// List of payment methods associated to the customer
    /// </summary>
    [JsonPropertyName("storedMethods")]
    public IEnumerable<MethodQueryRecords>? StoredMethods { get; set; }

    /// <summary>
    /// List of subscriptions associated to the customer
    /// </summary>
    [JsonPropertyName("subscriptions")]
    public IEnumerable<SubscriptionQueryRecords>? Subscriptions { get; set; }

    /// <summary>
    /// Customer's timezone
    /// </summary>
    [JsonPropertyName("timeZone")]
    public int? TimeZone { get; set; }

    /// <summary>
    /// Customer postal code.
    /// </summary>
    [JsonPropertyName("zip")]
    public string? Zip { get; set; }

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
