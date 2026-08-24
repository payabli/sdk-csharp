using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// The issued activation code and the time it expires.
/// </summary>
[Serializable]
public record DeviceChallengeData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The 6-digit verification code the operator enters on the device's
    /// terminal to activate it. It can start with leading zeros, so keep it as
    /// a string.
    /// </summary>
    [JsonPropertyName("code")]
    public required string Code { get; set; }

    /// <summary>
    /// UTC time when the code expires, in ISO-8601 round-trip format. A code is
    /// valid for 5 minutes after it's issued.
    /// </summary>
    [JsonPropertyName("expiresAt")]
    public required DateTime ExpiresAt { get; set; }

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
