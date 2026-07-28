using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record AssignCaseRequest
{
    /// <summary>
    /// The numeric id of the reviewer to assign the case to.
    /// </summary>
    [JsonPropertyName("assigneeId")]
    public required long AssigneeId { get; set; }

    /// <summary>
    /// An optional reason for the assignment.
    /// </summary>
    [JsonPropertyName("reason")]
    public string? Reason { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
