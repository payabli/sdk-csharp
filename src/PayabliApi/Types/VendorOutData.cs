using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record VendorOutData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("additionalData")]
    public Dictionary<string, Dictionary<string, object?>?>? AdditionalData { get; set; }

    /// <summary>
    /// Vendor's address
    /// </summary>
    [JsonPropertyName("Address1")]
    public string? Address1 { get; set; }

    /// <summary>
    /// Additional line for vendor's address.
    /// </summary>
    [JsonPropertyName("Address2")]
    public string? Address2 { get; set; }

    /// <summary>
    /// Object containing vendor's bank information.
    /// </summary>
    [JsonPropertyName("BillingData")]
    public BillingData? BillingData { get; set; }

    /// <summary>
    /// Vendor's city.
    /// </summary>
    [JsonPropertyName("City")]
    public required string City { get; set; }

    /// <summary>
    /// Array of objects describing the vendor's contacts.
    /// </summary>
    [JsonPropertyName("Contacts")]
    public IEnumerable<Contacts>? Contacts { get; set; }

    /// <summary>
    /// Vendor's country.
    /// </summary>
    [JsonPropertyName("Country")]
    public required string Country { get; set; }

    /// <summary>
    /// Account number of paypoint in the vendor side.
    /// </summary>
    [JsonPropertyName("customerVendorAccount")]
    public string? CustomerVendorAccount { get; set; }

    /// <summary>
    /// EIN/Tax ID for vendor. In reponses, this field is masked, and looks like: `XXXXX6789`.
    /// </summary>
    [JsonPropertyName("EIN")]
    public required string Ein { get; set; }

    /// <summary>
    /// Vendor's email address. Required for vCard.
    /// </summary>
    [JsonPropertyName("Email")]
    public string? Email { get; set; }

    /// <summary>
    /// Internal identifier for global vendor account.
    /// </summary>
    [JsonPropertyName("InternalReferenceId")]
    public long? InternalReferenceId { get; set; }

    [JsonPropertyName("LocationCode")]
    public string? LocationCode { get; set; }

    [JsonPropertyName("Mcc")]
    public string? Mcc { get; set; }

    /// <summary>
    /// Primary name for vendor. Required for new vendor.
    /// </summary>
    [JsonPropertyName("Name1")]
    public required string Name1 { get; set; }

    /// <summary>
    /// Secondary name for vendor.
    /// </summary>
    [JsonPropertyName("Name2")]
    public string? Name2 { get; set; }

    [JsonPropertyName("payeeName1")]
    public string? PayeeName1 { get; set; }

    [JsonPropertyName("payeeName2")]
    public string? PayeeName2 { get; set; }

    [JsonPropertyName("PaymentMethod")]
    public VendorPaymentMethod? PaymentMethod { get; set; }

    /// <summary>
    /// Vendor's phone number
    /// </summary>
    [JsonPropertyName("Phone")]
    public required string Phone { get; set; }

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
    [JsonPropertyName("State")]
    public required string State { get; set; }

    /// <summary>
    /// Payabli identifier for vendor record. Required when `VendorNumber` isn't included.
    /// </summary>
    [JsonPropertyName("VendorId")]
    public int? VendorId { get; set; }

    [JsonPropertyName("VendorNumber")]
    public string? VendorNumber { get; set; }

    [JsonPropertyName("VendorStatus")]
    public int? VendorStatus { get; set; }

    /// <summary>
    /// Vendor's zip code.
    /// </summary>
    [JsonPropertyName("Zip")]
    public required string Zip { get; set; }

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
