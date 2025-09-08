using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record RequestOutAuthorizeInvoiceData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("invoiceNumber")]
    public string? InvoiceNumber { get; set; }

    [JsonPropertyName("netAmount")]
    public string? NetAmount { get; set; }

    /// <summary>
    /// Invoice date in any of the accepted formats: YYYY-MM-DD, MM/DD/YYYY.
    /// </summary>
    [JsonPropertyName("invoiceDate")]
    public DateOnly? InvoiceDate { get; set; }

    /// <summary>
    /// Invoice due date in any of the accepted formats: YYYY-MM-DD, MM/DD/YYYY.
    /// </summary>
    [JsonPropertyName("dueDate")]
    public DateOnly? DueDate { get; set; }

    [JsonPropertyName("comments")]
    public string? Comments { get; set; }

    [JsonPropertyName("lotNumber")]
    public string? LotNumber { get; set; }

    [JsonPropertyName("billId")]
    public long? BillId { get; set; }

    [JsonPropertyName("discount")]
    public double? Discount { get; set; }

    [JsonPropertyName("terms")]
    public string? Terms { get; set; }

    [JsonPropertyName("accountingField1")]
    public string? AccountingField1 { get; set; }

    [JsonPropertyName("accountingField2")]
    public string? AccountingField2 { get; set; }

    [JsonPropertyName("additionalData")]
    public string? AdditionalData { get; set; }

    [JsonPropertyName("attachments")]
    public IEnumerable<FileContent>? Attachments { get; set; }

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
