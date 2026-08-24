using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// The required fields for a payment made with a semi-integrated device.
/// </summary>
[Serializable]
public record PayMethodDevice : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Identifier of the registered semi-integrated device that takes the payment.
    /// Omitting this field returns response code 7017, and an identifier that
    /// isn't registered to the paypoint returns 7018.
    /// </summary>
    [JsonPropertyName("device")]
    public required string Device { get; set; }

    /// <summary>
    /// Method to use for the transaction. For semi-integrated device transactions, the method is `device`.
    /// </summary>
    [JsonPropertyName("method")]
    public required PayMethodDeviceMethod Method { get; set; }

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
