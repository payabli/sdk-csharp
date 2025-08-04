using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record PayMethodCredit : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("cardcvv")]
    public string? Cardcvv { get; set; }

    [JsonPropertyName("cardexp")]
    public required string Cardexp { get; set; }

    [JsonPropertyName("cardHolder")]
    public string? CardHolder { get; set; }

    [JsonPropertyName("cardnumber")]
    public required string Cardnumber { get; set; }

    [JsonPropertyName("cardzip")]
    public string? Cardzip { get; set; }

    [JsonPropertyName("initiator")]
    public string? Initiator { get; set; }

    /// <summary>
    /// Method to use for the transaction. For transactions with a credit or debit card, or a tokenized card, use `card`.
    /// </summary>
    [JsonPropertyName("method")]
    public string Method { get; set; } = "card";

    [JsonPropertyName("saveIfSuccess")]
    public bool? SaveIfSuccess { get; set; }

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
