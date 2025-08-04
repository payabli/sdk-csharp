using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record QueryResponseSettlementsSummary : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Funds being held for fraud or risk concerns.
    /// </summary>
    [JsonPropertyName("heldAmount")]
    public double? HeldAmount { get; set; }

    [JsonPropertyName("pageidentifier")]
    public string? Pageidentifier { get; set; }

    /// <summary>
    /// Number of records per page.
    /// </summary>
    [JsonPropertyName("pageSize")]
    public int? PageSize { get; set; }

    /// <summary>
    /// Total refunds deducted from the transfer.
    /// </summary>
    [JsonPropertyName("refunds")]
    public double? Refunds { get; set; }

    /// <summary>
    /// Service fees are any pass-through fees charged to the customer at the time of payment. These aren't transferred to the merchant when the batch is transferred and funded.
    /// </summary>
    [JsonPropertyName("serviceFees")]
    public double? ServiceFees { get; set; }

    /// <summary>
    /// The total sum of the settlements in the response.
    /// </summary>
    [JsonPropertyName("totalAmount")]
    public double? TotalAmount { get; set; }

    /// <summary>
    /// The total sum of the settlements in the response.
    /// </summary>
    [JsonPropertyName("totalNetAmount")]
    public double? TotalNetAmount { get; set; }

    /// <summary>
    /// Number of pages in the response.
    /// </summary>
    [JsonPropertyName("totalPages")]
    public int? TotalPages { get; set; }

    /// <summary>
    /// Number of records in the response.
    /// </summary>
    [JsonPropertyName("totalRecords")]
    public int? TotalRecords { get; set; }

    /// <summary>
    /// The transfer amount is the net batch amount plus or minus any returns, refunds, billing and fees items, chargebacks, adjustments, and third party payments. This is the amount from the batch that's transferred to the merchant bank account.
    /// </summary>
    [JsonPropertyName("transferAmount")]
    public double? TransferAmount { get; set; }

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
