using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record PageContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Amount section of payment page
    /// </summary>
    [JsonPropertyName("amount")]
    public AmountElement? Amount { get; set; }

    /// <summary>
    /// Autopay section of payment page
    /// </summary>
    [JsonPropertyName("autopay")]
    public AutoElement? Autopay { get; set; }

    /// <summary>
    /// ContactUs section of payment page
    /// </summary>
    [JsonPropertyName("contactUs")]
    public ContactElement? ContactUs { get; set; }

    /// <summary>
    /// Identifier of entry point owner of page
    /// </summary>
    [JsonPropertyName("entry")]
    public string? Entry { get; set; }

    /// <summary>
    /// Invoices section of payment page
    /// </summary>
    [JsonPropertyName("invoices")]
    public InvoiceElement? Invoices { get; set; }

    /// <summary>
    /// Logo section of payment page
    /// </summary>
    [JsonPropertyName("logo")]
    public Element? Logo { get; set; }

    /// <summary>
    /// Message section of payment page
    /// </summary>
    [JsonPropertyName("messageBeforePaying")]
    public LabelElement? MessageBeforePaying { get; set; }

    /// <summary>
    /// Descriptor of page
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Notes section of payment page
    /// </summary>
    [JsonPropertyName("notes")]
    public NoteElement? Notes { get; set; }

    /// <summary>
    /// Page header section of payment page
    /// </summary>
    [JsonPropertyName("page")]
    public PageElement? Page { get; set; }

    /// <summary>
    /// Payment button section of payment page
    /// </summary>
    [JsonPropertyName("paymentButton")]
    public LabelElement? PaymentButton { get; set; }

    /// <summary>
    /// Payment methods section of payment page
    /// </summary>
    [JsonPropertyName("paymentMethods")]
    public MethodElement? PaymentMethods { get; set; }

    /// <summary>
    /// Customer/Payor section of payment page
    /// </summary>
    [JsonPropertyName("payor")]
    public PayorElement? Payor { get; set; }

    /// <summary>
    /// Review section of payment page
    /// </summary>
    [JsonPropertyName("review")]
    public HeaderElement? Review { get; set; }

    /// <summary>
    /// Unique identifier assigned to the page.
    /// </summary>
    [JsonPropertyName("subdomain")]
    public string? Subdomain { get; set; }

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
