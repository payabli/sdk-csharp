using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Scheduled call details.
/// </summary>
[Serializable]
public record VendorScheduleCallResponseData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Identifier for the scheduled call.
    /// </summary>
    [JsonPropertyName("callScheduleId")]
    public int? CallScheduleId { get; set; }

    /// <summary>
    /// ID of the enrichment run associated with this call. When the request omits `enrichmentId`, Payabli generates one and returns it here.
    /// </summary>
    [JsonPropertyName("enrichmentId")]
    public string? EnrichmentId { get; set; }

    /// <summary>
    /// ISO-8601 timestamp of the next scheduled call attempt.
    /// </summary>
    [JsonPropertyName("scheduledCallDate")]
    public string? ScheduledCallDate { get; set; }

    /// <summary>
    /// Status of the call schedule. Values are `pending`, `dispatched`, `retry_scheduled`, `completed`, and `fallback_applied`.
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

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
