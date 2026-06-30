using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Details of a queued or in-progress outreach call.
/// </summary>
[Serializable]
public record VendorCallStatusScheduled : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// ISO-8601 timestamp of the next scheduled call attempt.
    /// </summary>
    [JsonPropertyName("scheduledFor")]
    public string? ScheduledFor { get; set; }

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
