using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record OList : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("oaddress")]
    public LinkData? Oaddress { get; set; }

    [JsonPropertyName("ocity")]
    public LinkData? Ocity { get; set; }

    [JsonPropertyName("ocountry")]
    public LinkData? Ocountry { get; set; }

    [JsonPropertyName("odriverstate")]
    public LinkData? Odriverstate { get; set; }

    [JsonPropertyName("ostate")]
    public LinkData? Ostate { get; set; }

    [JsonPropertyName("ownerdob")]
    public LinkData? Ownerdob { get; set; }

    [JsonPropertyName("ownerdriver")]
    public LinkData? Ownerdriver { get; set; }

    [JsonPropertyName("owneremail")]
    public LinkData? Owneremail { get; set; }

    [JsonPropertyName("ownername")]
    public LinkData? Ownername { get; set; }

    [JsonPropertyName("ownerpercent")]
    public LinkData? Ownerpercent { get; set; }

    [JsonPropertyName("ownerphone1")]
    public LinkData? Ownerphone1 { get; set; }

    [JsonPropertyName("ownerphone2")]
    public LinkData? Ownerphone2 { get; set; }

    [JsonPropertyName("ownerssn")]
    public LinkData? Ownerssn { get; set; }

    [JsonPropertyName("ownertitle")]
    public LinkData? Ownertitle { get; set; }

    [JsonPropertyName("ozip")]
    public LinkData? Ozip { get; set; }

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
