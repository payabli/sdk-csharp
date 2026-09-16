using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record SubscriptionStatsQueryRecord : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The renewal window this row represents: `30` (due within 30 days), `60` (31 to 60 days), `90` (61 to 90 days), or `+90` (more than 90 days out). Note the response label `+90` differs from its request path value `plus`. Requesting `all` returns one row per window.
    /// </summary>
    [JsonPropertyName("interval")]
    public required string Interval { get; set; }

    /// <summary>
    /// Number of active subscriptions scheduled to renew within this window. This is a forecast of upcoming renewals, not charges already taken, so it doesn't reconcile with `inSubscriptionsPaid` on `/Statistic/basic`.
    /// </summary>
    [JsonPropertyName("count")]
    public required int Count { get; set; }

    /// <summary>
    /// Total value of the upcoming renewals in this window, net of fees.
    /// </summary>
    [JsonPropertyName("volume")]
    public required double Volume { get; set; }

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
