using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// A payment method as returned by create, update, and deactivate. Sensitive fields are masked.
/// </summary>
[Serializable]
public record PaymentMethodResult : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The payment method reference, used to read and manage the payment method.
    /// </summary>
    [JsonPropertyName("paymentMethodReference")]
    public required string PaymentMethodReference { get; set; }

    /// <summary>
    /// The payment method type.
    /// </summary>
    [JsonPropertyName("type")]
    public required string Type { get; set; }

    /// <summary>
    /// A hash that uniquely identifies the underlying account, used to detect duplicates.
    /// </summary>
    [JsonPropertyName("fingerprint")]
    public string? Fingerprint { get; set; }

    /// <summary>
    /// The reference of the stored token for the payment method.
    /// </summary>
    [JsonPropertyName("tokenReference")]
    public string? TokenReference { get; set; }

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
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// When the payment method was last updated.
    /// </summary>
    [JsonPropertyName("lastUpdated")]
    public required DateTime LastUpdated { get; set; }

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
