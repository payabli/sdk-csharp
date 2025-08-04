using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record PSection : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("avgmonthly")]
    public LinkData? Avgmonthly { get; set; }

    [JsonPropertyName("binperson")]
    public LinkData? Binperson { get; set; }

    [JsonPropertyName("binphone")]
    public LinkData? Binphone { get; set; }

    [JsonPropertyName("binweb")]
    public LinkData? Binweb { get; set; }

    [JsonPropertyName("bsummary")]
    public LinkData? Bsummary { get; set; }

    [JsonPropertyName("highticketamt")]
    public LinkData? Highticketamt { get; set; }

    [JsonPropertyName("mcc")]
    public LinkData? Mcc { get; set; }

    [JsonPropertyName("ticketamt")]
    public LinkData? Ticketamt { get; set; }

    [JsonPropertyName("whenCharged")]
    public LinkData? WhenCharged { get; set; }

    [JsonPropertyName("whenDelivered")]
    public LinkData? WhenDelivered { get; set; }

    [JsonPropertyName("whenProvided")]
    public LinkData? WhenProvided { get; set; }

    [JsonPropertyName("whenRefunded")]
    public LinkData? WhenRefunded { get; set; }

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
