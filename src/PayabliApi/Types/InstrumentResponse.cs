using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// The organization's billing information. Fields that aren't set return `null`.
/// </summary>
[Serializable]
public record InstrumentResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Bank account number, masked.
    /// </summary>
    [JsonPropertyName("achAccount")]
    public string? AchAccount { get; set; }

    /// <summary>
    /// ABA/routing number of bank account.
    /// </summary>
    [JsonPropertyName("achRouting")]
    public string? AchRouting { get; set; }

    /// <summary>
    /// Billing address.
    /// </summary>
    [JsonPropertyName("billingAddress")]
    public string? BillingAddress { get; set; }

    /// <summary>
    /// Billing city.
    /// </summary>
    [JsonPropertyName("billingCity")]
    public string? BillingCity { get; set; }

    /// <summary>
    /// Billing address country.
    /// </summary>
    [JsonPropertyName("billingCountry")]
    public string? BillingCountry { get; set; }

    /// <summary>
    /// Billing state.
    /// </summary>
    [JsonPropertyName("billingState")]
    public string? BillingState { get; set; }

    /// <summary>
    /// Billing address ZIP code.
    /// </summary>
    [JsonPropertyName("billingZip")]
    public string? BillingZip { get; set; }

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
