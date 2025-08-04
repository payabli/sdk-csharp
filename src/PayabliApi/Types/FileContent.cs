using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Contains details about a file. Max upload size is 30 MB.
/// </summary>
[Serializable]
public record FileContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Content of file, Base64-encoded. Ignored if furl is specified. Max upload size is 30 MB.
    /// </summary>
    [JsonPropertyName("fContent")]
    public string? FContent { get; set; }

    /// <summary>
    /// The name of the attached file.
    /// </summary>
    [JsonPropertyName("filename")]
    public string? Filename { get; set; }

    /// <summary>
    /// The MIME type of the file (if content is provided)
    /// </summary>
    [JsonPropertyName("ftype")]
    public FileContentFtype? Ftype { get; set; }

    /// <summary>
    /// Optional URL provided to show or download the file remotely
    /// </summary>
    [JsonPropertyName("furl")]
    public string? Furl { get; set; }

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
