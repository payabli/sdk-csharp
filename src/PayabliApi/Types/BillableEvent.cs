using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// A chargeable action covered by a billing profile, with the fee schedule(s)
/// that apply to it.
/// </summary>
[Serializable]
public record BillableEvent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Event identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public required long Id { get; set; }

    /// <summary>
    /// Internal label for the event, for example `payin-card-auth-all`.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("vertical")]
    public required int Vertical { get; set; }

    [JsonPropertyName("service")]
    public required int Service { get; set; }

    [JsonPropertyName("serviceType")]
    public required int ServiceType { get; set; }

    [JsonPropertyName("eventType")]
    public required int EventType { get; set; }

    [JsonPropertyName("eventGroup")]
    public required int EventGroup { get; set; }

    [JsonPropertyName("eventSource")]
    public required int EventSource { get; set; }

    [JsonPropertyName("regionType")]
    public required int RegionType { get; set; }

    /// <summary>
    /// The fee schedule(s) that apply to this event.
    /// </summary>
    [JsonPropertyName("feeSchedules")]
    public IEnumerable<FeeSchedule> FeeSchedules { get; set; } = new List<FeeSchedule>();

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
