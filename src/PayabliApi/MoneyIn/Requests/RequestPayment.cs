using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record RequestPayment
{
    [JsonIgnore]
    public bool? AchValidation { get; set; }

    [JsonIgnore]
    public bool? ForceCustomerCreation { get; set; }

    /// <summary>
    /// When `true`, transactionDetails object is returned in the response. See a full example of the `transactionDetails` object in the [Transaction integration guide](/developers/developer-guides/money-in-transaction-add#includedetailstrue-response).
    /// </summary>
    [JsonIgnore]
    public bool? IncludeDetails { get; set; }

    [JsonIgnore]
    public string? IdempotencyKey { get; set; }

    /// <summary>
    /// Value obtained from user when an API generated CAPTCHA is used in payment page
    /// </summary>
    [JsonIgnore]
    public string? ValidationCode { get; set; }

    [JsonIgnore]
    public required TransRequestBody Body { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
