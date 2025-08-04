using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record RequestUpdateSchedule
{
    /// <summary>
    /// Object describing details of the payment. To skip the payment, set the `totalAmount` to 0. Payments will be paused until the amount is updated to a non-zero value. When `totalAmount` is set to 0, the `serviceFee` must also be set to 0.
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
