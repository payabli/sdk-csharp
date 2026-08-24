using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Vendor to pay with this payout. Create the vendor first with
/// [Create vendor](/developers/api-reference/vendor/create-vendor), then
/// reference it here by `vendorNumber` or `vendorId`.
/// </summary>
[Serializable]
public record RequestOutAuthorizeVendorData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("vendorNumber")]
    public string? VendorNumber { get; set; }

    /// <summary>
    /// Payabli identifier for the vendor record. Required when `vendorNumber` isn't included.
    /// </summary>
    [JsonPropertyName("vendorId")]
    public int? VendorId { get; set; }

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
