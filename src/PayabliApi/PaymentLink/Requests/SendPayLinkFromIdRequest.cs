using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record SendPayLinkFromIdRequest
{
    /// <summary>
    /// When `true`, attaches a PDF version of invoice to the email.
    /// </summary>
    [JsonIgnore]
    public bool? Attachfile { get; set; }

    /// <summary>
    /// List of recipient email addresses. When there is more than one, separate them by a semicolon (;).
    /// </summary>
    [JsonIgnore]
    public string? Mail2 { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
