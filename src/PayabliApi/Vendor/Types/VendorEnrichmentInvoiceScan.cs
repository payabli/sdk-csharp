using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Vendor contact information and payment acceptance info extracted from an invoice.
/// </summary>
[Serializable]
public record VendorEnrichmentInvoiceScan : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Vendor name extracted from the invoice.
    /// </summary>
    [JsonPropertyName("vendorName")]
    public string? VendorName { get; set; }

    /// <summary>
    /// Street address.
    /// </summary>
    [JsonPropertyName("street")]
    public string? Street { get; set; }

    /// <summary>
    /// City.
    /// </summary>
    [JsonPropertyName("city")]
    public string? City { get; set; }

    /// <summary>
    /// State (two-letter abbreviation).
    /// </summary>
    [JsonPropertyName("state")]
    public string? State { get; set; }

    /// <summary>
    /// ZIP code.
    /// </summary>
    [JsonPropertyName("zipCode")]
    public string? ZipCode { get; set; }

    /// <summary>
    /// Country code.
    /// </summary>
    [JsonPropertyName("country")]
    public string? Country { get; set; }

    /// <summary>
    /// Phone number. Format isn't guaranteed and is extracted as-is from the invoice.
    /// </summary>
    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    /// <summary>
    /// Email address.
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>
    /// Payment portal URL, if found on the invoice.
    /// </summary>
    [JsonPropertyName("paymentLink")]
    public string? PaymentLink { get; set; }

    /// <summary>
    /// Whether the vendor accepts card payments. Values are `yes`, `no`, or `unable to determine`.
    /// </summary>
    [JsonPropertyName("cardAccepted")]
    public string? CardAccepted { get; set; }

    /// <summary>
    /// Whether the vendor accepts ACH payments. Values are `yes`, `no`, or `unable to determine`.
    /// </summary>
    [JsonPropertyName("achAccepted")]
    public string? AchAccepted { get; set; }

    /// <summary>
    /// Whether the vendor accepts check payments. Values are `yes`, `no`, or `unable to determine`.
    /// </summary>
    [JsonPropertyName("checkAccepted")]
    public string? CheckAccepted { get; set; }

    /// <summary>
    /// Invoice number extracted from the document.
    /// </summary>
    [JsonPropertyName("invoiceNumber")]
    public string? InvoiceNumber { get; set; }

    /// <summary>
    /// Invoice amount due in USD.
    /// </summary>
    [JsonPropertyName("amountDue")]
    public double? AmountDue { get; set; }

    /// <summary>
    /// Payment due date. Format is `YYYY-MM-DD`.
    /// </summary>
    [JsonPropertyName("dueDate")]
    public string? DueDate { get; set; }

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
