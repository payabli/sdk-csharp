using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record RequestCredit
{
    [JsonIgnore]
    public bool? ForceCustomerCreation { get; set; }

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
