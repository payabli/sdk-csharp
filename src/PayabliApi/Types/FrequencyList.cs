using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record FrequencyList : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Enable or disable frequency
    /// </summary>
    [JsonPropertyName("annually")]
    public bool? Annually { get; set; }

    /// <summary>
    /// Enable or disable frequency
    /// </summary>
    [JsonPropertyName("every2Weeks")]
    public bool? Every2Weeks { get; set; }

    /// <summary>
    /// Enable or disable frequency
    /// </summary>
    [JsonPropertyName("every3Months")]
    public bool? Every3Months { get; set; }

    /// <summary>
    /// Enable or disable frequency
    /// </summary>
    [JsonPropertyName("every6Months")]
    public bool? Every6Months { get; set; }

    /// <summary>
    /// Enable or disable frequency
    /// </summary>
    [JsonPropertyName("monthly")]
    public bool? Monthly { get; set; }

    /// <summary>
    /// Enable or disable frequency
    /// </summary>
    [JsonPropertyName("one-time")]
    public bool? OneTime { get; set; }

    /// <summary>
    /// Enable or disable frequency
    /// </summary>
    [JsonPropertyName("weekly")]
    public bool? Weekly { get; set; }

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
