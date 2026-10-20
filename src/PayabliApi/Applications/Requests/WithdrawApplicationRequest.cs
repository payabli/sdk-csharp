using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record WithdrawApplicationRequest
{
    /// <summary>
    /// An optional reason for the withdrawal, recorded in the status history.
    /// </summary>
    [JsonPropertyName("reason")]
    public string? Reason { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
