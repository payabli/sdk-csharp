using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record ReissuePayoutResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("isSuccess")]
    public required bool IsSuccess { get; set; }

    [JsonPropertyName("responseCode")]
    public required int ResponseCode { get; set; }

    [JsonPropertyName("responseText")]
    public required string ResponseText { get; set; }

    [JsonPropertyName("responseData")]
    public required ReissuePayoutResponseData ResponseData { get; set; }

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
