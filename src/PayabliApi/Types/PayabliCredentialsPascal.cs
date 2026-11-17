using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record PayabliCredentialsPascal : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// When `true`, the gateway for this credential is enabled for the paypoint. The value is
    /// `null` when the credential isn't linked to a gateway.
    /// </summary>
    [JsonPropertyName("active")]
    public bool? Active { get; set; }

    /// <summary>
    /// The customer ID configured for this gateway. Returned only for gateways that use a
    /// customer ID. For all other gateways, or when no customer ID is configured, the value is
    /// `null`.
    /// </summary>
    [JsonPropertyName("customerId")]
    public string? CustomerId { get; set; }

    /// <summary>
    /// The client ID configured for this gateway. Returned only for gateways that use a client
    /// ID. For all other gateways, or when no client ID is configured, the value is `null`.
    /// </summary>
    [JsonPropertyName("clientId")]
    public string? ClientId { get; set; }

    /// <summary>
    /// The payment service that this credential applies to. A paypoint can support multiple services, each represented by its own credential object in the array. Possible values are `card` (credit/debit card), `ach` (ACH bank transfer), `check` (paper check), `vcard` (virtual card), `cloud` (card-present), `cash`, `managed` (managed payment service), and `wallet`.
    /// </summary>
    [JsonPropertyName("Service")]
    public string? Service { get; set; }

    /// <summary>
    /// The payment mode supported by this service. `0` for one-time payments, `1` for recurring payments, `2` for both.
    /// </summary>
    [JsonPropertyName("Mode")]
    public int? Mode { get; set; }

    [JsonPropertyName("Minticket")]
    public double? Minticket { get; set; }

    [JsonPropertyName("Maxticket")]
    public double? Maxticket { get; set; }

    [JsonPropertyName("CfeeFix")]
    public double? CfeeFix { get; set; }

    [JsonPropertyName("CfeeFloat")]
    public double? CfeeFloat { get; set; }

    [JsonPropertyName("CfeeMin")]
    public double? CfeeMin { get; set; }

    [JsonPropertyName("CfeeMax")]
    public double? CfeeMax { get; set; }

    /// <summary>
    /// The identifier for the payment connector, matching the `accountId` of the linked bank account.
    /// </summary>
    [JsonPropertyName("AccountId")]
    public string? AccountId { get; set; }

    [JsonPropertyName("ReferenceId")]
    public long? ReferenceId { get; set; }

    [JsonPropertyName("acceptSameDayACH")]
    public bool? AcceptSameDayAch { get; set; }

    /// <summary>
    /// The default currency for the paypoint, either `USD` or `CAD`.
    /// </summary>
    [JsonPropertyName("Currency")]
    public IEnumerable<string>? Currency { get; set; }

    [JsonPropertyName("GreaterValueAllowed")]
    public bool? GreaterValueAllowed { get; set; }

    [JsonPropertyName("AbsorbDifference")]
    public bool? AbsorbDifference { get; set; }

    [JsonPropertyName("AllowOverride")]
    public bool? AllowOverride { get; set; }

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
