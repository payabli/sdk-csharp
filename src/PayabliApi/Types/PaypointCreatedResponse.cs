using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// The reference and initial status of a newly created paypoint.
/// </summary>
[Serializable]
public record PaypointCreatedResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The paypoint reference, used to read and manage the paypoint.
    /// </summary>
    [JsonPropertyName("paypointReference")]
    public required string PaypointReference { get; set; }

    /// <summary>
    /// The reference of the business the paypoint belongs to.
    /// </summary>
    [JsonPropertyName("businessReference")]
    public string? BusinessReference { get; set; }

    /// <summary>
    /// The name the paypoint does business as (DBA).
    /// </summary>
    [JsonPropertyName("doingBusinessAs")]
    public string? DoingBusinessAs { get; set; }

    /// <summary>
    /// The paypoint status. New paypoints start in `pending`.
    /// </summary>
    [JsonPropertyName("paypointStatus")]
    public required string PaypointStatus { get; set; }

    /// <summary>
    /// The paypoint's time zone.
    /// </summary>
    [JsonPropertyName("timezone")]
    public string? Timezone { get; set; }

    /// <summary>
    /// When the paypoint was created.
    /// </summary>
    [JsonPropertyName("createdAt")]
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// Hypermedia links for the paypoint resource.
    /// </summary>
    [JsonPropertyName("_links")]
    public required PaypointLinks Links { get; set; }

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
