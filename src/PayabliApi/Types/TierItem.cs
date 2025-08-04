using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record TierItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("amountxAuth")]
    public double? AmountxAuth { get; set; }

    [JsonPropertyName("highPayRange")]
    public double? HighPayRange { get; set; }

    [JsonPropertyName("lowPayRange")]
    public double? LowPayRange { get; set; }

    [JsonPropertyName("percentxAuth")]
    public double? PercentxAuth { get; set; }

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
