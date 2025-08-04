using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Request model for check capture processing.
/// </summary>
[Serializable]
public record CheckCaptureRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("entryPoint")]
    public required string EntryPoint { get; set; }

    /// <summary>
    /// Base64-encoded image of the front of the check. Must be JPEG or PNG format and less than 1MB. Image must show the entire check clearly with no partial, blurry, or illegible portions.
    /// </summary>
    [JsonPropertyName("frontImage")]
    public required string FrontImage { get; set; }

    /// <summary>
    /// Base64-encoded image of the back of the check. Must be JPEG or PNG format and less than 1MB. Image must show the entire check clearly with no partial, blurry, or illegible portions.
    /// </summary>
    [JsonPropertyName("rearImage")]
    public required string RearImage { get; set; }

    /// <summary>
    /// Check amount in cents (maximum 32-bit integer value). For example, $125.50 is represented as 12550.
    /// </summary>
    [JsonPropertyName("checkAmount")]
    public required int CheckAmount { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
