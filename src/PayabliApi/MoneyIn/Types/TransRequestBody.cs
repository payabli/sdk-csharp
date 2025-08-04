using System.Text.Json;
using System.Text.Json.Serialization;
using OneOf;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record TransRequestBody : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("accountId")]
    public string? AccountId { get; set; }

    /// <summary>
    /// Object describing the Customer/Payor. Which fields are required depends on the paypoint's custom identifier settings.
    /// </summary>
    [JsonPropertyName("customerData")]
    public PayorDataRequest? CustomerData { get; set; }

    [JsonPropertyName("entryPoint")]
    public string? EntryPoint { get; set; }

    /// <summary>
    /// Object describing an Invoice linked to the transaction.
    /// </summary>
    [JsonPropertyName("invoiceData")]
    public BillData? InvoiceData { get; set; }

    [JsonPropertyName("ipaddress")]
    public string? Ipaddress { get; set; }

    [JsonPropertyName("orderDescription")]
    public string? OrderDescription { get; set; }

    [JsonPropertyName("orderId")]
    public string? OrderId { get; set; }

    /// <summary>
    /// Object describing details of the payment. Required.
    /// </summary>
    [JsonPropertyName("paymentDetails")]
    public required PaymentDetail PaymentDetails { get; set; }

    /// <summary>
    /// Information about the payment method for the transaction. Required and recommended fields for each payment method type are described in each schema below.
    /// </summary>
    [JsonPropertyName("paymentMethod")]
    public required OneOf<
        PayMethodCredit,
        PayMethodAch,
        PayMethodStoredMethod,
        PayMethodCloud,
        Check,
        Cash,
        PayMethodBodyAllFields
    > PaymentMethod { get; set; }

    [JsonPropertyName("source")]
    public string? Source { get; set; }

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
