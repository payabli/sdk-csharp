using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Configuration for payment method selection on Pay Out payment links.
/// </summary>
[Serializable]
public record MethodElementOut : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Flag indicating if all allowed payment methods will be pre-selected.
    /// </summary>
    [JsonPropertyName("allMethodsChecked")]
    public bool? AllMethodsChecked { get; set; }

    /// <summary>
    /// When `true`, the vendor can select from multiple payment methods. When `false`, only the default method is shown.
    /// </summary>
    [JsonPropertyName("allowMultipleMethods")]
    public bool? AllowMultipleMethods { get; set; }

    /// <summary>
    /// The default payment method to highlight on the payment link page. For example, `"vcard"`, `"ach"`, or `"check"`.
    /// </summary>
    [JsonPropertyName("defaultMethod")]
    public string? DefaultMethod { get; set; }

    /// <summary>
    /// When `true`, the payment methods section is displayed on the payment link page.
    /// </summary>
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    /// <summary>
    /// Header text for the payment methods section.
    /// </summary>
    [JsonPropertyName("header")]
    public string? Header { get; set; }

    [JsonPropertyName("methods")]
    public MethodsListOut? Methods { get; set; }

    /// <summary>
    /// Display order of the payment methods section on the page.
    /// </summary>
    [JsonPropertyName("order")]
    public int? Order { get; set; }

    /// <summary>
    /// When `true`, a preview of the virtual card is shown on the payment link page.
    /// </summary>
    [JsonPropertyName("showPreviewVirtualCard")]
    public bool? ShowPreviewVirtualCard { get; set; }

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
