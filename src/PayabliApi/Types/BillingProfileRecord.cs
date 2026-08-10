using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// A single billing profile as it appears in the list.
/// </summary>
[Serializable]
public record BillingProfileRecord : IJsonOnDeserialized
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
    /// Sequential version counter. Starts at `1` and increments on every edit.
    /// </summary>
    [JsonPropertyName("versionNumber")]
    public required int VersionNumber { get; set; }

    [JsonPropertyName("business")]
    public required BillingEntityNamed Business { get; set; }

    [JsonPropertyName("serviceVertical")]
    public required ServiceVerticalName ServiceVertical { get; set; }

    /// <summary>
    /// Descriptive name for the profile.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("feeType")]
    public required FeeTypeName FeeType { get; set; }

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

    [JsonPropertyName("entitiesAssigned")]
    public required EntitiesAssigned EntitiesAssigned { get; set; }

    /// <summary>
    /// Parent-entity reference formatted as `{entityType}:{entityId}` (for
    /// example, `1:2`).
    /// </summary>
    [JsonPropertyName("parentId")]
    public required string ParentId { get; set; }

    /// <summary>
    /// Number of billable events configured on the profile.
    /// </summary>
    [JsonPropertyName("countOfEvents")]
    public required int CountOfEvents { get; set; }

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
