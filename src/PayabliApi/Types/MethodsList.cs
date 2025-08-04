using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record MethodsList : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// When `true`, American Express is accepted.
    /// </summary>
    [JsonPropertyName("amex")]
    public bool? Amex { get; set; }

    /// <summary>
    /// When `true`, Apple Pay is accepted.
    /// </summary>
    [JsonPropertyName("applePay")]
    public bool? ApplePay { get; set; }

    /// <summary>
    /// When `true`, Google Pay is accepted.
    /// </summary>
    [JsonPropertyName("googlePay")]
    public bool? GooglePay { get; set; }

    /// <summary>
    /// When `true`, Discover is accepted.
    /// </summary>
    [JsonPropertyName("discover")]
    public bool? Discover { get; set; }

    /// <summary>
    /// When `true`, ACH is accepted.
    /// </summary>
    [JsonPropertyName("eCheck")]
    public bool? ECheck { get; set; }

    /// <summary>
    /// When `true`, Mastercard is accepted.
    /// </summary>
    [JsonPropertyName("mastercard")]
    public bool? Mastercard { get; set; }

    /// <summary>
    /// When `true`, Visa is accepted.
    /// </summary>
    [JsonPropertyName("visa")]
    public bool? Visa { get; set; }

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
