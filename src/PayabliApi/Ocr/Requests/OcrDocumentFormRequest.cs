using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record OcrDocumentFormRequest
{
    public required FileParameter File { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
