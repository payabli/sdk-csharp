using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record ResponseDataRefunds : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("authCode")]
    public required string AuthCode { get; set; }

    [JsonPropertyName("expectedProcessingDateTime")]
    public DateTime? ExpectedProcessingDateTime { get; set; }

    /// <summary>
    /// This field isn't applicable to refund operations.
    /// </summary>
    [JsonPropertyName("avsResponseText")]
    public string? AvsResponseText { get; set; }

    [JsonPropertyName("customerId")]
    public long? CustomerId { get; set; }

    /// <summary>
    /// This field isn't applicable to refund operations.
    /// </summary>
    [JsonPropertyName("cvvResponseText")]
    public string? CvvResponseText { get; set; }

    /// <summary>
    /// This field isn't applicable to refund operations.
    /// </summary>
    [JsonPropertyName("methodReferenceId")]
    public string? MethodReferenceId { get; set; }

    [JsonPropertyName("referenceId")]
    public required string ReferenceId { get; set; }

    [JsonPropertyName("resultCode")]
    public required int ResultCode { get; set; }

    /// <summary>
    /// Text description of the transaction result
    /// </summary>
    [JsonPropertyName("resultText")]
    public required string ResultText { get; set; }

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
