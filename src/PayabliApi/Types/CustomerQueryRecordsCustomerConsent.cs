using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record CustomerQueryRecordsCustomerConsent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Describes the customer's email communications consent status.
    /// </summary>
    [JsonPropertyName("eCommunication")]
    public CustomerQueryRecordsCustomerConsentECommunication? ECommunication { get; set; }

    /// <summary>
    /// Describes the customer's SMS communications consent status.
    /// </summary>
    [JsonPropertyName("sms")]
    public CustomerQueryRecordsCustomerConsentSms? Sms { get; set; }

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
