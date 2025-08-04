using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// The wallet data.
/// </summary>
[Serializable]
public record GoogleWalletData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The Google Pay merchant identifier.
    /// </summary>
    [JsonPropertyName("gatewayMerchantId")]
    public string? GatewayMerchantId { get; set; }

    /// <summary>
    /// The Google Pay gateway identifier.
    /// </summary>
    [JsonPropertyName("gatewayId")]
    public string? GatewayId { get; set; }

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
