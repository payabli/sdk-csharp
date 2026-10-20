using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// The result of a lifecycle action, with the application's new status.
/// </summary>
[Serializable]
public record TransitionResult : IJsonOnDeserialized
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
    /// The application's lifecycle status after the action. See the application object for the list of statuses.
    /// </summary>
    [JsonPropertyName("applicationStatus")]
    public required string ApplicationStatus { get; set; }

    /// <summary>
    /// The lifecycle actions now allowed on the application. The list can include actions that Payabli or its internal services perform, which you can't call through the API.
    /// </summary>
    [JsonPropertyName("allowedActions")]
    public IEnumerable<string> AllowedActions { get; set; } = new List<string>();

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
