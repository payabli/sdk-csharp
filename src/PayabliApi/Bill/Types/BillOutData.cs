using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record BillOutData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("accountingField1")]
    public string? AccountingField1 { get; set; }

    [JsonPropertyName("accountingField2")]
    public string? AccountingField2 { get; set; }

    [JsonPropertyName("additionalData")]
    public string? AdditionalData { get; set; }

    /// <summary>
    /// An array of bill images. Attachments aren't required, but we strongly recommend including them. Including a bill image can make payouts smoother and prevent delays. You can include either the Base64-encoded file content, or you can include an fURL to a public file. The maximum file size for image uploads is 30 MB.
    /// </summary>
    [JsonPropertyName("attachments")]
    public IEnumerable<FileContent>? Attachments { get; set; }

    /// <summary>
    /// Date of bill. Accepted formats: YYYY-MM-DD, MM/DD/YYYY.
    /// </summary>
    [JsonPropertyName("billDate")]
    public DateOnly? BillDate { get; set; }

    [JsonPropertyName("billItems")]
    public IEnumerable<BillItem>? BillItems { get; set; }

    /// <summary>
    /// Unique identifier for the bill. Required when adding a bill.
    /// </summary>
    [JsonPropertyName("billNumber")]
    public string? BillNumber { get; set; }

    [JsonPropertyName("comments")]
    public string? Comments { get; set; }

    /// <summary>
    /// Discount amount applied to the bill.
    /// </summary>
    [JsonPropertyName("discount")]
    public double? Discount { get; set; }

    /// <summary>
    /// Due date of bill. Accepted formats: YYYY-MM-DD, MM/DD/YYYY.
    /// </summary>
    [JsonPropertyName("dueDate")]
    public DateOnly? DueDate { get; set; }

    /// <summary>
    /// End Date for scheduled bills. Applied only in `Mode` = 1. Accepted formats: YYYY-MM-DD, MM/DD/YYYY
    /// </summary>
    [JsonPropertyName("endDate")]
    public DateOnly? EndDate { get; set; }

    /// <summary>
    /// Frequency for scheduled bills. Applied only in `Mode` = 1.
    /// </summary>
    [JsonPropertyName("frequency")]
    public Frequency? Frequency { get; set; }

    /// <summary>
    /// Lot number associated with the bill.
    /// </summary>
    [JsonPropertyName("lotNumber")]
    public string? LotNumber { get; set; }

    /// <summary>
    /// Bill mode: value `0` for one-time bills, `1` for scheduled bills.
    /// </summary>
    [JsonPropertyName("mode")]
    public int? Mode { get; set; }

    /// <summary>
    /// Net Amount owed in bill. Required when adding a bill.
    /// </summary>
    [JsonPropertyName("netAmount")]
    public double? NetAmount { get; set; }

    /// <summary>
    /// Options for scheduled bills.
    /// </summary>
    [JsonPropertyName("scheduledOptions")]
    public BillOutDataScheduledOptions? ScheduledOptions { get; set; }

    [JsonPropertyName("status")]
    public int? Status { get; set; }

    [JsonPropertyName("terms")]
    public string? Terms { get; set; }

    /// <summary>
    /// Total amount of the bill.
    /// </summary>
    [JsonPropertyName("totalAmount")]
    public double? TotalAmount { get; set; }

    /// <summary>
    /// The vendor associated with the bill. Although you can create a vendor in a create bill request, Payabli recommends creating a vendor separately and passing a valid `vendorNumber` here. At minimum, the `vendorNumber` is required.
    /// </summary>
    [JsonPropertyName("vendor")]
    public VendorData? Vendor { get; set; }

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
