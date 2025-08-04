using System.Text.Json;
using System.Text.Json.Serialization;
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
    /// A user-defined internal identifier for the bank account. This allows you to specify which bank account should be used for payments in cases where multiple accounts are configured.
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
