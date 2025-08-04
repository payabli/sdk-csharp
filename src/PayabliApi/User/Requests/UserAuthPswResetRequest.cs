using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record UserAuthPswResetRequest
{
    /// <summary>
    /// New User password
    /// </summary>
    [JsonPropertyName("psw")]
    public string? Psw { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
