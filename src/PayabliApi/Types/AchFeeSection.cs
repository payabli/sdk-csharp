using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record AchFeeSection : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("advancedSettlementAchFee")]
    public TemplateElement? AdvancedSettlementAchFee { get; set; }

    [JsonPropertyName("annualAchFee")]
    public TemplateElement? AnnualAchFee { get; set; }

    [JsonPropertyName("chargebackAchFee")]
    public TemplateElement? ChargebackAchFee { get; set; }

    [JsonPropertyName("earlyTerminationAchFee")]
    public TemplateElement? EarlyTerminationAchFee { get; set; }

    [JsonPropertyName("monthlyAchFee")]
    public TemplateElement? MonthlyAchFee { get; set; }

    [JsonPropertyName("quarterlyPCIAchFee")]
    public TemplateElement? QuarterlyPciAchFee { get; set; }

    [JsonPropertyName("returnedAchFee")]
    public TemplateElement? ReturnedAchFee { get; set; }

    [JsonPropertyName("sameDayAchFee")]
    public TemplateElement? SameDayAchFee { get; set; }

    [JsonPropertyName("sundayOriginationAchFee")]
    public TemplateElement? SundayOriginationAchFee { get; set; }

    [JsonPropertyName("verifyBankAchFee")]
    public TemplateElement? VerifyBankAchFee { get; set; }

    [JsonPropertyName("verifyFundAchFee")]
    public TemplateElement? VerifyFundAchFee { get; set; }

    [JsonPropertyName("verifyNegativeAchFee")]
    public TemplateElement? VerifyNegativeAchFee { get; set; }

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
