using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record RequestPaymentV2
{
    /// <summary>
    /// When `true`, enables real-time validation of ACH account and routing numbers. This is an add-on feature, contact Payabli for more information.
    /// </summary>
    [JsonIgnore]
    public bool? AchValidation { get; set; }

    /// <summary>
    /// When `true`, the request creates a new customer record, regardless of whether customer identifiers match an existing customer. Defaults to `false`.
    /// </summary>
    [JsonIgnore]
    public bool? ForceCustomerCreation { get; set; }

    /// <summary>
    /// _Optional but recommended_ A unique ID that you can include to prevent duplicating objects or transactions in the case that a request is sent more than once. This key isn't generated in Payabli, you must generate it yourself. This key persists for 2 minutes. After 2 minutes, you can reuse the key if needed.
    /// </summary>
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
