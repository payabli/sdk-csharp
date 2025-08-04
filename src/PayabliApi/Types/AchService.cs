using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record AchService : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("achAbsorb")]
    public AchAbsorbSection? AchAbsorb { get; set; }

    [JsonPropertyName("achAbsorb_highPayRange")]
    public TemplateElement? AchAbsorbHighPayRange { get; set; }

    [JsonPropertyName("achAbsorb_lowPayRange")]
    public TemplateElement? AchAbsorbLowPayRange { get; set; }

    [JsonPropertyName("achAcceptance")]
    public AchAcceptanceElement? AchAcceptance { get; set; }

    [JsonPropertyName("achFees")]
    public AchFeeSection? AchFees { get; set; }

    [JsonPropertyName("achPass_highPayRange")]
    public TemplateElement? AchPassHighPayRange { get; set; }

    [JsonPropertyName("achPass_lowPayRange")]
    public TemplateElement? AchPassLowPayRange { get; set; }

    [JsonPropertyName("achPassThrough")]
    public AchPassThroughSection? AchPassThrough { get; set; }

    /// <summary>
    /// Controls how to present the `batchCutoffTime` field on the application. If this field isn't sent, batch cut off time defaults to 5 ET.
    /// </summary>
    [JsonPropertyName("batchCutoffTime")]
    public TemplateElement? BatchCutoffTime { get; set; }

    [JsonPropertyName("discountFrequency")]
    public TemplateElement? DiscountFrequency { get; set; }

    [JsonPropertyName("fundingRollup")]
    public TemplateElement? FundingRollup { get; set; }

    [JsonPropertyName("gateway")]
    public TemplateElement? Gateway { get; set; }

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
