using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Object with detailed error context.
/// </summary>
[Serializable]
public record PayabliErrorBodyResponseData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Human-readable explanation of what happened.
    /// </summary>
    [JsonPropertyName("explanation")]
    public string? Explanation { get; set; }

    /// <summary>
    /// Suggested resolution.
    /// </summary>
    [JsonPropertyName("todoAction")]
    public string? TodoAction { get; set; }

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
