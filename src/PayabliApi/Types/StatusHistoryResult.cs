using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// An application's status history.
/// </summary>
[Serializable]
public record StatusHistoryResult : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The application reference.
    /// </summary>
    [JsonPropertyName("requestsReference")]
    public required string RequestsReference { get; set; }

    /// <summary>
    /// The status transitions, oldest first.
    /// </summary>
    [JsonPropertyName("history")]
    public IEnumerable<StatusHistoryEntry> History { get; set; } = new List<StatusHistoryEntry>();

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
