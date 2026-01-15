using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Object describing the vendor owner of payment method. Required when saving an ACH payment method on behalf of a vendor (for Pay Out transactions).
/// </summary>
[Serializable]
public record VendorDataRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The unique numeric ID assigned to the vendor in Payabli. Either `vendorId` or `vendorNumber` is required.
    /// </summary>
    [JsonPropertyName("vendorId")]
    public long? VendorId { get; set; }

    /// <summary>
    /// Custom vendor number assigned by the business. Either `vendorId` or `vendorNumber` is required.
    /// </summary>
    [JsonPropertyName("vendorNumber")]
    public string? VendorNumber { get; set; }

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
