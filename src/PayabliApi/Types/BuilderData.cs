using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record BuilderData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("services")]
    public SSection? Services { get; set; }

    [JsonPropertyName("attributes")]
    public ASection? Attributes { get; set; }

    [JsonPropertyName("banking")]
    public DSection? Banking { get; set; }

    [JsonPropertyName("business")]
    public BSection? Business { get; set; }

    [JsonPropertyName("owners")]
    public OSection? Owners { get; set; }

    [JsonPropertyName("processing")]
    public PSection? Processing { get; set; }

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
