using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record Instrument : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("achAccount")]
    public required string AchAccount { get; set; }

    [JsonPropertyName("achRouting")]
    public required string AchRouting { get; set; }

    [JsonPropertyName("billingAddress")]
    public string? BillingAddress { get; set; }

    [JsonPropertyName("billingCity")]
    public string? BillingCity { get; set; }

    [JsonPropertyName("billingCountry")]
    public string? BillingCountry { get; set; }

    [JsonPropertyName("billingState")]
    public string? BillingState { get; set; }

    [JsonPropertyName("billingZip")]
    public string? BillingZip { get; set; }

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
