using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// The required and recommended fields for a payment made with a stored payment method.
/// </summary>
[Serializable]
public record RequestSchedulePaymentMethodInitiator : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("initiator")]
    public string? Initiator { get; set; }

    /// <summary>
    /// Payabli identifier of a tokenized payment method.
    /// </summary>
    [JsonPropertyName("storedMethodId")]
    public string? StoredMethodId { get; set; }

    [JsonPropertyName("storedMethodUsageType")]
    public string? StoredMethodUsageType { get; set; }

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
