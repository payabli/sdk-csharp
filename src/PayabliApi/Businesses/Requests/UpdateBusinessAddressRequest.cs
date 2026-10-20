using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record UpdateBusinessAddressRequest
{
    /// <summary>
    /// The address role.
    /// </summary>
    [JsonPropertyName("type")]
    public AddressType? Type { get; set; }

    /// <summary>
    /// The physical use of the address.
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

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
