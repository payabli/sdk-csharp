using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record CardService : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Controls how to present the `batchCutoffTime` field on the application. If this field isn't sent, batch cut off time defaults to 5 ET.
    /// </summary>
    [JsonPropertyName("batchCutoffTime")]
    public TemplateElement? BatchCutoffTime { get; set; }

    [JsonPropertyName("cardAcceptance")]
    public CardAcceptanceElement? CardAcceptance { get; set; }

    [JsonPropertyName("cardFees")]
    public CardFeeSection? CardFees { get; set; }

    [JsonPropertyName("cardFlat")]
    public CardFlatSection? CardFlat { get; set; }

    [JsonPropertyName("cardFlat_amountxAuth")]
    public TemplateElement? CardFlatAmountxAuth { get; set; }

    [JsonPropertyName("cardFlat_highPayRange")]
    public TemplateElement? CardFlatHighPayRange { get; set; }

    [JsonPropertyName("cardFlat_lowPayRange")]
    public TemplateElement? CardFlatLowPayRange { get; set; }

    [JsonPropertyName("cardFlat_percentxAuth")]
    public TemplateElement? CardFlatPercentxAuth { get; set; }

    [JsonPropertyName("cardICP")]
    public CardIcpSection? CardIcp { get; set; }

    [JsonPropertyName("cardICP_amountxAuth")]
    public TemplateElement? CardIcpAmountxAuth { get; set; }

    [JsonPropertyName("cardICP_highPayRange")]
    public TemplateElement? CardIcpHighPayRange { get; set; }

    [JsonPropertyName("cardICP_lowPayRange")]
    public TemplateElement? CardIcpLowPayRange { get; set; }

    [JsonPropertyName("cardICP_percentxAuth")]
    public TemplateElement? CardIcpPercentxAuth { get; set; }

    [JsonPropertyName("cardPassThrough")]
    public CardPassThroughSection? CardPassThrough { get; set; }

    [JsonPropertyName("cardPassThrough_amountRecurring")]
    public TemplateElement? CardPassThroughAmountRecurring { get; set; }

    [JsonPropertyName("cardPassThrough_amountxAuth")]
    public TemplateElement? CardPassThroughAmountxAuth { get; set; }

    [JsonPropertyName("cardPassThrough_highPayRange")]
    public TemplateElement? CardPassThroughHighPayRange { get; set; }

    [JsonPropertyName("cardPassThrough_lowPayRange")]
    public TemplateElement? CardPassThroughLowPayRange { get; set; }

    [JsonPropertyName("cardPassThrough_percentRecurring")]
    public TemplateElement? CardPassThroughPercentRecurring { get; set; }

    [JsonPropertyName("cardPassThrough_percentxAuth")]
    public TemplateElement? CardPassThroughPercentxAuth { get; set; }

    [JsonPropertyName("discountFrequency")]
    public TemplateElement? DiscountFrequency { get; set; }

    [JsonPropertyName("fundingRollup")]
    public TemplateElement? FundingRollup { get; set; }

    [JsonPropertyName("gateway")]
    public TemplateElement? Gateway { get; set; }

    [JsonPropertyName("passThroughCost")]
    public TemplateElement? PassThroughCost { get; set; }

    [JsonPropertyName("pdfTemplateId")]
    public TemplateElement? PdfTemplateId { get; set; }

    [JsonPropertyName("pricingPlan")]
    public long? PricingPlan { get; set; }

    [JsonPropertyName("pricingType")]
    public TemplateElement? PricingType { get; set; }

    [JsonPropertyName("processor")]
    public TemplateElement? Processor { get; set; }

    [JsonPropertyName("provider")]
    public TemplateElement? Provider { get; set; }

    [JsonPropertyName("tierName")]
    public TemplateElement? TierName { get; set; }

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
