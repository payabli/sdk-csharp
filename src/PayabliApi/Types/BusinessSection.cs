using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Details about a business.
/// </summary>
[Serializable]
public record BusinessSection : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("baddress")]
    public TemplateElement? Baddress { get; set; }

    [JsonPropertyName("baddress1")]
    public TemplateElement? Baddress1 { get; set; }

    [JsonPropertyName("bcity")]
    public TemplateElement? Bcity { get; set; }

    [JsonPropertyName("bcountry")]
    public TemplateElement? Bcountry { get; set; }

    [JsonPropertyName("bstate")]
    public TemplateElement? Bstate { get; set; }

    [JsonPropertyName("btype")]
    public TemplateElement? Btype { get; set; }

    [JsonPropertyName("bzip")]
    public TemplateElement? Bzip { get; set; }

    [JsonPropertyName("dbaname")]
    public TemplateElement? Dbaname { get; set; }

    [JsonPropertyName("ein")]
    public TemplateElement? Ein { get; set; }

    [JsonPropertyName("faxnumber")]
    public TemplateElement? Faxnumber { get; set; }

    [JsonPropertyName("legalname")]
    public TemplateElement? Legalname { get; set; }

    [JsonPropertyName("license")]
    public TemplateElement? License { get; set; }

    [JsonPropertyName("licstate")]
    public TemplateElement? Licstate { get; set; }

    [JsonPropertyName("maddress")]
    public TemplateElement? Maddress { get; set; }

    [JsonPropertyName("maddress1")]
    public TemplateElement? Maddress1 { get; set; }

    [JsonPropertyName("mcity")]
    public TemplateElement? Mcity { get; set; }

    [JsonPropertyName("mcountry")]
    public TemplateElement? Mcountry { get; set; }

    [JsonPropertyName("mstate")]
    public TemplateElement? Mstate { get; set; }

    [JsonPropertyName("mzip")]
    public TemplateElement? Mzip { get; set; }

    [JsonPropertyName("phonenumber")]
    public TemplateElement? Phonenumber { get; set; }

    [JsonPropertyName("startdate")]
    public TemplateElement? Startdate { get; set; }

    [JsonPropertyName("taxfillname")]
    public TemplateElement? Taxfillname { get; set; }

    [JsonPropertyName("visible")]
    public bool? Visible { get; set; }

    [JsonPropertyName("website")]
    public TemplateElement? Website { get; set; }

    [JsonPropertyName("additionalData")]
    public TemplateAdditionalDataSection? AdditionalData { get; set; }

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
