using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Response body for queries about virtual card transactions.
/// </summary>
[Serializable]
public record VCardTransactionQueryResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("Summary")]
    public required VCardSummary Summary { get; set; }

    [JsonPropertyName("Records")]
    public IEnumerable<VCardTransactionRecord> Records { get; set; } =
        new List<VCardTransactionRecord>();

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
