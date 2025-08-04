using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record PayabliCredentialsPascal : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("Service")]
    public string? Service { get; set; }

    [JsonPropertyName("Mode")]
    public int? Mode { get; set; }

    [JsonPropertyName("MinTicket")]
    public double? MinTicket { get; set; }

    [JsonPropertyName("MaxTicket")]
    public double? MaxTicket { get; set; }

    [JsonPropertyName("CfeeFix")]
    public double? CfeeFix { get; set; }

    [JsonPropertyName("CfeeFloat")]
    public double? CfeeFloat { get; set; }

    [JsonPropertyName("CfeeMin")]
    public double? CfeeMin { get; set; }

    [JsonPropertyName("CfeeMax")]
    public double? CfeeMax { get; set; }

    [JsonPropertyName("AccountId")]
    public string? AccountId { get; set; }

    [JsonPropertyName("ReferenceId")]
    public long? ReferenceId { get; set; }

    [JsonPropertyName("acceptSameDayACH")]
    public bool? AcceptSameDayAch { get; set; }

    /// <summary>
    /// The default currency for the paypoint, either `USD` or `CAD`.
    /// </summary>
    [JsonPropertyName("Currency")]
    public string? Currency { get; set; }

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
