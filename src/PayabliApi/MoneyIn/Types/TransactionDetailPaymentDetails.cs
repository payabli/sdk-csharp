using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Detailed breakdown of payment amounts and identifiers
/// </summary>
[Serializable]
public record TransactionDetailPaymentDetails : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("totalAmount")]
    public required double TotalAmount { get; set; }

    [JsonPropertyName("serviceFee")]
    public required double ServiceFee { get; set; }

    [JsonPropertyName("checkNumber")]
    public string? CheckNumber { get; set; }

    [JsonPropertyName("checkImage")]
    public object? CheckImage { get; set; }

    [JsonPropertyName("checkUniqueId")]
    public required string CheckUniqueId { get; set; }

    [JsonPropertyName("currency")]
    public required string Currency { get; set; }

    [JsonPropertyName("orderDescription")]
    public string? OrderDescription { get; set; }

    [JsonPropertyName("orderId")]
    public string? OrderId { get; set; }

    [JsonPropertyName("orderIdAlternative")]
    public string? OrderIdAlternative { get; set; }

    [JsonPropertyName("paymentDescription")]
    public string? PaymentDescription { get; set; }

    [JsonPropertyName("groupNumber")]
    public string? GroupNumber { get; set; }

    [JsonPropertyName("source")]
    public string? Source { get; set; }

    [JsonPropertyName("payabliTransId")]
    public string? PayabliTransId { get; set; }

    [JsonPropertyName("unbundled")]
    public object? Unbundled { get; set; }

    [JsonPropertyName("categories")]
    public IEnumerable<object> Categories { get; set; } = new List<object>();

    [JsonPropertyName("splitFunding")]
    public IEnumerable<object> SplitFunding { get; set; } = new List<object>();

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
