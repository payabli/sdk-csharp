using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record CreateBankAccountChangeCaseRequest
{
    /// <summary>
    /// A label for the account.
    /// </summary>
    [JsonPropertyName("nickname")]
    public required string Nickname { get; set; }

    /// <summary>
    /// The name of the bank.
    /// </summary>
    [JsonPropertyName("bankName")]
    public required string BankName { get; set; }

    /// <summary>
    /// The 9-digit bank routing number.
    /// </summary>
    [JsonPropertyName("routingNumber")]
    public required string RoutingNumber { get; set; }

    /// <summary>
    /// The bank account number (4 to 17 digits).
    /// </summary>
    [JsonPropertyName("accountNumber")]
    public required string AccountNumber { get; set; }

    /// <summary>
    /// The account type. Must be `checking` or `savings`.
    /// </summary>
    [JsonPropertyName("accountType")]
    public required string AccountType { get; set; }

    /// <summary>
    /// The account holder type. Must be `personal` or `business`.
    /// </summary>
    [JsonPropertyName("bankAccountHolderType")]
    public required string BankAccountHolderType { get; set; }

    [JsonPropertyName("bankAccountFunction")]
    public required CaseManagementBankAccountFunction BankAccountFunction { get; set; }

    [JsonPropertyName("services")]
    public required BankAccountServices Services { get; set; }

    /// <summary>
    /// Whether this is the default account for the selected services.
    /// </summary>
    [JsonPropertyName("default")]
    public required bool Default { get; set; }

    /// <summary>
    /// When to run the change, as a UTC timestamp (trailing `Z`). Must be at
    /// least 1 hour and at most 30 days in the future. Omit to run as soon as
    /// the case is approved.
    /// </summary>
    [JsonPropertyName("scheduleFor")]
    public DateTime? ScheduleFor { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
