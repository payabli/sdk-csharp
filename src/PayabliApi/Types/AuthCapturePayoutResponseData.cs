using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record AuthCapturePayoutResponseData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("authCode")]
    public string? AuthCode { get; set; }

    /// <summary>
    /// The transaction reference ID, used to capture the transaction. Returns `null` when no transaction is created, such as a declined authorization.
    /// </summary>
    [JsonPropertyName("referenceId")]
    public string? ReferenceId { get; set; }

    [JsonPropertyName("resultCode")]
    public required int ResultCode { get; set; }

    [JsonPropertyName("resultText")]
    public required string ResultText { get; set; }

    [JsonPropertyName("avsResponseText")]
    public string? AvsResponseText { get; set; }

    [JsonPropertyName("cvvResponseText")]
    public string? CvvResponseText { get; set; }

    /// <summary>
    /// Payabli-generated unique ID of the vendor on the payout. Returns the same value as `vendorId`, or `0` when no vendor is associated.
    /// </summary>
    [JsonPropertyName("customerId")]
    public required long CustomerId { get; set; }

    /// <summary>
    /// Payabli-generated unique ID of the vendor on the payout. Returns the same value as `customerId`, or `0` when no vendor is associated.
    /// </summary>
    [JsonPropertyName("vendorId")]
    public required long VendorId { get; set; }

    [JsonPropertyName("methodReferenceId")]
    public string? MethodReferenceId { get; set; }

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
