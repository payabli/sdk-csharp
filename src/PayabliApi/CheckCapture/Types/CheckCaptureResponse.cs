using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Response model for check capture processing.
/// </summary>
[Serializable]
public record CheckCaptureResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Unique ID for the check capture, to be used with the /api/MoneyIn/getpaid endpoint.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// Indicates whether the check processing was successful.
    /// </summary>
    [JsonPropertyName("success")]
    public required bool Success { get; set; }

    /// <summary>
    /// The date and time when the check was processed (ISO 8601 format).
    /// </summary>
    [JsonPropertyName("processDate")]
    public required string ProcessDate { get; set; }

    /// <summary>
    /// The OCR-extracted MICR (Magnetic Ink Character Recognition) line from the check.
    /// </summary>
    [JsonPropertyName("ocrMicr")]
    public string? OcrMicr { get; set; }

    /// <summary>
    /// Status of the MICR extraction process.
    /// </summary>
    [JsonPropertyName("ocrMicrStatus")]
    public string? OcrMicrStatus { get; set; }

    /// <summary>
    /// Confidence score for the MICR extraction (0 to 100).
    /// </summary>
    [JsonPropertyName("ocrMicrConfidence")]
    public string? OcrMicrConfidence { get; set; }

    /// <summary>
    /// The bank account number extracted from the check.
    /// </summary>
    [JsonPropertyName("ocrAccountNumber")]
    public string? OcrAccountNumber { get; set; }

    /// <summary>
    /// The bank routing number extracted from the check.
    /// </summary>
    [JsonPropertyName("ocrRoutingNumber")]
    public string? OcrRoutingNumber { get; set; }

    /// <summary>
    /// The check number extracted from the check.
    /// </summary>
    [JsonPropertyName("ocrCheckNumber")]
    public string? OcrCheckNumber { get; set; }

    /// <summary>
    /// The transaction code extracted from the check.
    /// </summary>
    [JsonPropertyName("ocrCheckTranCode")]
    public string? OcrCheckTranCode { get; set; }

    /// <summary>
    /// The amount extracted via OCR from the check.
    /// </summary>
    [JsonPropertyName("ocrAmount")]
    public string? OcrAmount { get; set; }

    /// <summary>
    /// Status of the amount extraction process.
    /// </summary>
    [JsonPropertyName("ocrAmountStatus")]
    public string? OcrAmountStatus { get; set; }

    /// <summary>
    /// Confidence score for the amount extraction (0 to 100).
    /// </summary>
    [JsonPropertyName("ocrAmountConfidence")]
    public string? OcrAmountConfidence { get; set; }

    /// <summary>
    /// Flag indicating whether there's a discrepancy between the provided amount and the OCR-detected amount.
    /// </summary>
    [JsonPropertyName("amountDiscrepancyDetected")]
    public required bool AmountDiscrepancyDetected { get; set; }

    /// <summary>
    /// Flag indicating whether an endorsement was detected on the check.
    /// </summary>
    [JsonPropertyName("endorsementDetected")]
    public required bool EndorsementDetected { get; set; }

    /// <summary>
    /// List of error messages that occurred during processing.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<string>? Errors { get; set; }

    /// <summary>
    /// List of informational messages about the processing.
    /// </summary>
    [JsonPropertyName("messages")]
    public IEnumerable<string>? Messages { get; set; }

    /// <summary>
    /// Confidence score for the match between Courtesy Amount Recognition (CAR) and Legal Amount Recognition (LAR).
    /// </summary>
    [JsonPropertyName("carLarMatchConfidence")]
    public string? CarLarMatchConfidence { get; set; }

    /// <summary>
    /// Status of the CAR/LAR match.
    /// </summary>
    [JsonPropertyName("carLarMatchStatus")]
    public string? CarLarMatchStatus { get; set; }

    /// <summary>
    /// Processed front image of the check (Base64-encoded).
    /// </summary>
    [JsonPropertyName("frontImage")]
    public string? FrontImage { get; set; }

    /// <summary>
    /// Processed rear image of the check (Base64-encoded).
    /// </summary>
    [JsonPropertyName("rearImage")]
    public string? RearImage { get; set; }

    /// <summary>
    /// Identifier for the type of check.
    /// Personal = 1
    /// Business = 2
    /// Only personal checks are supported for check capture.
    /// </summary>
    [JsonPropertyName("checkType")]
    public required double CheckType { get; set; }

    /// <summary>
    /// Reference number for the transaction.
    /// </summary>
    [JsonPropertyName("referenceNumber")]
    public string? ReferenceNumber { get; set; }

    [JsonPropertyName("pageIdentifier")]
    public string? PageIdentifier { get; set; }

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
