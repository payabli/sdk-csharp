using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Summary of vendor's billing and transaction status.
/// </summary>
[Serializable]
public record VCardGetResponseAssociatedVendorSummary : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Number of active bills.
    /// </summary>
    [JsonPropertyName("ActiveBills")]
    public int? ActiveBills { get; set; }

    /// <summary>
    /// Total amount of active bills.
    /// </summary>
    [JsonPropertyName("ActiveBillsAmount")]
    public double? ActiveBillsAmount { get; set; }

    /// <summary>
    /// Number of bills that have been approved.
    /// </summary>
    [JsonPropertyName("ApprovedBills")]
    public int? ApprovedBills { get; set; }

    /// <summary>
    /// Total amount of approved bills.
    /// </summary>
    [JsonPropertyName("ApprovedBillsAmount")]
    public double? ApprovedBillsAmount { get; set; }

    /// <summary>
    /// Number of bills that have been disapproved.
    /// </summary>
    [JsonPropertyName("DisapprovedBills")]
    public int? DisapprovedBills { get; set; }

    /// <summary>
    /// Total amount of rejected bills.
    /// </summary>
    [JsonPropertyName("DisapprovedBillsAmount")]
    public double? DisapprovedBillsAmount { get; set; }

    /// <summary>
    /// Number of bills in transit.
    /// </summary>
    [JsonPropertyName("InTransitBills")]
    public int? InTransitBills { get; set; }

    /// <summary>
    /// Total amount of bills in transit.
    /// </summary>
    [JsonPropertyName("InTransitBillsAmount")]
    public double? InTransitBillsAmount { get; set; }

    /// <summary>
    /// Number of bills that are overdue.
    /// </summary>
    [JsonPropertyName("OverdueBills")]
    public int? OverdueBills { get; set; }

    /// <summary>
    /// Total amount of overdue bills.
    /// </summary>
    [JsonPropertyName("OverdueBillsAmount")]
    public double? OverdueBillsAmount { get; set; }

    /// <summary>
    /// Number of bills that have been paid.
    /// </summary>
    [JsonPropertyName("PaidBills")]
    public int? PaidBills { get; set; }

    /// <summary>
    /// Total amount of paid bills.
    /// </summary>
    [JsonPropertyName("PaidBillsAmount")]
    public double? PaidBillsAmount { get; set; }

    /// <summary>
    /// Number of bills pending approval or payment.
    /// </summary>
    [JsonPropertyName("PendingBills")]
    public int? PendingBills { get; set; }

    /// <summary>
    /// Total amount of pending bills.
    /// </summary>
    [JsonPropertyName("PendingBillsAmount")]
    public double? PendingBillsAmount { get; set; }

    /// <summary>
    /// Total number of bills.
    /// </summary>
    [JsonPropertyName("TotalBills")]
    public int? TotalBills { get; set; }

    /// <summary>
    /// Total amount of all bills.
    /// </summary>
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
