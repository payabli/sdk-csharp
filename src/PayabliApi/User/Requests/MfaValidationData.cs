using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record MfaValidationData
{
    [JsonPropertyName("mfaCode")]
    public string? MfaCode { get; set; }

    [JsonPropertyName("mfaValidationCode")]
    public string? MfaValidationCode { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
