using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record AddMethodRequest
{
    /// <summary>
    /// When `true`, enables real-time validation of ACH account and routing numbers. This is an add-on feature, contact Payabli for more information.
    /// </summary>
    [JsonIgnore]
    public bool? AchValidation { get; set; }

    /// <summary>
    /// When `true`, creates a saved method with no associated customer information. The token will be associated with customer information the first time it's used to make a payment. Defaults to `false`.
    /// </summary>
    [JsonIgnore]
    public bool? CreateAnonymous { get; set; }

    /// <summary>
    /// When `true`, the request creates a new customer record, regardless of whether customer identifiers match an existing customer. Defaults to `false`.
    /// </summary>
    [JsonIgnore]
    public bool? ForceCustomerCreation { get; set; }

    /// <summary>
    /// Creates a temporary, one-time-use token for the payment method that expires in 12 hours. Defaults to `false`.
    /// </summary>
    [JsonIgnore]
    public bool? Temporary { get; set; }

    /// <summary>
    /// _Optional but recommended_ A unique ID that you can include to prevent duplicating objects or transactions in the case that a request is sent more than once. This key isn't generated in Payabli, you must generate it yourself. This key persists for 2 minutes. After 2 minutes, you can reuse the key if needed.
    /// </summary>
    [JsonIgnore]
    public string? IdempotencyKey { get; set; }

    [JsonIgnore]
    public required RequestTokenStorage Body { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
