using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record DeviceQueryRecord : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Unique identifier for the cloud device.
    /// </summary>
    [JsonPropertyName("deviceId")]
    public string? DeviceId { get; set; }

    /// <summary>
    /// Internal cloud device record ID.
    /// </summary>
    [JsonPropertyName("idCloud")]
    public int? IdCloud { get; set; }

    /// <summary>
    /// Description of the device.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Serial number of the device.
    /// </summary>
    [JsonPropertyName("serialNumber")]
    public string? SerialNumber { get; set; }

    /// <summary>
    /// Human-readable name for the device.
    /// </summary>
    [JsonPropertyName("friendlyName")]
    public string? FriendlyName { get; set; }

    /// <summary>
    /// Manufacturer of the device.
    /// </summary>
    [JsonPropertyName("make")]
    public string? Make { get; set; }

    /// <summary>
    /// Model name of the device.
    /// </summary>
    [JsonPropertyName("model")]
    public string? Model { get; set; }

    /// <summary>
    /// Type of device.
    /// </summary>
    [JsonPropertyName("deviceType")]
    public int? DeviceType { get; set; }

    /// <summary>
    /// Current status of the device.
    /// </summary>
    [JsonPropertyName("deviceStatus")]
    public int? DeviceStatus { get; set; }

    /// <summary>
    /// Operating system of the device.
    /// </summary>
    [JsonPropertyName("deviceOs")]
    public int? DeviceOs { get; set; }

    /// <summary>
    /// MAC address of the device.
    /// </summary>
    [JsonPropertyName("macAddress")]
    public string? MacAddress { get; set; }

    /// <summary>
    /// Timestamp of the last health check from the device.
    /// </summary>
    [JsonPropertyName("lastHealthCheck")]
    public string? LastHealthCheck { get; set; }

    /// <summary>
    /// Registration code used to activate the device.
    /// </summary>
    [JsonPropertyName("registrationCode")]
    public string? RegistrationCode { get; set; }

    /// <summary>
    /// Number of activation attempts for the device.
    /// </summary>
    [JsonPropertyName("activationAttempts")]
    public int? ActivationAttempts { get; set; }

    /// <summary>
    /// Expiration timestamp for the device activation code.
    /// </summary>
    [JsonPropertyName("activationCodeExpiry")]
    public string? ActivationCodeExpiry { get; set; }

    /// <summary>
    /// Timestamp when the device record was created.
    /// </summary>
    [JsonPropertyName("createdAt")]
    public string? CreatedAt { get; set; }

    /// <summary>
    /// Timestamp when the device record was last updated.
    /// </summary>
    [JsonPropertyName("updatedAt")]
    public string? UpdatedAt { get; set; }

    /// <summary>
    /// Numeric identifier for the paypoint.
    /// </summary>
    [JsonPropertyName("paypointId")]
    public int? PaypointId { get; set; }

    /// <summary>
    /// DBA name for the paypoint.
    /// </summary>
    [JsonPropertyName("paypointDba")]
    public string? PaypointDba { get; set; }

    /// <summary>
    /// Legal name for the paypoint.
    /// </summary>
    [JsonPropertyName("paypointLegal")]
    public string? PaypointLegal { get; set; }

    /// <summary>
    /// Entry identifier for the paypoint.
    /// </summary>
    [JsonPropertyName("paypointEntry")]
    public string? PaypointEntry { get; set; }

    /// <summary>
    /// External identifier for the paypoint.
    /// </summary>
    [JsonPropertyName("externalPaypointId")]
    public string? ExternalPaypointId { get; set; }

    /// <summary>
    /// Numeric identifier for the parent organization.
    /// </summary>
    [JsonPropertyName("parentOrgId")]
    public int? ParentOrgId { get; set; }

    /// <summary>
    /// Name of the parent organization.
    /// </summary>
    [JsonPropertyName("parentOrgName")]
    public string? ParentOrgName { get; set; }

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
