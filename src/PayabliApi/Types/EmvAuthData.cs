using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// EMV data exchanged during the authorization of a device transaction. `null`
/// when both values are `null`, such as for swiped cards, device transactions
/// that never reached the processor, and non-device transactions.
/// </summary>
[Serializable]
public record EmvAuthData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// EMV tag-length-value (TLV) data the device sent with the authorization request.
    /// </summary>
    [JsonPropertyName("RequestEmvData")]
    public string? RequestEmvData { get; set; }

    /// <summary>
    /// EMV data returned in the authorization response. Same value as `ResponseData.emv_auth_response_data`.
    /// </summary>
    [JsonPropertyName("ResponseEmvData")]
    public string? ResponseEmvData { get; set; }

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
