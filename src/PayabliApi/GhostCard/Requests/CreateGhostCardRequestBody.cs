using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record CreateGhostCardRequestBody
{
    /// <summary>
    /// ID of the vendor who receives the card. The vendor must belong to the paypoint and have an active status.
    /// </summary>
    [JsonPropertyName("vendorId")]
    public required long VendorId { get; set; }

    /// <summary>
    /// Spending limit for the card. Must be greater than `0` and can't exceed the paypoint's configured payout credit limit.
    /// </summary>
    [JsonPropertyName("expenseLimit")]
    public required double ExpenseLimit { get; set; }

    /// <summary>
    /// Requested expiration date for the card. If not provided, defaults to 30 days from creation.
    /// </summary>
    [JsonPropertyName("expirationDate")]
    public string? ExpirationDate { get; set; }

    /// <summary>
    /// Initial load amount for the card. Defaults to `0`.
    /// </summary>
    [JsonPropertyName("amount")]
    public double? Amount { get; set; }

    /// <summary>
    /// Maximum number of times the card can be used. If `0` or negative, defaults to `9999`. Ignored and set to `1` when `exactAmount` is `true`.
    /// </summary>
    [JsonPropertyName("maxNumberOfUses")]
    public int? MaxNumberOfUses { get; set; }

    /// <summary>
    /// When `true`, restricts the card to a single use. `maxNumberOfUses` is automatically set to `1` regardless of any other value provided.
    /// </summary>
    [JsonPropertyName("exactAmount")]
    public bool? ExactAmount { get; set; }

    /// <summary>
    /// Time period over which `expenseLimit` applies (for example, `monthly` or `weekly`). No server-side enforcement.
    /// </summary>
    [JsonPropertyName("expenseLimitPeriod")]
    public string? ExpenseLimitPeriod { get; set; }

    /// <summary>
    /// Billing cycle identifier.
    /// </summary>
    [JsonPropertyName("billingCycle")]
    public string? BillingCycle { get; set; }

    /// <summary>
    /// Day within the billing cycle.
    /// </summary>
    [JsonPropertyName("billingCycleDay")]
    public string? BillingCycleDay { get; set; }

    /// <summary>
    /// Maximum number of transactions allowed per day. Defaults to `0` (unlimited).
    /// </summary>
    [JsonPropertyName("dailyTransactionCount")]
    public int? DailyTransactionCount { get; set; }

    /// <summary>
    /// Maximum total spend allowed per day. Defaults to `0` (unlimited).
    /// </summary>
    [JsonPropertyName("dailyAmountLimit")]
    public double? DailyAmountLimit { get; set; }

    /// <summary>
    /// Maximum spend allowed per single transaction. Defaults to `0` (unlimited).
    /// </summary>
    [JsonPropertyName("transactionAmountLimit")]
    public int? TransactionAmountLimit { get; set; }

    /// <summary>
    /// Merchant Category Code to restrict where the card can be used. Must be a valid MCC if provided.
    /// </summary>
    [JsonPropertyName("mcc")]
    public string? Mcc { get; set; }

    /// <summary>
    /// Transaction Category Code to restrict where the card can be used. Must be a valid TCC if provided.
    /// </summary>
    [JsonPropertyName("tcc")]
    public string? Tcc { get; set; }

    /// <summary>
    /// Custom metadata field. Stored on the card record.
    /// </summary>
    [JsonPropertyName("misc1")]
    public string? Misc1 { get; set; }

    /// <summary>
    /// Custom metadata field. Stored on the card record.
    /// </summary>
    [JsonPropertyName("misc2")]
    public string? Misc2 { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
