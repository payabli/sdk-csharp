using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// The full detail of a paypoint.
/// </summary>
[Serializable]
public record PaypointDetailResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The paypoint reference.
    /// </summary>
    [JsonPropertyName("paypointReference")]
    public required string PaypointReference { get; set; }

    /// <summary>
    /// The reference of the business the paypoint belongs to.
    /// </summary>
    [JsonPropertyName("businessReference")]
    public string? BusinessReference { get; set; }

    /// <summary>
    /// The reference of the parent paypoint this paypoint nests under. For a merchant boarded directly under an organization, this is the organization, which is itself a paypoint.
    /// </summary>
    [JsonPropertyName("parentPaypointReference")]
    public required string ParentPaypointReference { get; set; }

    /// <summary>
    /// The paypoint type, for example `merchant`.
    /// </summary>
    [JsonPropertyName("paypointType")]
    public string? PaypointType { get; set; }

    /// <summary>
    /// The paypoint's current status.
    /// </summary>
    [JsonPropertyName("paypointStatus")]
    public required string PaypointStatus { get; set; }

    /// <summary>
    /// The name the paypoint does business as (DBA).
    /// </summary>
    [JsonPropertyName("doingBusinessAs")]
    public string? DoingBusinessAs { get; set; }

    /// <summary>
    /// A free-text description of the paypoint.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// The paypoint's website URL.
    /// </summary>
    [JsonPropertyName("website")]
    public string? Website { get; set; }

    /// <summary>
    /// The paypoint's time zone.
    /// </summary>
    [JsonPropertyName("timezone")]
    public string? Timezone { get; set; }

    /// <summary>
    /// The customer service phone number.
    /// </summary>
    [JsonPropertyName("customerServicePhone")]
    public string? CustomerServicePhone { get; set; }

    /// <summary>
    /// The customer service email address.
    /// </summary>
    [JsonPropertyName("customerServiceEmail")]
    public string? CustomerServiceEmail { get; set; }

    /// <summary>
    /// Your own identifier for the paypoint.
    /// </summary>
    [JsonPropertyName("externalId")]
    public string? ExternalId { get; set; }

    /// <summary>
    /// The paypoint's entrypoint name, used as the `entry` value on endpoints that target the paypoint.
    /// </summary>
    [JsonPropertyName("entryName")]
    public required string EntryName { get; set; }

    /// <summary>
    /// When the paypoint was created.
    /// </summary>
    [JsonPropertyName("createdAt")]
    public required string CreatedAt { get; set; }

    /// <summary>
    /// When the paypoint was last updated.
    /// </summary>
    [JsonPropertyName("updatedAt")]
    public required string UpdatedAt { get; set; }

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
