using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Enrichment result details.
/// </summary>
[Serializable]
public record VendorEnrichResponseData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Unique identifier for this enrichment run. Format: `enrich-{vendorId}-{8-char hex}`.
    /// </summary>
    [JsonPropertyName("enrichmentId")]
    public string? EnrichmentId { get; set; }

    /// <summary>
    /// Final enrichment status. Values are `completed` (vendor is payout-ready), `completed_from_network` (vendor was already enriched in the Payabli vendor network, no AI processing needed), or `insufficient` (all stages ran but the vendor still lacks sufficient payment data).
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>
    /// Stages that ran successfully. A stage is only listed here if it returned a successful response. Failed stages are excluded.
    /// </summary>
    [JsonPropertyName("stagesTriggered")]
    public IEnumerable<string>? StagesTriggered { get; set; }

    /// <summary>
    /// `true` if the vendor now has sufficient payment data to process a payout (ACH, card email, or check remit address).
    /// </summary>
    [JsonPropertyName("vendorPayoutReady")]
    public bool? VendorPayoutReady { get; set; }

    /// <summary>
    /// Raw extraction results from the enrichment stages that ran.
    /// </summary>
    [JsonPropertyName("enrichmentData")]
    public VendorEnrichmentData? EnrichmentData { get; set; }

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
