using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// The bank-account-change details stored on a case. The raw account and
/// routing numbers are write-only and never appear here — only a vault token
/// (`bankToken`) and non-sensitive details.
/// </summary>
[Serializable]
public record BankAccountChangeParameters : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The parameters type discriminator.
    /// </summary>
    [JsonPropertyName("type")]
    public required BankAccountChangeParametersType Type { get; set; }

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
    /// A vault token referencing the tokenized bank account. The raw account and routing numbers are never returned.
    /// </summary>
    [JsonPropertyName("bankToken")]
    public required string BankToken { get; set; }

    /// <summary>
    /// The account type, such as `Checking` or `Savings`.
    /// </summary>
    [JsonPropertyName("accountType")]
    public required string AccountType { get; set; }

    /// <summary>
    /// The account holder's name, taken from the paypoint's legal name.
    /// </summary>
    [JsonPropertyName("bankAccountHolderName")]
    public required string BankAccountHolderName { get; set; }

    /// <summary>
    /// The account holder type, such as `personal` or `business`.
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
