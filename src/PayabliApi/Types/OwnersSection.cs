using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Information about a business owner.
/// </summary>
[Serializable]
public record OwnersSection : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("contactEmail")]
    public TemplateElement? ContactEmail { get; set; }

    [JsonPropertyName("contactName")]
    public TemplateElement? ContactName { get; set; }

    [JsonPropertyName("contactPhone")]
    public TemplateElement? ContactPhone { get; set; }

    [JsonPropertyName("contactTitle")]
    public TemplateElement? ContactTitle { get; set; }

    /// <summary>
    /// Offer add more contacts
    /// </summary>
    [JsonPropertyName("multipleContacts")]
    public bool? MultipleContacts { get; set; }

    /// <summary>
    /// offer add more owners
    /// </summary>
    [JsonPropertyName("multipleOwners")]
    public bool? MultipleOwners { get; set; }

    [JsonPropertyName("oaddress")]
    public TemplateElement? Oaddress { get; set; }

    [JsonPropertyName("ocity")]
    public TemplateElement? Ocity { get; set; }

    [JsonPropertyName("ocountry")]
    public TemplateElement? Ocountry { get; set; }

    [JsonPropertyName("odriverstate")]
    public TemplateElement? Odriverstate { get; set; }

    [JsonPropertyName("ostate")]
    public TemplateElement? Ostate { get; set; }

    [JsonPropertyName("ownerdob")]
    public TemplateElement? Ownerdob { get; set; }

    [JsonPropertyName("ownerdriver")]
    public TemplateElement? Ownerdriver { get; set; }

    [JsonPropertyName("owneremail")]
    public TemplateElement? Owneremail { get; set; }

    [JsonPropertyName("ownername")]
    public TemplateElement? Ownername { get; set; }

    [JsonPropertyName("ownerpercent")]
    public TemplateElement? Ownerpercent { get; set; }

    [JsonPropertyName("ownerphone1")]
    public TemplateElement? Ownerphone1 { get; set; }

    [JsonPropertyName("ownerphone2")]
    public TemplateElement? Ownerphone2 { get; set; }

    [JsonPropertyName("ownerssn")]
    public TemplateElement? Ownerssn { get; set; }

    [JsonPropertyName("ownertitle")]
    public TemplateElement? Ownertitle { get; set; }

    [JsonPropertyName("ozip")]
    public TemplateElement? Ozip { get; set; }

    [JsonPropertyName("subFooter")]
    public string? SubFooter { get; set; }

    [JsonPropertyName("subHeader")]
    public string? SubHeader { get; set; }

    [JsonPropertyName("visible")]
    public bool? Visible { get; set; }

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
