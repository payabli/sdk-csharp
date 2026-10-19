using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// The vendor associated with the payout subscription.
/// </summary>
[Serializable]
public record PayoutSubscriptionVendor : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("vendorNumber")]
    public required string VendorNumber { get; set; }

    [JsonPropertyName("name1")]
    public required string Name1 { get; set; }

    [JsonPropertyName("name2")]
    public string? Name2 { get; set; }

    [JsonPropertyName("ein")]
    public string? Ein { get; set; }

    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("remitEmail")]
    public string? RemitEmail { get; set; }

    /// <summary>
    /// The address.
    /// </summary>
    [JsonPropertyName("address1")]
    public string? Address1 { get; set; }

    /// <summary>
    /// Additional line for the address.
    /// </summary>
    [JsonPropertyName("address2")]
    public string? Address2 { get; set; }

    /// <summary>
    /// The city.
    /// </summary>
    [JsonPropertyName("city")]
    public string? City { get; set; }

    /// <summary>
    /// The state or province.
    /// </summary>
    [JsonPropertyName("state")]
    public string? State { get; set; }

    [JsonPropertyName("zip")]
    public string? Zip { get; set; }

    [JsonPropertyName("country")]
    public string? Country { get; set; }

    [JsonPropertyName("mcc")]
    public string? Mcc { get; set; }

    [JsonPropertyName("locationCode")]
    public string? LocationCode { get; set; }

    [JsonPropertyName("issue1099")]
    public required bool Issue1099 { get; set; }

    /// <summary>
    /// Array of objects describing the vendor's contacts.
    /// </summary>
    [JsonPropertyName("contacts")]
    public IEnumerable<PayoutSubscriptionVendorContact>? Contacts { get; set; }

    [JsonPropertyName("billingData")]
    public BillingDataResponse? BillingData { get; set; }

    [JsonPropertyName("paymentMethod")]
    public string? PaymentMethod { get; set; }

    [JsonPropertyName("vendorStatus")]
    public required int VendorStatus { get; set; }

    [JsonPropertyName("vendorId")]
    public required int VendorId { get; set; }

    [JsonPropertyName("enrollmentStatus")]
    public string? EnrollmentStatus { get; set; }

    /// <summary>
    /// Summary of the vendor's bills. Always `null` on this endpoint.
    /// </summary>
    [JsonPropertyName("summary")]
    public VendorSummary? Summary { get; set; }

    [JsonPropertyName("paypointLegalname")]
    public required string PaypointLegalname { get; set; }

    /// <summary>
    /// The paypoint's ID. This is different from the entryname.
    /// </summary>
    [JsonPropertyName("paypointId")]
    public long? PaypointId { get; set; }

    [JsonPropertyName("paypointDbaname")]
    public required string PaypointDbaname { get; set; }

    [JsonPropertyName("paypointEntryname")]
    public required string PaypointEntryname { get; set; }

    [JsonPropertyName("parentOrgName")]
    public required string ParentOrgName { get; set; }

    [JsonPropertyName("parentOrgId")]
    public required long ParentOrgId { get; set; }

    [JsonPropertyName("createdDate")]
    public required DateTime CreatedDate { get; set; }

    [JsonPropertyName("lastUpdated")]
    public required DateTime LastUpdated { get; set; }

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

    [JsonPropertyName("payeeName1")]
    public string? PayeeName1 { get; set; }

    [JsonPropertyName("payeeName2")]
    public string? PayeeName2 { get; set; }

    [JsonPropertyName("customField1")]
    public string? CustomField1 { get; set; }

    [JsonPropertyName("customField2")]
    public string? CustomField2 { get; set; }

    [JsonPropertyName("customerVendorAccount")]
    public string? CustomerVendorAccount { get; set; }

    [JsonPropertyName("internalReferenceId")]
    public required long InternalReferenceId { get; set; }

    /// <summary>
    /// URL for the vendor's online payment portal, if known. Populated by the vendor enrichment pipeline.
    /// </summary>
    [JsonPropertyName("paymentPortalUrl")]
    public string? PaymentPortalUrl { get; set; }

    /// <summary>
    /// Whether the vendor accepts card payments. Values are `yes`, `no`, or `unable to determine`. Populated by the vendor enrichment pipeline.
    /// </summary>
    [JsonPropertyName("cardAccepted")]
    public string? CardAccepted { get; set; }

    /// <summary>
    /// Whether the vendor accepts ACH payments. Values are `yes`, `no`, or `unable to determine`. Populated by the vendor enrichment pipeline.
    /// </summary>
    [JsonPropertyName("achAccepted")]
    public string? AchAccepted { get; set; }

    /// <summary>
    /// Whether the vendor accepts check payments. Values are `yes`, `no`, or `unable to determine`. Populated by the vendor enrichment pipeline.
    /// </summary>
    [JsonPropertyName("checkAccepted")]
    public string? CheckAccepted { get; set; }

    /// <summary>
    /// Current enrichment state of the vendor. Values are `not_enriched`, `partially_enriched`, `fully_enriched`, or `fallback_applied`.
    /// </summary>
    [JsonPropertyName("enrichmentStatus")]
    public required string EnrichmentStatus { get; set; }

    /// <summary>
    /// Which enrichment method resolved the vendor's payment acceptance info. Values are `invoice_scan`, `web_search`, `vendor_network`, or `manual`.
    /// </summary>
    [JsonPropertyName("enrichedBy")]
    public string? EnrichedBy { get; set; }

    /// <summary>
    /// When the vendor was last enriched (UTC).
    /// </summary>
    [JsonPropertyName("enrichedAt")]
    public DateTime? EnrichedAt { get; set; }

    /// <summary>
    /// Identifier for the enrichment request that last updated this vendor.
    /// </summary>
    [JsonPropertyName("enrichmentId")]
    public string? EnrichmentId { get; set; }

    [JsonPropertyName("additionalData")]
    public Dictionary<string, string>? AdditionalData { get; set; }

    [JsonPropertyName("externalPaypointID")]
    public string? ExternalPaypointId { get; set; }

    /// <summary>
    /// The vendor's stored payment methods. Always `null` on this endpoint.
    /// </summary>
    [JsonPropertyName("storedMethods")]
    public IEnumerable<VendorResponseStoredMethod>? StoredMethods { get; set; }

    /// <summary>
    /// The vendor's vendor portal access. Always `null` on this endpoint.
    /// </summary>
    [JsonPropertyName("vendorPortal")]
    public PayoutSubscriptionVendorVendorPortal? VendorPortal { get; set; }

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
