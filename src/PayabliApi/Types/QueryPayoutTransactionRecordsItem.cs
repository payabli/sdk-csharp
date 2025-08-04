using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record QueryPayoutTransactionRecordsItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("BatchNumber")]
    public string? BatchNumber { get; set; }

    /// <summary>
    /// Events associated with this transaction.
    /// </summary>
    [JsonPropertyName("Bills")]
    public IEnumerable<BillPayOutData>? Bills { get; set; }

    [JsonPropertyName("CardToken")]
    public string? CardToken { get; set; }

    /// <summary>
    /// Object referencing paper check image.
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
    [JsonPropertyName("CreatedAt")]
    public DateTime? CreatedAt { get; set; }

    [JsonPropertyName("EntryName")]
    public string? EntryName { get; set; }

    /// <summary>
    /// Events associated with this transaction.
    /// </summary>
    [JsonPropertyName("Events")]
    public IEnumerable<QueryTransactionEvents>? Events { get; set; }

    [JsonPropertyName("externalPaypointID")]
    public string? ExternalPaypointId { get; set; }

    /// <summary>
    /// Service fee or sub-charge applied.
    /// </summary>
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
    /// Timestamp when payment record was updated.
    /// </summary>
    [JsonPropertyName("LastUpdated")]
    public DateTime? LastUpdated { get; set; }

    /// <summary>
    /// Net amount paid.
    /// </summary>
    [JsonPropertyName("NetAmount")]
    public double? NetAmount { get; set; }

    [JsonPropertyName("ParentOrgName")]
    public string? ParentOrgName { get; set; }

    [JsonPropertyName("PaymentData")]
    public QueryPayoutTransactionRecordsItemPaymentData? PaymentData { get; set; }

    [JsonPropertyName("PaymentId")]
    public string? PaymentId { get; set; }

    /// <summary>
    /// The payment method for the transaction.
    /// </summary>
    [JsonPropertyName("PaymentMethod")]
    public string? PaymentMethod { get; set; }

    /// <summary>
    /// Status of payout transaction. See [Payout Transaction Statuses](guides/money-out-statuses#payout-transaction-statuses) for a full reference.
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
    /// </summary>
    [JsonPropertyName("Status")]
    public int? Status { get; set; }

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
