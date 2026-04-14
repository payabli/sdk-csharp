using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Request body for the vendor enrichment endpoint.
/// </summary>
[Serializable]
public record VendorEnrichRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// ID of the vendor to enrich. Must be active and belong to the given entrypoint.
    /// </summary>
    [JsonPropertyName("vendorId")]
    public required long VendorId { get; set; }

    /// <summary>
    /// Enrichment stages to run. Valid values are `invoice_scan` and `web_search`. Stages run in order: invoice scan first, then web search. If the vendor becomes payout-ready after invoice scan, web search is skipped.
    /// </summary>
    [JsonPropertyName("scope")]
    public IEnumerable<string>? Scope { get; set; }

    /// <summary>
    /// When `true` (the default), extracted data is automatically written to the vendor record. Only empty fields are populated, existing values are never overwritten. When `false`, the vendor record isn't modified. In both cases, `enrichmentData` in the response contains the extracted results. Use `false` for UI flows where users review and confirm changes before applying them with the update vendor endpoint.
    /// </summary>
    [JsonPropertyName("applyEnrichmentData")]
    public bool? ApplyEnrichmentData { get; set; }

    /// <summary>
    /// When `true`, triggers an AI outreach call if enrichment stages return insufficient payment acceptance info. This feature is currently in development.
    /// </summary>
    [JsonPropertyName("scheduleCallIfNeeded")]
    public bool? ScheduleCallIfNeeded { get; set; }

    /// <summary>
    /// PDF invoice file, Base64-encoded. Required when `scope` includes `invoice_scan`.
    /// </summary>
    [JsonPropertyName("invoiceFile")]
    public FileContent? InvoiceFile { get; set; }

    /// <summary>
    /// Bill ID to associate with this enrichment request.
    /// </summary>
    [JsonPropertyName("billId")]
    public long? BillId { get; set; }

    /// <summary>
    /// Payment method to apply if enrichment can't find payment details. Values are `check`, `ach`, or `card`.
    /// </summary>
    [JsonPropertyName("fallbackMethod")]
    public string? FallbackMethod { get; set; }

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
