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

    [JsonPropertyName("ActiveBills")]
    public int? ActiveBills { get; set; }

    [JsonPropertyName("PendingBills")]
    public int? PendingBills { get; set; }

    [JsonPropertyName("InTransitBills")]
    public int? InTransitBills { get; set; }

    [JsonPropertyName("PaidBills")]
    public int? PaidBills { get; set; }

    [JsonPropertyName("OverdueBills")]
    public int? OverdueBills { get; set; }

    [JsonPropertyName("ApprovedBills")]
    public int? ApprovedBills { get; set; }

    [JsonPropertyName("DisapprovedBills")]
    public int? DisapprovedBills { get; set; }

    [JsonPropertyName("TotalBills")]
    public int? TotalBills { get; set; }

    [JsonPropertyName("ActiveBillsAmount")]
    public double? ActiveBillsAmount { get; set; }

    [JsonPropertyName("PendingBillsAmount")]
    public double? PendingBillsAmount { get; set; }

    [JsonPropertyName("InTransitBillsAmount")]
    public double? InTransitBillsAmount { get; set; }

    [JsonPropertyName("PaidBillsAmount")]
    public double? PaidBillsAmount { get; set; }

    [JsonPropertyName("OverdueBillsAmount")]
    public double? OverdueBillsAmount { get; set; }

    [JsonPropertyName("ApprovedBillsAmount")]
    public double? ApprovedBillsAmount { get; set; }

    [JsonPropertyName("DisapprovedBillsAmount")]
    public double? DisapprovedBillsAmount { get; set; }

    [JsonPropertyName("TotalBillsAmount")]
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
