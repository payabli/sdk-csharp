using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record SubscriptionQueryRecords : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Timestamp of when the subscription ws created, in UTC.
    /// </summary>
    [JsonPropertyName("CreatedAt")]
    public DateTime? CreatedAt { get; set; }

    [JsonPropertyName("Customer")]
    public QueryTransactionPayorData? Customer { get; set; }

    /// <summary>
    /// The subscription's end date.
    /// </summary>
    [JsonPropertyName("EndDate")]
    public DateTime? EndDate { get; set; }

    [JsonPropertyName("EntrypageId")]
    public long? EntrypageId { get; set; }

    [JsonPropertyName("ExternalPaypointID")]
    public string? ExternalPaypointId { get; set; }

    /// <summary>
    /// Fee applied to the subscription.
    /// </summary>
    [JsonPropertyName("FeeAmount")]
    public double? FeeAmount { get; set; }

    /// <summary>
    /// The subscription's frequency.
    /// </summary>
    [JsonPropertyName("Frequency")]
    public string? Frequency { get; set; }

    /// <summary>
    /// The subscription's ID.
    /// </summary>
    [JsonPropertyName("IdSub")]
    public long? IdSub { get; set; }

    [JsonPropertyName("InvoiceData")]
    public BillData? InvoiceData { get; set; }

    /// <summary>
    /// The last time the subscription was processed.
    /// </summary>
    [JsonPropertyName("LastRun")]
    public DateTime? LastRun { get; set; }

    /// <summary>
    /// The last date and time the subscription was updated.
    /// </summary>
    [JsonPropertyName("LastUpdated")]
    public DateTime? LastUpdated { get; set; }

    /// <summary>
    /// The number of cycles the subscription has left.
    /// </summary>
    [JsonPropertyName("LeftCycles")]
    public int? LeftCycles { get; set; }

    /// <summary>
    /// The subscription's payment method.
    /// </summary>
    [JsonPropertyName("Method")]
    public string? Method { get; set; }

    /// <summary>
    /// The subscription amount, minus any fees.
    /// </summary>
    [JsonPropertyName("NetAmount")]
    public double? NetAmount { get; set; }

    /// <summary>
    /// The next date the subscription will be processed.
    /// </summary>
    [JsonPropertyName("NextDate")]
    public DateTime? NextDate { get; set; }

    [JsonPropertyName("ParentOrgName")]
    public string? ParentOrgName { get; set; }

    [JsonPropertyName("PaymentData")]
    public QueryPaymentData? PaymentData { get; set; }

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

    [JsonPropertyName("PaypointId")]
    public long? PaypointId { get; set; }

    /// <summary>
    /// The paypoint's legal name.
    /// </summary>
    [JsonPropertyName("PaypointLegalname")]
    public string? PaypointLegalname { get; set; }

    /// <summary>
    /// Payment plan ID.
    /// </summary>
    [JsonPropertyName("PlanId")]
    public int? PlanId { get; set; }

    [JsonPropertyName("Source")]
    public string? Source { get; set; }

    /// <summary>
    /// The subscription start date.
    /// </summary>
    [JsonPropertyName("StartDate")]
    public DateTime? StartDate { get; set; }

    /// <summary>
    /// Events associated with the subscription.
    /// </summary>
    [JsonPropertyName("SubEvents")]
    public IEnumerable<GeneralEvents>? SubEvents { get; set; }

    /// <summary>
    /// The subscription's status.
    /// - 0: Paused
    /// - 1: Active
    /// </summary>
    [JsonPropertyName("SubStatus")]
    public int? SubStatus { get; set; }

    /// <summary>
    /// The subscription amount, including any fees.
    /// </summary>
    [JsonPropertyName("TotalAmount")]
    public double? TotalAmount { get; set; }

    /// <summary>
    /// The total number of cycles the subscription is set to run.
    /// </summary>
    [JsonPropertyName("TotalCycles")]
    public int? TotalCycles { get; set; }

    /// <summary>
    /// When `true`, the subscription has no explicit end date and will run until canceled.
    /// </summary>
    [JsonPropertyName("UntilCancelled")]
    public bool? UntilCancelled { get; set; }

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
