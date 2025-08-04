using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Response object for bill details. Contains basic information about a bill.
/// </summary>
[Serializable]
public record BillDetailsResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("billId")]
    public long? BillId { get; set; }

    /// <summary>
    /// Lot number of the bill.
    /// </summary>
    [JsonPropertyName("lotNumber")]
    public string? LotNumber { get; set; }

    /// <summary>
    /// Custom number identifying the bill.
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
    /// Any comments about bill. **For managed payouts, this field has a limit of 100 characters**.
    /// </summary>
    [JsonPropertyName("comments")]
    public string? Comments { get; set; }

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
