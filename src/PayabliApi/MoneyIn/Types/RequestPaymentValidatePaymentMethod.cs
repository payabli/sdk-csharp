using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Object describing payment method to use for validation.
/// </summary>
[Serializable]
public record RequestPaymentValidatePaymentMethod : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("method")]
    public required RequestPaymentValidatePaymentMethodMethod Method { get; set; }

    [JsonPropertyName("cardnumber")]
    public required string Cardnumber { get; set; }

    [JsonPropertyName("cardexp")]
    public required string Cardexp { get; set; }

    [JsonPropertyName("cardzip")]
    public required string Cardzip { get; set; }

    [JsonPropertyName("cardHolder")]
    public required string CardHolder { get; set; }

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
