using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// The issued activation code, its expiration, and whether it was reused.
/// </summary>
[Serializable]
public record TapToPayActivationChallengeData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The 6-digit activation code the partner delivers to the device
    /// user to activate the device. It can start with leading zeros, so
    /// keep it as a string.
    /// </summary>
    [JsonPropertyName("code")]
    public required string Code { get; set; }

    /// <summary>
    /// UTC time when the code expires, in ISO 8601 round-trip format. A
    /// code is valid for 30 minutes after it's issued.
    /// </summary>
    [JsonPropertyName("expiresAt")]
    public required DateTime ExpiresAt { get; set; }

    /// <summary>
    /// `true` when an unexpired code already exists for the device and
    /// this call returns it unchanged instead of generating a new one.
    /// </summary>
    [JsonPropertyName("alreadyIssued")]
    public required bool AlreadyIssued { get; set; }

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
