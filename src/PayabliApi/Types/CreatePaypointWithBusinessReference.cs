using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Create a paypoint under an existing business. Provide `businessReference` plus `doingBusinessAs`; all other fields are optional.
/// </summary>
[Serializable]
public record CreatePaypointWithBusinessReference : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The reference of the existing business the paypoint boards under.
    /// </summary>
    [JsonPropertyName("businessReference")]
    public required string BusinessReference { get; set; }

    /// <summary>
    /// The reference of the parent paypoint, for a paypoint that nests under another.
    /// </summary>
    [JsonPropertyName("parentPaypointReference")]
    public string? ParentPaypointReference { get; set; }

    /// <summary>
    /// The paypoint type, for example `merchant`.
    /// </summary>
    [JsonPropertyName("paypointType")]
    public string? PaypointType { get; set; }

    /// <summary>
    /// The name the paypoint does business as (DBA).
    /// </summary>
    [JsonPropertyName("doingBusinessAs")]
    public required string DoingBusinessAs { get; set; }

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
    /// The paypoint's time zone.
    /// </summary>
    [JsonPropertyName("timezone")]
    public string? Timezone { get; set; }

    /// <summary>
    /// Your own identifier for the paypoint.
    /// </summary>
    [JsonPropertyName("externalId")]
    public string? ExternalId { get; set; }

    /// <summary>
    /// Arbitrary key-value data you attach to the paypoint.
    /// </summary>
    [JsonPropertyName("customData")]
    public Dictionary<string, object?>? CustomData { get; set; }

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
