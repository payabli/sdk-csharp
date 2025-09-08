using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Information about the associated vendor.
/// </summary>
[Serializable]
public record VCardGetResponseAssociatedVendor : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Unique code identifying the vendor.
    /// </summary>
    [JsonPropertyName("VendorNumber")]
    public string? VendorNumber { get; set; }

    /// <summary>
    /// The primary name associated with the vendor.
    /// </summary>
    [JsonPropertyName("Name1")]
    public string? Name1 { get; set; }

    /// <summary>
    /// Additional name information for the vendor.
    /// </summary>
    [JsonPropertyName("Name2")]
    public string? Name2 { get; set; }

    /// <summary>
    /// Employer Identification Number of the vendor.
    /// </summary>
    [JsonPropertyName("EIN")]
    public string? Ein { get; set; }

    /// <summary>
    /// Contact phone number of the vendor.
    /// </summary>
    [JsonPropertyName("Phone")]
    public string? Phone { get; set; }

    /// <summary>
    /// Contact email address of the vendor.
    /// </summary>
    [JsonPropertyName("Email")]
    public string? Email { get; set; }

    /// <summary>
    /// Email address for remittance.
    /// </summary>
    [JsonPropertyName("RemitEmail")]
    public string? RemitEmail { get; set; }

    /// <summary>
    /// Primary address line of the vendor.
    /// </summary>
    [JsonPropertyName("Address1")]
    public string? Address1 { get; set; }

    /// <summary>
    /// Secondary address line of the vendor.
    /// </summary>
    [JsonPropertyName("Address2")]
    public string? Address2 { get; set; }

    /// <summary>
    /// City where the vendor is located.
    /// </summary>
    [JsonPropertyName("City")]
    public string? City { get; set; }

    /// <summary>
    /// State where the vendor is located.
    /// </summary>
    [JsonPropertyName("State")]
    public string? State { get; set; }

    /// <summary>
    /// ZIP code for the vendor's location.
    /// </summary>
    [JsonPropertyName("Zip")]
    public string? Zip { get; set; }

    /// <summary>
    /// Country where the vendor is located.
    /// </summary>
    [JsonPropertyName("Country")]
    public string? Country { get; set; }

    /// <summary>
    /// Merchant Category Code for the vendor.
    /// </summary>
    [JsonPropertyName("Mcc")]
    public string? Mcc { get; set; }

    [JsonPropertyName("LocationCode")]
    public string? LocationCode { get; set; }

    /// <summary>
    /// Array of objects describing the vendor's contacts.
    /// </summary>
    [JsonPropertyName("Contacts")]
    public IEnumerable<VCardGetResponseContact>? Contacts { get; set; }

    /// <summary>
    /// Billing data for the vendor.
    /// </summary>
    [JsonPropertyName("BillingData")]
    public VCardGetResponseAssociatedVendorBillingData? BillingData { get; set; }

    /// <summary>
    /// Preferred payment method for vendor.
    /// </summary>
    [JsonPropertyName("PaymentMethod")]
    public string? PaymentMethod { get; set; }

    /// <summary>
    /// Status of the vendor.
    /// </summary>
    [JsonPropertyName("VendorStatus")]
    public int? VendorStatus { get; set; }

    /// <summary>
    /// Unique identifier for the vendor.
    /// </summary>
    [JsonPropertyName("VendorId")]
    public int? VendorId { get; set; }

    /// <summary>
    /// Enrollment status of the vendor.
    /// </summary>
    [JsonPropertyName("EnrollmentStatus")]
    public string? EnrollmentStatus { get; set; }

    /// <summary>
    /// Summary of vendor's billing and transaction status.
    /// </summary>
    [JsonPropertyName("Summary")]
    public VCardGetResponseAssociatedVendorSummary? Summary { get; set; }

    /// <summary>
    /// Legal name of the paypoint.
    /// </summary>
    [JsonPropertyName("PaypointLegalname")]
    public string? PaypointLegalname { get; set; }

    /// <summary>
    /// DBA name of the paypoint.
    /// </summary>
    [JsonPropertyName("PaypointDbaname")]
    public string? PaypointDbaname { get; set; }

    /// <summary>
    /// Entryname of the paypoint.
    /// </summary>
    [JsonPropertyName("PaypointEntryname")]
    public string? PaypointEntryname { get; set; }

    [JsonPropertyName("ParentOrgName")]
    public string? ParentOrgName { get; set; }

    /// <summary>
    /// ID of the parent organization.
    /// </summary>
    [JsonPropertyName("ParentOrgId")]
    public int? ParentOrgId { get; set; }

    /// <summary>
    /// Date when the vendor record was created.
    /// </summary>
    [JsonPropertyName("CreatedDate")]
    public string? CreatedDate { get; set; }

    /// <summary>
    /// Date when the vendor's information was last updated.
    /// </summary>
    [JsonPropertyName("LastUpdated")]
    public string? LastUpdated { get; set; }

    [JsonPropertyName("remitAddress1")]
    public string? RemitAddress1 { get; set; }

    [JsonPropertyName("remitAddress2")]
    public string? RemitAddress2 { get; set; }

    [JsonPropertyName("remitCity")]
    public string? RemitCity { get; set; }

    [JsonPropertyName("remitState")]
    public string? RemitState { get; set; }

    [JsonPropertyName("remitZip")]
    public string? RemitZip { get; set; }

    [JsonPropertyName("remitCountry")]
    public string? RemitCountry { get; set; }

    /// <summary>
    /// Primary name of the payee.
    /// </summary>
    [JsonPropertyName("payeeName1")]
    public string? PayeeName1 { get; set; }

    /// <summary>
    /// Secondary name of the payee.
    /// </summary>
    [JsonPropertyName("payeeName2")]
    public string? PayeeName2 { get; set; }

    /// <summary>
    /// A custom field for additional data.
    /// </summary>
    [JsonPropertyName("customField1")]
    public string? CustomField1 { get; set; }

    /// <summary>
    /// Another custom field for extra data.
    /// </summary>
    [JsonPropertyName("customField2")]
    public string? CustomField2 { get; set; }

    /// <summary>
    /// Account number of paypoint in the vendor side.
    /// </summary>
    [JsonPropertyName("customerVendorAccount")]
    public string? CustomerVendorAccount { get; set; }

    /// <summary>
    /// Internal reference ID used within the system.
    /// </summary>
    [JsonPropertyName("InternalReferenceId")]
    public int? InternalReferenceId { get; set; }

    /// <summary>
    /// Field for additional data, if any.
    /// </summary>
    [JsonPropertyName("additionalData")]
    public string? AdditionalData { get; set; }

    [JsonPropertyName("externalPaypointID")]
    public string? ExternalPaypointId { get; set; }

    /// <summary>
    /// Stored payment methods for the vendor.
    /// </summary>
    [JsonPropertyName("StoredMethods")]
    public string? StoredMethods { get; set; }

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
