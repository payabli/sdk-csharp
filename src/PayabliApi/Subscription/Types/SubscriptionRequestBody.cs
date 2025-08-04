using System.Text.Json;
using System.Text.Json.Serialization;
using OneOf;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record SubscriptionRequestBody : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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
    /// Object describing details of the payment. To skip the payment, set the `totalAmount` to 0. Payments will be paused until the amount is updated to a non-zero value. When `totalAmount` is set to 0, the `serviceFee` must also be set to 0.
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
