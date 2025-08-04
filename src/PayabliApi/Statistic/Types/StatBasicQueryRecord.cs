using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record StatBasicQueryRecord : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Statistical grouping identifier
    /// </summary>
    [JsonPropertyName("statX")]
    public required string StatX { get; set; }

    /// <summary>
    /// Number of incoming transactions
    /// </summary>
    [JsonPropertyName("inTransactions")]
    public required int InTransactions { get; set; }

    /// <summary>
    /// Volume of incoming transactions
    /// </summary>
    [JsonPropertyName("inTransactionsVolume")]
    public required double InTransactionsVolume { get; set; }

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
