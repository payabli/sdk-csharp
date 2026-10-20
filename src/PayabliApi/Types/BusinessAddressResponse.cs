using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// A business address, returned by the address endpoints.
/// </summary>
[Serializable]
public record BusinessAddressResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Hypermedia links for the business address resource.
    /// </summary>
    [JsonPropertyName("_links")]
    public required BusinessAddressLinks Links { get; set; }

    /// <summary>
    /// The reference of the business-to-address link, used to read and manage the address. Valid only under its own business.
    /// </summary>
    [JsonPropertyName("businessAddressReference")]
    public required string BusinessAddressReference { get; set; }

    /// <summary>
    /// The address role.
    /// </summary>
    [JsonPropertyName("type")]
    public required AddressType Type { get; set; }

    /// <summary>
    /// The physical use of the address.
    /// </summary>
    [JsonPropertyName("location")]
    public required BusinessAddressLocation Location { get; set; }

    /// <summary>
    /// The first line of the street address.
    /// </summary>
    [JsonPropertyName("addressLine1")]
    public required string AddressLine1 { get; set; }

    /// <summary>
    /// The second line of the street address.
    /// </summary>
    [JsonPropertyName("addressLine2")]
    public string? AddressLine2 { get; set; }

    /// <summary>
    /// The city or locality.
    /// </summary>
    [JsonPropertyName("cityLocality")]
    public required string CityLocality { get; set; }

    /// <summary>
    /// The state or province.
    /// </summary>
    [JsonPropertyName("stateProvince")]
    public required string StateProvince { get; set; }

    /// <summary>
    /// The postal or ZIP code.
    /// </summary>
    [JsonPropertyName("postalCode")]
    public required string PostalCode { get; set; }

    /// <summary>
    /// The two-character ISO country code.
    /// </summary>
    [JsonPropertyName("country")]
    public required string Country { get; set; }

    /// <summary>
    /// The floor, if applicable.
    /// </summary>
    [JsonPropertyName("floor")]
    public string? Floor { get; set; }

    /// <summary>
    /// The suite or apartment number, if applicable.
    /// </summary>
    [JsonPropertyName("suiteApartNumber")]
    public string? SuiteApartNumber { get; set; }

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
