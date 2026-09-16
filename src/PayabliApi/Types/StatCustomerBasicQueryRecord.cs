using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record StatCustomerBasicQueryRecord : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The time bucket for this row, formatted according to the query's `freq` (for example, `2026-9` for a monthly bucket). The response returns one object per bucket across the requested range.
    /// </summary>
    [JsonPropertyName("statX")]
    public required string StatX { get; set; }

    /// <summary>
    /// Count of the customer's approved transactions.
    /// </summary>
    [JsonPropertyName("inTransactions")]
    public required int InTransactions { get; set; }

    /// <summary>
    /// Total gross value of the customer's approved transactions. Unlike `/Statistic/basic`, this volume is the gross amount, before fees.
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
