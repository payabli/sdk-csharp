using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Payment details for payout subscriptions.
/// </summary>
[Serializable]
public record PayoutPaymentDetail : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Total payout amount. If a service fee is included, this amount should include the service fee.
    /// </summary>
    [JsonPropertyName("totalAmount")]
    public required double TotalAmount { get; set; }

    /// <summary>
    /// Service fee to be deducted from the total amount. This amount must be a number, percentages aren't accepted.
    /// </summary>
    [JsonPropertyName("serviceFee")]
    public double? ServiceFee { get; set; }

    /// <summary>
    /// Currency code ISO-4217. If no code is provided, the currency in the paypoint setting is used. Default is `USD`.
    /// </summary>
    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    /// <summary>
    /// A check number for the payout. Required when the payment method is `check`.
    /// </summary>
    [JsonPropertyName("checkNumber")]
    public string? CheckNumber { get; set; }

    /// <summary>
    /// Description of the payout order.
    /// </summary>
    [JsonPropertyName("orderDescription")]
    public string? OrderDescription { get; set; }

    /// <summary>
    /// Order identifier associated with the payout.
    /// </summary>
    [JsonPropertyName("orderId")]
    public string? OrderId { get; set; }

    /// <summary>
    /// Alternative order identifier.
    /// </summary>
    [JsonPropertyName("orderIdAlternative")]
    public string? OrderIdAlternative { get; set; }

    /// <summary>
    /// Description of the payment.
    /// </summary>
    [JsonPropertyName("paymentDescription")]
    public string? PaymentDescription { get; set; }

    /// <summary>
    /// Settlement descriptor for the payout.
    /// </summary>
    [JsonPropertyName("settlementDescriptor")]
    public string? SettlementDescriptor { get; set; }

    /// <summary>
    /// Group number for the payout.
    /// </summary>
    [JsonPropertyName("groupNumber")]
    public string? GroupNumber { get; set; }

    /// <summary>
    /// Source identifier for the payout.
    /// </summary>
    [JsonPropertyName("source")]
    public string? Source { get; set; }

    /// <summary>
    /// Payabli transaction identifier.
    /// </summary>
    [JsonPropertyName("payabliTransId")]
    public string? PayabliTransId { get; set; }

    /// <summary>
    /// When `true`, each bill is processed as a separate payout. When `false` or not provided, multiple bills are paid with a single payout.
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
