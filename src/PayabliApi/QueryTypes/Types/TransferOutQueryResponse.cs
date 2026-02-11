using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Response body for queries about outbound transfers.
/// </summary>
[Serializable]
public record TransferOutQueryResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Summary information about the transfers.
    /// </summary>
    [JsonPropertyName("Summary")]
    public required TransferOutSummary Summary { get; set; }

    /// <summary>
    /// List of outbound transfer records.
    /// </summary>
    [JsonPropertyName("Records")]
    public IEnumerable<TransferOutRecord> Records { get; set; } = new List<TransferOutRecord>();

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
