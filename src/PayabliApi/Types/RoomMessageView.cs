using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// A note on a case.
/// </summary>
[Serializable]
public record RoomMessageView : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The message's identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public required long Id { get; set; }

    /// <summary>
    /// The numeric id of the user who posted the note.
    /// </summary>
    [JsonPropertyName("userId")]
    public required long UserId { get; set; }

    /// <summary>
    /// The note text.
    /// </summary>
    [JsonPropertyName("content")]
    public required string Content { get; set; }

    /// <summary>
    /// When the note was posted.
    /// </summary>
    [JsonPropertyName("createdAt")]
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// When the note was last edited. Null when never edited.
    /// </summary>
    [JsonPropertyName("updatedAt")]
    public DateTime? UpdatedAt { get; set; }

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
