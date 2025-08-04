using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record Owners : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Person who is registered as the beneficial owner of the business. This is a combination of first and last name.
    /// </summary>
    [JsonPropertyName("ownername")]
    public string? Ownername { get; set; }

    /// <summary>
    /// The job title of the person such as CEO or director.
    /// </summary>
    [JsonPropertyName("ownertitle")]
    public string? Ownertitle { get; set; }

    /// <summary>
    /// Percentage of ownership the person holds, in integer format.
    /// </summary>
    [JsonPropertyName("ownerpercent")]
    public int? Ownerpercent { get; set; }

    /// <summary>
    /// The relevant identifier for the person such as a Social Security Number.
    /// </summary>
    [JsonPropertyName("ownerssn")]
    public string? Ownerssn { get; set; }

    /// <summary>
    /// Owner's date of birth.
    /// </summary>
    [JsonPropertyName("ownerdob")]
    public string? Ownerdob { get; set; }

    /// <summary>
    /// Owner phone 1.
    /// </summary>
    [JsonPropertyName("ownerphone1")]
    public string? Ownerphone1 { get; set; }

    /// <summary>
    /// Owner phone 2.
    /// </summary>
    [JsonPropertyName("ownerphone2")]
    public string? Ownerphone2 { get; set; }

    /// <summary>
    /// Owner email.
    /// </summary>
    [JsonPropertyName("owneremail")]
    public string? Owneremail { get; set; }

    /// <summary>
    /// Owner driver's license ID number. Payabli strongly recommends including this.
    /// </summary>
    [JsonPropertyName("ownerdriver")]
    public string? Ownerdriver { get; set; }

    /// <summary>
    /// Owner street address. This must be the physical address of the owner, not a P.O. box.
    /// </summary>
    [JsonPropertyName("oaddress")]
    public string? Oaddress { get; set; }

    /// <summary>
    /// Owner address city.
    /// </summary>
    [JsonPropertyName("ocity")]
    public string? Ocity { get; set; }

    /// <summary>
    /// Owner address country in ISO-3166-1 alpha 2 format. Check out https://en.wikipedia.org/wiki/ISO_3166-1 for reference.
    /// </summary>
    [JsonPropertyName("ocountry")]
    public string? Ocountry { get; set; }

    /// <summary>
    /// Owner driver's license State. Payabli strongly recommends including this.
    /// </summary>
    [JsonPropertyName("odriverstate")]
    public string? Odriverstate { get; set; }

    /// <summary>
    /// Owner address state.
    /// </summary>
    [JsonPropertyName("ostate")]
    public string? Ostate { get; set; }

    /// <summary>
    /// Owner address ZIP.
    /// </summary>
    [JsonPropertyName("ozip")]
    public string? Ozip { get; set; }

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
