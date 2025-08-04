using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record ConfigurePaypointRequestGooglePay
{
    [JsonPropertyName("entry")]
    public string? Entry { get; set; }

    /// <summary>
    /// When `true`, Google Pay is enabled.
    /// </summary>
    [JsonPropertyName("isEnabled")]
    public bool? IsEnabled { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
