using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record PayLinkDataOut
{
    [JsonIgnore]
    public required string EntryPoint { get; set; }

    /// <summary>
    /// The vendor number for the vendor being paid with this payment link.
    /// </summary>
    [JsonIgnore]
    public required string VendorNumber { get; set; }

    /// <summary>
    /// List of recipient email addresses. When there is more than one, separate them by a semicolon (;).
    /// </summary>
    [JsonIgnore]
    public string? Mail2 { get; set; }

    /// <summary>
    /// Indicates whether customer can modify the payment amount. A value of `true` means the amount isn't modifiable, a value `false` means the payor can modify the amount to pay.
    /// </summary>
    [JsonIgnore]
    public string? AmountFixed { get; set; }

    [JsonIgnore]
    public required PaymentPageRequestBody Body { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
