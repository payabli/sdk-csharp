using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Data extracted from a completed outreach call.
/// </summary>
[Serializable]
public record VendorCallStatusExtractedData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Payment method the vendor said they accept. Values are `card`, `ach`, or `check`.
    /// </summary>
    [JsonPropertyName("selectedPaymentMethod")]
    public string? SelectedPaymentMethod { get; set; }

    /// <summary>
    /// Contact email collected during the call.
    /// </summary>
    [JsonPropertyName("contactEmail")]
    public string? ContactEmail { get; set; }

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
