using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// A cursor-paginated page of case notes, ordered oldest to newest.
/// </summary>
[Serializable]
public record MessagePage : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The notes on this page.
    /// </summary>
    [JsonPropertyName("messages")]
    public IEnumerable<RoomMessageView> Messages { get; set; } = new List<RoomMessageView>();

    /// <summary>
    /// The cursor for the next page. Null when there are no more notes.
    /// </summary>
    [JsonPropertyName("nextCursor")]
    public string? NextCursor { get; set; }

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
