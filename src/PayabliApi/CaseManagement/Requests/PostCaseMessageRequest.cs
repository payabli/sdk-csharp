using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record PostCaseMessageRequest
{
    /// <summary>
    /// The note text (1 to 4000 characters).
    /// </summary>
    [JsonPropertyName("content")]
    public required string Content { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
