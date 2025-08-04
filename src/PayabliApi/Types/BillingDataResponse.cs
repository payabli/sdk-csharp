using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record BillingDataResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("accountNumber")]
    public string? AccountNumber { get; set; }

    /// <summary>
    /// Describes whether the bank account is used for deposits or withdrawals in Payabli:
    ///   - `0`: Deposit
    ///   - `1`: Withdrawal
    ///   - `2`: Deposit and withdrawal
    /// </summary>
    [JsonPropertyName("bankAccountFunction")]
    public int? BankAccountFunction { get; set; }

    [JsonPropertyName("bankAccountHolderName")]
    public string? BankAccountHolderName { get; set; }

    [JsonPropertyName("bankAccountHolderType")]
    public BankAccountHolderType? BankAccountHolderType { get; set; }

    [JsonPropertyName("bankName")]
    public string? BankName { get; set; }

    /// <summary>
    /// The bank's ID in Payabli.
    /// </summary>
    [JsonPropertyName("id")]
    public int? Id { get; set; }

    [JsonPropertyName("routingAccount")]
    public string? RoutingAccount { get; set; }

    [JsonPropertyName("typeAccount")]
    public TypeAccount? TypeAccount { get; set; }

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
