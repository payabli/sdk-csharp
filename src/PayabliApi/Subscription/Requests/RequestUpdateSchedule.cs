using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record RequestUpdateSchedule
{
    /// <summary>
    /// Object describing details of the payment. For Regular subscriptions, skip a payment by setting `totalAmount` to 0; payments pause until you update it to a non-zero value, and `serviceFee` must also be 0 when `totalAmount` is 0. For BalanceDriven subscriptions, any `totalAmount` you send is accepted but ignored at run time. Each run charges the payor's live balance, and a zero balance is skipped.
    /// </summary>
    [JsonPropertyName("paymentDetails")]
    public PaymentDetail? PaymentDetails { get; set; }

    /// <summary>
    /// Object describing the schedule for subscription
    /// </summary>
    [JsonPropertyName("scheduleDetails")]
    public ScheduleDetail? ScheduleDetails { get; set; }

    [JsonPropertyName("setPause")]
    public bool? SetPause { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
