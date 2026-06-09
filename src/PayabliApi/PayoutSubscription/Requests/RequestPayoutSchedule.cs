using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record RequestPayoutSchedule
{
    /// <summary>
    /// _Optional but recommended_ A unique ID that you can include to prevent duplicating objects or transactions in the case that a request is sent more than once. This key isn't generated in Payabli, you must generate it yourself. This key persists for 2 minutes. After 2 minutes, you can reuse the key if needed.
    /// </summary>
    [JsonIgnore]
    public string? IdempotencyKey { get; set; }

    [JsonPropertyName("entryPoint")]
    public required string EntryPoint { get; set; }

    [JsonPropertyName("subdomain")]
    public string? Subdomain { get; set; }

    [JsonPropertyName("accountId")]
    public string? AccountId { get; set; }

    [JsonPropertyName("source")]
    public string? Source { get; set; }

    [JsonPropertyName("setPause")]
    public bool? SetPause { get; set; }

    /// <summary>
    /// Payment method for the payout subscription. Supports `ach`, `vcard`, and `check`. The `managed` method isn't supported for payout subscriptions.
    /// </summary>
    [JsonPropertyName("paymentMethod")]
    public required AuthorizePaymentMethod PaymentMethod { get; set; }

    /// <summary>
    /// Object describing details of the payout.
    /// </summary>
    [JsonPropertyName("paymentDetails")]
    public PayoutPaymentDetail? PaymentDetails { get; set; }

    /// <summary>
    /// Object identifying the vendor for this subscription. Only a `vendorId` or `vendorNumber` is needed to link to an existing vendor.
    /// </summary>
    [JsonPropertyName("vendorData")]
    public required RequestOutAuthorizeVendorData VendorData { get; set; }

    /// <summary>
    /// Array of bills associated with the payout subscription. If omitted and `doNotCreateBills` isn't set to `true`, the system creates a bill automatically.
    /// </summary>
    [JsonPropertyName("billData")]
    public IEnumerable<BillPayOutDataRequest>? BillData { get; set; }

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
