using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record ChargebackQueryRecords : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("accountType")]
    public string? AccountType { get; set; }

    /// <summary>
    /// Number of case assigned to the chargeback.
    /// </summary>
    [JsonPropertyName("caseNumber")]
    public string? CaseNumber { get; set; }

    /// <summary>
    /// Date of chargeback in format YYYY-MM-DD or MM/DD/YYYY.
    /// </summary>
    [JsonPropertyName("chargebackDate")]
    public DateTime? ChargebackDate { get; set; }

    /// <summary>
    /// Timestamp when the register was created, in UTC.
    /// </summary>
    [JsonPropertyName("createdAt")]
    public DateTime? CreatedAt { get; set; }

    [JsonPropertyName("customer")]
    public QueryTransactionPayorData? Customer { get; set; }

    /// <summary>
    /// Identifier of chargeback or return.
    /// </summary>
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    /// <summary>
    /// Last 4 digits of card or bank account involved in chargeback or return.
    /// </summary>
    [JsonPropertyName("lastFour")]
    public required string LastFour { get; set; }

    /// <summary>
    /// Type of payment vehicle: **ach** or **card**.
    /// </summary>
    [JsonPropertyName("method")]
    public required string Method { get; set; }

    /// <summary>
    /// Net amount in chargeback or ACH return.
    /// </summary>
    [JsonPropertyName("netAmount")]
    public double? NetAmount { get; set; }

    [JsonPropertyName("orderId")]
    public string? OrderId { get; set; }

    [JsonPropertyName("parentOrgName")]
    public string? ParentOrgName { get; set; }

    [JsonPropertyName("paymentData")]
    public QueryPaymentData? PaymentData { get; set; }

    /// <summary>
    /// ReferenceId of the transaction in Payabli.
    /// </summary>
    [JsonPropertyName("PaymentId")]
    public string? PaymentId { get; set; }

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

    /// <summary>
    /// The paypoint's legal name.
    /// </summary>
    [JsonPropertyName("paypointLegalname")]
    public string? PaypointLegalname { get; set; }

    /// <summary>
    /// Text describing the chargeback or ACH return reason.
    /// </summary>
    [JsonPropertyName("reason")]
    public string? Reason { get; set; }

    /// <summary>
    /// R code for returned ACH or custom code identifying the reason.
    /// </summary>
    [JsonPropertyName("reasonCode")]
    public string? ReasonCode { get; set; }

    /// <summary>
    /// Processor reference number to the chargeback.
    /// </summary>
    [JsonPropertyName("referenceNumber")]
    public string? ReferenceNumber { get; set; }

    /// <summary>
    /// Chargeback response records.
    /// </summary>
    [JsonPropertyName("responses")]
    public IEnumerable<ChargeBackResponse>? Responses { get; set; }

    /// <summary>
    /// Status for chargeback or ACH return
    ///
    /// - 0: Open (chargebacks only)
    /// - 1: Pending (chargebacks only)
    /// - 2: Closed-Won (chargebacks only)
    /// - 3: Closed-Lost (chargebacks only)
    /// - 4: ACH Return (ACH only)
    /// - 5: ACH Dispute, Not Authorized (ACH only)
    /// </summary>
    [JsonPropertyName("status")]
    public int? Status { get; set; }

    [JsonPropertyName("transaction")]
    public TransactionQueryRecords? Transaction { get; set; }

    [JsonPropertyName("transactionTime")]
    public DateTime? TransactionTime { get; set; }

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
