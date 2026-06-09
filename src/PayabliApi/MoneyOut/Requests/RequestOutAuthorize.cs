using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record RequestOutAuthorize
{
    /// <summary>
    /// When `true`, the authorization bypasses the requirement for unique bills, identified by vendor invoice number. This allows you to make more than one payout authorization for a bill, like a split payment.
    /// </summary>
    [JsonIgnore]
    public bool? AllowDuplicatedBills { get; set; }

    /// <summary>
    /// When `true`, Payabli won't automatically create a bill for this payout transaction.
    /// </summary>
    [JsonIgnore]
    public bool? DoNotCreateBills { get; set; }

    /// <summary>
    /// When `true`, the request creates a new vendor record, regardless of whether the vendor already exists.
    /// </summary>
    [JsonIgnore]
    public bool? ForceVendorCreation { get; set; }

    /// <summary>
    /// _Optional but recommended_ A unique ID that you can include to prevent duplicating objects or transactions in the case that a request is sent more than once. This key isn't generated in Payabli, you must generate it yourself. This key persists for 2 minutes. After 2 minutes, you can reuse the key if needed.
    /// </summary>
    [JsonIgnore]
    public string? IdempotencyKey { get; set; }

    [JsonPropertyName("entryPoint")]
    public required string EntryPoint { get; set; }

    [JsonPropertyName("source")]
    public string? Source { get; set; }

    [JsonPropertyName("orderId")]
    public string? OrderId { get; set; }

    [JsonPropertyName("orderDescription")]
    public string? OrderDescription { get; set; }

    [JsonPropertyName("paymentMethod")]
    public required AuthorizePaymentMethod PaymentMethod { get; set; }

    /// <summary>
    /// Object containing payment details.
    /// </summary>
    [JsonPropertyName("paymentDetails")]
    public required RequestOutAuthorizePaymentDetails PaymentDetails { get; set; }

    /// <summary>
    /// Object containing vendor data.
    /// </summary>
    [JsonPropertyName("vendorData")]
    public required RequestOutAuthorizeVendorData VendorData { get; set; }

    /// <summary>
    /// Array of bills associated to the transaction
    /// </summary>
    [JsonPropertyName("invoiceData")]
    public IEnumerable<RequestOutAuthorizeInvoiceData> InvoiceData { get; set; } =
        new List<RequestOutAuthorizeInvoiceData>();

    [JsonPropertyName("accountId")]
    public string? AccountId { get; set; }

    [JsonPropertyName("subdomain")]
    public string? Subdomain { get; set; }

    [JsonPropertyName("subscriptionId")]
    public long? SubscriptionId { get; set; }

    [JsonPropertyName("autoCapture")]
    public bool? AutoCapture { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
