using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record ResponseChargeBack
{
    /// <summary>
    /// _Optional but recommended_ A unique ID that you can include to prevent duplicating objects or transactions in the case that a request is sent more than once. This key isn't generated in Payabli, you must generate it yourself. This key persists for 2 minutes. After 2 minutes, you can reuse the key if needed.
    /// </summary>
    [JsonIgnore]
    public string? IdempotencyKey { get; set; }

    /// <summary>
    /// Array of attached files to response.
    /// </summary>
    [JsonPropertyName("attachments")]
    public IEnumerable<FileContent>? Attachments { get; set; }

    /// <summary>
    /// Email of response submitter.
    /// </summary>
    [JsonPropertyName("contactEmail")]
    public string? ContactEmail { get; set; }

    /// <summary>
    /// Name of response submitter
    /// </summary>
    [JsonPropertyName("contactName")]
    public string? ContactName { get; set; }

    /// <summary>
    /// Response notes
    /// </summary>
    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
