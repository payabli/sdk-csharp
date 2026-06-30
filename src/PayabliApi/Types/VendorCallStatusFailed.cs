using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Details of an outreach call that didn't complete successfully.
/// </summary>
[Serializable]
public record VendorCallStatusFailed : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// ISO-8601 timestamp of the most recent call attempt.
    /// </summary>
    [JsonPropertyName("lastAttemptAt")]
    public string? LastAttemptAt { get; set; }

    /// <summary>
    /// Reason the call didn't complete, as reported by the calling system (for example, `No answer`).
    /// </summary>
    [JsonPropertyName("reason")]
    public string? Reason { get; set; }

    /// <summary>
    /// Number of call attempts left before retries are exhausted.
    /// </summary>
    [JsonPropertyName("attemptsRemaining")]
    public int? AttemptsRemaining { get; set; }

    /// <summary>
    /// Maximum number of call attempts configured for this schedule.
    /// </summary>
    [JsonPropertyName("maxAttempts")]
    public int? MaxAttempts { get; set; }

    /// <summary>
    /// ISO-8601 timestamp of the next scheduled retry, or `null` when no further retries are scheduled.
    /// </summary>
    [JsonPropertyName("nextRetryScheduledFor")]
    public string? NextRetryScheduledFor { get; set; }

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
