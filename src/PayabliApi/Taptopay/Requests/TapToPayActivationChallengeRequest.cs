using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record TapToPayActivationChallengeRequest
{
    [JsonPropertyName("entry")]
    public required string Entry { get; set; }

    /// <summary>
    /// The device identifier (`poiId`) returned when the device was registered.
    /// </summary>
    [JsonPropertyName("deviceId")]
    public required string DeviceId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
