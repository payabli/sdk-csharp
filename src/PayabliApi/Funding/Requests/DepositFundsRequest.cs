using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record DepositFundsRequest
{
    /// <summary>
    /// The amount to deposit, in dollars. Must be greater than zero.
    /// </summary>
    [JsonPropertyName("amount")]
    public required double Amount { get; set; }

    /// <summary>
    /// The entry point identifier for the paypoint receiving the deposit.
    /// </summary>
    [JsonPropertyName("entrypoint")]
    public required string Entrypoint { get; set; }

    /// <summary>
    /// The remittance account ID to withdraw funds from.
    /// </summary>
    [JsonPropertyName("accountId")]
    public required string AccountId { get; set; }

    /// <summary>
    /// The paypoint ID. Optional if the entry point uniquely identifies the paypoint.
    /// </summary>
    [JsonPropertyName("paypointId")]
    public long? PaypointId { get; set; }

    /// <summary>
    /// When `true` and the request is submitted before 2 PM ET, the deposit processes as same-day ACH. If the request is submitted after 2 PM ET, it processes as standard ACH regardless of this flag.
    /// </summary>
    [JsonPropertyName("sameDayAch")]
    public bool? SameDayAch { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
