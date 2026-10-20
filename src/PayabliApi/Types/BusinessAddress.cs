using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// An address associated with a business.
/// </summary>
[Serializable]
public record BusinessAddress : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The address role.
    /// </summary>
    [JsonPropertyName("type")]
    public AddressType? Type { get; set; }

    /// <summary>
    /// The physical use of the address. Defaults to `other`.
    /// </summary>
    [JsonPropertyName("location")]
    public BusinessAddressLocation? Location { get; set; }

    /// <summary>
    /// The first line of the street address.
    /// </summary>
    [JsonPropertyName("addressLine1")]
    public string? AddressLine1 { get; set; }

    /// <summary>
    /// The second line of the street address.
    /// </summary>
    [JsonPropertyName("addressLine2")]
    public string? AddressLine2 { get; set; }

    /// <summary>
    /// The city or locality.
    /// </summary>
    [JsonPropertyName("cityLocality")]
    public string? CityLocality { get; set; }

    /// <summary>
    /// The state or province.
    /// </summary>
    [JsonPropertyName("stateProvince")]
    public string? StateProvince { get; set; }

    /// <summary>
    /// The postal or ZIP code.
    /// </summary>
    [JsonPropertyName("postalCode")]
    public string? PostalCode { get; set; }

    /// <summary>
    /// The two-character ISO country code.
    /// </summary>
    [JsonPropertyName("country")]
    public string? Country { get; set; }

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
