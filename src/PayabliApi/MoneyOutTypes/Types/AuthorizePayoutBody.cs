using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record AuthorizePayoutBody : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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
