using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record QueryBoardingLinksResponseRecordsItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("AcceptOauth")]
    public bool? AcceptOauth { get; set; }

    [JsonPropertyName("AcceptRegister")]
    public bool? AcceptRegister { get; set; }

    [JsonPropertyName("EntryAttributes")]
    public string? EntryAttributes { get; set; }

    /// <summary>
    /// The record ID.
    /// </summary>
    [JsonPropertyName("Id")]
    public int? Id { get; set; }

    [JsonPropertyName("LastUpdated")]
    public DateTime? LastUpdated { get; set; }

    [JsonPropertyName("OrgParentName")]
    public string? OrgParentName { get; set; }

    [JsonPropertyName("ReferenceName")]
    public string? ReferenceName { get; set; }

    [JsonPropertyName("ReferenceTemplateId")]
    public long? ReferenceTemplateId { get; set; }

    [JsonPropertyName("TemplateCode")]
    public string? TemplateCode { get; set; }

    [JsonPropertyName("TemplateName")]
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
