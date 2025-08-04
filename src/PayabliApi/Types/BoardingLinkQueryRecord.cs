using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record BoardingLinkQueryRecord : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("acceptOauth")]
    public bool? AcceptOauth { get; set; }

    [JsonPropertyName("acceptRegister")]
    public bool? AcceptRegister { get; set; }

    [JsonPropertyName("builderData")]
    public BuilderData? BuilderData { get; set; }

    [JsonPropertyName("entryAttributes")]
    public string? EntryAttributes { get; set; }

    [JsonPropertyName("id")]
    public long? Id { get; set; }

    /// <summary>
    /// Object containing logo file.
    /// </summary>
    [JsonPropertyName("logo")]
    public FileContent? Logo { get; set; }

    [JsonPropertyName("orgId")]
    public long? OrgId { get; set; }

    [JsonPropertyName("pageIdentifier:")]
    public string? PageIdentifier { get; set; }

    [JsonPropertyName("recipientEmailNotification")]
    public bool? RecipientEmailNotification { get; set; }

    [JsonPropertyName("referenceName")]
    public string? ReferenceName { get; set; }

    [JsonPropertyName("referenceTemplateId")]
    public long? ReferenceTemplateId { get; set; }

    [JsonPropertyName("resumable")]
    public bool? Resumable { get; set; }

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
