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
    /// Version of the Payabli app running on the device.
    /// </summary>
    [JsonPropertyName("appVersion")]
    public string? AppVersion { get; set; }

    /// <summary>
    /// Version of Android running on the device.
    /// </summary>
    [JsonPropertyName("osVersion")]
    public string? OsVersion { get; set; }

    /// <summary>
    /// Type of device.
    /// </summary>
    [JsonPropertyName("deviceType")]
    public int? DeviceType { get; set; }

    /// <summary>
    /// Lifecycle status of the device, as an integer. A value of `1` means the
    /// device is active. This field doesn't show whether the device is running
    /// a command. To check whether the device can accept a transaction now,
    /// use `operationalStatus`.
    /// </summary>
    [JsonPropertyName("deviceStatus")]
    public int? DeviceStatus { get; set; }

    /// <summary>
    /// Shows whether the device can accept a transaction now. The value
    /// reflects the device's state when you send the query.
    ///
    /// - `online`: The device is active and isn't running a command. It can
    ///   accept a transaction.
    /// - `busy`: The device is running a command that's pending, dispatched,
    ///   or processing, and the command hasn't expired. A new transaction sent
    ///   to the device fails with error `E7069` (Device busy). Wait for the
    ///   command to finish or expire, then query the device again.
    /// - `offline`: The device isn't active, so it can't accept transactions.
    ///   Its lifecycle status (`deviceStatus`) isn't active.
    ///
    /// Check this field before you send a transaction to a device.
    /// </summary>
    [JsonPropertyName("operationalStatus")]
    public required DeviceQueryRecordOperationalStatus OperationalStatus { get; set; }

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
    /// URL of the paypoint's logo, when available.
    /// </summary>
    [JsonPropertyName("paypointLogo")]
    public string? PaypointLogo { get; set; }

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

    /// <summary>
    /// URL of the parent organization's logo, when available.
    /// </summary>
    [JsonPropertyName("parentOrgLogo")]
    public string? ParentOrgLogo { get; set; }

    /// <summary>
    /// Total number of transactions processed by this device.
    /// </summary>
    [JsonPropertyName("transactionCount")]
    public required int TransactionCount { get; set; }

    /// <summary>
    /// Total volume processed by this device, as the sum of net transaction amounts.
    /// </summary>
    [JsonPropertyName("volumeProcessed")]
    public required double VolumeProcessed { get; set; }

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
