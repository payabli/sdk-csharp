using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Response body for queries about outbound transfer details.
/// </summary>
[Serializable]
public record TransferOutDetailQueryResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Summary information about the transfer details.
    /// </summary>
    [JsonPropertyName("Summary")]
    public required QueryTransferSummary Summary { get; set; }

    /// <summary>
    /// List of outbound transfer detail records.
    /// </summary>
    [JsonPropertyName("Records")]
    public IEnumerable<TransferOutDetailRecord> Records { get; set; } =
        new List<TransferOutDetailRecord>();

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
