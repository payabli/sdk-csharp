using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// A billing profile assigned to an entity, returned by the View profile
/// endpoint. A profile is a named configuration of billable events, each with
/// one or more fee schedules. Profiles are append-only versioned — every edit
/// mints a new version.
/// </summary>
[Serializable]
public record BillingProfileResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Unique, server-generated profile identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public required long Id { get; set; }

    /// <summary>
    /// Identifier of this specific version of the profile.
    /// </summary>
    [JsonPropertyName("versionId")]
    public required long VersionId { get; set; }

    /// <summary>
    /// Sequential version counter. Starts at `1` and increments on every edit
    /// (profiles are append-only versioned, not mutated in place).
    /// </summary>
    [JsonPropertyName("versionNumber")]
    public required int VersionNumber { get; set; }

    [JsonPropertyName("business")]
    public required BillingEntity Business { get; set; }

    /// <summary>
    /// Descriptive name for the profile.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("feeType")]
    public required int FeeType { get; set; }

    /// <summary>
    /// When this version was created.
    /// </summary>
    [JsonPropertyName("createdAt")]
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// When this version was last updated.
    /// </summary>
    [JsonPropertyName("updatedAt")]
    public required DateTime UpdatedAt { get; set; }

    /// <summary>
    /// Parent-entity reference used for inheritance and permission checks,
    /// formatted as `{entityType}:{entityId}` (for example, `1:2` is
    /// organization `2`). Org-level profiles reference their own organization;
    /// paypoint-level profiles reference their parent organization.
    /// </summary>
    [JsonPropertyName("parentId")]
    public required string ParentId { get; set; }

    /// <summary>
    /// The chargeable events this profile covers.
    /// </summary>
    [JsonPropertyName("billableEvents")]
    public IEnumerable<BillableEvent> BillableEvents { get; set; } = new List<BillableEvent>();

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
