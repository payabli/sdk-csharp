using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Details of the registered device used for the transaction. `null` when the
/// transaction has no `DeviceId`, or when no matching device is registered to
/// the paypoint.
/// </summary>
[Serializable]
public record QueryDeviceData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Device type, for example `SemiIntegrated`, `Standalone`, or `Softpos`.
    /// </summary>
    [JsonPropertyName("deviceType")]
    public string? DeviceType { get; set; }

    /// <summary>
    /// Device operating system, for example `Ios` or `Android`.
    /// </summary>
    [JsonPropertyName("deviceOs")]
    public string? DeviceOs { get; set; }

    /// <summary>
    /// Name assigned to the device at registration.
    /// </summary>
    [JsonPropertyName("friendlyName")]
    public string? FriendlyName { get; set; }

    /// <summary>
    /// Device serial number.
    /// </summary>
    [JsonPropertyName("serialNumber")]
    public string? SerialNumber { get; set; }

    /// <summary>
    /// Device manufacturer. Can be an empty string.
    /// </summary>
    [JsonPropertyName("make")]
    public string? Make { get; set; }

    /// <summary>
    /// Device model.
    /// </summary>
    [JsonPropertyName("model")]
    public string? Model { get; set; }

    /// <summary>
    /// Device MAC address.
    /// </summary>
    [JsonPropertyName("macAddress")]
    public string? MacAddress { get; set; }

    /// <summary>
    /// Device registration status: `Inactive`, `Active`, `Pending`, `Superseded`, `Unregistering`, or `Unregistered`.
    /// </summary>
    [JsonPropertyName("deviceStatus")]
    public string? DeviceStatus { get; set; }

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
