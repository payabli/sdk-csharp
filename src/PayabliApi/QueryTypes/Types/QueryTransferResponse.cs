using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record QueryTransferResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Summary information about the transfers.
    /// </summary>
    [JsonPropertyName("Summary")]
    public required QueryTransferSummary Summary { get; set; }

    /// <summary>
    /// List of transfer transaction records.
    /// </summary>
    [JsonPropertyName("Records")]
    public IEnumerable<TransactionQueryRecords> Records { get; set; } =
        new List<TransactionQueryRecords>();

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
