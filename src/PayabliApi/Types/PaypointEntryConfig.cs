using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record PaypointEntryConfig : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("EntryComment")]
    public string? EntryComment { get; set; }

    [JsonPropertyName("EntryLogo")]
    public string? EntryLogo { get; set; }

    [JsonPropertyName("EntryName")]
    public string? EntryName { get; set; }

    [JsonPropertyName("EntryPages")]
    public IEnumerable<PayabliPages>? EntryPages { get; set; }

    [JsonPropertyName("EntrySubtitle")]
    public string? EntrySubtitle { get; set; }

    [JsonPropertyName("EntryTitle")]
    public string? EntryTitle { get; set; }

    [JsonPropertyName("IdEntry")]
    public long? IdEntry { get; set; }

    [JsonPropertyName("Paypoint")]
    public PaypointData? Paypoint { get; set; }

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
