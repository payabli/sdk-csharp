using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record TemplateQueryRecord : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("addPrice")]
    public bool? AddPrice { get; set; }

    [JsonPropertyName("boardingLinks")]
    public IEnumerable<BoardingQueryLinks>? BoardingLinks { get; set; }

    [JsonPropertyName("createdAt")]
    public DateTime? CreatedAt { get; set; }

    [JsonPropertyName("idTemplate")]
    public long? IdTemplate { get; set; }

    [JsonPropertyName("isRoot")]
    public bool? IsRoot { get; set; }

    [JsonPropertyName("orgParentName")]
    public string? OrgParentName { get; set; }

    [JsonPropertyName("recipientEmailNotification")]
    public bool? RecipientEmailNotification { get; set; }

    [JsonPropertyName("resumable")]
    public bool? Resumable { get; set; }

    [JsonPropertyName("templateCode")]
    public string? TemplateCode { get; set; }

    [JsonPropertyName("templateContent")]
    public TemplateContentResponse? TemplateContent { get; set; }

    [JsonPropertyName("templateDescription")]
    public string? TemplateDescription { get; set; }

    [JsonPropertyName("templateTitle")]
    public string? TemplateTitle { get; set; }

    [JsonPropertyName("usedBy")]
    public int? UsedBy { get; set; }

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
