using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record OdpSetup : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Enables or disables ACH payout functionality
    /// </summary>
    [JsonPropertyName("allowAch")]
    public bool? AllowAch { get; set; }

    /// <summary>
    /// Enables or disables check printing payout functionality
    /// </summary>
    [JsonPropertyName("allowChecks")]
    public bool? AllowChecks { get; set; }

    /// <summary>
    /// Enables or disables vCard payout functionality
    /// </summary>
    [JsonPropertyName("allowVCard")]
    public bool? AllowVCard { get; set; }

    /// <summary>
    /// Region where payment processing occurs
    /// </summary>
    [JsonPropertyName("processing_region")]
    public OdpSetupProcessingRegion? ProcessingRegion { get; set; }

    /// <summary>
    /// Payment processor identifier
    /// </summary>
    [JsonPropertyName("processor")]
    public string? Processor { get; set; }

    /// <summary>
    /// Reference ID for the program enabled for ODP issuance
    /// </summary>
    [JsonPropertyName("issuerNetworkSettingsId")]
    public string? IssuerNetworkSettingsId { get; set; }

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
