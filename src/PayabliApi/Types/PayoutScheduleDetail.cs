using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record PayoutScheduleDetail : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Subscription start date in any of the accepted formats: YYYY-MM-DD, MM/DD/YYYY. This must be a future date.
    /// </summary>
    [JsonPropertyName("startDate")]
    public string? StartDate { get; set; }

    /// <summary>
    /// Subscription end date in any of the accepted formats: YYYY-MM-DD, MM/DD/YYYY or the value `untilcancelled` to indicate a scheduled payout with infinite cycle.
    /// </summary>
    [JsonPropertyName("endDate")]
    public string? EndDate { get; set; }

    /// <summary>
    /// Frequency of the payout subscription.
    /// </summary>
    [JsonPropertyName("frequency")]
    public Frequency? Frequency { get; set; }

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
