using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record CaptureAllOutRequest
{
    /// <summary>
    /// Controls what happens to a payout authorized with `sameDayACH` set to `true` when you capture it after the same-day ACH cutoff. When `true`, Payabli converts the payout to a standard ACH payment and captures it. When `false`, the capture is declined.
    ///
    /// This parameter has no effect on payouts that weren't authorized for same-day ACH.
    /// </summary>
    [JsonIgnore]
    public bool? AutoConvertSameDayAch { get; set; }

    /// <summary>
    /// _Optional but recommended_ A unique ID that you can include to prevent duplicating objects or transactions in the case that a request is sent more than once. This key isn't generated in Payabli, you must generate it yourself. This key persists for 2 minutes. After 2 minutes, you can reuse the key if needed.
    /// </summary>
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
