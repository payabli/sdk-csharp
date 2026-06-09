using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Container for enrichment stage results.
/// </summary>
[Serializable]
public record VendorEnrichmentData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Results from the invoice scan stage, if it ran.
    /// </summary>
    [JsonPropertyName("invoiceScan")]
    public VendorEnrichmentInvoiceScan? InvoiceScan { get; set; }

    /// <summary>
    /// Results from the web search stage, if it ran.
    /// </summary>
    [JsonPropertyName("webSearch")]
    public VendorEnrichmentWebSearch? WebSearch { get; set; }

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
