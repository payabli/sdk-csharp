using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record RenewVCardResponseData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Not used for virtual card renewal; always returns `null`.
    /// </summary>
    [JsonPropertyName("authCode")]
    public string? AuthCode { get; set; }

    /// <summary>
    /// Reference identifier for the renewed virtual card returned by the card processor.
    /// </summary>
    [JsonPropertyName("referenceId")]
    public required string ReferenceId { get; set; }

    [JsonPropertyName("resultCode")]
    public required int ResultCode { get; set; }

    [JsonPropertyName("resultText")]
    public required string ResultText { get; set; }

    /// <summary>
    /// Not used for virtual card renewal; always returns `null`.
    /// </summary>
    [JsonPropertyName("avsResponseText")]
    public string? AvsResponseText { get; set; }

    /// <summary>
    /// Not used for virtual card renewal; always returns `null`.
    /// </summary>
    [JsonPropertyName("cvvResponseText")]
    public string? CvvResponseText { get; set; }

    /// <summary>
    /// Not used for virtual card renewal; always returns `null`.
    /// </summary>
    [JsonPropertyName("customerId")]
    public long? CustomerId { get; set; }

    /// <summary>
    /// Not used for virtual card renewal; always returns `null`.
    /// </summary>
    [JsonPropertyName("vendorId")]
    public long? VendorId { get; set; }

    /// <summary>
    /// Not used for virtual card renewal; always returns `null`.
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
