using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record AutoElement : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    /// <summary>
    /// Type of end date
    /// </summary>
    [JsonPropertyName("finish")]
    public Finishtype? Finish { get; set; }

    /// <summary>
    /// accepted frequencies for autopay
    /// </summary>
    [JsonPropertyName("frequency")]
    public FrequencyList? Frequency { get; set; }

    /// <summary>
    /// Value of pre-selected frequency
    /// </summary>
    [JsonPropertyName("frequencySelected")]
    public string? FrequencySelected { get; set; }

    /// <summary>
    /// Header text for section
    /// </summary>
    [JsonPropertyName("header")]
    public string? Header { get; set; }

    [JsonPropertyName("order")]
    public int? Order { get; set; }

    /// <summary>
    /// Range of days enabled in calendar. Leave empty to enable all days.
    /// </summary>
    [JsonPropertyName("startDate")]
    public string? StartDate { get; set; }

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
