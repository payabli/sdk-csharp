using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record BAddress : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("baddress")]
    public LinkData? Baddress { get; set; }

    [JsonPropertyName("baddress1")]
    public LinkData? Baddress1 { get; set; }

    [JsonPropertyName("bcity")]
    public LinkData? Bcity { get; set; }

    [JsonPropertyName("bcountry")]
    public LinkData? Bcountry { get; set; }

    [JsonPropertyName("bstate")]
    public LinkData? Bstate { get; set; }

    [JsonPropertyName("bzip")]
    public LinkData? Bzip { get; set; }

    [JsonPropertyName("maddress")]
    public LinkData? Maddress { get; set; }

    [JsonPropertyName("maddress1")]
    public LinkData? Maddress1 { get; set; }

    [JsonPropertyName("mcity")]
    public LinkData? Mcity { get; set; }

    [JsonPropertyName("mcountry")]
    public LinkData? Mcountry { get; set; }

    [JsonPropertyName("mstate")]
    public LinkData? Mstate { get; set; }

    [JsonPropertyName("mzip")]
    public LinkData? Mzip { get; set; }

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
