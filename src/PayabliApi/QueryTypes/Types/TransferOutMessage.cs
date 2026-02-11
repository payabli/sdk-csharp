using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// A message associated with an outbound transfer.
/// </summary>
[Serializable]
public record TransferOutMessage : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Unique identifier for the message.
    /// </summary>
    [JsonPropertyName("Id")]
    public int? Id { get; set; }

    /// <summary>
    /// The ID of the room where the message was sent.
    /// </summary>
    [JsonPropertyName("RoomId")]
    public int? RoomId { get; set; }

    /// <summary>
    /// The ID of the user who sent the message.
    /// </summary>
    [JsonPropertyName("UserId")]
    public int? UserId { get; set; }

    /// <summary>
    /// The name of the user who sent the message.
    /// </summary>
    [JsonPropertyName("UserName")]
    public string? UserName { get; set; }

    /// <summary>
    /// The content of the message.
    /// </summary>
    [JsonPropertyName("Content")]
    public string? Content { get; set; }

    /// <summary>
    /// The time the message was created.
    /// </summary>
    [JsonPropertyName("CreatedAt")]
    public string? CreatedAt { get; set; }

    /// <summary>
    /// The type of message.
    /// </summary>
    [JsonPropertyName("MessageType")]
    public int? MessageType { get; set; }

    /// <summary>
    /// Additional properties for the message.
    /// </summary>
    [JsonPropertyName("MessageProperties")]
    public TransferOutMessageProperties? MessageProperties { get; set; }

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
