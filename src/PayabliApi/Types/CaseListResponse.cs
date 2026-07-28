using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// A paginated list of cases.
/// </summary>
[Serializable]
public record CaseListResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("summary")]
    public required CaseListSummary Summary { get; set; }

    /// <summary>
    /// The cases on this page. Each record is a full case object.
    /// </summary>
    [JsonPropertyName("records")]
    public IEnumerable<CaseResponse> Records { get; set; } = new List<CaseResponse>();

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
