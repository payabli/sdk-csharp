using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record QueryChargebacksResponseRecordsItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Type of account.
    /// </summary>
    [JsonPropertyName("AccountType")]
    public string? AccountType { get; set; }

    /// <summary>
    /// Case number of the chargeback.
    /// </summary>
    [JsonPropertyName("CaseNumber")]
    public string? CaseNumber { get; set; }

    /// <summary>
    /// Date of the chargeback.
    /// </summary>
    [JsonPropertyName("ChargebackDate")]
    public DateTime? ChargebackDate { get; set; }

    [JsonPropertyName("CreatedAt")]
    public DateTime? CreatedAt { get; set; }

    [JsonPropertyName("Customer")]
    public QueryTransactionPayorData? Customer { get; set; }

    [JsonPropertyName("externalPaypointID")]
    public string? ExternalPaypointId { get; set; }

    /// <summary>
    /// Unique identifier of the record.
    /// </summary>
    [JsonPropertyName("Id")]
    public int? Id { get; set; }

    /// <summary>
    /// Last four digits of the account number.
    /// </summary>
    [JsonPropertyName("LastFour")]
    public string? LastFour { get; set; }

    /// <summary>
    /// Method of payment.
    /// </summary>
    [JsonPropertyName("Method")]
    public string? Method { get; set; }

    /// <summary>
    /// Net amount after deductions.
    /// </summary>
    [JsonPropertyName("NetAmount")]
    public float? NetAmount { get; set; }

    [JsonPropertyName("OrderId")]
    public string? OrderId { get; set; }

    [JsonPropertyName("pageidentifier")]
    public string? Pageidentifier { get; set; }

    [JsonPropertyName("ParentOrgName")]
    public string? ParentOrgName { get; set; }

    /// <summary>
    /// Payment data associated with the transaction.
    /// </summary>
    [JsonPropertyName("PaymentData")]
    public QueryPaymentData? PaymentData { get; set; }

    /// <summary>
    /// Transaction ID for the payment.
    /// </summary>
    [JsonPropertyName("PaymentTransId")]
    public string? PaymentTransId { get; set; }

    /// <summary>
    /// The 'Doing Business As' (DBA) name of the paypoint.
    /// </summary>
    [JsonPropertyName("PaypointDbaname")]
    public string? PaypointDbaname { get; set; }

    /// <summary>
    /// Entryname for the paypoint.
    /// </summary>
    [JsonPropertyName("PaypointEntryname")]
    public string? PaypointEntryname { get; set; }

    /// <summary>
    /// Legal name of the paypoint.
    /// </summary>
    [JsonPropertyName("PaypointLegalname")]
    public string? PaypointLegalname { get; set; }

    /// <summary>
    /// Description of the reason for chargeback.
    /// </summary>
    [JsonPropertyName("Reason")]
    public string? Reason { get; set; }

    /// <summary>
    /// Code representing the reason for chargeback.
    /// </summary>
    [JsonPropertyName("ReasonCode")]
    public string? ReasonCode { get; set; }

    /// <summary>
    /// Reference number for the transaction.
    /// </summary>
    [JsonPropertyName("ReferenceNumber")]
    public string? ReferenceNumber { get; set; }

    [JsonPropertyName("ReplyBy")]
    public DateTime? ReplyBy { get; set; }

    /// <summary>
    /// Responses related to the transaction.
    /// </summary>
    [JsonPropertyName("Responses")]
    public string? Responses { get; set; }

    /// <summary>
    /// Reference for any scheduled transactions.
    /// </summary>
    [JsonPropertyName("ScheduleReference")]
    public int? ScheduleReference { get; set; }

    /// <summary>
    /// Status of the transaction.
    /// </summary>
    [JsonPropertyName("Status")]
    public int? Status { get; set; }

    [JsonPropertyName("Transaction")]
    public TransactionQueryRecords? Transaction { get; set; }

    [JsonPropertyName("TransactionTime")]
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
