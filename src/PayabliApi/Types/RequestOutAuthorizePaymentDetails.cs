using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Object containing payment details.
/// </summary>
[Serializable]
public record RequestOutAuthorizePaymentDetails : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("checkNumber")]
    public string? CheckNumber { get; set; }

    /// <summary>
    /// Currency code ISO-4217. If no code is provided, then the currency in the paypoint setting is used. Default is **USD**.
    /// </summary>
    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    /// <summary>
    /// Service fee to deduct from the total amount. This amount must be a number, percentages aren't accepted. If you're using a percentage-based fee schedule, you must calculate the value manually.
    ///
    /// Payabli honors this field only when the paypoint's ACH payout pricing allows fee overrides. Otherwise, Payabli ignores this field and charges the fee configured in the paypoint's pricing. Contact Payabli to check or change this setting.
    ///
    /// When fee overrides are allowed:
    ///
    /// - `0` overrides the configured fee, and no fee is charged.
    /// - A positive value replaces the configured fee. Payabli caps the fee at `totalAmount`.
    /// - A negative value results in no fee.
    /// - If you omit this field, Payabli charges the configured fee.
    ///
    /// The fee is deducted from the payout, so the vendor receives `totalAmount` minus the fee.
    /// </summary>
    [JsonPropertyName("serviceFee")]
    public double? ServiceFee { get; set; }

    /// <summary>
    /// Total amount to be charged. If a service fee is included, then this amount should include the service fee. If you're using managed payables (`paymentMethod.method` of `managed`), you can partially pay a single bill by setting this below the bill's outstanding balance. See [Partially pay a bill](/guides/pay-out-developer-bills-manage#partially-pay-a-bill).
    /// </summary>
    [JsonPropertyName("totalAmount")]
    public double? TotalAmount { get; set; }

    /// <summary>
    /// Indicates whether the payout should be bundled into a single transaction or processed separately. If set to `true`, each bill will be processed as a separate payout. If `false` or not provided, then multiple bills will be paid with a single payout.
    /// </summary>
    [JsonPropertyName("unbundled")]
    public bool? Unbundled { get; set; }

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
