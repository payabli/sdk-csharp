using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Contact information structure.
/// </summary>
[Serializable]
public record VCardGetResponseContact : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Name of the contact.
    /// </summary>
    [JsonPropertyName("ContactName")]
    public string? ContactName { get; set; }

    /// <summary>
    /// Email of the contact.
    /// </summary>
    [JsonPropertyName("ContactEmail")]
    public string? ContactEmail { get; set; }

    /// <summary>
    /// Title of the contact.
    /// </summary>
    [JsonPropertyName("ContactTitle")]
    public string? ContactTitle { get; set; }

    /// <summary>
    /// Phone number of the contact.
    /// </summary>
    [JsonPropertyName("ContactPhone")]
    public string? ContactPhone { get; set; }

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
