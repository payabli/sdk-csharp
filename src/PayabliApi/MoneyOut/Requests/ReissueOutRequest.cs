using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record ReissueOutRequest
{
    /// <summary>
    /// The transaction ID of the payout to reissue.
    /// </summary>
    [JsonIgnore]
    public required string TransId { get; set; }

    [JsonIgnore]
    public string? IdempotencyKey { get; set; }

    [JsonIgnore]
    public required ReissuePayoutBody Body { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
