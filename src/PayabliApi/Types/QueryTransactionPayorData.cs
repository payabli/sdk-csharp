using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record QueryTransactionPayorData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Array of field names to be used as identifiers.
    /// </summary>
    [JsonPropertyName("Identifiers")]
    public IEnumerable<object>? Identifiers { get; set; }

    /// <summary>
    /// Customer/Payor first name.
    /// </summary>
    [JsonPropertyName("FirstName")]
    public string? FirstName { get; set; }

    /// <summary>
    /// Customer/Payor last name.
    /// </summary>
    [JsonPropertyName("LastName")]
    public string? LastName { get; set; }

    /// <summary>
    /// Customer's company name.
    /// </summary>
    [JsonPropertyName("CompanyName")]
    public string? CompanyName { get; set; }

    /// <summary>
    /// Customer's billing address.
    /// </summary>
    [JsonPropertyName("BillingAddress1")]
    public string? BillingAddress1 { get; set; }

    /// <summary>
    /// Additional line for Customer's billing address.
    /// </summary>
    [JsonPropertyName("BillingAddress2")]
    public string? BillingAddress2 { get; set; }

    /// <summary>
    /// Customer's billing city.
    /// </summary>
    [JsonPropertyName("BillingCity")]
    public string? BillingCity { get; set; }

    /// <summary>
    /// Customer's billing state. Must be 2-letter state code for address in US.
    /// </summary>
    [JsonPropertyName("BillingState")]
    public string? BillingState { get; set; }

    /// <summary>
    /// Customer's billing ZIP code.
    /// </summary>
    [JsonPropertyName("BillingZip")]
    public string? BillingZip { get; set; }

    /// <summary>
    /// Customer's billing country.
    /// </summary>
    [JsonPropertyName("BillingCountry")]
    public string? BillingCountry { get; set; }

    /// <summary>
    /// Customer's phone number.
    /// </summary>
    [JsonPropertyName("BillingPhone")]
    public string? BillingPhone { get; set; }

    /// <summary>
    /// Customer's email address.
    /// </summary>
    [JsonPropertyName("BillingEmail")]
    public string? BillingEmail { get; set; }

    [JsonPropertyName("CustomerNumber")]
    public string? CustomerNumber { get; set; }

    [JsonPropertyName("ShippingAddress1")]
    public string? ShippingAddress1 { get; set; }

    [JsonPropertyName("ShippingAddress2")]
    public string? ShippingAddress2 { get; set; }

    [JsonPropertyName("ShippingCity")]
    public string? ShippingCity { get; set; }

    [JsonPropertyName("ShippingState")]
    public string? ShippingState { get; set; }

    [JsonPropertyName("ShippingZip")]
    public string? ShippingZip { get; set; }

    [JsonPropertyName("ShippingCountry")]
    public string? ShippingCountry { get; set; }

    [JsonPropertyName("customerId")]
    public long? CustomerId { get; set; }

    [JsonPropertyName("customerStatus")]
    public int? CustomerStatus { get; set; }

    [JsonPropertyName("AdditionalData")]
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
