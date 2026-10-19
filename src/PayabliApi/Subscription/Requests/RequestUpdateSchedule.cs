using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record RequestUpdateSchedule
{
    /// <summary>
    /// Object describing an invoice linked to the subscription. Replaces the subscription's existing invoice data entirely. Send `null` to remove it, or leave it out to keep the current invoice data. See [Update a subscription](/guides/pay-in-developer-subscriptions-manage#update-a-subscription) for details.
    /// </summary>
    [JsonPropertyName("invoiceData")]
    public BillData? InvoiceData { get; set; }

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
