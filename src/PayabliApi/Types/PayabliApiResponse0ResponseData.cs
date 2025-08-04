using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record PayabliApiResponse0ResponseData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("AuthCode")]
    public string? AuthCode { get; set; }

    [JsonPropertyName("avsResponseText")]
    public string? AvsResponseText { get; set; }

    [JsonPropertyName("CustomerId")]
    public long? CustomerId { get; set; }

    [JsonPropertyName("cvvResponseText")]
    public string? CvvResponseText { get; set; }

    [JsonPropertyName("methodReferenceId")]
    public string? MethodReferenceId { get; set; }

    [JsonPropertyName("ReferenceId")]
    public string? ReferenceId { get; set; }

    [JsonPropertyName("ResultCode")]
    public int? ResultCode { get; set; }

    [JsonPropertyName("ResultText")]
    public string? ResultText { get; set; }

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
