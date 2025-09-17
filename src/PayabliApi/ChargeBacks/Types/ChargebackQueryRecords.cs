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

    /// <summary>
    /// Identifier of chargeback or return.
    /// </summary>
    [JsonPropertyName("Id")]
    public required long Id { get; set; }

    /// <summary>
    /// Date of chargeback in format YYYY-MM-DD or MM/DD/YYYY.
    /// </summary>
    [JsonPropertyName("ChargebackDate")]
    public required DateTime ChargebackDate { get; set; }

    /// <summary>
    /// Number of case assigned to the chargeback.
    /// </summary>
    [JsonPropertyName("CaseNumber")]
    public required string CaseNumber { get; set; }

    /// <summary>
    /// R code for returned ACH or custom code identifying the reason.
    /// </summary>
    [JsonPropertyName("ReasonCode")]
    public required string ReasonCode { get; set; }

    /// <summary>
    /// Text describing the chargeback or ACH return reason.
    /// </summary>
    [JsonPropertyName("Reason")]
    public required string Reason { get; set; }

    /// <summary>
    /// Processor reference number to the chargeback.
    /// </summary>
    [JsonPropertyName("ReferenceNumber")]
    public required string ReferenceNumber { get; set; }

    /// <summary>
    /// Last 4 digits of card or bank account involved in chargeback or return.
    /// </summary>
    [JsonPropertyName("LastFour")]
    public required string LastFour { get; set; }

    [JsonPropertyName("AccountType")]
    public required string AccountType { get; set; }

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
    [JsonPropertyName("Status")]
    public required int Status { get; set; }

    /// <summary>
    /// Type of payment vehicle: **ach** or **card**.
    /// </summary>
    [JsonPropertyName("Method")]
    public required string Method { get; set; }

    /// <summary>
    /// Timestamp when the register was created, in UTC.
    /// </summary>
    [JsonPropertyName("CreatedAt")]
    public required DateTime CreatedAt { get; set; }

    [JsonPropertyName("ReplyBy")]
    public required DateTime ReplyBy { get; set; }

    /// <summary>
    /// ReferenceId of the transaction in Payabli.
    /// </summary>
    [JsonPropertyName("PaymentTransId")]
    public required string PaymentTransId { get; set; }

    /// <summary>
    /// Reference to the subscription originating the transaction.
    /// </summary>
    [JsonPropertyName("ScheduleReference")]
    public long? ScheduleReference { get; set; }

    [JsonPropertyName("OrderId")]
    public required string OrderId { get; set; }

    /// <summary>
    /// Net amount in chargeback or ACH return.
    /// </summary>
    [JsonPropertyName("NetAmount")]
    public double? NetAmount { get; set; }

    [JsonPropertyName("TransactionTime")]
    public required DateTime TransactionTime { get; set; }

    [JsonPropertyName("Customer")]
    public required QueryTransactionPayorData Customer { get; set; }

    [JsonPropertyName("PaymentData")]
    public required QueryPaymentData PaymentData { get; set; }

    /// <summary>
    /// The paypoint's legal name.
    /// </summary>
    [JsonPropertyName("PaypointLegalname")]
    public required string PaypointLegalname { get; set; }

    /// <summary>
    /// The paypoint's DBA name.
    /// </summary>
    [JsonPropertyName("PaypointDbaname")]
    public required string PaypointDbaname { get; set; }

    [JsonPropertyName("ParentOrgName")]
    public required string ParentOrgName { get; set; }

    /// <summary>
    /// The ID of the parent organization.
    /// </summary>
    [JsonPropertyName("ParentOrgId")]
    public required long ParentOrgId { get; set; }

    /// <summary>
    /// The paypoint's entryname.
    /// </summary>
    [JsonPropertyName("PaypointEntryname")]
    public required string PaypointEntryname { get; set; }

    /// <summary>
    /// Chargeback response records.
    /// </summary>
    [JsonPropertyName("Responses")]
    public IEnumerable<ChargeBackResponse> Responses { get; set; } = new List<ChargeBackResponse>();

    [JsonPropertyName("Transaction")]
    public required TransactionQueryRecords Transaction { get; set; }

    [JsonPropertyName("externalPaypointID")]
    public string? ExternalPaypointId { get; set; }

    [JsonPropertyName("pageidentifier")]
    public string? Pageidentifier { get; set; }

    /// <summary>
    /// Messages related to the chargeback.
    /// </summary>
    [JsonPropertyName("messages")]
    public IEnumerable<ChargebackMessage> Messages { get; set; } = new List<ChargebackMessage>();

    /// <summary>
    /// Service group classification.
    /// </summary>
    [JsonPropertyName("ServiceGroup")]
    public required string ServiceGroup { get; set; }

    /// <summary>
    /// Type of dispute classification.
    /// </summary>
    [JsonPropertyName("DisputeType")]
    public required string DisputeType { get; set; }

    /// <summary>
    /// Name of the payment processor.
    /// </summary>
    [JsonPropertyName("ProcessorName")]
    public required string ProcessorName { get; set; }

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
