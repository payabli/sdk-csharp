using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record PayLinkDataBill
{
    /// <summary>
    /// Indicates whether customer can modify the payment amount. A value of `true` means the amount isn't modifiable, a value `false` means the payor can modify the amount to pay.
    /// </summary>
    [JsonIgnore]
    public bool? AmountFixed { get; set; }

    /// <summary>
    /// List of recipient email addresses. When there is more than one, separate them by a semicolon (;).
    /// </summary>
    [JsonIgnore]
    public string? Mail2 { get; set; }

    [JsonIgnore]
    public string? IdempotencyKey { get; set; }

    [JsonIgnore]
    public required PaymentPageRequestBody Body { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
