using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record CapturePaymentDetails : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Total amount to be captured, including the `serviceFee` amount. The amount can't be greater the original
    /// total amount of the transaction, and can't be more than 15% lower than the original amount.
    /// </summary>
    [JsonPropertyName("totalAmount")]
    public required double TotalAmount { get; set; }

    /// <summary>
    /// Service fee to capture for the transaction.
    /// </summary>
    [JsonPropertyName("serviceFee")]
    public double? ServiceFee { get; set; }

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
