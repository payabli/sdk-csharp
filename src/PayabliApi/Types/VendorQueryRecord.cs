using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record VendorQueryRecord : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("additionalData")]
    public Dictionary<string, Dictionary<string, object?>?>? AdditionalData { get; set; }

    /// <summary>
    /// Vendor's address.
    /// </summary>
    [JsonPropertyName("address1")]
    public string? Address1 { get; set; }

    /// <summary>
    /// Additional line for vendor's address.
    /// </summary>
    [JsonPropertyName("address2")]
    public string? Address2 { get; set; }

    [JsonPropertyName("billingData")]
    public BillingDataResponse? BillingData { get; set; }

    /// <summary>
    /// Vendor's city.
    /// </summary>
    [JsonPropertyName("city")]
    public string? City { get; set; }

    [JsonPropertyName("contacts")]
    public IEnumerable<Contacts>? Contacts { get; set; }

    /// <summary>
    /// Vendor's country.
    /// </summary>
    [JsonPropertyName("country")]
    public string? Country { get; set; }

    [JsonPropertyName("createdDate")]
    public DateTime? CreatedDate { get; set; }

    /// <summary>
    /// Account number of paypoint in the vendor system.
    /// </summary>
    [JsonPropertyName("customerVendorAccount")]
    public string? CustomerVendorAccount { get; set; }

    [JsonPropertyName("ein")]
    public string? Ein { get; set; }

    /// <summary>
    /// Vendor's email address.
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("enrollmentStatus")]
    public string? EnrollmentStatus { get; set; }

    [JsonPropertyName("externalPaypointId")]
    public string? ExternalPaypointId { get; set; }

    [JsonPropertyName("internalReferenceId")]
    public long? InternalReferenceId { get; set; }

    [JsonPropertyName("lastUpdated")]
    public DateTime? LastUpdated { get; set; }

    /// <summary>
    /// Additional location code used to identify the vendor.
    /// </summary>
    [JsonPropertyName("locationCode")]
    public string? LocationCode { get; set; }

    [JsonPropertyName("mcc")]
    public string? Mcc { get; set; }

    /// <summary>
    /// Primary name for vendor.
    /// </summary>
    [JsonPropertyName("name1")]
    public string? Name1 { get; set; }

    /// <summary>
    /// Secondary name for vendor.
    /// </summary>
    [JsonPropertyName("name2")]
    public string? Name2 { get; set; }

    [JsonPropertyName("parentOrgName")]
    public string? ParentOrgName { get; set; }

    [JsonPropertyName("payeeName1")]
    public string? PayeeName1 { get; set; }

    [JsonPropertyName("payeeName2")]
    public string? PayeeName2 { get; set; }

    [JsonPropertyName("paymentMethod")]
    public VendorPaymentMethod? PaymentMethod { get; set; }

    [JsonPropertyName("paypointDbaname")]
    public string? PaypointDbaname { get; set; }

    [JsonPropertyName("paypointEntryname")]
    public string? PaypointEntryname { get; set; }

    [JsonPropertyName("paypointLegalname")]
    public string? PaypointLegalname { get; set; }

    /// <summary>
    /// Vendor's phone number.
    /// </summary>
    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    [JsonPropertyName("remitAddress1")]
    public string? RemitAddress1 { get; set; }

    [JsonPropertyName("remitAddress2")]
    public string? RemitAddress2 { get; set; }

    [JsonPropertyName("remitCity")]
    public string? RemitCity { get; set; }

    [JsonPropertyName("remitCountry")]
    public string? RemitCountry { get; set; }

    [JsonPropertyName("remitState")]
    public string? RemitState { get; set; }

    [JsonPropertyName("remitZip")]
    public string? RemitZip { get; set; }

    /// <summary>
    /// Vendor's state.
    /// </summary>
    [JsonPropertyName("state")]
    public string? State { get; set; }

    [JsonPropertyName("summary")]
    public VendorSummary? Summary { get; set; }

    [JsonPropertyName("vendorId")]
    public int? VendorId { get; set; }

    [JsonPropertyName("vendorNumber")]
    public string? VendorNumber { get; set; }

    [JsonPropertyName("vendorStatus")]
    public int? VendorStatus { get; set; }

    /// <summary>
    /// Vendor's zip code.
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
