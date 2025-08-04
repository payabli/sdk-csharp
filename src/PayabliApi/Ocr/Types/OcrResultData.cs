using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record OcrResultData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("billNumber")]
    public string? BillNumber { get; set; }

    [JsonPropertyName("netAmount")]
    public double? NetAmount { get; set; }

    [JsonPropertyName("billDate")]
    public DateTime? BillDate { get; set; }

    [JsonPropertyName("dueDate")]
    public DateTime? DueDate { get; set; }

    [JsonPropertyName("comments")]
    public string? Comments { get; set; }

    [JsonPropertyName("billItems")]
    public IEnumerable<OcrBillItem>? BillItems { get; set; }

    [JsonPropertyName("mode")]
    public int? Mode { get; set; }

    [JsonPropertyName("accountingField1")]
    public string? AccountingField1 { get; set; }

    [JsonPropertyName("accountingField2")]
    public string? AccountingField2 { get; set; }

    [JsonPropertyName("additionalData")]
    public OcrBillItemAdditionalData? AdditionalData { get; set; }

    [JsonPropertyName("vendor")]
    public OcrVendor? Vendor { get; set; }

    [JsonPropertyName("endDate")]
    public DateTime? EndDate { get; set; }

    [JsonPropertyName("frequency")]
    public string? Frequency { get; set; }

    [JsonPropertyName("terms")]
    public string? Terms { get; set; }

    [JsonPropertyName("status")]
    public int? Status { get; set; }

    [JsonPropertyName("lotNumber")]
    public string? LotNumber { get; set; }

    [JsonPropertyName("attachments")]
    public IEnumerable<OcrAttachment>? Attachments { get; set; }

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
