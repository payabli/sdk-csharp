using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record LinkData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("ro")]
    public bool? Ro { get; set; }

    [JsonPropertyName("rq")]
    public bool? Rq { get; set; }

    /// <summary>
    /// The type of validation applied to the field. Available values:
    /// - text
    /// - alpha
    /// - ein
    /// - url
    /// - phone
    /// - alphanumeric
    /// - zipcode
    /// - numbers
    /// - float
    /// - ssn
    /// - email
    /// - routing
    /// </summary>
    [JsonPropertyName("validator")]
    public string? Validator { get; set; }

    [JsonPropertyName("value")]
    public string? Value { get; set; }

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
