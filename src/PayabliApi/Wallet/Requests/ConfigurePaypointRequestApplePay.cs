using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record ConfigurePaypointRequestApplePay
{
    [JsonPropertyName("entry")]
    public string? Entry { get; set; }

    /// <summary>
    /// When `true`, Apple Pay is enabled.
    /// </summary>
    [JsonPropertyName("isEnabled")]
    public bool? IsEnabled { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
