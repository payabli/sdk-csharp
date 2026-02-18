using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Customer information. May be required, depending on the paypoint's settings. Required for subscriptions.
/// </summary>
[Serializable]
public record PayorDataRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("additionalData")]
    public Dictionary<string, Dictionary<string, object?>>? AdditionalData { get; set; }

    [JsonPropertyName("billingAddress1")]
    public string? BillingAddress1 { get; set; }

    [JsonPropertyName("billingAddress2")]
    public string? BillingAddress2 { get; set; }

    [JsonPropertyName("billingCity")]
    public string? BillingCity { get; set; }

    [JsonPropertyName("billingCountry")]
    public string? BillingCountry { get; set; }

    [JsonPropertyName("billingEmail")]
    public string? BillingEmail { get; set; }

    [JsonPropertyName("billingPhone")]
    public string? BillingPhone { get; set; }

    [JsonPropertyName("billingState")]
    public string? BillingState { get; set; }

    /// <summary>
    /// Customer's billing ZIP code. For Pay In functions, this field supports 5-digit and 9-digit ZIP codes and alphanumeric Canadian postal codes. For example: "37615-1234" or "37615".
    /// </summary>
    [JsonPropertyName("billingZip")]
    public string? BillingZip { get; set; }

    /// <summary>
    /// Customer's company name.
    /// </summary>
    [JsonPropertyName("company")]
    public string? Company { get; set; }

    [JsonPropertyName("customerId")]
    public long? CustomerId { get; set; }

    [JsonPropertyName("customerNumber")]
    public string? CustomerNumber { get; set; }

    /// <summary>
    /// Customer/Payor first name.
    /// </summary>
    [JsonPropertyName("firstName")]
    public string? FirstName { get; set; }

    [JsonPropertyName("identifierFields")]
    public IEnumerable<string>? IdentifierFields { get; set; }

    /// <summary>
    /// Customer/Payor last name.
    /// </summary>
    [JsonPropertyName("lastName")]
    public string? LastName { get; set; }

    [JsonPropertyName("shippingAddress1")]
    public string? ShippingAddress1 { get; set; }

    [JsonPropertyName("shippingAddress2")]
    public string? ShippingAddress2 { get; set; }

    [JsonPropertyName("shippingCity")]
    public string? ShippingCity { get; set; }

    [JsonPropertyName("shippingCountry")]
    public string? ShippingCountry { get; set; }

    [JsonPropertyName("shippingState")]
    public string? ShippingState { get; set; }

    [JsonPropertyName("shippingZip")]
    public string? ShippingZip { get; set; }

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
