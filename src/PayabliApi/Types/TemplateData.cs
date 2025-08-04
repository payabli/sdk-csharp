using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Object containing the template's data.
/// </summary>
[Serializable]
public record TemplateData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The ID of the organization the template belongs to.
    /// </summary>
    [JsonPropertyName("orgId")]
    public long? OrgId { get; set; }

    [JsonPropertyName("pricingId")]
    public long? PricingId { get; set; }

    [JsonPropertyName("templateCode")]
    public string? TemplateCode { get; set; }

    [JsonPropertyName("templateContent")]
    public TemplateContent? TemplateContent { get; set; }

    /// <summary>
    /// A description for the template.
    /// </summary>
    [JsonPropertyName("templateDescription")]
    public string? TemplateDescription { get; set; }

    [JsonPropertyName("templateName")]
    public string? TemplateName { get; set; }

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
