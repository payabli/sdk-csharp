using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Latest AI outreach call activity for a vendor. The populated block depends on the `state` discriminator.
/// </summary>
[Serializable]
public record VendorCallStatusResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// ID of the vendor this status applies to.
    /// </summary>
    [JsonPropertyName("vendorId")]
    public long? VendorId { get; set; }

    /// <summary>
    /// Current call state. Values are: `none` (no call activity for the vendor), `scheduled` (a call is queued or being retried), `successful` (a call completed and returned data), or `failed` (the call didn't complete successfully).
    /// </summary>
    [JsonPropertyName("state")]
    public string? State { get; set; }

    /// <summary>
    /// Populated when `state` is `scheduled`.
    /// </summary>
    [JsonPropertyName("scheduled")]
    public VendorCallStatusScheduled? Scheduled { get; set; }

    /// <summary>
    /// Populated when `state` is `successful`.
    /// </summary>
    [JsonPropertyName("completed")]
    public VendorCallStatusCompleted? Completed { get; set; }

    /// <summary>
    /// Populated when `state` is `failed`.
    /// </summary>
    [JsonPropertyName("failed")]
    public VendorCallStatusFailed? Failed { get; set; }

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
