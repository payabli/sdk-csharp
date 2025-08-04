using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record CList : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("contactEmail")]
    public LinkData? ContactEmail { get; set; }

    [JsonPropertyName("contactName")]
    public LinkData? ContactName { get; set; }

    [JsonPropertyName("contactPhone")]
    public LinkData? ContactPhone { get; set; }

    [JsonPropertyName("contactTitle")]
    public LinkData? ContactTitle { get; set; }

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
