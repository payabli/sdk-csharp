using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record ProcessingSection : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("avgmonthly")]
    public TemplateElement? Avgmonthly { get; set; }

    [JsonPropertyName("binperson")]
    public TemplateElement? Binperson { get; set; }

    [JsonPropertyName("binphone")]
    public TemplateElement? Binphone { get; set; }

    [JsonPropertyName("binweb")]
    public TemplateElement? Binweb { get; set; }

    [JsonPropertyName("bsummary")]
    public TemplateElement? Bsummary { get; set; }

    [JsonPropertyName("highticketamt")]
    public TemplateElement? Highticketamt { get; set; }

    [JsonPropertyName("mcc")]
    public TemplateElement? Mcc { get; set; }

    [JsonPropertyName("subFooter")]
    public string? SubFooter { get; set; }

    [JsonPropertyName("subHeader")]
    public string? SubHeader { get; set; }

    [JsonPropertyName("ticketamt")]
    public TemplateElement? Ticketamt { get; set; }

    [JsonPropertyName("visible")]
    public bool? Visible { get; set; }

    [JsonPropertyName("whenCharged")]
    public TemplateElement? WhenCharged { get; set; }

    [JsonPropertyName("whenDelivered")]
    public TemplateElement? WhenDelivered { get; set; }

    [JsonPropertyName("whenProvided")]
    public TemplateElement? WhenProvided { get; set; }

    [JsonPropertyName("whenRefunded")]
    public TemplateElement? WhenRefunded { get; set; }

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
