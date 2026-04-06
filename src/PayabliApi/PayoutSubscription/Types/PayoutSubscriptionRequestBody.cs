using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record PayoutSubscriptionRequestBody : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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
