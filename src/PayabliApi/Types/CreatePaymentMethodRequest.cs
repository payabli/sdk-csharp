using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// A single payment method to create.
/// </summary>
[Serializable]
public record CreatePaymentMethodRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The payment method type.
    /// </summary>
    [JsonPropertyName("type")]
    public required CreatePaymentMethodRequestType Type { get; set; }

    /// <summary>
    /// The reference of the person or business that owns the payment method (for example, a business `businessUuid` or a person `personReference`).
    /// </summary>
    [JsonPropertyName("accountOwner")]
    public required string AccountOwner { get; set; }

    /// <summary>
    /// Whether the owner is a `person` or a `business`.
    /// </summary>
    [JsonPropertyName("ownerType")]
    public required PaymentMethodOwnerType OwnerType { get; set; }

    /// <summary>
    /// An optional label for the payment method.
    /// </summary>
    [JsonPropertyName("nickname")]
    public string? Nickname { get; set; }

    /// <summary>
    /// The bank or financial institution that holds the account.
    /// </summary>
    [JsonPropertyName("financialInstitution")]
    public string? FinancialInstitution { get; set; }

    /// <summary>
    /// The account type, for example `checking` or `savings`.
    /// </summary>
    [JsonPropertyName("accountType")]
    public required string AccountType { get; set; }

    /// <summary>
    /// The bank account number.
    /// </summary>
    [JsonPropertyName("accountNumber")]
    public required string AccountNumber { get; set; }

    /// <summary>
    /// The bank routing number.
    /// </summary>
    [JsonPropertyName("routingNumber")]
    public required string RoutingNumber { get; set; }

    /// <summary>
    /// What the payment method is used for. Provide at least one value.
    /// </summary>
    [JsonPropertyName("usage")]
    public IEnumerable<PaymentMethodUsage> Usage { get; set; } = new List<PaymentMethodUsage>();

    /// <summary>
    /// When `true`, makes this the owner's default payment method. If the owner
    /// already has a default, this payment method replaces it.
    /// </summary>
    [JsonPropertyName("isDefault")]
    public bool? IsDefault { get; set; }

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
