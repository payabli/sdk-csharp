using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record QueryTransferSummary : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// ACH returns deducted from the batch.
    /// </summary>
    [JsonPropertyName("achReturns")]
    public double? AchReturns { get; set; }

    /// <summary>
    /// Corrections applied to Billing & Fees charges.
    /// </summary>
    [JsonPropertyName("adjustments")]
    public double? Adjustments { get; set; }

    /// <summary>
    /// Charges applied for transactions and services.
    /// </summary>
    [JsonPropertyName("billingFees")]
    public double? BillingFees { get; set; }

    /// <summary>
    /// Chargebacks deducted from batch.
    /// </summary>
    [JsonPropertyName("chargebacks")]
    public double? Chargebacks { get; set; }

    /// <summary>
    /// The gross batch amount before deductions.
    /// </summary>
    [JsonPropertyName("grossTransferAmount")]
    public double? GrossTransferAmount { get; set; }

    /// <summary>
    /// Previously held funds that have been released after a risk review.
    /// </summary>
    [JsonPropertyName("releaseAmount")]
    public double? ReleaseAmount { get; set; }

    /// <summary>
    /// Payments captured in the batch cycle that are deposited separately. For example,  checks or cash payments recorded in the batch but not deposited via Payabli,  or card brands making a direct transfer in certain situations.
    /// </summary>
    [JsonPropertyName("thirdPartyPaid")]
    public double? ThirdPartyPaid { get; set; }

    /// <summary>
    /// The gross batch amount minus service fees.
    /// </summary>
    [JsonPropertyName("totalNetAmountTransfer")]
    public double? TotalNetAmountTransfer { get; set; }

    /// <summary>
    /// The sum of each splitFundingAmount of each record in the transfer.
    /// </summary>
    [JsonPropertyName("splitAmount")]
    public double? SplitAmount { get; set; }

    /// <summary>
    /// Service fees are any pass-through fees charged to the customer at the time of payment.  These aren't transferred to the merchant when the batch is transferred and funded.
    /// </summary>
    [JsonPropertyName("serviceFees")]
    public double? ServiceFees { get; set; }

    /// <summary>
    /// The net batch amount is the gross batch amount minus any returns, refunds,
    /// billing and fees items, chargebacks, adjustments, and third party payments.
    /// </summary>
    [JsonPropertyName("netBatchAmount")]
    public double? NetBatchAmount { get; set; }

    /// <summary>
    /// The transfer amount is the net batch amount plus or minus any returns, refunds,  billing and fees items, chargebacks, adjustments, and third party payments.  This is the amount from the batch that is transferred to the merchant bank account.
    /// </summary>
    [JsonPropertyName("transferAmount")]
    public double? TransferAmount { get; set; }

    /// <summary>
    /// Refunds deducted from batch.
    /// </summary>
    [JsonPropertyName("refunds")]
    public double? Refunds { get; set; }

    /// <summary>
    /// Funds being held for fraud or risk concerns.
    /// </summary>
    [JsonPropertyName("heldAmount")]
    public double? HeldAmount { get; set; }

    /// <summary>
    /// Number of records in the response.
    /// </summary>
    [JsonPropertyName("totalRecords")]
    public int? TotalRecords { get; set; }

    /// <summary>
    /// The total sum of the transfers in the response.
    /// </summary>
    [JsonPropertyName("totalAmount")]
    public double? TotalAmount { get; set; }

    /// <summary>
    /// The total sum of the transfers in the response.
    /// </summary>
    [JsonPropertyName("totalNetAmount")]
    public double? TotalNetAmount { get; set; }

    /// <summary>
    /// Number of pages in the response.
    /// </summary>
    [JsonPropertyName("totalPages")]
    public int? TotalPages { get; set; }

    /// <summary>
    /// Number of records per page.
    /// </summary>
    [JsonPropertyName("pageSize")]
    public int? PageSize { get; set; }

    /// <summary>
    /// Auxiliary validation used internally by payment pages and components.
    /// </summary>
    [JsonPropertyName("pageidentifier")]
    public string? Pageidentifier { get; set; }

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
