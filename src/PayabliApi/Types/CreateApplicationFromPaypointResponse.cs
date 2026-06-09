using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Response returned when creating a boarding application linked to an existing paypoint.
/// </summary>
[Serializable]
public record CreateApplicationFromPaypointResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("responseCode")]
    public int? ResponseCode { get; set; }

    [JsonPropertyName("pageIdentifier")]
    public string? PageIdentifier { get; set; }

    [JsonPropertyName("roomId")]
    public long? RoomId { get; set; }

    [JsonPropertyName("isSuccess")]
    public bool? IsSuccess { get; set; }

    [JsonPropertyName("responseText")]
    public required string ResponseText { get; set; }

    [JsonPropertyName("responseData")]
    public CreateApplicationFromPaypointResponseData? ResponseData { get; set; }

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
