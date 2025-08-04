using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record TierItemPass : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("amountFeeone-time")]
    public double? AmountFeeoneTime { get; set; }

    [JsonPropertyName("amountFeeRecurring")]
    public double? AmountFeeRecurring { get; set; }

    [JsonPropertyName("highPayRange")]
    public double? HighPayRange { get; set; }

    [JsonPropertyName("lowPayRange")]
    public double? LowPayRange { get; set; }

    [JsonPropertyName("percentFeeone-time")]
    public double? PercentFeeoneTime { get; set; }

    [JsonPropertyName("percentFeeRecurring")]
    public double? PercentFeeRecurring { get; set; }

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
