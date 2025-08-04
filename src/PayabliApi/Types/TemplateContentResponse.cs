using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record TemplateContentResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("businessData")]
    public BusinessSection? BusinessData { get; set; }

    [JsonPropertyName("documentsData")]
    public DocumentSection? DocumentsData { get; set; }

    [JsonPropertyName("ownershipData")]
    public OwnersSection? OwnershipData { get; set; }

    [JsonPropertyName("processingData")]
    public ProcessingSection? ProcessingData { get; set; }

    [JsonPropertyName("salesData")]
    public SalesSection? SalesData { get; set; }

    [JsonPropertyName("servicesData")]
    public ServicesSection? ServicesData { get; set; }

    [JsonPropertyName("underwritingData")]
    public UnderwritingDataResponse? UnderwritingData { get; set; }

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
