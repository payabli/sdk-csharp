using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record ResponseChargeBack
{
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
