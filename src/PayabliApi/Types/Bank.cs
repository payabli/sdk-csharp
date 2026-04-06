using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Object that contains bank account details.
/// </summary>
[Serializable]
public record Bank : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The Payabli-assigned internal identifier for the bank account.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("id")]
    public int? Id { get; set; }

    /// <summary>
    /// An identifier for the bank account, used to specify which account handles payments when multiple accounts are configured. If not provided during creation or update, the system generates one in the format `acct-{first_digit}xxxxx{last_4_digits}` based on the account number. The mask always uses five `x` characters regardless of account number length. For example, account number `123456789` produces `acct-1xxxxx6789`. If a duplicate exists within the same service at the paypoint, a numeric suffix is appended, such as `acct-1xxxxx6789-2`. This value is also used as the identifier for the bank account's associated payment connector.
    /// </summary>
    [JsonPropertyName("accountId")]
    public string? AccountId { get; set; }

    [JsonPropertyName("nickname")]
    public string? Nickname { get; set; }

    [JsonPropertyName("bankName")]
    public string? BankName { get; set; }

    [JsonPropertyName("routingAccount")]
    public string? RoutingAccount { get; set; }

    [JsonPropertyName("accountNumber")]
    public string? AccountNumber { get; set; }

    [JsonPropertyName("typeAccount")]
    public TypeAccount? TypeAccount { get; set; }

    [JsonPropertyName("bankAccountHolderName")]
    public string? BankAccountHolderName { get; set; }

    [JsonPropertyName("bankAccountHolderType")]
    public BankAccountHolderType? BankAccountHolderType { get; set; }

    [JsonPropertyName("bankAccountFunction")]
    public int? BankAccountFunction { get; set; }

    /// <summary>
    /// Bank account verification status. When `true`, the account has been verified to exist and be in good standing based on vendor checks or previous processing histories.
    /// </summary>
    [JsonPropertyName("verified")]
    public bool? Verified { get; set; }

    /// <summary>
    /// Bank account status
    /// </summary>
    [JsonPropertyName("status")]
    public int? Status { get; set; }

    /// <summary>
    /// Array of services associated with this bank account
    /// </summary>
    [JsonPropertyName("services")]
    public IEnumerable<string>? Services { get; set; }

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
