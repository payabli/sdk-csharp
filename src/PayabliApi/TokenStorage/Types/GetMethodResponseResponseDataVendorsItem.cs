using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record GetMethodResponseResponseDataVendorsItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Additional data for vendor
    /// </summary>
    [JsonPropertyName("additionalData")]
    public Dictionary<string, string>? AdditionalData { get; set; }

    /// <summary>
    /// Vendor's address
    /// </summary>
    [JsonPropertyName("address1")]
    public string? Address1 { get; set; }

    /// <summary>
    /// Additional line for vendor's address
    /// </summary>
    [JsonPropertyName("address2")]
    public string? Address2 { get; set; }

    /// <summary>
    /// Object containing vendor's bank information
    /// </summary>
    [JsonPropertyName("billingData")]
    public VendorResponseBillingData? BillingData { get; set; }

    /// <summary>
    /// Vendor's city
    /// </summary>
    [JsonPropertyName("city")]
    public string? City { get; set; }

    /// <summary>
    /// Array of objects describing the vendor's contacts
    /// </summary>
    [JsonPropertyName("contacts")]
    public IEnumerable<Contacts>? Contacts { get; set; }

    /// <summary>
    /// Vendor's country
    /// </summary>
    [JsonPropertyName("country")]
    public string? Country { get; set; }

    /// <summary>
    /// Date when vendor was created
    /// </summary>
    [JsonPropertyName("createdDate")]
    public DateTime? CreatedDate { get; set; }

    /// <summary>
    /// Custom field 1 for vendor
    /// </summary>
    [JsonPropertyName("customField1")]
    public string? CustomField1 { get; set; }

    /// <summary>
    /// Custom field 2 for vendor
    /// </summary>
    [JsonPropertyName("customField2")]
    public string? CustomField2 { get; set; }

    /// <summary>
    /// Account number of paypoint in the vendor's side
    /// </summary>
    [JsonPropertyName("customerVendorAccount")]
    public string? CustomerVendorAccount { get; set; }

    /// <summary>
    /// EIN/Tax ID for vendor. In responses, this field is masked.
    /// </summary>
    [JsonPropertyName("ein")]
    public string? Ein { get; set; }

    /// <summary>
    /// Vendor's email address
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>
    /// Vendor enrollment status
    /// </summary>
    [JsonPropertyName("enrollmentStatus")]
    public string? EnrollmentStatus { get; set; }

    /// <summary>
    /// External paypoint identifier
    /// </summary>
    [JsonPropertyName("externalPaypointID")]
    public string? ExternalPaypointId { get; set; }

    /// <summary>
    /// Internal reference ID for vendor
    /// </summary>
    [JsonPropertyName("internalReferenceId")]
    public long? InternalReferenceId { get; set; }

    /// <summary>
    /// Date when vendor was last updated
    /// </summary>
    [JsonPropertyName("lastUpdated")]
    public DateTime? LastUpdated { get; set; }

    /// <summary>
    /// Location code for vendor
    /// </summary>
    [JsonPropertyName("locationCode")]
    public string? LocationCode { get; set; }

    /// <summary>
    /// Merchant category code
    /// </summary>
    [JsonPropertyName("mcc")]
    public string? Mcc { get; set; }

    /// <summary>
    /// Primary name for vendor
    /// </summary>
    [JsonPropertyName("name1")]
    public string? Name1 { get; set; }

    /// <summary>
    /// Secondary name for vendor
    /// </summary>
    [JsonPropertyName("name2")]
    public string? Name2 { get; set; }

    /// <summary>
    /// ID of the parent organization
    /// </summary>
    [JsonPropertyName("parentOrgId")]
    public int? ParentOrgId { get; set; }

    /// <summary>
    /// Name of the parent organization
    /// </summary>
    [JsonPropertyName("parentOrgName")]
    public string? ParentOrgName { get; set; }

    /// <summary>
    /// Primary payee name
    /// </summary>
    [JsonPropertyName("payeeName1")]
    public string? PayeeName1 { get; set; }

    /// <summary>
    /// Secondary payee name
    /// </summary>
    [JsonPropertyName("payeeName2")]
    public string? PayeeName2 { get; set; }

    /// <summary>
    /// Preferred payment method for vendor
    /// </summary>
    [JsonPropertyName("paymentMethod")]
    public string? PaymentMethod { get; set; }

    /// <summary>
    /// DBA name of the paypoint
    /// </summary>
    [JsonPropertyName("paypointDbaname")]
    public string? PaypointDbaname { get; set; }

    /// <summary>
    /// Entry name of the paypoint
    /// </summary>
    [JsonPropertyName("paypointEntryname")]
    public string? PaypointEntryname { get; set; }

    /// <summary>
    /// Paypoint ID
    /// </summary>
    [JsonPropertyName("paypointId")]
    public string? PaypointId { get; set; }

    /// <summary>
    /// Legal name of the paypoint
    /// </summary>
    [JsonPropertyName("paypointLegalname")]
    public string? PaypointLegalname { get; set; }

    /// <summary>
    /// Vendor's phone number
    /// </summary>
    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    /// <summary>
    /// Remittance address line 1
    /// </summary>
    [JsonPropertyName("remitAddress1")]
    public string? RemitAddress1 { get; set; }

    /// <summary>
    /// Remittance address line 2
    /// </summary>
    [JsonPropertyName("remitAddress2")]
    public string? RemitAddress2 { get; set; }

    /// <summary>
    /// Remittance city
    /// </summary>
    [JsonPropertyName("remitCity")]
    public string? RemitCity { get; set; }

    /// <summary>
    /// Remittance country
    /// </summary>
    [JsonPropertyName("remitCountry")]
    public string? RemitCountry { get; set; }

    /// <summary>
    /// Email address for remittance
    /// </summary>
    [JsonPropertyName("remitEmail")]
    public string? RemitEmail { get; set; }

    /// <summary>
    /// Remittance state
    /// </summary>
    [JsonPropertyName("remitState")]
    public string? RemitState { get; set; }

    /// <summary>
    /// Remittance ZIP code
    /// </summary>
    [JsonPropertyName("remitZip")]
    public string? RemitZip { get; set; }

    /// <summary>
    /// Vendor's state
    /// </summary>
    [JsonPropertyName("state")]
    public string? State { get; set; }

    /// <summary>
    /// Array of stored payment methods for vendor
    /// </summary>
    [JsonPropertyName("storedMethods")]
    public IEnumerable<VendorResponseStoredMethod>? StoredMethods { get; set; }

    /// <summary>
    /// Vendor bill summary statistics
    /// </summary>
    [JsonPropertyName("summary")]
    public VendorResponseSummary? Summary { get; set; }

    /// <summary>
    /// The unique numeric ID assigned to the vendor in Payabli
    /// </summary>
    [JsonPropertyName("vendorId")]
    public int? VendorId { get; set; }

    /// <summary>
    /// Custom vendor number assigned by the business
    /// </summary>
    [JsonPropertyName("vendorNumber")]
    public string? VendorNumber { get; set; }

    /// <summary>
    /// Status code for the vendor
    /// </summary>
    [JsonPropertyName("vendorStatus")]
    public int? VendorStatus { get; set; }

    /// <summary>
    /// Vendor's ZIP code
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
