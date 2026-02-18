using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record GetMethodResponseResponseDataCustomersItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Customer's current balance
    /// </summary>
    [JsonPropertyName("balance")]
    public float? Balance { get; set; }

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

    [JsonPropertyName("externalPaypointID")]
    public string? ExternalPaypointId { get; set; }

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

    [JsonPropertyName("additionalData")]
    public Dictionary<string, Dictionary<string, object?>>? AdditionalData { get; set; }

    [JsonPropertyName("billingAddress1")]
    public string? BillingAddress1 { get; set; }

    [JsonPropertyName("billingAddress2")]
    public string? BillingAddress2 { get; set; }

    [JsonPropertyName("billingCity")]
    public string? BillingCity { get; set; }

    [JsonPropertyName("billingCountry")]
    public string? BillingCountry { get; set; }

    [JsonPropertyName("billingEmail")]
    public string? BillingEmail { get; set; }

    [JsonPropertyName("billingPhone")]
    public string? BillingPhone { get; set; }

    [JsonPropertyName("billingState")]
    public string? BillingState { get; set; }

    /// <summary>
    /// Customer's billing ZIP code. For Pay In functions, this field supports 5-digit and 9-digit ZIP codes and alphanumeric Canadian postal codes. For example: "37615-1234" or "37615".
    /// </summary>
    [JsonPropertyName("billingZip")]
    public string? BillingZip { get; set; }

    /// <summary>
    /// Customer's company name.
    /// </summary>
    [JsonPropertyName("company")]
    public string? Company { get; set; }

    [JsonPropertyName("customerId")]
    public long? CustomerId { get; set; }

    [JsonPropertyName("customerNumber")]
    public string? CustomerNumber { get; set; }

    /// <summary>
    /// Customer/Payor first name.
    /// </summary>
    [JsonPropertyName("firstName")]
    public string? FirstName { get; set; }

    [JsonPropertyName("identifierFields")]
    public IEnumerable<string>? IdentifierFields { get; set; }

    /// <summary>
    /// Customer/Payor last name.
    /// </summary>
    [JsonPropertyName("lastName")]
    public string? LastName { get; set; }

    [JsonPropertyName("shippingAddress1")]
    public string? ShippingAddress1 { get; set; }

    [JsonPropertyName("shippingAddress2")]
    public string? ShippingAddress2 { get; set; }

    [JsonPropertyName("shippingCity")]
    public string? ShippingCity { get; set; }

    [JsonPropertyName("shippingCountry")]
    public string? ShippingCountry { get; set; }

    [JsonPropertyName("shippingState")]
    public string? ShippingState { get; set; }

    [JsonPropertyName("shippingZip")]
    public string? ShippingZip { get; set; }

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
