using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record VerifyAccountDetailsRequest
{
    /// <summary>
    /// The bank routing number to verify.
    /// </summary>
    [JsonPropertyName("routingNumber")]
    public required string RoutingNumber { get; set; }

    /// <summary>
    /// The bank account number to verify.
    /// </summary>
    [JsonPropertyName("accountNumber")]
    public required string AccountNumber { get; set; }

    /// <summary>
    /// The type of bank account, such as `Checking` or `Savings`.
    /// </summary>
    [JsonPropertyName("accountType")]
    public string? AccountType { get; set; }

    /// <summary>
    /// The ISO country code for the bank account, such as `US`.
    /// </summary>
    [JsonPropertyName("country")]
    public string? Country { get; set; }

    /// <summary>
    /// The type of account holder. Accepted values are `personal` or `business`. Required when bank authentication is enabled for the paypoint's organization.
    /// </summary>
    [JsonPropertyName("accountHolderType")]
    public string? AccountHolderType { get; set; }

    /// <summary>
    /// The name of the bank account holder. For personal accounts, provide the holder's full name (for example, `Jane Doe`); the value is split on the first space into first and last name. For business accounts, provide the legal business name. Required when bank authentication is enabled for the paypoint's organization.
    /// </summary>
    [JsonPropertyName("holderName")]
    public string? HolderName { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
