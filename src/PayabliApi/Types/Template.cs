using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// A boarding template, including its current content version.
/// </summary>
[Serializable]
public record Template : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The template's unique identifier, used to read and manage the template.
    /// </summary>
    [JsonPropertyName("uuid")]
    public required string Uuid { get; set; }

    /// <summary>
    /// The numeric identifier of the organization that owns the template.
    /// </summary>
    [JsonPropertyName("orgId")]
    public required int OrgId { get; set; }

    /// <summary>
    /// The name of the organization that owns the template.
    /// </summary>
    [JsonPropertyName("orgName")]
    public string? OrgName { get; set; }

    /// <summary>
    /// The template's display name.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// An optional description of the template.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// An optional URL-friendly identifier for the template.
    /// </summary>
    [JsonPropertyName("slug")]
    public string? Slug { get; set; }

    [JsonPropertyName("status")]
    public required TemplateStatus Status { get; set; }

    /// <summary>
    /// The UUID of the template's active content version.
    /// </summary>
    [JsonPropertyName("currentVersionUuid")]
    public required string CurrentVersionUuid { get; set; }

    /// <summary>
    /// The template's active content version.
    /// </summary>
    [JsonPropertyName("currentVersion")]
    public required TemplateVersion CurrentVersion { get; set; }

    /// <summary>
    /// Whether the template is inherited from an ancestor organization rather than owned directly.
    /// </summary>
    [JsonPropertyName("isInherited")]
    public required bool IsInherited { get; set; }

    /// <summary>
    /// Whether the template is read-only for the calling organization.
    /// </summary>
    [JsonPropertyName("readOnly")]
    public required bool ReadOnly { get; set; }

    /// <summary>
    /// The identifier of the user who created the template.
    /// </summary>
    [JsonPropertyName("createdBy")]
    public required string CreatedBy { get; set; }

    /// <summary>
    /// The identifier of the user who last updated the template.
    /// </summary>
    [JsonPropertyName("updatedBy")]
    public required string UpdatedBy { get; set; }

    /// <summary>
    /// When the template was created.
    /// </summary>
    [JsonPropertyName("createdAt")]
    public required string CreatedAt { get; set; }

    /// <summary>
    /// When the template was last updated.
    /// </summary>
    [JsonPropertyName("updatedAt")]
    public required string UpdatedAt { get; set; }

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
