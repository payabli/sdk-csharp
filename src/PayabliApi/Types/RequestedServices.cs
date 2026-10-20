using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// The services the application requests, grouped by direction. Values are
/// case-insensitive on input and returned in the casing shown.
/// </summary>
[Serializable]
public record RequestedServices : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The Pay In services to request.
    /// </summary>
    [JsonPropertyName("moneyIn")]
    public IEnumerable<MoneyInService>? MoneyIn { get; set; }

    /// <summary>
    /// The Pay Out services to request.
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
