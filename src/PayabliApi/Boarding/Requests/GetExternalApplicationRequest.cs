using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record GetExternalApplicationRequest
{
    /// <summary>
    /// If `true`, sends an email that includes the link to the application to the `mail2` address. Defaults to `false`.
    /// </summary>
    [JsonIgnore]
    public bool? SendEmail { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
