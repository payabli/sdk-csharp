using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record RequestCredit
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

    [JsonPropertyName("accountId")]
    public string? AccountId { get; set; }

    /// <summary>
    /// Object describing the customer/payor.
    /// </summary>
    [JsonPropertyName("customerData")]
    public required PayorDataRequest CustomerData { get; set; }

    [JsonPropertyName("entrypoint")]
    public string? Entrypoint { get; set; }

    [JsonPropertyName("orderDescription")]
    public string? OrderDescription { get; set; }

    [JsonPropertyName("orderId")]
    public string? OrderId { get; set; }

    [JsonPropertyName("paymentDetails")]
    public required PaymentDetailCredit PaymentDetails { get; set; }

    /// <summary>
    /// Object describing the ACH payment method to use for transaction.
    /// </summary>
    [JsonPropertyName("paymentMethod")]
    public required RequestCreditPaymentMethod PaymentMethod { get; set; }

    [JsonPropertyName("source")]
    public string? Source { get; set; }

    [JsonPropertyName("subdomain")]
    public string? Subdomain { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
