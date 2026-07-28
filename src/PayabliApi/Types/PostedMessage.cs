using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// The result of posting a note to a case.
/// </summary>
[Serializable]
public record PostedMessage : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The new message's identifier.
    /// </summary>
    [JsonPropertyName("messageId")]
    public required long MessageId { get; set; }

    /// <summary>
    /// The message room the note was posted to.
    /// </summary>
    [JsonPropertyName("roomId")]
    public required long RoomId { get; set; }

    /// <summary>
    /// When the note was posted.
    /// </summary>
    [JsonPropertyName("createdAt")]
    public required DateTime CreatedAt { get; set; }

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
