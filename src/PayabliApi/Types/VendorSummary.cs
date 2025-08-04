using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record VendorSummary : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("inTransitBills")]
    public int? InTransitBills { get; set; }

    [JsonPropertyName("inTransitBillsAmount")]
    public double? InTransitBillsAmount { get; set; }

    [JsonPropertyName("overdueBills")]
    public int? OverdueBills { get; set; }

    [JsonPropertyName("overdueBillsAmount")]
    public double? OverdueBillsAmount { get; set; }

    [JsonPropertyName("paidBills")]
    public int? PaidBills { get; set; }

    [JsonPropertyName("paidBillsAmount")]
    public double? PaidBillsAmount { get; set; }

    [JsonPropertyName("pendingBills")]
    public int? PendingBills { get; set; }

    [JsonPropertyName("pendingBillsAmount")]
    public double? PendingBillsAmount { get; set; }

    [JsonPropertyName("totalBills")]
    public int? TotalBills { get; set; }

    [JsonPropertyName("totalBillsAmount")]
    public double? TotalBillsAmount { get; set; }

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
