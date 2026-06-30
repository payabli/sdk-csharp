using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record PayLinkDataInvoice
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

    /// <summary>
    /// _Optional but recommended_ A unique ID that you can include to prevent duplicating objects or transactions in the case that a request is sent more than once. This key isn't generated in Payabli, you must generate it yourself. This key persists for 2 minutes. After 2 minutes, you can reuse the key if needed.
    /// </summary>
    [JsonIgnore]
    public string? IdempotencyKey { get; set; }

    /// <summary>
    /// Contact us section of payment link page. If omitted, this block is enabled at display order 11.
    /// </summary>
    [JsonPropertyName("contactUs")]
    public ContactElement? ContactUs { get; set; }

    /// <summary>
    /// Invoices section of payment link page. Required. Omitting it returns a `400` error with code `7045`.
    /// </summary>
    [JsonPropertyName("invoices")]
    public required InvoiceElement Invoices { get; set; }

    /// <summary>
    /// Logo section of payment link page. If omitted, this block is enabled at display order 1, and the logo image is resolved from the paypoint's entry logo.
    /// </summary>
    [JsonPropertyName("logo")]
    public Element? Logo { get; set; }

    /// <summary>
    /// Message section of payment link page. If omitted, this block is enabled at display order 5.
    /// </summary>
    [JsonPropertyName("messageBeforePaying")]
    public LabelElement? MessageBeforePaying { get; set; }

    /// <summary>
    /// Notes section of payment link page. If omitted, this block is enabled at display order 10.
    /// </summary>
    [JsonPropertyName("notes")]
    public NoteElement? Notes { get; set; }

    /// <summary>
    /// Page header section of payment link page. If omitted, this block is enabled at display order 2.
    /// </summary>
    [JsonPropertyName("page")]
    public PageElement? Page { get; set; }

    /// <summary>
    /// Payment button section of payment link page. If omitted, this block is enabled at display order 6, with the label "Pay Now".
    /// </summary>
    [JsonPropertyName("paymentButton")]
    public LabelElement? PaymentButton { get; set; }

    /// <summary>
    /// Payment methods section of payment link page. If omitted, this block is enabled at display order 3, with all payment methods enabled except RDC.
    /// </summary>
    [JsonPropertyName("paymentMethods")]
    public MethodElement? PaymentMethods { get; set; }

    /// <summary>
    /// Customer/Payor section of payment link page
    /// </summary>
    [JsonPropertyName("payor")]
    public PayorElement? Payor { get; set; }

    /// <summary>
    /// Review section of payment link page. If omitted, this block is enabled at display order 4.
    /// </summary>
    [JsonPropertyName("review")]
    public HeaderElement? Review { get; set; }

    /// <summary>
    /// Settings section of payment link page. If omitted, defaults are applied, including page color `#10a0e3` and language `en`.
    /// </summary>
    [JsonPropertyName("settings")]
    public PagelinkSetting? Settings { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
