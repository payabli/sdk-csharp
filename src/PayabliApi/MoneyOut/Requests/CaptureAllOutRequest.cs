using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record CaptureAllOutRequest
{
    [JsonIgnore]
    public string? IdempotencyKey { get; set; }

    /// <summary>
    /// Array of identifiers of payout transactions to capture.
    /// </summary>
    [JsonIgnore]
    public IEnumerable<string> Body { get; set; } = new List<string>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
