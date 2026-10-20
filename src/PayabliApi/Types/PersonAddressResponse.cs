using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// An address in a person response.
/// </summary>
[Serializable]
public record PersonAddressResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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
    /// The two-letter state or province code.
    /// </summary>
    [JsonPropertyName("stateProvince")]
    public string? StateProvince { get; set; }

    /// <summary>
    /// The postal or ZIP code.
    /// </summary>
    [JsonPropertyName("postalCode")]
    public string? PostalCode { get; set; }

    /// <summary>
    /// The two-letter ISO 3166-1 alpha-2 country code.
    /// </summary>
    [JsonPropertyName("country")]
    public string? Country { get; set; }

    /// <summary>
    /// The role the address plays for the person, for example `legal` or `physical`.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

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
