using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Payment details for the payout subscription.
/// </summary>
[Serializable]
public record PayoutSubscriptionPaymentDetails : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Total payout amount, including any service fee.
    /// </summary>
    [JsonPropertyName("totalAmount")]
    public double? TotalAmount { get; set; }

    /// <summary>
    /// Service fee deducted from the total amount.
    /// </summary>
    [JsonPropertyName("serviceFee")]
    public double? ServiceFee { get; set; }

    /// <summary>
    /// Surcharge amount. Always `0` for payout subscriptions.
    /// </summary>
    [JsonPropertyName("surchargeFee")]
    public double? SurchargeFee { get; set; }

    /// <summary>
    /// Check number for the payout. Set when the payment method is `check`.
    /// </summary>
    [JsonPropertyName("checkNumber")]
    public string? CheckNumber { get; set; }

    /// <summary>
    /// Object containing an image of a paper check.
    /// </summary>
    [JsonPropertyName("checkImage")]
    public Dictionary<string, object?>? CheckImage { get; set; }

    /// <summary>
    /// Unique identifier for a processed check image.
    /// </summary>
    [JsonPropertyName("checkUniqueId")]
    public string? CheckUniqueId { get; set; }

    /// <summary>
    /// Currency code ISO-4217.
    /// </summary>
    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

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
    /// Settlement descriptor for the payout. Always `null` on this endpoint.
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
    /// Payabli transaction identifier. Always `null` on this endpoint.
    /// </summary>
    [JsonPropertyName("payabliTransId")]
    public string? PayabliTransId { get; set; }

    /// <summary>
    /// When `true`, each bill is processed as a separate payout. Always `null` on this endpoint.
    /// </summary>
    [JsonPropertyName("unbundled")]
    public bool? Unbundled { get; set; }

    /// <summary>
    /// Payment categories or line items describing the amount.
    /// </summary>
    [JsonPropertyName("categories")]
    public IEnumerable<PaymentCategories>? Categories { get; set; }

    [JsonPropertyName("splitFunding")]
    public IEnumerable<SplitFundingContent>? SplitFunding { get; set; }

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
