using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record UpdatePaymentMethodDomainRequest
{
    [JsonPropertyName("applePay")]
    public UpdatePaymentMethodDomainRequestWallet? ApplePay { get; set; }

    [JsonPropertyName("googlePay")]
    public UpdatePaymentMethodDomainRequestWallet? GooglePay { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
