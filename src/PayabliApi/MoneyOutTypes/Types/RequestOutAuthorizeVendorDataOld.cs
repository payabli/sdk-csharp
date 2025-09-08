using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Object containing vendor data.
/// </summary>
[Serializable]
public record RequestOutAuthorizeVendorDataOld : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("additionalData")]
    public Dictionary<string, Dictionary<string, object?>?>? AdditionalData { get; set; }

    /// <summary>
    /// Vendor's address
    /// </summary>
    [JsonPropertyName("address1")]
    public string? Address1 { get; set; }

    /// <summary>
    /// Additional line for vendor's address.
    /// </summary>
    [JsonPropertyName("address2")]
    public string? Address2 { get; set; }

    /// <summary>
    /// Object containing vendor's bank information.
    /// </summary>
    [JsonPropertyName("billingData")]
    public BillingData? BillingData { get; set; }

    /// <summary>
    /// Vendor's city.
    /// </summary>
    [JsonPropertyName("city")]
    public string? City { get; set; }

    /// <summary>
    /// Array of objects describing the vendor's contacts.
    /// </summary>
    [JsonPropertyName("contacts")]
    public IEnumerable<Contacts>? Contacts { get; set; }

    /// <summary>
    /// Vendor's country.
    /// </summary>
    [JsonPropertyName("country")]
    public string? Country { get; set; }

    /// <summary>
    /// Account number of paypoint in the vendor side.
    /// </summary>
    [JsonPropertyName("customerVendorAccount")]
    public string? CustomerVendorAccount { get; set; }

    [JsonPropertyName("customField1")]
    public string? CustomField1 { get; set; }

    [JsonPropertyName("customField2")]
    public string? CustomField2 { get; set; }

    [JsonPropertyName("ein")]
    public string? Ein { get; set; }

    /// <summary>
    /// Vendor's email address. Required for vCard.
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>
    /// Internal identifier for global vendor account.
    /// </summary>
    [JsonPropertyName("internalReferenceId")]
    public long? InternalReferenceId { get; set; }

    [JsonPropertyName("locationCode")]
    public string? LocationCode { get; set; }

    [JsonPropertyName("mcc")]
    public string? Mcc { get; set; }

    [JsonPropertyName("name1")]
    public string? Name1 { get; set; }

    [JsonPropertyName("name2")]
    public string? Name2 { get; set; }

    [JsonPropertyName("payeeName1")]
    public string? PayeeName1 { get; set; }

    [JsonPropertyName("payeeName2")]
    public string? PayeeName2 { get; set; }

    [JsonPropertyName("paymentMethod")]
    public VendorPaymentMethod? PaymentMethod { get; set; }

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
    /// Vendor's state. Must be a 2 character state code.
    /// </summary>
    [JsonPropertyName("state")]
    public string? State { get; set; }

    /// <summary>
    /// Payabli identifier for vendor record. Required when `vendorNumber` isn't included.
    /// </summary>
    [JsonPropertyName("vendorId")]
    public int? VendorId { get; set; }

    [JsonPropertyName("vendorNumber")]
    public string? VendorNumber { get; set; }

    [JsonPropertyName("vendorStatus")]
    public int? VendorStatus { get; set; }

    /// <summary>
    /// Vendor's postal code.
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
