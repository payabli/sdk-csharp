using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record CreateGhostCardResponseData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Card token for the ghost card. Use this value to reference the card in subsequent operations (update, cancel, etc.).
    /// </summary>
    [JsonPropertyName("ReferenceId")]
    public string? ReferenceId { get; set; }

    [JsonPropertyName("ResultCode")]
    public int? ResultCode { get; set; }

    [JsonPropertyName("ResultText")]
    public string? ResultText { get; set; }

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
