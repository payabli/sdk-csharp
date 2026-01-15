using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record RequestPaymentAuthorizeV2
{
    [JsonIgnore]
    public bool? ForceCustomerCreation { get; set; }

    [JsonIgnore]
    public string? IdempotencyKey { get; set; }

    [JsonIgnore]
    public required TransRequestBody Body { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
