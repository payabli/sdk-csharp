using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record PayLinkData
{
    /// <summary>
    /// Indicates whether customer can modify the payment amount. A value of `true` means the amount isn't modifiable, a value `false` means the payor can modify the amount to pay.
    /// </summary>
    [JsonIgnore]
    public bool? AmountFixed { get; set; }

    /// <summary>
    /// List of recipient email addresses. When there is more than one, separate them by a semicolon (;).
    /// </summary>
    [JsonIgnore]
    public string? Mail2 { get; set; }

    [JsonIgnore]
    public string? IdempotencyKey { get; set; }

    /// <summary>
    /// ContactUs section of payment link page
    /// </summary>
    [JsonPropertyName("contactUs")]
    public ContactElement? ContactUs { get; set; }

    /// <summary>
    /// Invoices section of payment link page
    /// </summary>
    [JsonPropertyName("invoices")]
    public InvoiceElement? Invoices { get; set; }

    /// <summary>
    /// Logo section of payment link page
    /// </summary>
    [JsonPropertyName("logo")]
    public Element? Logo { get; set; }

    /// <summary>
    /// Message section of payment link page
    /// </summary>
    [JsonPropertyName("messageBeforePaying")]
    public LabelElement? MessageBeforePaying { get; set; }

    /// <summary>
    /// Notes section of payment link page
    /// </summary>
    [JsonPropertyName("notes")]
    public NoteElement? Notes { get; set; }

    /// <summary>
    /// Page header section of payment link page
    /// </summary>
    [JsonPropertyName("page")]
    public PageElement? Page { get; set; }

    /// <summary>
    /// Payment button section of payment link page
    /// </summary>
    [JsonPropertyName("paymentButton")]
    public LabelElement? PaymentButton { get; set; }

    /// <summary>
    /// Payment methods section of payment link page
    /// </summary>
    [JsonPropertyName("paymentMethods")]
    public MethodElement? PaymentMethods { get; set; }

    /// <summary>
    /// Customer/Payor section of payment link page
    /// </summary>
    [JsonPropertyName("payor")]
    public PayorElement? Payor { get; set; }

    /// <summary>
    /// Review section of payment link page
    /// </summary>
    [JsonPropertyName("review")]
    public HeaderElement? Review { get; set; }

    /// <summary>
    /// Settings section of payment link page
    /// </summary>
    [JsonPropertyName("settings")]
    public PagelinkSetting? Settings { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
