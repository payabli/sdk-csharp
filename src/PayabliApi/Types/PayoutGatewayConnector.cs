using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record PayoutGatewayConnector : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("configuration")]
    public string? Configuration { get; set; }

    [JsonPropertyName("Name")]
    public string? Name { get; set; }

    [JsonPropertyName("Mode")]
    public int? Mode { get; set; }

    [JsonPropertyName("Bank")]
    public string? Bank { get; set; }

    [JsonPropertyName("Descriptor")]
    public string? Descriptor { get; set; }

    [JsonPropertyName("gatewayID")]
    public int? GatewayId { get; set; }

    [JsonPropertyName("Enabled")]
    public bool? Enabled { get; set; }

    [JsonPropertyName("EnableACHValidation")]
    public bool? EnableAchValidation { get; set; }

    [JsonPropertyName("TestMode")]
    public bool? TestMode { get; set; }

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
