using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record PairFiles : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Original filename
    /// </summary>
    [JsonPropertyName("originalName")]
    public string? OriginalName { get; set; }

    /// <summary>
    /// Filename assigned to zipped file. This is the name to use for reference in the API functions to get files in attachments.
    /// </summary>
    [JsonPropertyName("zipName")]
    public string? ZipName { get; set; }

    /// <summary>
    /// Descriptor of the file.
    /// </summary>
    [JsonPropertyName("descriptor")]
    public string? Descriptor { get; set; }

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
