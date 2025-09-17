using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
///
/// </summary>
[Serializable]
public record BoardingLinkApiResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Reference name for boarding link (if responseText = Success) or
    /// List of empty fields separated by comma (if responseText = Fail)
    /// </summary>
    [JsonPropertyName("responseData")]
    public string? ResponseData { get; set; }

    [JsonPropertyName("responseText")]
    public required string ResponseText { get; set; }

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
