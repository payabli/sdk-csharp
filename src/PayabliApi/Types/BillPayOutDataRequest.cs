using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record BillPayOutDataRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Bill ID in Payabli.
    /// </summary>
    [JsonPropertyName("billId")]
    public long? BillId { get; set; }

    /// <summary>
    /// Any comments about bill. **For managed payouts, this field has a limit of 100 characters**.
    /// </summary>
    [JsonPropertyName("comments")]
    public string? Comments { get; set; }

    /// <summary>
    /// Bill due date in format YYYY-MM-DD or MM/DD/YYYY.
    /// </summary>
    [JsonPropertyName("dueDate")]
    public DateOnly? DueDate { get; set; }

    /// <summary>
    /// Bill date in format YYYY-MM-DD or MM/DD/YYYY.
    /// </summary>
    [JsonPropertyName("invoiceDate")]
    public DateOnly? InvoiceDate { get; set; }

    /// <summary>
    /// Custom number identifying the bill. Must be unique in paypoint. **Required** for new bill and when `billId` isn't provided.
    /// </summary>
    [JsonPropertyName("invoiceNumber")]
    public string? InvoiceNumber { get; set; }

    /// <summary>
    /// Net Amount owed in bill. Required when adding a bill.
    /// </summary>
    [JsonPropertyName("netAmount")]
    public string? NetAmount { get; set; }

    /// <summary>
    /// Bill discount amount.
    /// </summary>
    [JsonPropertyName("discount")]
    public string? Discount { get; set; }

    /// <summary>
    /// Description of payment terms.
    /// </summary>
    [JsonPropertyName("terms")]
    public string? Terms { get; set; }

    [JsonPropertyName("accountingField1")]
    public string? AccountingField1 { get; set; }

    [JsonPropertyName("accountingField2")]
    public string? AccountingField2 { get; set; }

    [JsonPropertyName("additionalData")]
    public string? AdditionalData { get; set; }

    /// <summary>
    /// Bill image attachment. Send the bill image as Base64-encoded string, or as a publicly accessible link. For full details on using this field with a payout authorization, see [the documentation](/developers/developer-guides/pay-out-manage-payouts).
    /// </summary>
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
