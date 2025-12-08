using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record StatBasicExtendedQueryRecord : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The time window based on the mode and frequency used for the query.
    /// </summary>
    [JsonPropertyName("statX")]
    public required string StatX { get; set; }

    /// <summary>
    /// Number of active vendors.
    /// </summary>
    [JsonPropertyName("outCustomers")]
    public required int OutCustomers { get; set; }

    /// <summary>
    /// Number of new vendors.
    /// </summary>
    [JsonPropertyName("outNewCustomers")]
    public required int OutNewCustomers { get; set; }

    /// <summary>
    /// Outbound (payout) transactions count.
    /// </summary>
    [JsonPropertyName("outTransactions")]
    public required int OutTransactions { get; set; }

    /// <summary>
    /// Recurring outbound (payout) transactions count.
    /// </summary>
    [JsonPropertyName("outSubscriptionsPaid")]
    public required int OutSubscriptionsPaid { get; set; }

    /// <summary>
    /// Outbound (payout) pCard transactions count.
    /// </summary>
    [JsonPropertyName("outCardTransactions")]
    public required int OutCardTransactions { get; set; }

    /// <summary>
    /// Outbound (payout) vCard transactions count.
    /// </summary>
    [JsonPropertyName("outVCardTransactions")]
    public required int OutVCardTransactions { get; set; }

    /// <summary>
    /// Outbound (payout) ACH transactions count.
    /// </summary>
    [JsonPropertyName("outACHTransactions")]
    public required int OutAchTransactions { get; set; }

    /// <summary>
    /// Outbound (payout) check transactions count.
    /// </summary>
    [JsonPropertyName("outCheckTransactions")]
    public required int OutCheckTransactions { get; set; }

    /// <summary>
    /// Outbound (payout) Managed Payables transactions count.
    /// </summary>
    [JsonPropertyName("outPendingMethodTransactions")]
    public required int OutPendingMethodTransactions { get; set; }

    /// <summary>
    /// Outbound (payout) volume.
    /// </summary>
    [JsonPropertyName("outTransactionsVolume")]
    public required double OutTransactionsVolume { get; set; }

    /// <summary>
    /// Recurring outbound (payout) volume.
    /// </summary>
    [JsonPropertyName("outSubscriptionsPaidVolume")]
    public required double OutSubscriptionsPaidVolume { get; set; }

    /// <summary>
    /// Outbound (payout) pCard transactions volume.
    /// </summary>
    [JsonPropertyName("outCardVolume")]
    public required double OutCardVolume { get; set; }

    /// <summary>
    /// Outbound (payout) vCard transactions volume.
    /// </summary>
    [JsonPropertyName("outVCardVolume")]
    public required double OutVCardVolume { get; set; }

    /// <summary>
    /// Outbound (payout) ACH transactions volume.
    /// </summary>
    [JsonPropertyName("outACHVolume")]
    public required double OutAchVolume { get; set; }

    /// <summary>
    /// Outbound (payout) check transactions volume.
    /// </summary>
    [JsonPropertyName("outCheckVolume")]
    public required double OutCheckVolume { get; set; }

    /// <summary>
    /// Outbound (payout) Managed Payables volume.
    /// </summary>
    [JsonPropertyName("outPendingMethodVolume")]
    public required double OutPendingMethodVolume { get; set; }

    /// <summary>
    /// Inbound transactions count.
    /// </summary>
    [JsonPropertyName("inTransactions")]
    public required int InTransactions { get; set; }

    /// <summary>
    /// Inbound recurring transactions count.
    /// </summary>
    [JsonPropertyName("inSubscriptionsPaid")]
    public required int InSubscriptionsPaid { get; set; }

    /// <summary>
    /// Number of active customers.
    /// </summary>
    [JsonPropertyName("inCustomers")]
    public required int InCustomers { get; set; }

    /// <summary>
    /// Number of new customers.
    /// </summary>
    [JsonPropertyName("inNewCustomers")]
    public required int InNewCustomers { get; set; }

    /// <summary>
    /// Inbound card transactions count.
    /// </summary>
    [JsonPropertyName("inCardTransactions")]
    public required int InCardTransactions { get; set; }

    /// <summary>
    /// Inbound ACH transactions count.
    /// </summary>
    [JsonPropertyName("inACHTransactions")]
    public required int InAchTransactions { get; set; }

    /// <summary>
    /// Inbound check transactions count.
    /// </summary>
    [JsonPropertyName("inCheckTransactions")]
    public required int InCheckTransactions { get; set; }

    /// <summary>
    /// Inbound cash transactions count.
    /// </summary>
    [JsonPropertyName("inCashTransactions")]
    public required int InCashTransactions { get; set; }

    /// <summary>
    /// Inbound wallet transactions count.
    /// </summary>
    [JsonPropertyName("inWalletTransactions")]
    public required int InWalletTransactions { get; set; }

    /// <summary>
    /// Inbound card chargebacks and returns count.
    /// </summary>
    [JsonPropertyName("inCardChargeBacks")]
    public required int InCardChargeBacks { get; set; }

    /// <summary>
    /// Inbound ACH returns count.
    /// </summary>
    [JsonPropertyName("inACHReturns")]
    public required int InAchReturns { get; set; }

    /// <summary>
    /// Inbound volume.
    /// </summary>
    [JsonPropertyName("inTransactionsVolume")]
    public required double InTransactionsVolume { get; set; }

    /// <summary>
    /// Inbound recurring payments volume.
    /// </summary>
    [JsonPropertyName("inSubscriptionsPaidVolume")]
    public required double InSubscriptionsPaidVolume { get; set; }

    /// <summary>
    /// Inbound card volume.
    /// </summary>
    [JsonPropertyName("inCardVolume")]
    public required double InCardVolume { get; set; }

    /// <summary>
    /// Inbound ACH volume.
    /// </summary>
    [JsonPropertyName("inACHVolume")]
    public required double InAchVolume { get; set; }

    /// <summary>
    /// Inbound check volume.
    /// </summary>
    [JsonPropertyName("inCheckVolume")]
    public required double InCheckVolume { get; set; }

    /// <summary>
    /// Inbound cash volume recognized.
    /// </summary>
    [JsonPropertyName("inCashVolume")]
    public required double InCashVolume { get; set; }

    /// <summary>
    /// Inbound wallet transactions.
    /// </summary>
    [JsonPropertyName("inWalletVolume")]
    public required double InWalletVolume { get; set; }

    /// <summary>
    /// Inbound Card chargebacks and returns volume.
    /// </summary>
    [JsonPropertyName("inCardChargeBackVolume")]
    public required double InCardChargeBackVolume { get; set; }

    /// <summary>
    /// Inbound ACH returns volume.
    /// </summary>
    [JsonPropertyName("inACHReturnsVolume")]
    public required double InAchReturnsVolume { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
