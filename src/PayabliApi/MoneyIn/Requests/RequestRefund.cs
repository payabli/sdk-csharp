using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record RequestRefund
{
    /// <summary>
    /// _Optional but recommended_ A unique ID that you can include to prevent duplicating objects or transactions in the case that a request is sent more than once. This key isn't generated in Payabli, you must generate it yourself. This key persists for 2 minutes. After 2 minutes, you can reuse the key if needed.
    /// </summary>
    [JsonIgnore]
    public string? IdempotencyKey { get; set; }

    /// <summary>
    /// Amount to refund from original transaction, minus any service fees charged on the original transaction.
    ///
    /// The amount provided can't be greater than the original total amount of the transaction, minus service fees. For example, if a transaction was $90 plus a $10 service fee, you can refund up to $90.
    ///
    /// An amount equal to zero will refund the total amount authorized minus any service fee.
    /// </summary>
    [JsonPropertyName("amount")]
    public double? Amount { get; set; }

    [JsonPropertyName("ipaddress")]
    public string? Ipaddress { get; set; }

    [JsonPropertyName("orderDescription")]
    public string? OrderDescription { get; set; }

    [JsonPropertyName("orderId")]
    public string? OrderId { get; set; }

    [JsonPropertyName("refundDetails")]
    public RefundDetail? RefundDetails { get; set; }

    [JsonPropertyName("source")]
    public string? Source { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
