using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record InvoiceDataRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Object describing the customer/payor. Required for POST requests. Which fields are required depends on the paypoint's custom identifier settings.
    /// </summary>
    [JsonPropertyName("customerData")]
    public PayorDataRequest? CustomerData { get; set; }

    /// <summary>
    /// Object describing the invoice. Required for POST requests.
    /// </summary>
    [JsonPropertyName("invoiceData")]
    public BillData? InvoiceData { get; set; }

    /// <summary>
    /// Object with options for scheduled invoices.
    /// </summary>
    [JsonPropertyName("scheduledOptions")]
    public BillOptions? ScheduledOptions { get; set; }

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
