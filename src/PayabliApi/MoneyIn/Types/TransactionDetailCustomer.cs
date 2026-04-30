using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Customer information associated with the transaction
/// </summary>
[Serializable]
public record TransactionDetailCustomer : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("identifiers")]
    public IEnumerable<string>? Identifiers { get; set; }

    [JsonPropertyName("firstName")]
    public required string FirstName { get; set; }

    [JsonPropertyName("lastName")]
    public required string LastName { get; set; }

    [JsonPropertyName("companyName")]
    public string? CompanyName { get; set; }

    [JsonPropertyName("billingAddress1")]
    public string? BillingAddress1 { get; set; }

    [JsonPropertyName("billingAddress2")]
    public string? BillingAddress2 { get; set; }

    [JsonPropertyName("billingCity")]
    public string? BillingCity { get; set; }

    [JsonPropertyName("billingState")]
    public string? BillingState { get; set; }

    [JsonPropertyName("billingZip")]
    public string? BillingZip { get; set; }

    [JsonPropertyName("billingCountry")]
    public string? BillingCountry { get; set; }

    [JsonPropertyName("billingPhone")]
    public string? BillingPhone { get; set; }

    [JsonPropertyName("billingEmail")]
    public string? BillingEmail { get; set; }

    [JsonPropertyName("customerNumber")]
    public string? CustomerNumber { get; set; }

    [JsonPropertyName("shippingAddress1")]
    public string? ShippingAddress1 { get; set; }

    [JsonPropertyName("shippingAddress2")]
    public string? ShippingAddress2 { get; set; }

    [JsonPropertyName("shippingCity")]
    public string? ShippingCity { get; set; }

    [JsonPropertyName("shippingState")]
    public string? ShippingState { get; set; }

    [JsonPropertyName("shippingZip")]
    public string? ShippingZip { get; set; }

    [JsonPropertyName("shippingCountry")]
    public string? ShippingCountry { get; set; }

    [JsonPropertyName("customerId")]
    public required long CustomerId { get; set; }

    [JsonPropertyName("customerStatus")]
    public required int CustomerStatus { get; set; }

    [JsonPropertyName("additionalData")]
    public Dictionary<string, string>? AdditionalData { get; set; }

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
