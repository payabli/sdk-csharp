using System.Text.Json;
using System.Text.Json.Serialization;
using OneOf;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record RequestTokenStorage : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Object describing the Customer/Payor owner of payment method. Required for POST requests. Which fields are required depends on the paypoint's custom identifier settings.
    /// </summary>
    [JsonPropertyName("customerData")]
    public PayorDataRequest? CustomerData { get; set; }

    /// <summary>
    /// Entrypoint identifier. Required for POST requests.
    /// </summary>
    [JsonPropertyName("entryPoint")]
    public string? EntryPoint { get; set; }

    /// <summary>
    /// When `true`, if tokenization fails, Payabli will attempt an authorization transaction to request a permanent token for the card. If the authorization is successful, the card will be tokenized and the authorization will be voided automatically.
    /// </summary>
    [JsonPropertyName("fallbackAuth")]
    public bool? FallbackAuth { get; set; }

    /// <summary>
    /// The amount for the `fallbackAuth` transaction. Defaults to one dollar (`100`).
    /// </summary>
    [JsonPropertyName("fallbackAuthAmount")]
    public int? FallbackAuthAmount { get; set; }

    /// <summary>
    /// Custom description for stored payment method.
    /// </summary>
    [JsonPropertyName("methodDescription")]
    public string? MethodDescription { get; set; }

    /// <summary>
    /// Information about the payment method for the transaction.
    /// </summary>
    [JsonPropertyName("paymentMethod")]
    public OneOf<TokenizeCard, TokenizeAch, ConvertToken>? PaymentMethod { get; set; }

    [JsonPropertyName("vendorData")]
    public VendorDataRequest? VendorData { get; set; }

    /// <summary>
    /// Custom identifier to indicate the source for the request
    /// </summary>
    [JsonPropertyName("source")]
    public string? Source { get; set; }

    [JsonPropertyName("subdomain")]
    public string? Subdomain { get; set; }

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
