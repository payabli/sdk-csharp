using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Details about the payment.
/// </summary>
[Serializable]
public record PaymentDetail : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Array of payment categories/line items describing the amount to be paid.
    /// **Note**: These categories are for information only and aren't validated against the total amount provided.
    /// </summary>
    [JsonPropertyName("categories")]
    public IEnumerable<PaymentCategories>? Categories { get; set; }

    /// <summary>
    /// Object containing image of paper check.
    /// </summary>
    [JsonPropertyName("checkImage")]
    public Dictionary<string, object?>? CheckImage { get; set; }

    /// <summary>
    /// A check number to be used in the ach transaction. **Required** for payment method = 'check'.
    /// </summary>
    [JsonPropertyName("checkNumber")]
    public string? CheckNumber { get; set; }

    /// <summary>
    /// The currency for the transaction, `USD` or `CAD`. If your paypoint is configured for CAD, you must send the `CAD` value in this field, otherwise it defaults to USD, which will cause the transaction to fail.
    /// </summary>
    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    /// <summary>
    /// Service fee to be deducted from the total amount. This amount must be a number, percentages aren't accepted. If you are using a percentage-based fee schedule, you must calculate the value manually.
    /// </summary>
    [JsonPropertyName("serviceFee")]
    public double? ServiceFee { get; set; }

    /// <summary>
    /// Split funding instructions for the transaction. See [Split a Transaction](/developers/developer-guides/money-in-split-funding) for more.
    /// </summary>
    [JsonPropertyName("splitFunding")]
    public IEnumerable<SplitFundingContent>? SplitFunding { get; set; }

    /// <summary>
    /// Total amount to be charged. If a service fee is sent, then this amount should include the service fee."
    /// </summary>
    [JsonPropertyName("totalAmount")]
    public required double TotalAmount { get; set; }

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
