using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record PayabliCredentials : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("accountId")]
    public string? AccountId { get; set; }

    [JsonPropertyName("cfeeFix")]
    public double? CfeeFix { get; set; }

    [JsonPropertyName("cfeeFloat")]
    public double? CfeeFloat { get; set; }

    [JsonPropertyName("cfeeMax")]
    public double? CfeeMax { get; set; }

    [JsonPropertyName("cfeeMin")]
    public double? CfeeMin { get; set; }

    [JsonPropertyName("maxticket")]
    public double? Maxticket { get; set; }

    [JsonPropertyName("minticket")]
    public double? Minticket { get; set; }

    [JsonPropertyName("mode")]
    public int? Mode { get; set; }

    [JsonPropertyName("referenceId")]
    public long? ReferenceId { get; set; }

    [JsonPropertyName("service")]
    public string? Service { get; set; }

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
