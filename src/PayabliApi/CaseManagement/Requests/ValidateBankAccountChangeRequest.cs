using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record ValidateBankAccountChangeRequest
{
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

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
