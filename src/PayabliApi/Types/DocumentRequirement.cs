using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// A document the application asks for. A requirement comes from the application's template or from a Payabli business rule. For example, a business with an annual revenue of $1,000,000 or more needs bank statements.
///
/// A person requirement appears once for each owner of the business, with that owner's `personReference`.
/// </summary>
[Serializable]
public record DocumentRequirement : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The requirement's identifier, such as `documents.bankStatement` or `person.documents.w9`. Send it as `fieldPath` when you upload a document for this requirement.
    /// </summary>
    [JsonPropertyName("fieldPath")]
    public required string FieldPath { get; set; }

    /// <summary>
    /// The requirement's display name.
    /// </summary>
    [JsonPropertyName("label")]
    public required string Label { get; set; }

    /// <summary>
    /// Guidance on what to upload. Omitted when the requirement has none.
    /// </summary>
    [JsonPropertyName("hint")]
    public string? Hint { get; set; }

    /// <summary>
    /// Where the requirement comes from:
    ///
    /// - `template`: the application's template.
    /// - `businessRule`: a Payabli rule, such as bank statements for a business with an annual revenue of $1,000,000 or more.
    /// </summary>
    [JsonPropertyName("source")]
    public required DocumentRequirementSource Source { get; set; }

    /// <summary>
    /// The subjects a document for this requirement can be about. Send one of them as `subject` when you upload.
    /// </summary>
    [JsonPropertyName("subjectTypes")]
    public IEnumerable<DocumentSubjectType> SubjectTypes { get; set; } =
        new List<DocumentSubjectType>();

    /// <summary>
    /// The person this requirement is for. Returned for person requirements only.
    /// </summary>
    [JsonPropertyName("personReference")]
    public string? PersonReference { get; set; }

    /// <summary>
    /// When `true`, validation reports the requirement as missing until at least one document is uploaded for it. Submit doesn't enforce document requirements.
    /// </summary>
    [JsonPropertyName("required")]
    public required bool Required { get; set; }

    /// <summary>
    /// The most documents you can upload for this requirement.
    /// </summary>
    [JsonPropertyName("maxUploads")]
    public required int MaxUploads { get; set; }

    /// <summary>
    /// The file formats this requirement accepts, such as `pdf`, `jpg`, `jpeg`, or `png`.
    /// </summary>
    [JsonPropertyName("allowedFormats")]
    public IEnumerable<string> AllowedFormats { get; set; } = new List<string>();

    /// <summary>
    /// The number of documents uploaded for this requirement.
    /// </summary>
    [JsonPropertyName("uploadedCount")]
    public required int UploadedCount { get; set; }

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
