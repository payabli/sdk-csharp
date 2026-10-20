using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record CreatePaymentMethodsRequest
{
    /// <summary>
    /// The payment methods to create.
    /// </summary>
    [JsonPropertyName("data")]
    public IEnumerable<CreatePaymentMethodRequest> Data { get; set; } =
        new List<CreatePaymentMethodRequest>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
