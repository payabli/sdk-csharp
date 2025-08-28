using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Response for MoneyIn/void endpoint
/// </summary>
[Serializable]
public record VoidResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("responseCode")]
    public required int ResponseCode { get; set; }

    [JsonPropertyName("pageIdentifier")]
    public string? PageIdentifier { get; set; }

    [JsonPropertyName("roomId")]
    public required long RoomId { get; set; }

    [JsonPropertyName("isSuccess")]
    public required bool IsSuccess { get; set; }

    [JsonPropertyName("responseText")]
    public required string ResponseText { get; set; }

    [JsonPropertyName("responseData")]
    public required VoidResponseData ResponseData { get; set; }

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
