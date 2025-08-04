using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// The wallet data.
/// </summary>
[Serializable]
public record AppleWalletData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("entry")]
    public string? Entry { get; set; }

    /// <summary>
    /// The Apple Pay merchant identifier.
    /// </summary>
    [JsonPropertyName("applePayMerchantId")]
    public string? ApplePayMerchantId { get; set; }

    /// <summary>
    /// A list of domain names that are enabled for this paypoint.
    /// </summary>
    [JsonPropertyName("domainNames")]
    public IEnumerable<string>? DomainNames { get; set; }

    [JsonPropertyName("paypointName")]
    public string? PaypointName { get; set; }

    /// <summary>
    /// The paypoint URL.
    /// </summary>
    [JsonPropertyName("paypointUrl")]
    public string? PaypointUrl { get; set; }

    /// <summary>
    /// The date and time a paypoint's Apple Pay registration was scheduled for deletion. The paypoint will be unregistered from Apple Pay permanently 30 days from this value.
    /// </summary>
    [JsonPropertyName("markedForDeletionAt")]
    public DateTime? MarkedForDeletionAt { get; set; }

    [JsonPropertyName("createdAt")]
    public DateTime? CreatedAt { get; set; }

    [JsonPropertyName("updatedAt")]
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Internal ID for the Apple Pay paypoint registration update.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The record type, in this context it will always be `ApplePayRegistration`.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

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
