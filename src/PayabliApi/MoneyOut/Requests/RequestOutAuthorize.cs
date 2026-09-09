using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record RequestOutAuthorize
{
    /// <summary>
    /// When `true`, the authorization bypasses the requirement for unique bills, identified by vendor invoice number. This allows you to make more than one payout authorization for a bill, like a split payment.
    /// </summary>
    [JsonIgnore]
    public bool? AllowDuplicatedBills { get; set; }

    /// <summary>
    /// When `true`, Payabli won't automatically create a bill for this payout transaction.
    /// </summary>
    [JsonIgnore]
    public bool? DoNotCreateBills { get; set; }

    /// <summary>
    /// When `true`, Payabli authorizes the payout for same-day ACH processing instead of standard ACH. Same-day ACH must be enabled for the paypoint, otherwise the authorization fails with a `400` response and `responseCode` `3492`. Only ACH payouts honor this flag. Wire and RTP payouts ignore it.
    ///
    /// Same-day ACH has a daily cutoff. Capture the transaction before the cutoff, or pass `autoConvertSameDayAch` with a value of `true` when you capture it.
    /// </summary>
    [JsonIgnore]
    public bool? SameDayAch { get; set; }

    /// <summary>
    /// _Optional but recommended_ A unique ID that you can include to prevent duplicating objects or transactions in the case that a request is sent more than once. This key isn't generated in Payabli, you must generate it yourself. This key persists for 2 minutes. After 2 minutes, you can reuse the key if needed.
    /// </summary>
    [JsonIgnore]
    public string? IdempotencyKey { get; set; }

    [JsonIgnore]
    public required AuthorizePayoutBody Body { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
