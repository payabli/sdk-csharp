using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Information about the point of interaction device (also known as a terminal or cloud device) used to process the transaction.
/// </summary>
[Serializable]
public record PoiDevice : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The device connection status.
    /// </summary>
    [JsonPropertyName("connected")]
    public bool? Connected { get; set; }

    /// <summary>
    /// The date the device was unregistered.
    /// </summary>
    [JsonPropertyName("dateDeRegistered")]
    public DateTime? DateDeRegistered { get; set; }

    /// <summary>
    /// The date the device was registered.
    /// </summary>
    [JsonPropertyName("dateRegistered")]
    public DateTime? DateRegistered { get; set; }

    /// <summary>
    /// The device identifier.
    /// </summary>
    [JsonPropertyName("deviceId")]
    public string? DeviceId { get; set; }

    /// <summary>
    /// Device license. This is typically the same as `deviceId`.
    /// </summary>
    [JsonPropertyName("deviceLicense")]
    public string? DeviceLicense { get; set; }

    /// <summary>
    /// Device description provided during registration.
    /// </summary>
    [JsonPropertyName("deviceNickName")]
    public string? DeviceNickName { get; set; }

    /// <summary>
    /// Last connected date.
    /// </summary>
    [JsonPropertyName("lastConnectedDate")]
    public DateTime? LastConnectedDate { get; set; }

    /// <summary>
    /// Last disconnected date.
    /// </summary>
    [JsonPropertyName("lastDisconnectedDate")]
    public DateTime? LastDisconnectedDate { get; set; }

    /// <summary>
    /// Last transaction date.
    /// </summary>
    [JsonPropertyName("lastTransactionDate")]
    public DateTime? LastTransactionDate { get; set; }

    /// <summary>
    /// The device manufacturer.
    /// </summary>
    [JsonPropertyName("make")]
    public string? Make { get; set; }

    /// <summary>
    /// The device model.
    /// </summary>
    [JsonPropertyName("model")]
    public string? Model { get; set; }

    /// <summary>
    /// The device registration status.
    /// </summary>
    [JsonPropertyName("registered")]
    public bool? Registered { get; set; }

    /// <summary>
    /// The device serial number.
    /// </summary>
    [JsonPropertyName("serialNumber")]
    public string? SerialNumber { get; set; }

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
