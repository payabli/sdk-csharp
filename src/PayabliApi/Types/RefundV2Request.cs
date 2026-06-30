using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Optional request body for the v2 refund endpoints. Provide split instructions to refund a split-funded transaction. Omit the body for a standard refund. Fields match the v1 refund-with-instructions request.
/// </summary>
[Serializable]
public record RefundV2Request : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Amount to refund from original transaction, minus any service fees charged on the original transaction.
    ///
    /// The amount provided can't be greater than the original total amount of the transaction, minus service fees. For example, if a transaction was $90 plus a $10 service fee, you can refund up to $90.
    ///
    /// An amount equal to zero will refund the total amount authorized minus any service fee.
    /// </summary>
    [JsonPropertyName("amount")]
    public double? Amount { get; set; }

    [JsonPropertyName("ipaddress")]
    public string? Ipaddress { get; set; }

    [JsonPropertyName("orderDescription")]
    public string? OrderDescription { get; set; }

    [JsonPropertyName("orderId")]
    public string? OrderId { get; set; }

    [JsonPropertyName("refundDetails")]
    public RefundDetail? RefundDetails { get; set; }

    [JsonPropertyName("source")]
    public string? Source { get; set; }

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
