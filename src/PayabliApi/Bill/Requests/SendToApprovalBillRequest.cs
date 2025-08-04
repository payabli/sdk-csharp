using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record SendToApprovalBillRequest
{
    /// <summary>
    /// Automatically create the target user for approval if they don't exist.
    /// </summary>
    [JsonIgnore]
    public bool? AutocreateUser { get; set; }

    [JsonIgnore]
    public string? IdempotencyKey { get; set; }

    [JsonIgnore]
    public IEnumerable<string> Body { get; set; } = new List<string>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
