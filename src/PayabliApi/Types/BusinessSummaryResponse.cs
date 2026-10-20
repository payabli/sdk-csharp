using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// A business as it appears in a list response.
/// </summary>
[Serializable]
public record BusinessSummaryResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The business reference.
    /// </summary>
    [JsonPropertyName("businessUuid")]
    public required string BusinessUuid { get; set; }

    /// <summary>
    /// The registered legal name of the business.
    /// </summary>
    [JsonPropertyName("legalName")]
    public string? LegalName { get; set; }

    /// <summary>
    /// The business's current status.
    /// </summary>
    [JsonPropertyName("businessStatus")]
    public required string BusinessStatus { get; set; }

    /// <summary>
    /// The organization entrypoint the business belongs to.
    /// </summary>
    [JsonPropertyName("parentReference")]
    public string? ParentReference { get; set; }

    /// <summary>
    /// When the business was created.
    /// </summary>
    [JsonPropertyName("createdAt")]
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// When the business was last updated.
    /// </summary>
    [JsonPropertyName("lastUpdated")]
    public required DateTime LastUpdated { get; set; }

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
