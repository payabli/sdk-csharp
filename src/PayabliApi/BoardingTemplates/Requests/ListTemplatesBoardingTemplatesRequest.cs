using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record ListTemplatesBoardingTemplatesRequest
{
    /// <summary>
    /// The numeric identifier of the organization to list templates for.
    /// </summary>
    [JsonIgnore]
    public required int OrgId { get; set; }

    /// <summary>
    /// Filter by template status.
    /// </summary>
    [JsonIgnore]
    public TemplateStatus? Status { get; set; }

    /// <summary>
    /// Filter by exact template name.
    /// </summary>
    [JsonIgnore]
    public string? Name { get; set; }

    /// <summary>
    /// Filter by exact template slug.
    /// </summary>
    [JsonIgnore]
    public string? Slug { get; set; }

    /// <summary>
    /// Filter by exact owning organization name.
    /// </summary>
    [JsonIgnore]
    public string? OrgName { get; set; }

    /// <summary>
    /// Filter by whether the template is inherited from an ancestor organization.
    /// </summary>
    [JsonIgnore]
    public bool? Inherited { get; set; }

    /// <summary>
    /// The number of records to skip before collecting the result set.
    /// </summary>
    [JsonIgnore]
    public int? FromRecord { get; set; }

    /// <summary>
    /// The maximum number of records to return. Use `0` or a negative value to return all records.
    /// </summary>
    [JsonIgnore]
    public int? LimitRecord { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
