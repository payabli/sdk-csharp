using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record CardFeeSection : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("achBatchCardFee")]
    public TemplateElement? AchBatchCardFee { get; set; }

    [JsonPropertyName("annualCardFee")]
    public TemplateElement? AnnualCardFee { get; set; }

    [JsonPropertyName("avsCardFee")]
    public TemplateElement? AvsCardFee { get; set; }

    [JsonPropertyName("chargebackCardFee")]
    public TemplateElement? ChargebackCardFee { get; set; }

    [JsonPropertyName("ddaRejectsCardFee")]
    public TemplateElement? DdaRejectsCardFee { get; set; }

    [JsonPropertyName("earlyTerminationCardFee")]
    public TemplateElement? EarlyTerminationCardFee { get; set; }

    [JsonPropertyName("minimumProcessingCardFee")]
    public TemplateElement? MinimumProcessingCardFee { get; set; }

    [JsonPropertyName("monthlyPCICardFee")]
    public TemplateElement? MonthlyPciCardFee { get; set; }

    [JsonPropertyName("montlyPlatformCardFee")]
    public TemplateElement? MontlyPlatformCardFee { get; set; }

    [JsonPropertyName("retrievalCardFee")]
    public TemplateElement? RetrievalCardFee { get; set; }

    [JsonPropertyName("transactionCardFee")]
    public TemplateElement? TransactionCardFee { get; set; }

    [JsonPropertyName("visible")]
    public bool? Visible { get; set; }

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
