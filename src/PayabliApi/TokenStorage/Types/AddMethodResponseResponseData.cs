using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record AddMethodResponseResponseData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Internal unique ID of customer owner of the stored method.
    ///
    /// Returns `0` if the method wasn't assigned to an existing customer or no customer was created."
    /// </summary>
    [JsonPropertyName("CustomerId")]
    public long? CustomerId { get; set; }

    [JsonPropertyName("methodReferenceId")]
    public string? MethodReferenceId { get; set; }

    /// <summary>
    /// Stored method identifier in Payabli platform. This ID is used to manage the stored method.
    /// </summary>
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
