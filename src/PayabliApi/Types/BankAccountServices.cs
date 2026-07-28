using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// The Pay In and Pay Out services the bank account applies to. Include at least one entry across the two lists.
/// </summary>
[Serializable]
public record BankAccountServices : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Pay In services the account is used for.
    /// </summary>
    [JsonPropertyName("moneyIn")]
    public IEnumerable<MoneyInService>? MoneyIn { get; set; }

    /// <summary>
    /// Pay Out services the account is used for.
    /// </summary>
    [JsonPropertyName("moneyOut")]
    public IEnumerable<MoneyOutService>? MoneyOut { get; set; }

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
