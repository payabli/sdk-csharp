using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record BillingDataResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The bank's ID in Payabli.
    /// </summary>
    [JsonPropertyName("id")]
    public required int Id { get; set; }

    /// <summary>
    /// An identifier for the bank account. If not provided during creation or update, the system generates one in the format `acct-{first_digit}xxxxx{last_4_digits}` based on the account number. If a duplicate exists within the same service at the paypoint, a numeric suffix is appended, such as `-2`. This value is also used as the identifier for the bank account's associated payment connector.
    /// </summary>
    [JsonPropertyName("accountId")]
    public string? AccountId { get; set; }

    [JsonPropertyName("nickname")]
    public required string Nickname { get; set; }

    [JsonPropertyName("bankName")]
    public required string BankName { get; set; }

    [JsonPropertyName("routingAccount")]
    public required string RoutingAccount { get; set; }

    [JsonPropertyName("accountNumber")]
    public required string AccountNumber { get; set; }

    [JsonPropertyName("typeAccount")]
    public required TypeAccount TypeAccount { get; set; }

    [JsonPropertyName("bankAccountHolderName")]
    public required string BankAccountHolderName { get; set; }

    [JsonPropertyName("bankAccountHolderType")]
    public required BankAccountHolderType BankAccountHolderType { get; set; }

    /// <summary>
    /// Describes whether the bank account is used for deposits or withdrawals in Payabli:
    ///   - `0`: Deposit
    ///   - `1`: Withdrawal
    ///   - `2`: Deposit and withdrawal
    /// </summary>
    [JsonPropertyName("bankAccountFunction")]
    public required int BankAccountFunction { get; set; }

    [JsonPropertyName("verified")]
    public required bool Verified { get; set; }

    [JsonPropertyName("status")]
    public required int Status { get; set; }

    [JsonPropertyName("services")]
    public IEnumerable<object> Services { get; set; } = new List<object>();

    [JsonPropertyName("default")]
    public required bool Default { get; set; }

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
