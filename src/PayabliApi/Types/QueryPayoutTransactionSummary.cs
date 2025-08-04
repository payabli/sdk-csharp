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
    public float? TotalAmount { get; set; }

    [JsonPropertyName("totalAuthorized")]
    public int? TotalAuthorized { get; set; }

    [JsonPropertyName("totalAuthorizedAmount")]
    public float? TotalAuthorizedAmount { get; set; }

    [JsonPropertyName("totalCanceled")]
    public int? TotalCanceled { get; set; }

    [JsonPropertyName("totalCanceledAmount")]
    public float? TotalCanceledAmount { get; set; }

    [JsonPropertyName("totalCaptured")]
    public int? TotalCaptured { get; set; }

    [JsonPropertyName("totalCapturedAmount")]
    public float? TotalCapturedAmount { get; set; }

    [JsonPropertyName("totalNetAmount")]
    public float? TotalNetAmount { get; set; }

    [JsonPropertyName("totalOpen")]
    public int? TotalOpen { get; set; }

    [JsonPropertyName("totalOpenAmount")]
    public float? TotalOpenAmount { get; set; }

    [JsonPropertyName("totalPages")]
    public int? TotalPages { get; set; }

    [JsonPropertyName("totalPaid")]
    public int? TotalPaid { get; set; }

    [JsonPropertyName("totalPaidAmount")]
    public float? TotalPaidAmount { get; set; }

    /// <summary>
    /// Total number of transactions that are currently on hold.
    /// </summary>
    [JsonPropertyName("totalOnHold")]
    public int? TotalOnHold { get; set; }

    /// <summary>
    /// Total amount of transactions that are currently on hold.
    /// </summary>
    [JsonPropertyName("totalOnHoldAmount")]
    public float? TotalOnHoldAmount { get; set; }

    [JsonPropertyName("totalProcessing")]
    public int? TotalProcessing { get; set; }

    [JsonPropertyName("totalProcessingAmount")]
    public float? TotalProcessingAmount { get; set; }

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
