using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record CardTypes : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("amex")]
    public BasicTemplateElement? Amex { get; set; }

    [JsonPropertyName("discover")]
    public BasicTemplateElement? Discover { get; set; }

    [JsonPropertyName("masterCard")]
    public BasicTemplateElement? MasterCard { get; set; }

    [JsonPropertyName("visa")]
    public BasicTemplateElement? Visa { get; set; }

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
