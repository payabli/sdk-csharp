using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record PayabliApiResponse11ResponseData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Payabli-generated unique ID of vendor owner of transaction. It will return `0`` if the transaction wasn't assigned to an existing vendor or no vendor was created.
    /// </summary>
    [JsonPropertyName("CustomerId")]
    public long? CustomerId { get; set; }

    [JsonPropertyName("ReferenceId")]
    public string? ReferenceId { get; set; }

    [JsonPropertyName("ResultCode")]
    public int? ResultCode { get; set; }

    /// <summary>
    /// Text describing the result. If **ResultCode** = 1, will return 'Authorized'. If **ResultCode** = 2 or 3, will contain the reason for the decline.
    /// </summary>
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
