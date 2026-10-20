using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// A bank account or card attached to a business.
/// </summary>
[Serializable]
public record BusinessPaymentMethod : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The payment method type, for example a bank account or card.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// The name of the account owner.
    /// </summary>
    [JsonPropertyName("accountOwner")]
    public string? AccountOwner { get; set; }

    /// <summary>
    /// An optional label for the payment method.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The bank or financial institution that holds the account.
    /// </summary>
    [JsonPropertyName("financialInstitution")]
    public string? FinancialInstitution { get; set; }

    /// <summary>
    /// Whether the owner is a business or an individual.
    /// </summary>
    [JsonPropertyName("ownerType")]
    public string? OwnerType { get; set; }

    /// <summary>
    /// The account type, for example checking or savings.
    /// </summary>
    [JsonPropertyName("accountType")]
    public string? AccountType { get; set; }

    /// <summary>
    /// The bank account number.
    /// </summary>
    [JsonPropertyName("accountNumber")]
    public string? AccountNumber { get; set; }

    /// <summary>
    /// The bank routing number.
    /// </summary>
    [JsonPropertyName("routingNumber")]
    public string? RoutingNumber { get; set; }

    /// <summary>
    /// The card number, for card payment methods.
    /// </summary>
    [JsonPropertyName("cardNumber")]
    public string? CardNumber { get; set; }

    /// <summary>
    /// The card expiration date, for card payment methods.
    /// </summary>
    [JsonPropertyName("expirationDate")]
    public string? ExpirationDate { get; set; }

    /// <summary>
    /// The card verification value, for card payment methods.
    /// </summary>
    [JsonPropertyName("cvv")]
    public string? Cvv { get; set; }

    /// <summary>
    /// The card type, for card payment methods.
    /// </summary>
    [JsonPropertyName("cardType")]
    public string? CardType { get; set; }

    /// <summary>
    /// What the payment method is used for.
    /// </summary>
    [JsonPropertyName("usage")]
    public IEnumerable<string>? Usage { get; set; }

    /// <summary>
    /// Whether this is the owner's default payment method. At most one payment
    /// method per owner can set `isDefault` to `true`; sending two `true` values
    /// in one request fails validation.
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
