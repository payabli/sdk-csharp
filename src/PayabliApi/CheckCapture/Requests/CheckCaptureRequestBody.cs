using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record CheckCaptureRequestBody
{
    [JsonPropertyName("entryPoint")]
    public required string EntryPoint { get; set; }

    /// <summary>
    /// Base64-encoded front check image. Must be JPEG or PNG format and less than 1MB. Image must show the entire check clearly with no partial, blurry, or illegible portions.
    /// </summary>
    [JsonPropertyName("frontImage")]
    public required string FrontImage { get; set; }

    /// <summary>
    /// Base64-encoded rear check image. Must be JPEG or PNG format and less than 1MB. Image must show the entire check clearly with no partial, blurry, or illegible portions.
    /// </summary>
    [JsonPropertyName("rearImage")]
    public required string RearImage { get; set; }

    /// <summary>
    /// Check amount in cents (maximum 32-bit integer value).
    /// </summary>
    [JsonPropertyName("checkAmount")]
    public required int CheckAmount { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
