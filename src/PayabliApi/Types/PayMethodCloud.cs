using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record PayMethodCloud : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("device")]
    public string? Device { get; set; }

    /// <summary>
    /// Method to use for the transaction. For cloud device transactions, the method is `cloud`.
    /// </summary>
    [JsonPropertyName("method")]
    public string Method { get; set; } = "cloud";

    [JsonPropertyName("saveIfSuccess")]
    public bool? SaveIfSuccess { get; set; }

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
