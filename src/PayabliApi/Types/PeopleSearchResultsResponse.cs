using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// The results of a people search.
/// </summary>
[Serializable]
public record PeopleSearchResultsResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The matched records.
    /// </summary>
    [JsonPropertyName("results")]
    public IEnumerable<PeopleSearchResultResponse>? Results { get; set; }

    /// <summary>
    /// The total number of matches.
    /// </summary>
    [JsonPropertyName("total")]
    public required int Total { get; set; }

    /// <summary>
    /// Whether the person was sent to the identity vendor for evaluation.
    /// </summary>
    [JsonPropertyName("isEnrichedByVendor")]
    public required bool IsEnrichedByVendor { get; set; }

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
