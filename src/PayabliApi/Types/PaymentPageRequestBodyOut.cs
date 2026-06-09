using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Configuration for the Pay Out payment link page. Controls branding, messaging, vendor fields, and which payout methods are offered to the vendor.
/// </summary>
[Serializable]
public record PaymentPageRequestBodyOut : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// ContactUs section of payment link page.
    /// </summary>
    [JsonPropertyName("contactUs")]
    public ContactElement? ContactUs { get; set; }

    /// <summary>
    /// Logo section of payment link page.
    /// </summary>
    [JsonPropertyName("logo")]
    public Element? Logo { get; set; }

    /// <summary>
    /// Message section of payment link page.
    /// </summary>
    [JsonPropertyName("messageBeforePaying")]
    public LabelElement? MessageBeforePaying { get; set; }

    /// <summary>
    /// Notes section of payment link page.
    /// </summary>
    [JsonPropertyName("notes")]
    public NoteElement? Notes { get; set; }

    /// <summary>
    /// Page header section of payment link page.
    /// </summary>
    [JsonPropertyName("page")]
    public PageElement? Page { get; set; }

    /// <summary>
    /// Payment button section of payment link page.
    /// </summary>
    [JsonPropertyName("paymentButton")]
    public LabelElement? PaymentButton { get; set; }

    /// <summary>
    /// Payment methods section of payment link page. Use this to configure which payout methods (ACH, vCard, check) are offered to the vendor.
    /// </summary>
    [JsonPropertyName("paymentMethods")]
    public MethodElementOut? PaymentMethods { get; set; }

    /// <summary>
    /// Review section of payment link page.
    /// </summary>
    [JsonPropertyName("review")]
    public HeaderElement? Review { get; set; }

    /// <summary>
    /// Bills section of payment link page.
    /// </summary>
    [JsonPropertyName("bills")]
    public Element? Bills { get; set; }

    /// <summary>
    /// Settings section of payment link page.
    /// </summary>
    [JsonPropertyName("settings")]
    public PagelinkSetting? Settings { get; set; }

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
