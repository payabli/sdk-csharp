using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record StatisticsVendorQueryRecord : IJsonOnDeserialized
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
    /// Number of active transactions
    /// </summary>
    [JsonPropertyName("active")]
    public required int Active { get; set; }

    /// <summary>
    /// Volume of active transactions
    /// </summary>
    [JsonPropertyName("activeVolume")]
    public required double ActiveVolume { get; set; }

    /// <summary>
    /// Number of transactions sent to approval
    /// </summary>
    [JsonPropertyName("sentToApproval")]
    public required int SentToApproval { get; set; }

    /// <summary>
    /// Volume of transactions sent to approval
    /// </summary>
    [JsonPropertyName("sentToApprovalVolume")]
    public required double SentToApprovalVolume { get; set; }

    /// <summary>
    /// Number of transactions to approval
    /// </summary>
    [JsonPropertyName("toApproval")]
    public required int ToApproval { get; set; }

    /// <summary>
    /// Volume of transactions to approval
    /// </summary>
    [JsonPropertyName("toApprovalVolume")]
    public required double ToApprovalVolume { get; set; }

    /// <summary>
    /// Number of approved transactions
    /// </summary>
    [JsonPropertyName("approved")]
    public required int Approved { get; set; }

    /// <summary>
    /// Volume of approved transactions
    /// </summary>
    [JsonPropertyName("approvedVolume")]
    public required double ApprovedVolume { get; set; }

    /// <summary>
    /// Number of disapproved transactions
    /// </summary>
    [JsonPropertyName("disapproved")]
    public required int Disapproved { get; set; }

    /// <summary>
    /// Volume of disapproved transactions
    /// </summary>
    [JsonPropertyName("disapprovedVolume")]
    public required double DisapprovedVolume { get; set; }

    /// <summary>
    /// Number of cancelled transactions
    /// </summary>
    [JsonPropertyName("cancelled")]
    public required int Cancelled { get; set; }

    /// <summary>
    /// Volume of cancelled transactions
    /// </summary>
    [JsonPropertyName("cancelledVolume")]
    public required double CancelledVolume { get; set; }

    /// <summary>
    /// Number of transactions in transit
    /// </summary>
    [JsonPropertyName("inTransit")]
    public required int InTransit { get; set; }

    /// <summary>
    /// Volume of transactions in transit
    /// </summary>
    [JsonPropertyName("inTransitVolume")]
    public required double InTransitVolume { get; set; }

    /// <summary>
    /// Number of paid transactions
    /// </summary>
    [JsonPropertyName("paid")]
    public required int Paid { get; set; }

    /// <summary>
    /// Volume of paid transactions
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
