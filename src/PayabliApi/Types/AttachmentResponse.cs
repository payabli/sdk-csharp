using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// A file attached to a case.
/// </summary>
[Serializable]
public record AttachmentResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The attachment's identifier.
    /// </summary>
    [JsonPropertyName("uuid")]
    public required string Uuid { get; set; }

    /// <summary>
    /// The case the attachment belongs to.
    /// </summary>
    [JsonPropertyName("caseUuid")]
    public required string CaseUuid { get; set; }

    /// <summary>
    /// The file's content type.
    /// </summary>
    [JsonPropertyName("fileType")]
    public required string FileType { get; set; }

    /// <summary>
    /// The file's name.
    /// </summary>
    [JsonPropertyName("filename")]
    public required string Filename { get; set; }

    /// <summary>
    /// A reference to the stored file.
    /// </summary>
    [JsonPropertyName("fileUrl")]
    public required string FileUrl { get; set; }

    /// <summary>
    /// When the file was uploaded.
    /// </summary>
    [JsonPropertyName("uploadedAt")]
    public required DateTime UploadedAt { get; set; }

    /// <summary>
    /// The id of the user who uploaded the file.
    /// </summary>
    [JsonPropertyName("uploadedBy")]
    public required string UploadedBy { get; set; }

    /// <summary>
    /// The resolved user who uploaded the file. Null when not enriched.
    /// </summary>
    [JsonPropertyName("uploadedByUser")]
    public UserRef? UploadedByUser { get; set; }

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
