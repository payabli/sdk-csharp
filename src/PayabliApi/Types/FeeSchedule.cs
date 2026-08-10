using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// A fee schedule attached to a billable event. Flat and interchange-plus
/// schedules share this shape; `feeType` is the discriminator.
/// </summary>
[Serializable]
public record FeeSchedule : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Fee schedule identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public required long Id { get; set; }

    /// <summary>
    /// The flat-fee component of the fee, for example `0.30`.
    /// </summary>
    [JsonPropertyName("value")]
    public required double Value { get; set; }

    /// <summary>
    /// The percentage-rate component of the fee, for example `2.9`.
    /// </summary>
    [JsonPropertyName("rate")]
    public required double Rate { get; set; }

    [JsonPropertyName("passthrough")]
    public required int Passthrough { get; set; }

    /// <summary>
    /// Entity responsible for paying this fee. `null` when not set.
    /// </summary>
    [JsonPropertyName("payor")]
    public BillingEntity? Payor { get; set; }

    /// <summary>
    /// Entity that collects this fee. `null` when not set.
    /// </summary>
    [JsonPropertyName("collector")]
    public BillingEntity? Collector { get; set; }

    /// <summary>
    /// Fallback payor used when the primary payor can't cover the fee. `null`
    /// when not set.
    /// </summary>
    [JsonPropertyName("overflowPayor")]
    public BillingEntity? OverflowPayor { get; set; }

    /// <summary>
    /// Collection cadence for the overflow payor. `null` when not set.
    /// </summary>
    [JsonPropertyName("overflowCollectionSchedule")]
    public int? OverflowCollectionSchedule { get; set; }

    /// <summary>
    /// Floor on the combined fee (rate + flat value) for this schedule.
    /// </summary>
    [JsonPropertyName("minimumTotal")]
    public double? MinimumTotal { get; set; }

    /// <summary>
    /// Ceiling on the combined fee (rate + flat value) for this schedule.
    /// </summary>
    [JsonPropertyName("maximumTotal")]
    public double? MaximumTotal { get; set; }

    /// <summary>
    /// When this schedule starts applying. Drives ordering when an event has
    /// multiple schedules.
    /// </summary>
    [JsonPropertyName("effectiveDate")]
    public required DateTime EffectiveDate { get; set; }

    /// <summary>
    /// When this schedule stops applying. `null` means no end date.
    /// </summary>
    [JsonPropertyName("expirationDate")]
    public DateTime? ExpirationDate { get; set; }

    /// <summary>
    /// When this schedule was created.
    /// </summary>
    [JsonPropertyName("createdAt")]
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// When this schedule was last updated.
    /// </summary>
    [JsonPropertyName("updatedAt")]
    public required DateTime UpdatedAt { get; set; }

    /// <summary>
    /// Identifier of the schedule's creator. Surfaces in the Payabli Portal as
    /// "Configuration Owner" — informational, not a permission boundary.
    /// </summary>
    [JsonPropertyName("createdBy")]
    public required string CreatedBy { get; set; }

    [JsonPropertyName("collectionSchedule")]
    public required int CollectionSchedule { get; set; }

    /// <summary>
    /// Day of the month a monthly bill is applied, when set. `null` otherwise.
    /// </summary>
    [JsonPropertyName("billDate")]
    public int? BillDate { get; set; }

    /// <summary>
    /// Identifier of another fee schedule this one overrides. `null` otherwise.
    /// </summary>
    [JsonPropertyName("overrideFeeScheduleId")]
    public long? OverrideFeeScheduleId { get; set; }

    [JsonPropertyName("feeType")]
    public required int FeeType { get; set; }

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
