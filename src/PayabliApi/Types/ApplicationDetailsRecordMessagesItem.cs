using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record ApplicationDetailsRecordMessagesItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("content")]
    public string? Content { get; set; }

    [JsonPropertyName("createdAt")]
    public DateTime? CreatedAt { get; set; }

    [JsonPropertyName("currentApplicationStatus")]
    public int? CurrentApplicationStatus { get; set; }

    [JsonPropertyName("currentApplicationSubStatus")]
    public int? CurrentApplicationSubStatus { get; set; }

    [JsonPropertyName("id")]
    public int? Id { get; set; }

    [JsonPropertyName("messageType")]
    public int? MessageType { get; set; }

    [JsonPropertyName("originalApplicationStatus")]
    public int? OriginalApplicationStatus { get; set; }

    [JsonPropertyName("originalApplicationSubStatus")]
    public int? OriginalApplicationSubStatus { get; set; }

    [JsonPropertyName("roomId")]
    public int? RoomId { get; set; }

    [JsonPropertyName("userId")]
    public int? UserId { get; set; }

    [JsonPropertyName("userName")]
    public string? UserName { get; set; }

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
