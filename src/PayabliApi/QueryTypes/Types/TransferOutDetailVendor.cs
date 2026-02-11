using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Vendor information for an outbound transfer detail.
/// </summary>
[Serializable]
public record TransferOutDetailVendor : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The vendor's unique number.
    /// </summary>
    [JsonPropertyName("VendorNumber")]
    public string? VendorNumber { get; set; }

    /// <summary>
    /// Primary name of the vendor.
    /// </summary>
    [JsonPropertyName("Name1")]
    public string? Name1 { get; set; }

    /// <summary>
    /// Secondary name of the vendor.
    /// </summary>
    [JsonPropertyName("Name2")]
    public string? Name2 { get; set; }

    /// <summary>
    /// Employer Identification Number.
    /// </summary>
    [JsonPropertyName("EIN")]
    public string? Ein { get; set; }

    /// <summary>
    /// Vendor's phone number.
    /// </summary>
    [JsonPropertyName("Phone")]
    public string? Phone { get; set; }

    /// <summary>
    /// Vendor's email address.
    /// </summary>
    [JsonPropertyName("Email")]
    public string? Email { get; set; }

    /// <summary>
    /// Email for remittance notifications.
    /// </summary>
    [JsonPropertyName("RemitEmail")]
    public string? RemitEmail { get; set; }

    /// <summary>
    /// Primary address line.
    /// </summary>
    [JsonPropertyName("Address1")]
    public string? Address1 { get; set; }

    /// <summary>
    /// Secondary address line.
    /// </summary>
    [JsonPropertyName("Address2")]
    public string? Address2 { get; set; }

    /// <summary>
    /// City of the vendor.
    /// </summary>
    [JsonPropertyName("City")]
    public string? City { get; set; }

    /// <summary>
    /// State of the vendor.
    /// </summary>
    [JsonPropertyName("State")]
    public string? State { get; set; }

    /// <summary>
    /// ZIP code of the vendor.
    /// </summary>
    [JsonPropertyName("Zip")]
    public string? Zip { get; set; }

    /// <summary>
    /// Country of the vendor.
    /// </summary>
    [JsonPropertyName("Country")]
    public string? Country { get; set; }

    /// <summary>
    /// Merchant Category Code.
    /// </summary>
    [JsonPropertyName("Mcc")]
    public string? Mcc { get; set; }

    /// <summary>
    /// Location code for the vendor.
    /// </summary>
    [JsonPropertyName("LocationCode")]
    public string? LocationCode { get; set; }

    /// <summary>
    /// List of contacts for the vendor.
    /// </summary>
    [JsonPropertyName("Contacts")]
    public IEnumerable<ContactsResponse>? Contacts { get; set; }

    /// <summary>
    /// Billing data for the vendor.
    /// </summary>
    [JsonPropertyName("BillingData")]
    public TransferOutDetailVendorBillingData? BillingData { get; set; }

    /// <summary>
    /// Preferred payment method.
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
    public int? EnrollmentStatus { get; set; }

    /// <summary>
    /// Summary information about the vendor.
    /// </summary>
    [JsonPropertyName("Summary")]
    public string? Summary { get; set; }

    /// <summary>
    /// Legal name of the paypoint.
    /// </summary>
    [JsonPropertyName("PaypointLegalname")]
    public string? PaypointLegalname { get; set; }

    /// <summary>
    /// ID of the paypoint.
    /// </summary>
    [JsonPropertyName("PaypointId")]
    public int? PaypointId { get; set; }

    /// <summary>
    /// DBA name of the paypoint.
    /// </summary>
    [JsonPropertyName("PaypointDbaname")]
    public string? PaypointDbaname { get; set; }

    /// <summary>
    /// Entry name of the paypoint.
    /// </summary>
    [JsonPropertyName("PaypointEntryname")]
    public string? PaypointEntryname { get; set; }

    /// <summary>
    /// Name of the parent organization.
    /// </summary>
    [JsonPropertyName("ParentOrgName")]
    public string? ParentOrgName { get; set; }

    /// <summary>
    /// ID of the parent organization.
    /// </summary>
    [JsonPropertyName("ParentOrgId")]
    public int? ParentOrgId { get; set; }

    /// <summary>
    /// Date the vendor was created.
    /// </summary>
    [JsonPropertyName("CreatedDate")]
    public string? CreatedDate { get; set; }

    /// <summary>
    /// Date the vendor was last updated.
    /// </summary>
    [JsonPropertyName("LastUpdated")]
    public string? LastUpdated { get; set; }

    /// <summary>
    /// Primary remittance address line.
    /// </summary>
    [JsonPropertyName("remitAddress1")]
    public string? RemitAddress1 { get; set; }

    /// <summary>
    /// Secondary remittance address line.
    /// </summary>
    [JsonPropertyName("remitAddress2")]
    public string? RemitAddress2 { get; set; }

    /// <summary>
    /// Remittance city.
    /// </summary>
    [JsonPropertyName("remitCity")]
    public string? RemitCity { get; set; }

    /// <summary>
    /// Remittance state.
    /// </summary>
    [JsonPropertyName("remitState")]
    public string? RemitState { get; set; }

    /// <summary>
    /// Remittance ZIP code.
    /// </summary>
    [JsonPropertyName("remitZip")]
    public string? RemitZip { get; set; }

    /// <summary>
    /// Remittance country.
    /// </summary>
    [JsonPropertyName("remitCountry")]
    public string? RemitCountry { get; set; }

    /// <summary>
    /// Primary payee name.
    /// </summary>
    [JsonPropertyName("payeeName1")]
    public string? PayeeName1 { get; set; }

    /// <summary>
    /// Secondary payee name.
    /// </summary>
    [JsonPropertyName("payeeName2")]
    public string? PayeeName2 { get; set; }

    /// <summary>
    /// Custom field 1.
    /// </summary>
    [JsonPropertyName("customField1")]
    public string? CustomField1 { get; set; }

    /// <summary>
    /// Custom field 2.
    /// </summary>
    [JsonPropertyName("customField2")]
    public string? CustomField2 { get; set; }

    /// <summary>
    /// Customer vendor account number.
    /// </summary>
    [JsonPropertyName("customerVendorAccount")]
    public string? CustomerVendorAccount { get; set; }

    /// <summary>
    /// Internal reference ID.
    /// </summary>
    [JsonPropertyName("InternalReferenceId")]
    public int? InternalReferenceId { get; set; }

    /// <summary>
    /// Additional data for the vendor.
    /// </summary>
    [JsonPropertyName("additionalData")]
    public Dictionary<string, object?>? AdditionalData { get; set; }

    /// <summary>
    /// External paypoint ID.
    /// </summary>
    [JsonPropertyName("externalPaypointID")]
    public string? ExternalPaypointId { get; set; }

    /// <summary>
    /// Stored payment methods for the vendor.
    /// </summary>
    [JsonPropertyName("StoredMethods")]
    public IEnumerable<object>? StoredMethods { get; set; }

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
