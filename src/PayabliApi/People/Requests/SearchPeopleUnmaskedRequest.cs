using global::System.Text.Json.Serialization;
using OneOf;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record SearchPeopleUnmaskedRequest
{
    /// <summary>
    /// The entry name of your organization, from `OrgEntryName` on the organization. With a paypoint's entry name instead, the search covers only that paypoint's business.
    /// </summary>
    [JsonIgnore]
    public required string Entry { get; set; }

    /// <summary>
    /// The ID of your organization.
    /// </summary>
    [JsonIgnore]
    public required long OrgId { get; set; }

    [JsonIgnore]
    public required OneOf<object> Body { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
