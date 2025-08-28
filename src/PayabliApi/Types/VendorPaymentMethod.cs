using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Payment method object to use for the payout.
/// - `{ method: "managed" }` - Managed payment method
/// - `{ method: "vcard" }` - Virtual card payment method
/// - `{ method: "check" }` - Check payment method
/// - `{ method: "ach", storedMethodId?: "..." }` - ACH payment method with optional stored method ID
/// </summary>
[Serializable]
public record VendorPaymentMethod : IJsonOnDeserialized
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
    /// ID of the stored ACH payment method. Only applicable when method is "ach". Required when using a previously saved ACH method when the vendor has more than one saved method. See the [Payouts with saved ACH payment methods](/developers/developer-guides/pay-out-manage-payouts) section for more details.
    /// </summary>
    [JsonPropertyName("storedMethodId")]
    public string? StoredMethodId { get; set; }

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
