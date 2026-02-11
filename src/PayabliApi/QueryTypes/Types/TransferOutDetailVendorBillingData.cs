using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Billing data for a vendor.
/// </summary>
[Serializable]
public record TransferOutDetailVendorBillingData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Unique identifier for the billing data.
    /// </summary>
    [JsonPropertyName("id")]
    public int? Id { get; set; }

    /// <summary>
    /// The account ID.
    /// </summary>
    [JsonPropertyName("accountId")]
    public string? AccountId { get; set; }

    /// <summary>
    /// A nickname for the account.
    /// </summary>
    [JsonPropertyName("nickname")]
    public string? Nickname { get; set; }

    /// <summary>
    /// The name of the bank.
    /// </summary>
    [JsonPropertyName("bankName")]
    public string? BankName { get; set; }

    /// <summary>
    /// The routing number.
    /// </summary>
    [JsonPropertyName("routingAccount")]
    public string? RoutingAccount { get; set; }

    /// <summary>
    /// The account number.
    /// </summary>
    [JsonPropertyName("accountNumber")]
    public string? AccountNumber { get; set; }

    /// <summary>
    /// The type of account.
    /// </summary>
    [JsonPropertyName("typeAccount")]
    public string? TypeAccount { get; set; }

    /// <summary>
    /// The name of the account holder.
    /// </summary>
    [JsonPropertyName("bankAccountHolderName")]
    public string? BankAccountHolderName { get; set; }

    /// <summary>
    /// The type of account holder.
    /// </summary>
    [JsonPropertyName("bankAccountHolderType")]
    public string? BankAccountHolderType { get; set; }

    /// <summary>
    /// The function of the bank account.
    /// </summary>
    [JsonPropertyName("bankAccountFunction")]
    public int? BankAccountFunction { get; set; }

    /// <summary>
    /// Whether the account is verified.
    /// </summary>
    [JsonPropertyName("verified")]
    public bool? Verified { get; set; }

    /// <summary>
    /// The status of the billing data.
    /// </summary>
    [JsonPropertyName("status")]
    public int? Status { get; set; }

    /// <summary>
    /// Services associated with the billing data.
    /// </summary>
    [JsonPropertyName("services")]
    public IEnumerable<object>? Services { get; set; }

    /// <summary>
    /// Whether this is the default billing data.
    /// </summary>
    [JsonPropertyName("default")]
    public bool? Default { get; set; }

    /// <summary>
    /// The country of the bank account.
    /// </summary>
    [JsonPropertyName("country")]
    public string? Country { get; set; }

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
