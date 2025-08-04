using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record TokenizeCard : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The type of payment method to tokenize. For cards, this is always `card`.
    /// </summary>
    [JsonPropertyName("method")]
    public required string Method { get; set; }

    [JsonPropertyName("cardcvv")]
    public string? Cardcvv { get; set; }

    [JsonPropertyName("cardexp")]
    public required string Cardexp { get; set; }

    [JsonPropertyName("cardHolder")]
    public required string CardHolder { get; set; }

    [JsonPropertyName("cardnumber")]
    public required string Cardnumber { get; set; }

    [JsonPropertyName("cardzip")]
    public string? Cardzip { get; set; }

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
