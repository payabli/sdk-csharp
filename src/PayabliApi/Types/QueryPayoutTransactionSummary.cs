using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record QueryPayoutTransactionSummary : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("pageIdentifier")]
    public string? PageIdentifier { get; set; }

    [JsonPropertyName("pageSize")]
    public int? PageSize { get; set; }

    [JsonPropertyName("totalAmount")]
    public double? TotalAmount { get; set; }

    [JsonPropertyName("totalAuthorized")]
    public int? TotalAuthorized { get; set; }

    [JsonPropertyName("totalAuthorizedAmount")]
    public double? TotalAuthorizedAmount { get; set; }

    [JsonPropertyName("totalCanceled")]
    public int? TotalCanceled { get; set; }

    [JsonPropertyName("totalCanceledAmount")]
    public double? TotalCanceledAmount { get; set; }

    [JsonPropertyName("totalCaptured")]
    public int? TotalCaptured { get; set; }

    [JsonPropertyName("totalCapturedAmount")]
    public double? TotalCapturedAmount { get; set; }

    [JsonPropertyName("totalNetAmount")]
    public double? TotalNetAmount { get; set; }

    [JsonPropertyName("totalOpen")]
    public int? TotalOpen { get; set; }

    [JsonPropertyName("totalOpenAmount")]
    public double? TotalOpenAmount { get; set; }

    [JsonPropertyName("totalPages")]
    public int? TotalPages { get; set; }

    [JsonPropertyName("totalPaid")]
    public int? TotalPaid { get; set; }

    [JsonPropertyName("totalPaidAmount")]
    public double? TotalPaidAmount { get; set; }

    /// <summary>
    /// Total number of transactions that are currently on hold.
    /// </summary>
    [JsonPropertyName("totalOnHold")]
    public int? TotalOnHold { get; set; }

    /// <summary>
    /// Total amount of transactions that are currently on hold.
    /// </summary>
    [JsonPropertyName("totalOnHoldAmount")]
    public double? TotalOnHoldAmount { get; set; }

    [JsonPropertyName("totalProcessing")]
    public int? TotalProcessing { get; set; }

    [JsonPropertyName("totalProcessingAmount")]
    public double? TotalProcessingAmount { get; set; }

    [JsonPropertyName("totalRecords")]
    public int? TotalRecords { get; set; }

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
