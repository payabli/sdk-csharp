using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// The reference and initial status of a newly created business.
/// </summary>
[Serializable]
public record BusinessCreatedResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The business reference, used to read and manage the business.
    /// </summary>
    [JsonPropertyName("businessUuid")]
    public required string BusinessUuid { get; set; }

    /// <summary>
    /// The business status. New businesses start in Draft.
    /// </summary>
    [JsonPropertyName("businessStatus")]
    public required string BusinessStatus { get; set; }

    /// <summary>
    /// When the business was created.
    /// </summary>
    [JsonPropertyName("createdAt")]
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// Hypermedia links for the business resource.
    /// </summary>
    [JsonPropertyName("_links")]
    public required BusinessLinks Links { get; set; }

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
