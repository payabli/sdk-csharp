using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record UpdatePayoutSubscriptionBody
{
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

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
