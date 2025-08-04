using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record FileContentImageOnly : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("ftype")]
    public FileContentFtype? Ftype { get; set; }

    /// <summary>
    /// The name of the file to be uploaded
    /// </summary>
    [JsonPropertyName("filename")]
    public string? Filename { get; set; }

    /// <summary>
    /// Optional URL link to the file
    /// </summary>
    [JsonPropertyName("furl")]
    public string? Furl { get; set; }

    /// <summary>
    /// Base64-encoded file content
    /// </summary>
    [JsonPropertyName("fContent")]
    public string? FContent { get; set; }

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
