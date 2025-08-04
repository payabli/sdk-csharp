using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record CustomerSummaryRecord : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Number total of transactions or payments
    /// </summary>
    [JsonPropertyName("numberofTransactions")]
    public int? NumberofTransactions { get; set; }

    /// <summary>
    /// List of more recent 5 transactions belonging to the customer
    /// </summary>
    [JsonPropertyName("recentTransactions")]
    public IEnumerable<TransactionQueryRecords>? RecentTransactions { get; set; }

    /// <summary>
    /// Total amount in transactions
    /// </summary>
    [JsonPropertyName("totalAmountTransactions")]
    public double? TotalAmountTransactions { get; set; }

    /// <summary>
    /// Total net amount in transactions
    /// </summary>
    [JsonPropertyName("totalNetAmountTransactions")]
    public double? TotalNetAmountTransactions { get; set; }

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
