using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record SubmitApplicationRequest
{
    /// <summary>
    /// The signature details for the application's signer, and optionally which person signs.
    /// </summary>
    [JsonPropertyName("signer")]
    public required SubmitSigner Signer { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
