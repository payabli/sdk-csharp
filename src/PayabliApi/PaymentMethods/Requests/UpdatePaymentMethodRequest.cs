using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record UpdatePaymentMethodRequest
{
    /// <summary>
    /// An optional label for the payment method.
    /// </summary>
    [JsonPropertyName("nickname")]
    public string? Nickname { get; set; }

    /// <summary>
    /// The bank or financial institution that holds the account.
    /// </summary>
    [JsonPropertyName("financialInstitution")]
    public string? FinancialInstitution { get; set; }

    /// <summary>
    /// The account type, for example `checking` or `savings`.
    /// </summary>
    [JsonPropertyName("accountType")]
    public string? AccountType { get; set; }

    /// <summary>
    /// The bank account number.
    /// </summary>
    [JsonPropertyName("accountNumber")]
    public string? AccountNumber { get; set; }

    /// <summary>
    /// The bank routing number.
    /// </summary>
    [JsonPropertyName("routingNumber")]
    public string? RoutingNumber { get; set; }

    /// <summary>
    /// What the payment method is used for. Provide at least one value.
    /// </summary>
    [JsonPropertyName("usage")]
    public IEnumerable<PaymentMethodUsage>? Usage { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
