using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record PayoutSubscriptionQueryRecordPascal : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The payout subscription's ID.
    /// </summary>
    [JsonPropertyName("IdOutSubscription")]
    public long? IdOutSubscription { get; set; }

    /// <summary>
    /// The payout subscription's status.
    /// - 0: Paused
    /// - 1: Active
    /// </summary>
    [JsonPropertyName("Status")]
    public int? Status { get; set; }

    /// <summary>
    /// Events associated with the payout subscription.
    /// </summary>
    [JsonPropertyName("Events")]
    public IEnumerable<GeneralEvents>? Events { get; set; }

    [JsonPropertyName("Vendor")]
    public VendorQueryRecord? Vendor { get; set; }

    /// <summary>
    /// Bills associated with the payout subscription.
    /// </summary>
    [JsonPropertyName("BillData")]
    public IEnumerable<BillPayOutData>? BillData { get; set; }

    [JsonPropertyName("ExternalPaypointID")]
    public string? ExternalPaypointId { get; set; }

    /// <summary>
    /// The payout subscription's payment method.
    /// </summary>
    [JsonPropertyName("Method")]
    public string? Method { get; set; }

    [JsonPropertyName("PaypointId")]
    public long? PaypointId { get; set; }

    /// <summary>
    /// The payout subscription amount, including any fees.
    /// </summary>
    [JsonPropertyName("TotalAmount")]
    public double? TotalAmount { get; set; }

    /// <summary>
    /// The payout subscription amount, minus any fees.
    /// </summary>
    [JsonPropertyName("NetAmount")]
    public double? NetAmount { get; set; }

    /// <summary>
    /// Fee applied to the payout subscription.
    /// </summary>
    [JsonPropertyName("FeeAmount")]
    public double? FeeAmount { get; set; }

    [JsonPropertyName("PaymentData")]
    public QueryPaymentData? PaymentData { get; set; }

    /// <summary>
    /// The payout subscription start date.
    /// </summary>
    [JsonPropertyName("StartDate")]
    public DateTime? StartDate { get; set; }

    /// <summary>
    /// The payout subscription's end date.
    /// </summary>
    [JsonPropertyName("EndDate")]
    public DateTime? EndDate { get; set; }

    /// <summary>
    /// The next date the payout subscription will be processed.
    /// </summary>
    [JsonPropertyName("NextDate")]
    public DateTime? NextDate { get; set; }

    /// <summary>
    /// The payout subscription's frequency.
    /// </summary>
    [JsonPropertyName("Frequency")]
    public string? Frequency { get; set; }

    /// <summary>
    /// The total number of cycles the payout subscription is set to run.
    /// </summary>
    [JsonPropertyName("TotalCycles")]
    public int? TotalCycles { get; set; }

    /// <summary>
    /// The number of cycles the payout subscription has left.
    /// </summary>
    [JsonPropertyName("LeftCycles")]
    public int? LeftCycles { get; set; }

    /// <summary>
    /// The last time the payout subscription was processed.
    /// </summary>
    [JsonPropertyName("LastRun")]
    public DateTime? LastRun { get; set; }

    [JsonPropertyName("EntrypageId")]
    public long? EntrypageId { get; set; }

    /// <summary>
    /// When `true`, the payout subscription has no explicit end date and runs until canceled.
    /// </summary>
    [JsonPropertyName("UntilCancelled")]
    public bool? UntilCancelled { get; set; }

    /// <summary>
    /// The last date and time the payout subscription was updated.
    /// </summary>
    [JsonPropertyName("LastUpdated")]
    public DateTime? LastUpdated { get; set; }

    /// <summary>
    /// Timestamp of when the payout subscription was created, in UTC.
    /// </summary>
    [JsonPropertyName("CreatedAt")]
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// The paypoint's legal name.
    /// </summary>
    [JsonPropertyName("PaypointLegalname")]
    public string? PaypointLegalname { get; set; }

    /// <summary>
    /// The paypoint's DBA name.
    /// </summary>
    [JsonPropertyName("PaypointDbaname")]
    public string? PaypointDbaname { get; set; }

    /// <summary>
    /// The paypoint's entryname.
    /// </summary>
    [JsonPropertyName("PaypointEntryname")]
    public string? PaypointEntryname { get; set; }

    [JsonPropertyName("ParentOrgName")]
    public string? ParentOrgName { get; set; }

    [JsonPropertyName("ParentOrgId")]
    public long? ParentOrgId { get; set; }

    [JsonPropertyName("Source")]
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
