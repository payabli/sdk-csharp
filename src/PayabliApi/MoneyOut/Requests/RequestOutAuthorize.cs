using System.Text.Json.Serialization;
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
    /// When `true`, the request creates a new vendor record, regardless of whether the vendor already exists.
    /// </summary>
    [JsonIgnore]
    public bool? ForceVendorCreation { get; set; }

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
