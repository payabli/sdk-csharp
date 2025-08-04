using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Object containing receipt body configuration
/// </summary>
[Serializable]
public record ReceiptContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Section amount of payment receipt
    /// </summary>
    [JsonPropertyName("amount")]
    public Element? Amount { get; set; }

    /// <summary>
    /// Section contactUs of payment receipt
    /// </summary>
    [JsonPropertyName("contactUs")]
    public Element? ContactUs { get; set; }

    /// <summary>
    /// Section payment details of payment receipt
    /// </summary>
    [JsonPropertyName("details")]
    public Element? Details { get; set; }

    /// <summary>
    /// Section logo of payment receipt
    /// </summary>
    [JsonPropertyName("logo")]
    public Element? Logo { get; set; }

    /// <summary>
    /// Section message of payment receipt
    /// </summary>
    [JsonPropertyName("messageBeforeButton")]
    public LabelElement? MessageBeforeButton { get; set; }

    /// <summary>
    /// Section page of payment receipt
    /// </summary>
    [JsonPropertyName("page")]
    public PageElement? Page { get; set; }

    /// <summary>
    /// Section payment button of payment receipt
    /// </summary>
    [JsonPropertyName("paymentButton")]
    public LabelElement? PaymentButton { get; set; }

    /// <summary>
    /// Section payment information of payment receipt
    /// </summary>
    [JsonPropertyName("paymentInformation")]
    public Element? PaymentInformation { get; set; }

    /// <summary>
    /// The receipt's settings.
    /// </summary>
    [JsonPropertyName("settings")]
    public SettingElement? Settings { get; set; }

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
