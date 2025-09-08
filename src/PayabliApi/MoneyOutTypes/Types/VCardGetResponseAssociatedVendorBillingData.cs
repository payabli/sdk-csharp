using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Billing data for the vendor.
/// </summary>
[Serializable]
public record VCardGetResponseAssociatedVendorBillingData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Unique identifier for billing data.
    /// </summary>
    [JsonPropertyName("id")]
    public int? Id { get; set; }

    /// <summary>
    /// Account identifier.
    /// </summary>
    [JsonPropertyName("accountId")]
    public string? AccountId { get; set; }

    /// <summary>
    /// Nickname for the account.
    /// </summary>
    [JsonPropertyName("nickname")]
    public string? Nickname { get; set; }

    /// <summary>
    /// Name of the bank used for transactions.
    /// </summary>
    [JsonPropertyName("bankName")]
    public string? BankName { get; set; }

    /// <summary>
    /// Routing number for the bank account.
    /// </summary>
    [JsonPropertyName("routingAccount")]
    public string? RoutingAccount { get; set; }

    /// <summary>
    /// Masked account number for transactions.
    /// </summary>
    [JsonPropertyName("accountNumber")]
    public string? AccountNumber { get; set; }

    /// <summary>
    /// Type of the bank account.
    /// </summary>
    [JsonPropertyName("typeAccount")]
    public string? TypeAccount { get; set; }

    /// <summary>
    /// Name of the bank account holder.
    /// </summary>
    [JsonPropertyName("bankAccountHolderName")]
    public string? BankAccountHolderName { get; set; }

    /// <summary>
    /// Type of bank account holder.
    /// </summary>
    [JsonPropertyName("bankAccountHolderType")]
    public string? BankAccountHolderType { get; set; }

    /// <summary>
    /// Function of the bank account.
    /// </summary>
    [JsonPropertyName("bankAccountFunction")]
    public int? BankAccountFunction { get; set; }

    /// <summary>
    /// Indicates if the account is verified.
    /// </summary>
    [JsonPropertyName("verified")]
    public bool? Verified { get; set; }

    /// <summary>
    /// Status of the billing data.
    /// </summary>
    [JsonPropertyName("status")]
    public int? Status { get; set; }

    /// <summary>
    /// Services associated with the account.
    /// </summary>
    [JsonPropertyName("services")]
    public IEnumerable<object>? Services { get; set; }

    /// <summary>
    /// Indicates if this is the default billing account.
    /// </summary>
    [JsonPropertyName("default")]
    public bool? Default { get; set; }

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
