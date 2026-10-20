using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// A payment method as returned by read and list. Sensitive fields are masked.
/// </summary>
[Serializable]
public record PaymentMethodDetail : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Whether this is the owner's default payment method. Returned when you list payment methods, but not when you get a single payment method.
    /// </summary>
    [JsonPropertyName("isDefault")]
    public bool? IsDefault { get; set; }

    /// <summary>
    /// The payment method reference.
    /// </summary>
    [JsonPropertyName("paymentMethodReference")]
    public required string PaymentMethodReference { get; set; }

    /// <summary>
    /// The payment method type.
    /// </summary>
    [JsonPropertyName("type")]
    public required string Type { get; set; }

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
    /// The account type.
    /// </summary>
    [JsonPropertyName("accountType")]
    public string? AccountType { get; set; }

    /// <summary>
    /// The bank account number, masked (only the last four digits are shown).
    /// </summary>
    [JsonPropertyName("accountNumber")]
    public string? AccountNumber { get; set; }

    /// <summary>
    /// The bank routing number, masked.
    /// </summary>
    [JsonPropertyName("routingNumber")]
    public string? RoutingNumber { get; set; }

    /// <summary>
    /// The payment method's current status.
    /// </summary>
    [JsonPropertyName("status")]
    public required string Status { get; set; }

    /// <summary>
    /// What the payment method is used for.
    /// </summary>
    [JsonPropertyName("usage")]
    public IEnumerable<PaymentMethodUsage>? Usage { get; set; }

    /// <summary>
    /// When the payment method was created.
    /// </summary>
    [JsonPropertyName("createdAt")]
    public required string CreatedAt { get; set; }

    /// <summary>
    /// When the payment method was last updated.
    /// </summary>
    [JsonPropertyName("lastUpdated")]
    public required string LastUpdated { get; set; }

    /// <summary>
    /// Hypermedia links for the payment method resource.
    /// </summary>
    [JsonPropertyName("_links")]
    public required PaymentMethodLinks Links { get; set; }

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
