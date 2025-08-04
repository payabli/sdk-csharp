using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Object containing details about the refund, including line items and optional split instructions.
/// </summary>
[Serializable]
public record RefundDetail : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Array of payment categories/line items describing the amount to be paid. Note: These categories are for information only and aren't validated against the total amount provided.
    /// </summary>
    [JsonPropertyName("categories")]
    public IEnumerable<PaymentCategories>? Categories { get; set; }

    /// <summary>
    /// Array of objects containing split instructions for the refund.
    /// </summary>
    [JsonPropertyName("splitRefunding")]
    public IEnumerable<SplitFundingRefundContent>? SplitRefunding { get; set; }

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
