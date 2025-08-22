using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record VendorDataResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("VendorNumber")]
    public required string VendorNumber { get; set; }

    /// <summary>
    /// Primary name for vendor.
    /// </summary>
    [JsonPropertyName("Name1")]
    public required string Name1 { get; set; }

    /// <summary>
    /// Secondary name for vendor.
    /// </summary>
    [JsonPropertyName("Name2")]
    public required string Name2 { get; set; }

    /// <summary>
    /// EIN/Tax ID for vendor. In responses, this field is masked, and looks like: `"ein": "XXXXX6789"`.
    /// </summary>
    [JsonPropertyName("EIN")]
    public required string Ein { get; set; }

    /// <summary>
    /// Vendor's phone number.
    /// </summary>
    [JsonPropertyName("Phone")]
    public required string Phone { get; set; }

    [JsonPropertyName("Email")]
    public required string Email { get; set; }

    /// <summary>
    /// Email address for remittance
    /// </summary>
    [JsonPropertyName("RemitEmail")]
    public string? RemitEmail { get; set; }

    /// <summary>
    /// Vendor's address.
    /// </summary>
    [JsonPropertyName("Address1")]
    public required string Address1 { get; set; }

    /// <summary>
    /// Additional line for vendor's address.
    /// </summary>
    [JsonPropertyName("Address2")]
    public required string Address2 { get; set; }

    /// <summary>
    /// Vendor's city.
    /// </summary>
    [JsonPropertyName("City")]
    public required string City { get; set; }

    /// <summary>
    /// Vendor's state. Must be a two-character state code.
    /// </summary>
    [JsonPropertyName("State")]
    public required string State { get; set; }

    /// <summary>
    /// Vendor's zip code.
    /// </summary>
    [JsonPropertyName("Zip")]
    public required string Zip { get; set; }

    /// <summary>
    /// Vendor's country. Payabli supports only US and Canadian vendors.
    /// </summary>
    [JsonPropertyName("Country")]
    public required string Country { get; set; }

    [JsonPropertyName("Mcc")]
    public required string Mcc { get; set; }

    /// <summary>
    /// Additional location code used to identify the vendor.
    /// </summary>
    [JsonPropertyName("LocationCode")]
    public required string LocationCode { get; set; }

    /// <summary>
    /// Array of objects describing the vendor's contacts.
    /// </summary>
    [JsonPropertyName("Contacts")]
    public IEnumerable<ContactsResponse> Contacts { get; set; } = new List<ContactsResponse>();

    /// <summary>
    /// Object containing vendor's bank information.
    /// </summary>
    [JsonPropertyName("BillingData")]
    public required VendorResponseBillingData BillingData { get; set; }

    /// <summary>
    /// Preferred payment method for vendor.
    /// </summary>
    [JsonPropertyName("PaymentMethod")]
    public required VendorDataResponsePaymentMethod PaymentMethod { get; set; }

    [JsonPropertyName("VendorStatus")]
    public int? VendorStatus { get; set; }

    [JsonPropertyName("VendorId")]
    public int? VendorId { get; set; }

    /// <summary>
    /// Vendor enrollment status
    /// </summary>
    [JsonPropertyName("EnrollmentStatus")]
    public string? EnrollmentStatus { get; set; }

    /// <summary>
    /// Vendor bill summary statistics
    /// </summary>
    [JsonPropertyName("Summary")]
    public required VendorResponseSummary Summary { get; set; }

    /// <summary>
    /// Legal name of the paypoint
    /// </summary>
    [JsonPropertyName("PaypointLegalname")]
    public required string PaypointLegalname { get; set; }

    /// <summary>
    /// DBA name of the paypoint
    /// </summary>
    [JsonPropertyName("PaypointDbaname")]
    public required string PaypointDbaname { get; set; }

    /// <summary>
    /// Entry name of the paypoint
    /// </summary>
    [JsonPropertyName("PaypointEntryname")]
    public required string PaypointEntryname { get; set; }

    /// <summary>
    /// Name of the parent organization
    /// </summary>
    [JsonPropertyName("ParentOrgName")]
    public required string ParentOrgName { get; set; }

    /// <summary>
    /// ID of the parent organization
    /// </summary>
    [JsonPropertyName("ParentOrgId")]
    public required int ParentOrgId { get; set; }

    /// <summary>
    /// Date when vendor was created
    /// </summary>
    [JsonPropertyName("CreatedDate")]
    public required DateTime CreatedDate { get; set; }

    /// <summary>
    /// Date when vendor was last updated
    /// </summary>
    [JsonPropertyName("LastUpdated")]
    public required DateTime LastUpdated { get; set; }

    [JsonPropertyName("remitAddress1")]
    public required string RemitAddress1 { get; set; }

    [JsonPropertyName("remitAddress2")]
    public required string RemitAddress2 { get; set; }

    [JsonPropertyName("remitCity")]
    public required string RemitCity { get; set; }

    [JsonPropertyName("remitState")]
    public required string RemitState { get; set; }

    [JsonPropertyName("remitZip")]
    public required string RemitZip { get; set; }

    [JsonPropertyName("remitCountry")]
    public required string RemitCountry { get; set; }

    [JsonPropertyName("payeeName1")]
    public required string PayeeName1 { get; set; }

    [JsonPropertyName("payeeName2")]
    public required string PayeeName2 { get; set; }

    /// <summary>
    /// Custom field 1 for vendor
    /// </summary>
    [JsonPropertyName("customField1")]
    public required string CustomField1 { get; set; }

    /// <summary>
    /// Custom field 2 for vendor
    /// </summary>
    [JsonPropertyName("customField2")]
    public required string CustomField2 { get; set; }

    /// <summary>
    /// Account number of paypoint in the Vendor side.
    /// </summary>
    [JsonPropertyName("customerVendorAccount")]
    public string? CustomerVendorAccount { get; set; }

    [JsonPropertyName("InternalReferenceId")]
    public long? InternalReferenceId { get; set; }

    [JsonPropertyName("additionalData")]
    public Dictionary<string, string> AdditionalData { get; set; } =
        new Dictionary<string, string>();

    /// <summary>
    /// External paypoint identifier
    /// </summary>
    [JsonPropertyName("externalPaypointID")]
    public required string ExternalPaypointId { get; set; }

    /// <summary>
    /// Array of stored payment methods for vendor
    /// </summary>
    [JsonPropertyName("StoredMethods")]
    public IEnumerable<VendorResponseStoredMethod> StoredMethods { get; set; } =
        new List<VendorResponseStoredMethod>();

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
