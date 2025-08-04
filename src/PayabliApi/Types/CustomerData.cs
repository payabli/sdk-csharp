using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Data about a single customer.
/// </summary>
[Serializable]
public record CustomerData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("customerNumber")]
    public string? CustomerNumber { get; set; }

    /// <summary>
    /// Customer username for customer portal
    /// </summary>
    [JsonPropertyName("customerUsername")]
    public string? CustomerUsername { get; set; }

    /// <summary>
    /// Customer password for customer portal
    /// </summary>
    [JsonPropertyName("customerPsw")]
    public string? CustomerPsw { get; set; }

    [JsonPropertyName("customerStatus")]
    public int? CustomerStatus { get; set; }

    /// <summary>
    /// Company name
    /// </summary>
    [JsonPropertyName("company")]
    public string? Company { get; set; }

    /// <summary>
    /// Customer first name
    /// </summary>
    [JsonPropertyName("firstname")]
    public string? Firstname { get; set; }

    /// <summary>
    /// Customer last name
    /// </summary>
    [JsonPropertyName("lastname")]
    public string? Lastname { get; set; }

    /// <summary>
    /// Customer phone number
    /// </summary>
    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    /// <summary>
    /// Customer email address.
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>
    /// Customer address
    /// </summary>
    [JsonPropertyName("address")]
    public string? Address { get; set; }

    /// <summary>
    /// Additional customer address
    /// </summary>
    [JsonPropertyName("address1")]
    public string? Address1 { get; set; }

    /// <summary>
    /// Customer city
    /// </summary>
    [JsonPropertyName("city")]
    public string? City { get; set; }

    /// <summary>
    /// Customer State
    /// </summary>
    [JsonPropertyName("state")]
    public string? State { get; set; }

    /// <summary>
    /// Customer postal code
    /// </summary>
    [JsonPropertyName("zip")]
    public string? Zip { get; set; }

    /// <summary>
    /// Customer country in ISO-3166-1 alpha 2 format. See https://en.wikipedia.org/wiki/ISO_3166-1 for reference.
    /// </summary>
    [JsonPropertyName("country")]
    public string? Country { get; set; }

    [JsonPropertyName("shippingAddress")]
    public string? ShippingAddress { get; set; }

    [JsonPropertyName("shippingAddress1")]
    public string? ShippingAddress1 { get; set; }

    [JsonPropertyName("shippingCity")]
    public string? ShippingCity { get; set; }

    [JsonPropertyName("shippingState")]
    public string? ShippingState { get; set; }

    [JsonPropertyName("shippingZip")]
    public string? ShippingZip { get; set; }

    [JsonPropertyName("shippingCountry")]
    public string? ShippingCountry { get; set; }

    /// <summary>
    /// Customer balance.
    /// </summary>
    [JsonPropertyName("balance")]
    public double? Balance { get; set; }

    [JsonPropertyName("timeZone")]
    public int? TimeZone { get; set; }

    /// <summary>
    /// Additional Custom fields in format "key":"value".
    /// </summary>
    [JsonPropertyName("additionalFields")]
    public Dictionary<string, string?>? AdditionalFields { get; set; }

    [JsonPropertyName("identifierFields")]
    public IEnumerable<string>? IdentifierFields { get; set; }

    [JsonPropertyName("createdAt")]
    public DateTime? CreatedAt { get; set; }

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
