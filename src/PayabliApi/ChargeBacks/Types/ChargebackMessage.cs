using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record ChargebackMessage : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Message identifier.
    /// </summary>
    [JsonPropertyName("Id")]
    public required int Id { get; set; }

    /// <summary>
    /// Room identifier for the message.
    /// </summary>
    [JsonPropertyName("RoomId")]
    public required int RoomId { get; set; }

    /// <summary>
    /// User identifier who sent the message.
    /// </summary>
    [JsonPropertyName("UserId")]
    public required int UserId { get; set; }

    /// <summary>
    /// Name of the user who sent the message.
    /// </summary>
    [JsonPropertyName("UserName")]
    public required string UserName { get; set; }

    /// <summary>
    /// Content of the message.
    /// </summary>
    [JsonPropertyName("Content")]
    public required string Content { get; set; }

    /// <summary>
    /// Timestamp when the message was created.
    /// </summary>
    [JsonPropertyName("CreatedAt")]
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// Type of message.
    /// </summary>
    [JsonPropertyName("MessageType")]
    public required int MessageType { get; set; }

    /// <summary>
    /// Additional properties of the message.
    /// </summary>
    [JsonPropertyName("MessageProperties")]
    public Dictionary<string, string>? MessageProperties { get; set; }

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
