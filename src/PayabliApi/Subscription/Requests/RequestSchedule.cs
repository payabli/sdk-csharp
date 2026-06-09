using global::System.Text.Json.Serialization;
using OneOf;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record RequestSchedule
{
    /// <summary>
    /// When `true`, the request creates a new customer record, regardless of whether customer identifiers match an existing customer. Defaults to `false`.
    /// </summary>
    [JsonIgnore]
    public bool? ForceCustomerCreation { get; set; }

    /// <summary>
    /// _Optional but recommended_ A unique ID that you can include to prevent duplicating objects or transactions in the case that a request is sent more than once. This key isn't generated in Payabli, you must generate it yourself. This key persists for 2 minutes. After 2 minutes, you can reuse the key if needed.
    /// </summary>
    [JsonIgnore]
    public string? IdempotencyKey { get; set; }

    /// <summary>
    /// Object describing the customer/payor.
    /// </summary>
    [JsonPropertyName("customerData")]
    public PayorDataRequest? CustomerData { get; set; }

    [JsonPropertyName("entryPoint")]
    public string? EntryPoint { get; set; }

    /// <summary>
    /// Object describing an Invoice linked to the subscription.
    /// </summary>
    [JsonPropertyName("invoiceData")]
    public BillData? InvoiceData { get; set; }

    /// <summary>
    /// Object describing details of the payment. For Regular subscriptions, skip a payment by setting `totalAmount` to 0; payments pause until you update it to a non-zero value, and `serviceFee` must also be 0 when `totalAmount` is 0. For BalanceDriven subscriptions, any `totalAmount` you send is accepted but ignored at run time. Each run charges the payor's live balance, and a zero balance is skipped.
    /// </summary>
    [JsonPropertyName("paymentDetails")]
    public PaymentDetail? PaymentDetails { get; set; }

    /// <summary>
    /// Information about the payment method for the transaction. Required and recommended fields for each payment method type are described in each schema below.
    /// </summary>
    [JsonPropertyName("paymentMethod")]
    public OneOf<
        PayMethodCredit,
        PayMethodAch,
        RequestSchedulePaymentMethodInitiator
    >? PaymentMethod { get; set; }

    /// <summary>
    /// Object describing the schedule for subscription.
    /// </summary>
    [JsonPropertyName("scheduleDetails")]
    public ScheduleDetail? ScheduleDetails { get; set; }

    [JsonPropertyName("setPause")]
    public bool? SetPause { get; set; }

    [JsonPropertyName("source")]
    public string? Source { get; set; }

    [JsonPropertyName("subdomain")]
    public string? Subdomain { get; set; }

    /// <summary>
    /// Subscription type. Defaults to `Regular` when omitted. Can't be changed after the subscription is created. If you send it to the update endpoint, it's ignored.
    /// </summary>
    [JsonPropertyName("subscriptionType")]
    public SubscriptionType? SubscriptionType { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
