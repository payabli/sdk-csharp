using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Payment method for reissuing a payout transaction. The reissue endpoint uses the payment method details directly. It doesn't fall back to the vendor's managed payment method.
/// - `{ method: "vcard" }` - Reissue as a virtual card
/// - `{ method: "check" }` - Reissue as a paper check
/// - `{ method: "ach", achHolder: "...", achRouting: "...", achAccount: "...", achAccountType: "...", achHolderType: "..." }` - Reissue as ACH with bank details
/// </summary>
[Serializable]
public record ReissuePaymentMethod : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Payment method type. Must be `"ach"`, `"check"`, or `"vcard"`.
    /// </summary>
    [JsonPropertyName("method")]
    public required string Method { get; set; }

    /// <summary>
    /// Account holder name. Required when `method` is `"ach"`.
    /// </summary>
    [JsonPropertyName("achHolder")]
    public string? AchHolder { get; set; }

    /// <summary>
    /// Bank routing number (9 digits). Required when `method` is `"ach"`.
    /// </summary>
    [JsonPropertyName("achRouting")]
    public string? AchRouting { get; set; }

    /// <summary>
    /// Bank account number (8-17 digits). Required when `method` is `"ach"`.
    /// </summary>
    [JsonPropertyName("achAccount")]
    public string? AchAccount { get; set; }

    /// <summary>
    /// Bank account type (`"checking"` or `"savings"`). Required when `method` is `"ach"`.
    /// </summary>
    [JsonPropertyName("achAccountType")]
    public string? AchAccountType { get; set; }

    [JsonPropertyName("achHolderType")]
    public AchHolderType? AchHolderType { get; set; }

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
