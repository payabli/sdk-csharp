using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record PageSetting : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// An HTML color code in format #RRGGBB
    /// </summary>
    [JsonPropertyName("color")]
    public string? Color { get; set; }

    /// <summary>
    /// Complete URL to a custom CSS file to be loaded with the page
    /// </summary>
    [JsonPropertyName("customCssUrl")]
    public string? CustomCssUrl { get; set; }

    /// <summary>
    /// Two-letter code following ISO 639-1
    /// </summary>
    [JsonPropertyName("language")]
    public string? Language { get; set; }

    /// <summary>
    /// Object containing logo file to upload/ use in page
    /// </summary>
    [JsonPropertyName("pageLogo")]
    public FileContent? PageLogo { get; set; }

    [JsonPropertyName("paymentButton")]
    public ButtomElement? PaymentButton { get; set; }

    /// <summary>
    /// Flag indicating if the capability for redirection in the page will be activated
    /// </summary>
    [JsonPropertyName("redirectAfterApprove")]
    public bool? RedirectAfterApprove { get; set; }

    /// <summary>
    /// Complete URL where the page will be redirected after completion
    /// </summary>
    [JsonPropertyName("redirectAfterApproveUrl")]
    public string? RedirectAfterApproveUrl { get; set; }

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
