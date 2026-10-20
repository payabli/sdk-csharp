using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Expected Pay In processing profile for the business.
/// </summary>
[Serializable]
public record ProcessingMetrics : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Expected monthly Pay In volume.
    /// </summary>
    [JsonPropertyName("monthlyReceivablesVolume")]
    public double? MonthlyReceivablesVolume { get; set; }

    /// <summary>
    /// Expected average transaction amount.
    /// </summary>
    [JsonPropertyName("averageReceivableSize")]
    public double? AverageReceivableSize { get; set; }

    /// <summary>
    /// Expected largest transaction amount.
    /// </summary>
    [JsonPropertyName("largestReceivableSize")]
    public double? LargestReceivableSize { get; set; }

    /// <summary>
    /// Percent of volume from card-present transactions.
    /// </summary>
    [JsonPropertyName("inboundPresentPercent")]
    public int? InboundPresentPercent { get; set; }

    /// <summary>
    /// Percent of volume from online transactions.
    /// </summary>
    [JsonPropertyName("inboundOnlinePercent")]
    public int? InboundOnlinePercent { get; set; }

    /// <summary>
    /// Percent of volume from mail-order/telephone-order transactions.
    /// </summary>
    [JsonPropertyName("inboundMotoPercent")]
    public int? InboundMotoPercent { get; set; }

    /// <summary>
    /// The business's refund policy.
    /// </summary>
    [JsonPropertyName("refundPolicy")]
    public string? RefundPolicy { get; set; }

    /// <summary>
    /// Whether the business delivers goods or services before it's paid.
    /// </summary>
    [JsonPropertyName("advancedDelivery")]
    public bool? AdvancedDelivery { get; set; }

    /// <summary>
    /// Percent of sales delivered before payment.
    /// </summary>
    [JsonPropertyName("percentAdvancedDelivery")]
    public int? PercentAdvancedDelivery { get; set; }

    /// <summary>
    /// Average number of days between payment and delivery.
    /// </summary>
    [JsonPropertyName("advancedDeliveryDays")]
    public double? AdvancedDeliveryDays { get; set; }

    /// <summary>
    /// Expected number of transactions per month.
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
