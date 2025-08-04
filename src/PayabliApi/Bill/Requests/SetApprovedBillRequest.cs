using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record SetApprovedBillRequest
{
    /// <summary>
    /// Email or username of user modifying approval status.
    /// </summary>
    [JsonIgnore]
    public string? Email { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
