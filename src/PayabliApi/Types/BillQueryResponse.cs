using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record BillQueryResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Summary statistics for the bill query response.
    /// </summary>
    [JsonPropertyName("Summary")]
    public BillQueryResponseSummary? Summary { get; set; }

    /// <summary>
    /// Array of bill records returned by the query.
    /// </summary>
    [JsonPropertyName("Records")]
    public IEnumerable<BillQueryRecord2>? Records { get; set; }

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
