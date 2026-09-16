using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record StatisticsVendorQueryRecord : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The time bucket for this row, formatted according to the query's `freq` (for example, `2025-11` for a monthly bucket). Each bill falls in the bucket of its most recent update. The counts below break the vendor's bills down by bill state.
    /// </summary>
    [JsonPropertyName("statX")]
    public required string StatX { get; set; }

    /// <summary>
    /// Number of the vendor's bills in the active state (created, not yet submitted for approval).
    /// </summary>
    [JsonPropertyName("active")]
    public required int Active { get; set; }

    /// <summary>
    /// Total value of the vendor's active bills, net of fees.
    /// </summary>
    [JsonPropertyName("activeVolume")]
    public required double ActiveVolume { get; set; }

    /// <summary>
    /// Number of the vendor's bills submitted into an approval workflow.
    /// </summary>
    [JsonPropertyName("sentToApproval")]
    public required int SentToApproval { get; set; }

    /// <summary>
    /// Total value of the vendor's bills sent to approval, net of fees.
    /// </summary>
    [JsonPropertyName("sentToApprovalVolume")]
    public required double SentToApprovalVolume { get; set; }

    /// <summary>
    /// Number of the vendor's bills awaiting an approver's decision.
    /// </summary>
    [JsonPropertyName("toApproval")]
    public required int ToApproval { get; set; }

    /// <summary>
    /// Total value of the vendor's bills awaiting approval, net of fees.
    /// </summary>
    [JsonPropertyName("toApprovalVolume")]
    public required double ToApprovalVolume { get; set; }

    /// <summary>
    /// Number of the vendor's bills approved for payment.
    /// </summary>
    [JsonPropertyName("approved")]
    public required int Approved { get; set; }

    /// <summary>
    /// Total value of the vendor's approved bills, net of fees.
    /// </summary>
    [JsonPropertyName("approvedVolume")]
    public required double ApprovedVolume { get; set; }

    /// <summary>
    /// Number of the vendor's bills rejected during approval.
    /// </summary>
    [JsonPropertyName("disapproved")]
    public required int Disapproved { get; set; }

    /// <summary>
    /// Total value of the vendor's disapproved bills, net of fees.
    /// </summary>
    [JsonPropertyName("disapprovedVolume")]
    public required double DisapprovedVolume { get; set; }

    /// <summary>
    /// Number of the vendor's cancelled bills.
    /// </summary>
    [JsonPropertyName("cancelled")]
    public required int Cancelled { get; set; }

    /// <summary>
    /// Total value of the vendor's cancelled bills, net of fees.
    /// </summary>
    [JsonPropertyName("cancelledVolume")]
    public required double CancelledVolume { get; set; }

    /// <summary>
    /// Number of the vendor's bills whose payment is in transit.
    /// </summary>
    [JsonPropertyName("inTransit")]
    public required int InTransit { get; set; }

    /// <summary>
    /// Total value of the vendor's in-transit bills, net of fees.
    /// </summary>
    [JsonPropertyName("inTransitVolume")]
    public required double InTransitVolume { get; set; }

    /// <summary>
    /// Number of the vendor's bills marked paid. Paid means the payout has settled, not merely that Payabli issued it.
    /// </summary>
    [JsonPropertyName("paid")]
    public required int Paid { get; set; }

    /// <summary>
    /// Total value of the vendor's paid bills, net of fees.
    /// </summary>
    [JsonPropertyName("paidVolume")]
    public required double PaidVolume { get; set; }

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
