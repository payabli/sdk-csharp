using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record OcrDocumentJsonRequest
{
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

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
