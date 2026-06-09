using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record RequestPaymentValidate
{
    /// <summary>
    /// _Optional but recommended_ A unique ID that you can include to prevent duplicating objects or transactions in the case that a request is sent more than once. This key isn't generated in Payabli, you must generate it yourself. This key persists for 2 minutes. After 2 minutes, you can reuse the key if needed.
    /// </summary>
    [JsonIgnore]
    public string? IdempotencyKey { get; set; }

    [JsonPropertyName("accountId")]
    public string? AccountId { get; set; }

    [JsonPropertyName("entryPoint")]
    public required string EntryPoint { get; set; }

    [JsonPropertyName("orderDescription")]
    public string? OrderDescription { get; set; }

    [JsonPropertyName("orderId")]
    public string? OrderId { get; set; }

    /// <summary>
    /// Object describing payment method to use for transaction.
    /// </summary>
    [JsonPropertyName("paymentMethod")]
    public required RequestPaymentValidatePaymentMethod PaymentMethod { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
