using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record AddPaymentMethodDomainRequest
{
    /// <summary>
    /// Apple Pay configuration information.
    /// </summary>
    [JsonPropertyName("applePay")]
    public AddPaymentMethodDomainRequestApplePay? ApplePay { get; set; }

    /// <summary>
    /// Google Pay configuration information.
    /// </summary>
    [JsonPropertyName("googlePay")]
    public AddPaymentMethodDomainRequestGooglePay? GooglePay { get; set; }

    [JsonPropertyName("domainName")]
    public string? DomainName { get; set; }

    [JsonPropertyName("entityId")]
    public long? EntityId { get; set; }

    [JsonPropertyName("entityType")]
    public string? EntityType { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
