using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record BillDetailResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Events associated to this transaction.
    /// </summary>
    [JsonPropertyName("Bills")]
    public IEnumerable<BillDetailsResponse>? Bills { get; set; }

    /// <summary>
    /// Object referencing to paper check image.
    /// </summary>
    [JsonPropertyName("CheckData")]
    public FileContent? CheckData { get; set; }

    /// <summary>
    /// Paper check number related to payout transaction.
    /// </summary>
    [JsonPropertyName("CheckNumber")]
    public string? CheckNumber { get; set; }

    /// <summary>
    /// Any comment or description for payout transaction.
    /// </summary>
    [JsonPropertyName("Comments")]
    public string? Comments { get; set; }

    /// <summary>
    /// Timestamp when the payment was created, in UTC.
    /// </summary>
    [JsonPropertyName("CreatedDate")]
    public DateTime? CreatedDate { get; set; }

    [JsonPropertyName("CreatedAt")]
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// Events associated to this transaction.
    /// </summary>
    [JsonPropertyName("Events")]
    public IEnumerable<QueryTransactionEvents>? Events { get; set; }

    [JsonPropertyName("FeeAmount")]
    public double? FeeAmount { get; set; }

    [JsonPropertyName("Gateway")]
    public string? Gateway { get; set; }

    /// <summary>
    /// Identifier of payout transaction.
    /// </summary>
    [JsonPropertyName("IdOut")]
    public long? IdOut { get; set; }

    /// <summary>
    /// Timestamp when payment record was updated, in UTC.
    /// </summary>
    [JsonPropertyName("LastUpdated")]
    public DateTime? LastUpdated { get; set; }

    [JsonPropertyName("NetAmount")]
    public double? NetAmount { get; set; }

    [JsonPropertyName("ParentOrgName")]
    public string? ParentOrgName { get; set; }

    [JsonPropertyName("ParentOrgId")]
    public long? ParentOrgId { get; set; }

    [JsonPropertyName("PaymentData")]
    public QueryPaymentData? PaymentData { get; set; }

    /// <summary>
    /// Unique identifier for group or batch containing the transaction.
    /// </summary>
    [JsonPropertyName("PaymentGroup")]
    public string? PaymentGroup { get; set; }

    [JsonPropertyName("PaymentId")]
    public string? PaymentId { get; set; }

    /// <summary>
    /// Method of payment applied to the transaction.
    /// </summary>
    [JsonPropertyName("PaymentMethod")]
    public string? PaymentMethod { get; set; }

    /// <summary>
    /// Status of payout transaction.
    /// </summary>
    [JsonPropertyName("PaymentStatus")]
    public string? PaymentStatus { get; set; }

    [JsonPropertyName("PaypointDbaname")]
    public string? PaypointDbaname { get; set; }

    /// <summary>
    /// Paypoint legal name.
    /// </summary>
    [JsonPropertyName("PaypointLegalname")]
    public string? PaypointLegalname { get; set; }

    [JsonPropertyName("Source")]
    public string? Source { get; set; }

    /// <summary>
    /// Internal status of transaction.
    ///
    /// Payout statuses, also known as money out transaction statuses, appear in PartnerHub and PayHub, and the API, and describe where a payout transaction is in its lifecycle.
    ///
    /// | Status | Key | Description | Events |
    /// |--------|-----|-------------|---------|
    /// | **Authorized** | 11 | A payout is authorized. These are queued payouts, and nothing happens with them until they're captured. | Authorized |
    /// | **Captured** | 1 | A payout is captured and is now part of the batch for payout. | Captured |
    /// | **Canceled** | 0 | An authorized payout has been canceled. A captured payout can be canceled before batch close at 5 PM ET. | Cancelled |
    /// | **Processing** | 2 | A payout is being processed. | Waiting funds, Funded, Pending (payment type is pending), Generating check |
    /// | **Processed** | 3 | A payment method is defined for the vendor, and the payout has been sent to the recipient. | Open (vCard issued, ACH sent, check generated but not yet cashed), Processed (Payment Type is no longer pending), Reissued, Returned, Errored |
    /// | **OnHold** | 4 | A payout has been placed on hold and requires review before proceeding. | OnHold |
    /// | **Paid** | 5 | A payout has been paid and the recipient has redeemed the funds. | Paid (check cleared, vCard used, ACH settled) |
    /// </summary>
    [JsonPropertyName("Status")]
    public int? Status { get; set; }

    /// <summary>
    /// Status of payout transaction.
    /// </summary>
    [JsonPropertyName("StatusText")]
    public string? StatusText { get; set; }

    /// <summary>
    /// Transaction total amount (including service fee or sub-charge).
    /// </summary>
    [JsonPropertyName("TotalAmount")]
    public double? TotalAmount { get; set; }

    /// <summary>
    /// Vendor related to the payout transaction.
    /// </summary>
    [JsonPropertyName("Vendor")]
    public VendorQueryRecord? Vendor { get; set; }

    [JsonPropertyName("externalPaypointID")]
    public string? ExternalPaypointId { get; set; }

    [JsonPropertyName("EntryName")]
    public string? EntryName { get; set; }

    /// <summary>
    /// Identifier for the batch in which this transaction was processed. Used to track and reconcile batch-level operations.
    /// </summary>
    [JsonPropertyName("BatchId")]
    public string? BatchId { get; set; }

    [JsonPropertyName("HasVcardTransactions")]
    public bool? HasVcardTransactions { get; set; }

    [JsonPropertyName("IsSameDayACH")]
    public bool? IsSameDayAch { get; set; }

    [JsonPropertyName("ScheduleId")]
    public long? ScheduleId { get; set; }

    [JsonPropertyName("SettlementStatus")]
    public int? SettlementStatus { get; set; }

    [JsonPropertyName("RiskFlagged")]
    public bool? RiskFlagged { get; set; }

    [JsonPropertyName("RiskFlaggedOn")]
    public DateTime? RiskFlaggedOn { get; set; }

    [JsonPropertyName("RiskStatus")]
    public string? RiskStatus { get; set; }

    [JsonPropertyName("RiskReason")]
    public string? RiskReason { get; set; }

    [JsonPropertyName("RiskAction")]
    public string? RiskAction { get; set; }

    [JsonPropertyName("RiskActionCode")]
    public int? RiskActionCode { get; set; }

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
