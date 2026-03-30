using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record PayoutSubscriptionQueryRecord : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The payout subscription's ID.
    /// </summary>
    [JsonPropertyName("idOutSubscription")]
    public long? IdOutSubscription { get; set; }

    /// <summary>
    /// The payout subscription's status.
    /// - 0: Paused
    /// - 1: Active
    /// </summary>
    [JsonPropertyName("status")]
    public int? Status { get; set; }

    /// <summary>
    /// Events associated with the payout subscription.
    /// </summary>
    [JsonPropertyName("events")]
    public IEnumerable<GeneralEvents>? Events { get; set; }

    [JsonPropertyName("vendor")]
    public VendorQueryRecord? Vendor { get; set; }

    /// <summary>
    /// Bills associated with the payout subscription.
    /// </summary>
    [JsonPropertyName("billData")]
    public IEnumerable<BillPayOutData>? BillData { get; set; }

    [JsonPropertyName("externalPaypointID")]
    public string? ExternalPaypointId { get; set; }

    /// <summary>
    /// The payout subscription's payment method.
    /// </summary>
    [JsonPropertyName("method")]
    public string? Method { get; set; }

    [JsonPropertyName("paypointId")]
    public long? PaypointId { get; set; }

    /// <summary>
    /// The payout subscription amount, including any fees.
    /// </summary>
    [JsonPropertyName("totalAmount")]
    public double? TotalAmount { get; set; }

    /// <summary>
    /// The payout subscription amount, minus any fees.
    /// </summary>
    [JsonPropertyName("netAmount")]
    public double? NetAmount { get; set; }

    /// <summary>
    /// Fee applied to the payout subscription.
    /// </summary>
    [JsonPropertyName("feeAmount")]
    public double? FeeAmount { get; set; }

    [JsonPropertyName("paymentData")]
    public QueryPaymentData? PaymentData { get; set; }

    /// <summary>
    /// The payout subscription start date.
    /// </summary>
    [JsonPropertyName("startDate")]
    public DateTime? StartDate { get; set; }

    /// <summary>
    /// The payout subscription's end date.
    /// </summary>
    [JsonPropertyName("endDate")]
    public DateTime? EndDate { get; set; }

    /// <summary>
    /// The next date the payout subscription will be processed.
    /// </summary>
    [JsonPropertyName("nextDate")]
    public DateTime? NextDate { get; set; }

    /// <summary>
    /// The payout subscription's frequency.
    /// </summary>
    [JsonPropertyName("frequency")]
    public string? Frequency { get; set; }

    /// <summary>
    /// The total number of cycles the payout subscription is set to run.
    /// </summary>
    [JsonPropertyName("totalCycles")]
    public int? TotalCycles { get; set; }

    /// <summary>
    /// The number of cycles the payout subscription has left.
    /// </summary>
    [JsonPropertyName("leftCycles")]
    public int? LeftCycles { get; set; }

    /// <summary>
    /// The last time the payout subscription was processed.
    /// </summary>
    [JsonPropertyName("lastRun")]
    public DateTime? LastRun { get; set; }

    [JsonPropertyName("entrypageId")]
    public long? EntrypageId { get; set; }

    /// <summary>
    /// When `true`, the payout subscription has no explicit end date and runs until canceled.
    /// </summary>
    [JsonPropertyName("untilCancelled")]
    public bool? UntilCancelled { get; set; }

    /// <summary>
    /// The last date and time the payout subscription was updated.
    /// </summary>
    [JsonPropertyName("lastUpdated")]
    public DateTime? LastUpdated { get; set; }

    /// <summary>
    /// Timestamp of when the payout subscription was created, in UTC.
    /// </summary>
    [JsonPropertyName("createdAt")]
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// The paypoint's legal name.
    /// </summary>
    [JsonPropertyName("paypointLegalname")]
    public string? PaypointLegalname { get; set; }

    /// <summary>
    /// The paypoint's DBA name.
    /// </summary>
    [JsonPropertyName("paypointDbaname")]
    public string? PaypointDbaname { get; set; }

    /// <summary>
    /// The paypoint's entryname.
    /// </summary>
    [JsonPropertyName("paypointEntryname")]
    public string? PaypointEntryname { get; set; }

    [JsonPropertyName("parentOrgName")]
    public string? ParentOrgName { get; set; }

    [JsonPropertyName("parentOrgId")]
    public long? ParentOrgId { get; set; }

    [JsonPropertyName("source")]
    public string? Source { get; set; }

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
