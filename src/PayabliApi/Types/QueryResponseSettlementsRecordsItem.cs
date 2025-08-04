using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record QueryResponseSettlementsRecordsItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The batch amount.
    /// </summary>
    [JsonPropertyName("BatchAmount")]
    public double? BatchAmount { get; set; }

    [JsonPropertyName("BatchNumber")]
    public string? BatchNumber { get; set; }

    [JsonPropertyName("Category")]
    public string? Category { get; set; }

    [JsonPropertyName("CreatedAt")]
    public DateTime? CreatedAt { get; set; }

    [JsonPropertyName("Customer")]
    public QueryTransactionPayorData? Customer { get; set; }

    [JsonPropertyName("DepositDate")]
    public DateTime? DepositDate { get; set; }

    [JsonPropertyName("ExpectedDepositDate")]
    public DateTime? ExpectedDepositDate { get; set; }

    [JsonPropertyName("externalPaypointID")]
    public string? ExternalPaypointId { get; set; }

    /// <summary>
    /// Internal identifier used for processing.
    /// </summary>
    [JsonPropertyName("GatewayTransId")]
    public string? GatewayTransId { get; set; }

    [JsonPropertyName("Id")]
    public int? Id { get; set; }

    [JsonPropertyName("invoiceData")]
    public BillData? InvoiceData { get; set; }

    /// <summary>
    /// Describes whether the transaction is being held or not.
    ///
    /// 1 - Transaction is held
    ///
    /// 0 - Transaction isn't being held
    /// </summary>
    [JsonPropertyName("isHold")]
    public int? IsHold { get; set; }

    [JsonPropertyName("MaskedAccount")]
    public string? MaskedAccount { get; set; }

    /// <summary>
    /// The payment method.
    /// </summary>
    [JsonPropertyName("Method")]
    public string? Method { get; set; }

    /// <summary>
    /// Net amount paid.
    /// </summary>
    [JsonPropertyName("NetAmount")]
    public double? NetAmount { get; set; }

    /// <summary>
    /// The operation performed.
    /// </summary>
    [JsonPropertyName("Operation")]
    public string? Operation { get; set; }

    [JsonPropertyName("OrderId")]
    public string? OrderId { get; set; }

    [JsonPropertyName("ParentOrgName")]
    public string? ParentOrgName { get; set; }

    [JsonPropertyName("PaymentData")]
    public QueryPaymentData? PaymentData { get; set; }

    /// <summary>
    /// The transaction ID for the payment.
    /// </summary>
    [JsonPropertyName("PaymentTransId")]
    public string? PaymentTransId { get; set; }

    [JsonPropertyName("PaymentTransStatus")]
    public int? PaymentTransStatus { get; set; }

    /// <summary>
    /// Paypoint DBA name.
    /// </summary>
    [JsonPropertyName("PaypointDbaname")]
    public string? PaypointDbaname { get; set; }

    /// <summary>
    /// Paypoint entryname.
    /// </summary>
    [JsonPropertyName("PaypointEntryname")]
    public string? PaypointEntryname { get; set; }

    /// <summary>
    /// Paypoint legal name.
    /// </summary>
    [JsonPropertyName("PaypointLegalname")]
    public string? PaypointLegalname { get; set; }

    [JsonPropertyName("ResponseData")]
    public QueryResponseData? ResponseData { get; set; }

    /// <summary>
    /// Reference to the subscription originating the transaction.
    /// </summary>
    [JsonPropertyName("ScheduleReference")]
    public int? ScheduleReference { get; set; }

    /// <summary>
    /// The transaction amount.
    /// </summary>
    [JsonPropertyName("SettledAmount")]
    public double? SettledAmount { get; set; }

    /// <summary>
    ///
    /// </summary>
    [JsonPropertyName("SettlementDate")]
    public DateTime? SettlementDate { get; set; }

    [JsonPropertyName("Source")]
    public string? Source { get; set; }

    [JsonPropertyName("Status")]
    public int? Status { get; set; }

    /// <summary>
    /// Events associated with this transaction.
    /// </summary>
    [JsonPropertyName("TransactionEvents")]
    public IEnumerable<QueryTransactionEvents>? TransactionEvents { get; set; }

    [JsonPropertyName("TransactionTime")]
    public DateTime? TransactionTime { get; set; }

    /// <summary>
    /// Payment method used: card or ach.
    /// </summary>
    [JsonPropertyName("TransMethod")]
    public string? TransMethod { get; set; }

    /// <summary>
    /// The transaction type: credit or debit.
    /// </summary>
    [JsonPropertyName("Type")]
    public string? Type { get; set; }

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
