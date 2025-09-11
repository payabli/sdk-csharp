using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Payment method object for vendor payouts.
/// - `{ method: "managed" }` - Managed payment method
/// - `{ method: "vcard" }` - Virtual card payment method
/// - `{ method: "check" }` - Check payment method
/// - `{ method: "ach", achHolder: "...", achRouting: "...", achAccount: "...", achAccountType: "..." }` - ACH payment method with bank details
/// - `{ method: "ach", storedMethodId: "..." }` - ACH payment method using stored method ID
/// </summary>
[Serializable]
public record AuthorizePaymentMethod : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Payment method type - "managed", "vcard", "check", or "ach"
    /// </summary>
    [JsonPropertyName("method")]
    public required string Method { get; set; }

    /// <summary>
    /// Account holder name for ACH payments. Required when method is "ach" and not using `storedMethodId`.
    /// </summary>
    [JsonPropertyName("achHolder")]
    public string? AchHolder { get; set; }

    /// <summary>
    /// Bank routing number for ACH payments. Required when method is "ach" and not using `storedMethodId`.
    /// </summary>
    [JsonPropertyName("achRouting")]
    public string? AchRouting { get; set; }

    /// <summary>
    /// Bank account number for ACH payments. Required when method is "ach" and not using `storedMethodId`.
    /// </summary>
    [JsonPropertyName("achAccount")]
    public string? AchAccount { get; set; }

    /// <summary>
    /// Account type for ACH payments ("checking" or "savings"). Required when method is "ach" and not using `storedMethodId`.
    /// </summary>
    [JsonPropertyName("achAccountType")]
    public string? AchAccountType { get; set; }

    [JsonPropertyName("achCode")]
    public string? AchCode { get; set; }

    [JsonPropertyName("achHolderType")]
    public AchHolderType? AchHolderType { get; set; }

    /// <summary>
    /// ID of the stored ACH payment method. Only applicable when method is `ach`. Use this to reference a previously saved ACH method instead of providing bank details directly.
    /// </summary>
    [JsonPropertyName("storedMethodId")]
    public string? StoredMethodId { get; set; }

    [JsonPropertyName("initiator")]
    public string? Initiator { get; set; }

    [JsonPropertyName("storedMethodUsageType")]
    public string? StoredMethodUsageType { get; set; }

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
