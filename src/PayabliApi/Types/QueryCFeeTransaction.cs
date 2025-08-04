using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record QueryCFeeTransaction : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("cFeeTransid")]
    public string? CFeeTransid { get; set; }

    [JsonPropertyName("feeAmount")]
    public double? FeeAmount { get; set; }

    [JsonPropertyName("operation")]
    public string? Operation { get; set; }

    [JsonPropertyName("refundId")]
    public long? RefundId { get; set; }

    [JsonPropertyName("responseData")]
    public Dictionary<string, object?>? ResponseData { get; set; }

    [JsonPropertyName("settlementStatus")]
    public int? SettlementStatus { get; set; }

    [JsonPropertyName("transactionTime")]
    public DateTime? TransactionTime { get; set; }

    [JsonPropertyName("transStatus")]
    public int? TransStatus { get; set; }

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
