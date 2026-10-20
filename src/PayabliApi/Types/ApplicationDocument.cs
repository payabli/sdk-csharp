using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// A document uploaded to an application.
/// </summary>
[Serializable]
public record ApplicationDocument : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The document reference. Use it to delete the document.
    /// </summary>
    [JsonPropertyName("documentReference")]
    public required string DocumentReference { get; set; }

    /// <summary>
    /// How the document was added to the application. Documents you upload are `applicantUpload`.
    /// </summary>
    [JsonPropertyName("kind")]
    public required string Kind { get; set; }

    /// <summary>
    /// The record the document is about.
    /// </summary>
    [JsonPropertyName("subjectType")]
    public required DocumentSubjectType SubjectType { get; set; }

    /// <summary>
    /// The person the document is about, when `subjectType` is `person`. Otherwise, `null`.
    /// </summary>
    [JsonPropertyName("personReference")]
    public string? PersonReference { get; set; }

    /// <summary>
    /// The requirement the document was uploaded for.
    /// </summary>
    [JsonPropertyName("fieldPath")]
    public required string FieldPath { get; set; }

    /// <summary>
    /// The name of the uploaded file.
    /// </summary>
    [JsonPropertyName("fileName")]
    public required string FileName { get; set; }

    /// <summary>
    /// The file's media type, such as `application/pdf`.
    /// </summary>
    [JsonPropertyName("mimeType")]
    public required string MimeType { get; set; }

    /// <summary>
    /// The file's size, in bytes.
    /// </summary>
    [JsonPropertyName("fileSizeBytes")]
    public required long FileSizeBytes { get; set; }

    /// <summary>
    /// When the document was uploaded.
    /// </summary>
    [JsonPropertyName("uploadedAt")]
    public required DateTime UploadedAt { get; set; }

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
