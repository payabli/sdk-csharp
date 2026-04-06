using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record UpdatePayoutSubscriptionBody : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("setPause")]
    public bool? SetPause { get; set; }

    /// <summary>
    /// Object describing details of the payout.
    /// </summary>
    [JsonPropertyName("paymentDetails")]
    public PayoutPaymentDetail? PaymentDetails { get; set; }

    [JsonPropertyName("paymentMethod")]
    public AuthorizePaymentMethod? PaymentMethod { get; set; }

    /// <summary>
    /// Object describing the schedule for the payout subscription.
    /// </summary>
    [JsonPropertyName("scheduleDetails")]
    public PayoutScheduleDetail? ScheduleDetails { get; set; }

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
