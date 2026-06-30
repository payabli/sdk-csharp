using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record ScheduleEnrichmentCallRequest
{
    /// <summary>
    /// ID of the vendor to call. Must be active and belong to the entrypoint in the path.
    /// </summary>
    [JsonPropertyName("vendorId")]
    public required long VendorId { get; set; }

    /// <summary>
    /// Vendor phone number to call, digits only. Optional. When omitted, Payabli uses the phone number on the vendor's record. If the vendor has no phone on record, the request returns an error.
    /// </summary>
    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    /// <summary>
    /// ID of the originating enrichment run to associate with this call. Optional. When omitted, Payabli generates a standalone call schedule and skips the enrichment lookup. The bill due-date check only runs when both `enrichmentId` and `billId` are supplied.
    /// </summary>
    [JsonPropertyName("enrichmentId")]
    public string? EnrichmentId { get; set; }

    /// <summary>
    /// Bill ID used for the due-date check. When the bill is due in fewer than three days, the call is skipped and the fallback method is applied. Only evaluated when `enrichmentId` is also supplied.
    /// </summary>
    [JsonPropertyName("billId")]
    public long? BillId { get; set; }

    /// <summary>
    /// Payment method to apply to the vendor record if the call can't determine a preference or all retries are exhausted. Values are `check` (the default) or `managed`.
    /// </summary>
    [JsonPropertyName("fallbackMethod")]
    public string? FallbackMethod { get; set; }

    /// <summary>
    /// Number of times to retry the call if the vendor doesn't answer. Defaults to 3. Maximum is 5. The get outreach call status response reports this value as `maxAttempts`.
    /// </summary>
    [JsonPropertyName("maxRetries")]
    public int? MaxRetries { get; set; }

    /// <summary>
    /// IANA timezone identifier used to schedule the call in the vendor's local time. Defaults to `America/New_York`.
    /// </summary>
    [JsonPropertyName("timezone")]
    public string? Timezone { get; set; }

    /// <summary>
    /// When `true`, dispatches the call immediately and bypasses the business-hours window and the bill due-date check. Defaults to `false`.
    /// </summary>
    [JsonPropertyName("sendNow")]
    public bool? SendNow { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
