using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record BDetails : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("btype")]
    public LinkData? Btype { get; set; }

    [JsonPropertyName("dbaname")]
    public LinkData? Dbaname { get; set; }

    [JsonPropertyName("ein")]
    public LinkData? Ein { get; set; }

    [JsonPropertyName("faxnumber")]
    public LinkData? Faxnumber { get; set; }

    [JsonPropertyName("legalname")]
    public LinkData? Legalname { get; set; }

    [JsonPropertyName("license")]
    public LinkData? License { get; set; }

    [JsonPropertyName("licstate")]
    public LinkData? Licstate { get; set; }

    [JsonPropertyName("phonenumber")]
    public LinkData? Phonenumber { get; set; }

    [JsonPropertyName("startdate")]
    public LinkData? Startdate { get; set; }

    [JsonPropertyName("taxfillname")]
    public LinkData? Taxfillname { get; set; }

    [JsonPropertyName("website")]
    public LinkData? Website { get; set; }

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
