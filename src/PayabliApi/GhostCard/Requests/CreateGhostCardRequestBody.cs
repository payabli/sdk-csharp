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
    /// Initial load amount for the card.
    /// </summary>
    [JsonPropertyName("amount")]
    public required double Amount { get; set; }

    /// <summary>
    /// Maximum number of times the card can be used. Ignored and set to `1` when `exactAmount` is `true`.
    /// </summary>
    [JsonPropertyName("maxNumberOfUses")]
    public required int MaxNumberOfUses { get; set; }

    /// <summary>
    /// When `true`, restricts the card to a single use. `maxNumberOfUses` is automatically set to `1` regardless of any other value provided.
    /// </summary>
    [JsonPropertyName("exactAmount")]
    public required bool ExactAmount { get; set; }

    /// <summary>
    /// Time period over which `expenseLimit` applies (for example, `monthly` or `weekly`).
    /// </summary>
    [JsonPropertyName("expenseLimitPeriod")]
    public required string ExpenseLimitPeriod { get; set; }

    /// <summary>
    /// Billing cycle identifier.
    /// </summary>
    [JsonPropertyName("billingCycle")]
    public required string BillingCycle { get; set; }

    /// <summary>
    /// Day within the billing cycle.
    /// </summary>
    [JsonPropertyName("billingCycleDay")]
    public required string BillingCycleDay { get; set; }

    /// <summary>
    /// Maximum number of transactions allowed per day.
    /// </summary>
    [JsonPropertyName("dailyTransactionCount")]
    public required int DailyTransactionCount { get; set; }

    /// <summary>
    /// Maximum total spend allowed per day.
    /// </summary>
    [JsonPropertyName("dailyAmountLimit")]
    public required double DailyAmountLimit { get; set; }

    /// <summary>
    /// Maximum spend allowed per single transaction.
    /// </summary>
    [JsonPropertyName("transactionAmountLimit")]
    public required int TransactionAmountLimit { get; set; }

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
