using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record AddMethodResponseResponseData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Stored method identifier in Payabli platform. This ID is used to manage the stored method.
    /// </summary>
    [JsonPropertyName("referenceId")]
    public string? ReferenceId { get; set; }

    [JsonPropertyName("resultCode")]
    public int? ResultCode { get; set; }

    [JsonPropertyName("resultText")]
    public string? ResultText { get; set; }

    /// <summary>
    /// Internal unique ID of customer owner of the stored method.
    ///
    /// Returns `0` if the method wasn't assigned to an existing customer or no customer was created.
    /// </summary>
    [JsonPropertyName("customerId")]
    public long? CustomerId { get; set; }

    /// <summary>
    /// Only returned when the request is declined.
    /// </summary>
    [JsonPropertyName("authCode")]
    public string? AuthCode { get; set; }

    /// <summary>
    /// Only returned when the request is declined.
    /// </summary>
    [JsonPropertyName("avsResponseText")]
    public string? AvsResponseText { get; set; }

    /// <summary>
    /// Only returned when the request is declined.
    /// </summary>
    [JsonPropertyName("cvvResponseText")]
    public string? CvvResponseText { get; set; }

    /// <summary>
    /// Only returned when the request is declined.
    /// </summary>
    [JsonPropertyName("vendorId")]
    public int? VendorId { get; set; }

    /// <summary>
    /// Stored method identifier in Payabli platform. Returns the same value as
    /// `referenceId`. This field isn't returned when you convert a temporary
    /// token to a permanent token, so use `referenceId` to get the stored
    /// method ID.
    /// </summary>
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
