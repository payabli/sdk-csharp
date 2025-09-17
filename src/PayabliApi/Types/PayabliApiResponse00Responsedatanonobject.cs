using System.Text.Json;
using System.Text.Json.Serialization;
using OneOf;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record PayabliApiResponse00Responsedatanonobject : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("responseCode")]
    public int? ResponseCode { get; set; }

    [JsonPropertyName("pageIdentifier")]
    public string? PageIdentifier { get; set; }

    /// <summary>
    /// Describes the room ID. Only in use on Boarding endpoints, returns `0` when not applicable.
    /// </summary>
    [JsonPropertyName("roomId")]
    public long? RoomId { get; set; }

    [JsonPropertyName("isSuccess")]
    public bool? IsSuccess { get; set; }

    [JsonPropertyName("responseText")]
    public required string ResponseText { get; set; }

    [JsonPropertyName("responseData")]
    public OneOf<string, int>? ResponseData { get; set; }

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
