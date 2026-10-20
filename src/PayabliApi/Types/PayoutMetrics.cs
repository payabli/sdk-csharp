using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Expected Pay Out profile for the business.
/// </summary>
[Serializable]
public record PayoutMetrics : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Expected monthly Pay Out volume.
    /// </summary>
    [JsonPropertyName("monthlyPayablesVolume")]
    public double? MonthlyPayablesVolume { get; set; }

    /// <summary>
    /// Expected average payout amount.
    /// </summary>
    [JsonPropertyName("averagePayablesSize")]
    public double? AveragePayablesSize { get; set; }

    /// <summary>
    /// Expected largest payout amount.
    /// </summary>
    [JsonPropertyName("largestPayablesSize")]
    public double? LargestPayablesSize { get; set; }

    /// <summary>
    /// Expected number of payouts per month.
    /// </summary>
    [JsonPropertyName("numberOfTransactions")]
    public int? NumberOfTransactions { get; set; }

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
