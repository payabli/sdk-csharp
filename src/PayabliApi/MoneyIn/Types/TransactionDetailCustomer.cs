using System.Text.Json;
using System.Text.Json.Serialization;
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
    public required string CompanyName { get; set; }

    [JsonPropertyName("billingAddress1")]
    public required string BillingAddress1 { get; set; }

    [JsonPropertyName("billingAddress2")]
    public required string BillingAddress2 { get; set; }

    [JsonPropertyName("billingCity")]
    public required string BillingCity { get; set; }

    [JsonPropertyName("billingState")]
    public required string BillingState { get; set; }

    [JsonPropertyName("billingZip")]
    public required string BillingZip { get; set; }

    [JsonPropertyName("billingCountry")]
    public required string BillingCountry { get; set; }

    [JsonPropertyName("billingPhone")]
    public required string BillingPhone { get; set; }

    [JsonPropertyName("billingEmail")]
    public required string BillingEmail { get; set; }

    [JsonPropertyName("customerNumber")]
    public required string CustomerNumber { get; set; }

    [JsonPropertyName("shippingAddress1")]
    public required string ShippingAddress1 { get; set; }

    [JsonPropertyName("shippingAddress2")]
    public required string ShippingAddress2 { get; set; }

    [JsonPropertyName("shippingCity")]
    public required string ShippingCity { get; set; }

    [JsonPropertyName("shippingState")]
    public required string ShippingState { get; set; }

    [JsonPropertyName("shippingZip")]
    public required string ShippingZip { get; set; }

    [JsonPropertyName("shippingCountry")]
    public required string ShippingCountry { get; set; }

    [JsonPropertyName("customerId")]
    public required long CustomerId { get; set; }

    [JsonPropertyName("customerStatus")]
    public required int CustomerStatus { get; set; }

    [JsonPropertyName("additionalData")]
    public string? AdditionalData { get; set; }

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
