using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record MethodElement : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Flag indicating if all allowed payment methods will be pre-selected.
    /// </summary>
    [JsonPropertyName("allMethodsChecked")]
    public bool? AllMethodsChecked { get; set; }

    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    /// <summary>
    /// Header text for section
    /// </summary>
    [JsonPropertyName("header")]
    public string? Header { get; set; }

    [JsonPropertyName("methods")]
    public MethodsList? Methods { get; set; }

    [JsonPropertyName("order")]
    public int? Order { get; set; }

    /// <summary>
    /// Description text shown in the payment methods section.
    /// </summary>
    [JsonPropertyName("paymentDescription")]
    public string? PaymentDescription { get; set; }

    /// <summary>
    /// Settings for wallet payment methods.
    /// </summary>
    [JsonPropertyName("settings")]
    public MethodElementSettings? Settings { get; set; }

    /// <summary>
    /// Controls whether the "Save payment details for future use" checkbox appears on the hosted payment page. Set to `false` to hide the checkbox. Defaults to `true`.
    /// </summary>
    [JsonPropertyName("showSaveMethod")]
    public bool? ShowSaveMethod { get; set; }

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
