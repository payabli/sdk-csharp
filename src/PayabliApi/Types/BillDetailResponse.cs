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

    /// <summary>
    /// Events associated to this transaction.
    /// </summary>
    [JsonPropertyName("Events")]
    public IEnumerable<QueryTransactionEvents>? Events { get; set; }

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
    /// Timestamp when payment record was updated, in UTC.
    /// </summary>
    [JsonPropertyName("LastUpdated")]
    public DateTime? LastUpdated { get; set; }

    [JsonPropertyName("NetAmount")]
    public double? NetAmount { get; set; }

    [JsonPropertyName("parentOrgName")]
    public string? ParentOrgName { get; set; }

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

    [JsonPropertyName("paypointDbaname")]
    public string? PaypointDbaname { get; set; }

    /// <summary>
    /// Paypoint legal name.
    /// </summary>
    [JsonPropertyName("paypointLegalname")]
    public string? PaypointLegalname { get; set; }

    [JsonPropertyName("Source")]
    public string? Source { get; set; }

    /// <summary>
    /// Internal status of transaction.
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
