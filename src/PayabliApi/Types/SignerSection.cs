using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record SignerSection : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("visible")]
    public bool? Visible { get; set; }

    [JsonPropertyName("name")]
    public TemplateElement? Name { get; set; }

    [JsonPropertyName("ssn")]
    public TemplateElement? Ssn { get; set; }

    [JsonPropertyName("dob")]
    public TemplateElement? Dob { get; set; }

    [JsonPropertyName("phone")]
    public TemplateElement? Phone { get; set; }

    [JsonPropertyName("email")]
    public TemplateElement? Email { get; set; }

    [JsonPropertyName("address")]
    public TemplateElement? Address { get; set; }

    [JsonPropertyName("address1")]
    public TemplateElement? Address1 { get; set; }

    [JsonPropertyName("city")]
    public TemplateElement? City { get; set; }

    [JsonPropertyName("country")]
    public TemplateElement? Country { get; set; }

    [JsonPropertyName("state")]
    public TemplateElement? State { get; set; }

    [JsonPropertyName("zip")]
    public TemplateElement? Zip { get; set; }

    [JsonPropertyName("acceptance")]
    public TemplateElement? Acceptance { get; set; }

    [JsonPropertyName("signedDocumentReference")]
    public TemplateElement? SignedDocumentReference { get; set; }

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
