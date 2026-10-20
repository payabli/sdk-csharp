using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record UploadApplicationDocumentRequest
{
    public required FileParameter File { get; set; }

    /// <summary>
    /// The `fieldPath` of the requirement you're uploading for, from [List application document requirements](/developers/api-reference/applications/list-application-document-requirements).
    /// </summary>
    public required string FieldPath { get; set; }

    /// <summary>
    /// The record the document is about. Send one of the requirement's `subjectTypes`.
    /// </summary>
    public required DocumentSubjectType Subject { get; set; }

    /// <summary>
    /// The person the document is about. Required when `subject` is `person`. Use the `personReference` from the person's requirement.
    /// </summary>
    public string? PersonReference { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
