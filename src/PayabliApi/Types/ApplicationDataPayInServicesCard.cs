using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record ApplicationDataPayInServicesCard : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Determines whether American Express is accepted.
    /// </summary>
    [JsonPropertyName("acceptAmex")]
    public bool? AcceptAmex { get; set; }

    /// <summary>
    /// Determines whether Discover is accepted.
    /// </summary>
    [JsonPropertyName("acceptDiscover")]
    public bool? AcceptDiscover { get; set; }

    /// <summary>
    /// Determines whether Mastercard is accepted.
    /// </summary>
    [JsonPropertyName("acceptMastercard")]
    public bool? AcceptMastercard { get; set; }

    /// <summary>
    /// Determines whether Visa is accepted.
    /// </summary>
    [JsonPropertyName("acceptVisa")]
    public bool? AcceptVisa { get; set; }

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
