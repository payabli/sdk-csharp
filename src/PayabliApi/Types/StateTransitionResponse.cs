using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// A single entry in a case's state history.
/// </summary>
[Serializable]
public record StateTransitionResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The transition's unique identifier.
    /// </summary>
    [JsonPropertyName("uuid")]
    public required string Uuid { get; set; }

    /// <summary>
    /// The case this transition belongs to.
    /// </summary>
    [JsonPropertyName("caseUuid")]
    public required string CaseUuid { get; set; }

    [JsonPropertyName("fromState")]
    public required CaseState FromState { get; set; }

    [JsonPropertyName("toState")]
    public required CaseState ToState { get; set; }

    /// <summary>
    /// The IP address of the actor. Null for system transitions.
    /// </summary>
    [JsonPropertyName("ipAddress")]
    public string? IpAddress { get; set; }

    /// <summary>
    /// The numeric id of the user who triggered the transition. Null for system transitions.
    /// </summary>
    [JsonPropertyName("triggeredBy")]
    public long? TriggeredBy { get; set; }

    /// <summary>
    /// The reason recorded for the transition.
    /// </summary>
    [JsonPropertyName("reason")]
    public string? Reason { get; set; }

    /// <summary>
    /// When the transition occurred.
    /// </summary>
    [JsonPropertyName("createdAt")]
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// The resolved user who triggered the transition. Null for system transitions.
    /// </summary>
    [JsonPropertyName("triggeredByUser")]
    public UserRef? TriggeredByUser { get; set; }

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
