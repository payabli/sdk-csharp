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
    public Dictionary<string, Dictionary<string, object?>>? AdditionalData { get; set; }

    [JsonPropertyName("Address1")]
    public string? Address1 { get; set; }

    [JsonPropertyName("Address2")]
    public string? Address2 { get; set; }

    [JsonPropertyName("BillingData")]
    public BillingDataResponse? BillingData { get; set; }

    [JsonPropertyName("City")]
    public string? City { get; set; }

    [JsonPropertyName("Contacts")]
    public ContactsResponse? Contacts { get; set; }

    [JsonPropertyName("Country")]
    public string? Country { get; set; }

    [JsonPropertyName("CreatedDate")]
    public DateTime? CreatedDate { get; set; }

    [JsonPropertyName("customerVendorAccount")]
    public string? CustomerVendorAccount { get; set; }

    [JsonPropertyName("customField1")]
    public string? CustomField1 { get; set; }

    [JsonPropertyName("customField2")]
    public string? CustomField2 { get; set; }

    [JsonPropertyName("EIN")]
    public string? Ein { get; set; }

    [JsonPropertyName("Email")]
    public string? Email { get; set; }

    [JsonPropertyName("EnrollmentStatus")]
    public string? EnrollmentStatus { get; set; }

    [JsonPropertyName("externalPaypointID")]
    public string? ExternalPaypointId { get; set; }

    [JsonPropertyName("InternalReferenceId")]
    public long? InternalReferenceId { get; set; }

    [JsonPropertyName("LastUpdated")]
    public DateTime? LastUpdated { get; set; }

    [JsonPropertyName("LocationCode")]
    public string? LocationCode { get; set; }

    [JsonPropertyName("Mcc")]
    public string? Mcc { get; set; }

    [JsonPropertyName("Name1")]
    public string? Name1 { get; set; }

    [JsonPropertyName("Name2")]
    public string? Name2 { get; set; }

    [JsonPropertyName("ParentOrgName")]
    public string? ParentOrgName { get; set; }

    [JsonPropertyName("ParentOrgId")]
    public long? ParentOrgId { get; set; }

    [JsonPropertyName("payeeName1")]
    public string? PayeeName1 { get; set; }

    [JsonPropertyName("payeeName2")]
    public string? PayeeName2 { get; set; }

    [JsonPropertyName("PaymentMethod")]
    public string? PaymentMethod { get; set; }

    [JsonPropertyName("PaypointDbaname")]
    public string? PaypointDbaname { get; set; }

    [JsonPropertyName("PaypointEntryname")]
    public string? PaypointEntryname { get; set; }

    [JsonPropertyName("PaypointLegalname")]
    public string? PaypointLegalname { get; set; }

    [JsonPropertyName("Phone")]
    public string? Phone { get; set; }

    [JsonPropertyName("remitAddress1")]
    public string? RemitAddress1 { get; set; }

    [JsonPropertyName("remitAddress2")]
    public string? RemitAddress2 { get; set; }

    [JsonPropertyName("remitCity")]
    public string? RemitCity { get; set; }

    [JsonPropertyName("remitCountry")]
    public string? RemitCountry { get; set; }

    [JsonPropertyName("RemitEmail")]
    public string? RemitEmail { get; set; }

    [JsonPropertyName("remitState")]
    public string? RemitState { get; set; }

    [JsonPropertyName("remitZip")]
    public string? RemitZip { get; set; }

    [JsonPropertyName("State")]
    public string? State { get; set; }

    [JsonPropertyName("StoredMethods")]
    public IEnumerable<VendorResponseStoredMethod>? StoredMethods { get; set; }

    [JsonPropertyName("Summary")]
    public VendorSummary? Summary { get; set; }

    [JsonPropertyName("VendorId")]
    public int? VendorId { get; set; }

    [JsonPropertyName("VendorNumber")]
    public string? VendorNumber { get; set; }

    [JsonPropertyName("VendorStatus")]
    public int? VendorStatus { get; set; }

    [JsonPropertyName("Zip")]
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
