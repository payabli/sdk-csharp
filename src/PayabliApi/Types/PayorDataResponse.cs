using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Customer information.
/// </summary>
[Serializable]
public record PayorDataResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("AdditionalData")]
    public Dictionary<string, string>? AdditionalData { get; set; }

    [JsonPropertyName("BillingAddress1")]
    public string? BillingAddress1 { get; set; }

    [JsonPropertyName("BillingAddress2")]
    public string? BillingAddress2 { get; set; }

    [JsonPropertyName("BillingCity")]
    public string? BillingCity { get; set; }

    [JsonPropertyName("BillingCountry")]
    public string? BillingCountry { get; set; }

    [JsonPropertyName("BillingEmail")]
    public string? BillingEmail { get; set; }

    [JsonPropertyName("BillingPhone")]
    public string? BillingPhone { get; set; }

    [JsonPropertyName("BillingState")]
    public string? BillingState { get; set; }

    /// <summary>
    /// Customer's billing ZIP code. For Pay In functions, this field supports 5-digit and 9-digit ZIP codes and alphanumeric Canadian postal codes. For example: "37615-1234" or "37615".
    /// </summary>
    [JsonPropertyName("BillingZip")]
    public string? BillingZip { get; set; }

    /// <summary>
    /// Customer's company name.
    /// </summary>
    [JsonPropertyName("CompanyName")]
    public string? CompanyName { get; set; }

    [JsonPropertyName("customerId")]
    public long? CustomerId { get; set; }

    [JsonPropertyName("CustomerNumber")]
    public string? CustomerNumber { get; set; }

    /// <summary>
    /// Customer status. This is used to determine if the customer is active or inactive.
    /// </summary>
    [JsonPropertyName("customerStatus")]
    public int? CustomerStatus { get; set; }

    /// <summary>
    /// Customer/Payor first name.
    /// </summary>
    [JsonPropertyName("FirstName")]
    public string? FirstName { get; set; }

    [JsonPropertyName("Identifiers")]
    public IEnumerable<string>? Identifiers { get; set; }

    /// <summary>
    /// Customer/Payor last name.
    /// </summary>
    [JsonPropertyName("LastName")]
    public string? LastName { get; set; }

    [JsonPropertyName("ShippingAddress1")]
    public string? ShippingAddress1 { get; set; }

    [JsonPropertyName("ShippingAddress2")]
    public string? ShippingAddress2 { get; set; }

    [JsonPropertyName("ShippingCity")]
    public string? ShippingCity { get; set; }

    [JsonPropertyName("ShippingCountry")]
    public string? ShippingCountry { get; set; }

    [JsonPropertyName("ShippingState")]
    public string? ShippingState { get; set; }

    [JsonPropertyName("ShippingZip")]
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
