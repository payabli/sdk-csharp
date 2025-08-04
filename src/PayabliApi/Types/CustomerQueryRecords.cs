using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record CustomerQueryRecords : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("customerId")]
    public long? CustomerId { get; set; }

    [JsonPropertyName("customerNumber")]
    public string? CustomerNumber { get; set; }

    /// <summary>
    /// Username for customer.
    /// </summary>
    [JsonPropertyName("customerUsername")]
    public string? CustomerUsername { get; set; }

    [JsonPropertyName("customerStatus")]
    public int? CustomerStatus { get; set; }

    /// <summary>
    /// Company name.
    /// </summary>
    [JsonPropertyName("Company")]
    public string? Company { get; set; }

    /// <summary>
    /// Customer first name.
    /// </summary>
    [JsonPropertyName("Firstname")]
    public string? Firstname { get; set; }

    /// <summary>
    /// Customer last name.
    /// </summary>
    [JsonPropertyName("Lastname")]
    public string? Lastname { get; set; }

    /// <summary>
    /// Customer phone number.
    /// </summary>
    [JsonPropertyName("Phone")]
    public string? Phone { get; set; }

    /// <summary>
    /// Customer email address.
    /// </summary>
    [JsonPropertyName("Email")]
    public string? Email { get; set; }

    /// <summary>
    /// Customer address.
    /// </summary>
    [JsonPropertyName("Address")]
    public string? Address { get; set; }

    /// <summary>
    /// Additional line for customer address.
    /// </summary>
    [JsonPropertyName("Address1")]
    public string? Address1 { get; set; }

    /// <summary>
    /// Customer city.
    /// </summary>
    [JsonPropertyName("City")]
    public string? City { get; set; }

    /// <summary>
    /// Customer state.
    /// </summary>
    [JsonPropertyName("State")]
    public string? State { get; set; }

    /// <summary>
    /// Customer postal code.
    /// </summary>
    [JsonPropertyName("Zip")]
    public string? Zip { get; set; }

    /// <summary>
    /// Customer country.
    /// </summary>
    [JsonPropertyName("Country")]
    public string? Country { get; set; }

    [JsonPropertyName("ShippingAddress")]
    public string? ShippingAddress { get; set; }

    [JsonPropertyName("ShippingAddress1")]
    public string? ShippingAddress1 { get; set; }

    [JsonPropertyName("ShippingCity")]
    public string? ShippingCity { get; set; }

    [JsonPropertyName("ShippingState")]
    public string? ShippingState { get; set; }

    [JsonPropertyName("ShippingZip")]
    public string? ShippingZip { get; set; }

    [JsonPropertyName("ShippingCountry")]
    public string? ShippingCountry { get; set; }

    /// <summary>
    /// Customer balance.
    /// </summary>
    [JsonPropertyName("Balance")]
    public double? Balance { get; set; }

    [JsonPropertyName("TimeZone")]
    public int? TimeZone { get; set; }

    [JsonPropertyName("MFA")]
    public bool? Mfa { get; set; }

    [JsonPropertyName("MFAMode")]
    public int? MfaMode { get; set; }

    /// <summary>
    /// Social network linked to customer. Possible values:
    ///
    /// - `facebook`
    ///
    /// - `google`
    ///
    /// - `twitter`
    ///
    /// - `microsoft`
    /// </summary>
    [JsonPropertyName("snProvider")]
    public string? SnProvider { get; set; }

    /// <summary>
    /// Identifier or token for customer in linked social network.
    /// </summary>
    [JsonPropertyName("snIdentifier")]
    public string? SnIdentifier { get; set; }

    /// <summary>
    /// Additional data provided by the social network related to the customer.
    /// </summary>
    [JsonPropertyName("snData")]
    public string? SnData { get; set; }

    /// <summary>
    /// Date and time of last update.
    /// </summary>
    [JsonPropertyName("LastUpdated")]
    public DateTime? LastUpdated { get; set; }

    /// <summary>
    /// Date and time created.
    /// </summary>
    [JsonPropertyName("Created")]
    public DateTime? Created { get; set; }

    /// <summary>
    /// List of additional custom fields in format key:value.
    /// </summary>
    [JsonPropertyName("AdditionalFields")]
    public Dictionary<string, string?>? AdditionalFields { get; set; }

    [JsonPropertyName("IdentifierFields")]
    public IEnumerable<string>? IdentifierFields { get; set; }

    /// <summary>
    /// List of subscriptions associated to the customer.
    /// </summary>
    [JsonPropertyName("Subscriptions")]
    public IEnumerable<SubscriptionQueryRecords>? Subscriptions { get; set; }

    /// <summary>
    /// List of payment methods associated to the customer.
    /// </summary>
    [JsonPropertyName("StoredMethods")]
    public IEnumerable<MethodQueryRecords>? StoredMethods { get; set; }

    [JsonPropertyName("customerSummary")]
    public CustomerSummaryRecord? CustomerSummary { get; set; }

    /// <summary>
    /// Paypoint legal name.
    /// </summary>
    [JsonPropertyName("PaypointLegalname")]
    public string? PaypointLegalname { get; set; }

    /// <summary>
    /// Paypoint DBA name.
    /// </summary>
    [JsonPropertyName("PaypointDbaname")]
    public string? PaypointDbaname { get; set; }

    [JsonPropertyName("ParentOrgName")]
    public string? ParentOrgName { get; set; }

    [JsonPropertyName("ParentOrgId")]
    public long? ParentOrgId { get; set; }

    [JsonPropertyName("PaypointEntryname")]
    public string? PaypointEntryname { get; set; }

    [JsonPropertyName("pageidentifier")]
    public string? Pageidentifier { get; set; }

    [JsonPropertyName("externalPaypointID")]
    public string? ExternalPaypointId { get; set; }

    [JsonPropertyName("customerConsent")]
    public CustomerQueryRecordsCustomerConsent? CustomerConsent { get; set; }

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
