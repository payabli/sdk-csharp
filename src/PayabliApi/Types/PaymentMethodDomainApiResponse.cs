using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Data related to the payment method domain.
/// </summary>
[Serializable]
public record PaymentMethodDomainApiResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The record type. For payment method domains, this is always `PaymentMethodDomain`.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("applePay")]
    public required ApplePayData ApplePay { get; set; }

    [JsonPropertyName("googlePay")]
    public required GooglePayData GooglePay { get; set; }

    /// <summary>
    /// Data about the domain's cascade status.
    /// </summary>
    [JsonPropertyName("cascades")]
    public IEnumerable<CascadeJobDetails>? Cascades { get; set; }

    [JsonPropertyName("createdAt")]
    public required DateTime CreatedAt { get; set; }

    [JsonPropertyName("domainName")]
    public required string DomainName { get; set; }

    [JsonPropertyName("entityId")]
    public required long EntityId { get; set; }

    [JsonPropertyName("entityType")]
    public required string EntityType { get; set; }

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("ownerEntityId")]
    public required long OwnerEntityId { get; set; }

    [JsonPropertyName("ownerEntityType")]
    public required string OwnerEntityType { get; set; }

    [JsonPropertyName("updatedAt")]
    public DateTime? UpdatedAt { get; set; }

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
