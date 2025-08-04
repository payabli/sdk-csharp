using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record MethodElementSettingsApplePay : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The Apple Pay button style. See [Apple Pay Button Style](/developers/developer-guides/hosted-payment-page-apple-pay#param-applepay-button-style) for more information.
    /// </summary>
    [JsonPropertyName("buttonStyle")]
    public MethodElementSettingsApplePayButtonStyle? ButtonStyle { get; set; }

    /// <summary>
    /// The text on Apple Pay button. See [Apple Pay Button Type](/developers/developer-guides/hosted-payment-page-apple-pay#param-applepay-button-type) for more information.
    /// </summary>
    [JsonPropertyName("buttonType")]
    public MethodElementSettingsApplePayButtonType? ButtonType { get; set; }

    /// <summary>
    /// The Apple Pay button locale. See [Apple Pay Button Language](/developers/developer-guides/hosted-payment-page-apple-pay#param-applepay-language) for more information.
    /// </summary>
    [JsonPropertyName("language")]
    public MethodElementSettingsApplePayLanguage? Language { get; set; }

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
