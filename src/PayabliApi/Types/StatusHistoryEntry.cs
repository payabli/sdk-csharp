using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// A single transition in an application's status history.
/// </summary>
[Serializable]
public record StatusHistoryEntry : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The status before the transition. The transition that creates the application has a `fromStatus` of `none`.
    /// </summary>
    [JsonPropertyName("fromStatus")]
    public required string FromStatus { get; set; }

    /// <summary>
    /// The status after the transition.
    /// </summary>
    [JsonPropertyName("toStatus")]
    public required string ToStatus { get; set; }

    /// <summary>
    /// What triggered the transition (for example, `Create` or `Withdraw`).
    /// </summary>
    [JsonPropertyName("trigger")]
    public required string Trigger { get; set; }

    /// <summary>
    /// The identifier of the actor that triggered the transition.
    /// </summary>
    [JsonPropertyName("actor")]
    public string? Actor { get; set; }

    /// <summary>
    /// The reason recorded for the transition.
    /// </summary>
    [JsonPropertyName("reason")]
    public string? Reason { get; set; }

    /// <summary>
    /// Additional metadata about the transition.
    /// </summary>
    [JsonPropertyName("metadata")]
    public Dictionary<string, object?>? Metadata { get; set; }

    /// <summary>
    /// When the transition occurred.
    /// </summary>
    [JsonPropertyName("createdAt")]
    public required string CreatedAt { get; set; }

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
