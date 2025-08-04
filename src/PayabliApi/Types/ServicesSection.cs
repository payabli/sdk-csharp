using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Details about pricing and payment services for a business.
/// </summary>
[Serializable]
public record ServicesSection : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("ach")]
    public AchService? Ach { get; set; }

    [JsonPropertyName("card")]
    public CardService? Card { get; set; }

    [JsonPropertyName("subFooter")]
    public string? SubFooter { get; set; }

    [JsonPropertyName("subHeader")]
    public string? SubHeader { get; set; }

    [JsonPropertyName("visible")]
    public bool? Visible { get; set; }

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
