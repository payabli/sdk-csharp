using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record DeviceEntry
{
    /// <summary>
    /// _Optional but recommended_ A unique ID that you can include to prevent duplicating objects or transactions in the case that a request is sent more than once. This key isn't generated in Payabli, you must generate it yourself. This key persists for 2 minutes. After 2 minutes, you can reuse the key if needed.
    /// </summary>
    [JsonIgnore]
    public string? IdempotencyKey { get; set; }

    /// <summary>
    /// Description or name for the device. This can be anything, but Payabli recommends entering the name of the paypoint, or some other easy to identify descriptor. If you have several devices for one paypoint, you can give them descriptions like "Cashier 1" and "Cashier 2", or "Front Desk" and "Back Office"
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// The device registration code or serial number, depending on the model.
    ///
    /// - Ingenico devices: This is the activation code that's displayed on the device screen during setup.
    ///
    /// - PAX A920 device: This code is the serial number on the back of the device.
    /// </summary>
    [JsonPropertyName("registrationCode")]
    public string? RegistrationCode { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
