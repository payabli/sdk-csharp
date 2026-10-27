using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Fields you can set when you create an organization. Payabli sets the organization type, so the request has no `paypointType`. Of these shared fields, only `doingBusinessAs` is required. Set `description`, `website`, `customerServicePhone`, `customerServiceEmail`, and `timezone` when you have them.
/// </summary>
[Serializable]
public record OrganizationWritableFields : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The reference of the parent organization this organization nests under. If you omit it, the organization nests under the organization your credential belongs to.
    /// </summary>
    [JsonPropertyName("parentPaypointReference")]
    public string? ParentPaypointReference { get; set; }

    /// <summary>
    /// The name the organization does business as (DBA).
    /// </summary>
    [JsonPropertyName("doingBusinessAs")]
    public required string DoingBusinessAs { get; set; }

    /// <summary>
    /// A free-text description of the organization.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// The organization's website URL.
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
    /// The organization's time zone, as an IANA identifier such as `America/Chicago`.
    /// </summary>
    [JsonPropertyName("timezone")]
    public string? Timezone { get; set; }

    /// <summary>
    /// Your own identifier for the organization.
    /// </summary>
    [JsonPropertyName("externalId")]
    public string? ExternalId { get; set; }

    /// <summary>
    /// Arbitrary key-value data you attach to the organization.
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
