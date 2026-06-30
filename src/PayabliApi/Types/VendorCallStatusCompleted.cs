using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Details of a completed outreach call that returned data.
/// </summary>
[Serializable]
public record VendorCallStatusCompleted : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// ISO-8601 timestamp when the call ended.
    /// </summary>
    [JsonPropertyName("completedAt")]
    public string? CompletedAt { get; set; }

    /// <summary>
    /// Call duration in seconds.
    /// </summary>
    [JsonPropertyName("durationSeconds")]
    public int? DurationSeconds { get; set; }

    /// <summary>
    /// Short summary of the call.
    /// </summary>
    [JsonPropertyName("summary")]
    public string? Summary { get; set; }

    /// <summary>
    /// Reference identifier for the call.
    /// </summary>
    [JsonPropertyName("callId")]
    public string? CallId { get; set; }

    /// <summary>
    /// Full call transcript. `null` when no transcript is available.
    /// </summary>
    [JsonPropertyName("transcript")]
    public string? Transcript { get; set; }

    /// <summary>
    /// Payment and contact details collected during the call.
    /// </summary>
    [JsonPropertyName("extractedData")]
    public VendorCallStatusExtractedData? ExtractedData { get; set; }

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
