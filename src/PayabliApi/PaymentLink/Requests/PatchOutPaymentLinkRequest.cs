using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record PatchOutPaymentLinkRequest
{
    /// <summary>
    /// Updated payment link page configuration.
    /// </summary>
    [JsonPropertyName("billPageData")]
    public PaymentPageRequestBodyOut? BillPageData { get; set; }

    /// <summary>
    /// New expiration date for the payment link. Must be a future date. If null and the link is expired, uses the default expiration from settings. Updating the expiration date reactivates an expired payment link to Active status.
    /// </summary>
    [JsonPropertyName("expirationDate")]
    public string? ExpirationDate { get; set; }

    /// <summary>
    /// Updated status for the payment link.
    /// </summary>
    [JsonPropertyName("status")]
    public PaymentLinkStatus? Status { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
