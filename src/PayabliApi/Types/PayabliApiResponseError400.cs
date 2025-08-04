using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record PayabliApiResponseError400 : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Boolean indicating whether the operation was successful. A `true` value indicates success. A `false` value indicates failure.
    /// </summary>
    [JsonPropertyName("isSuccess")]
    public bool? IsSuccess { get; set; }

    [JsonPropertyName("pageidentifier")]
    public string? Pageidentifier { get; set; }

    /// <summary>
    /// A code that indicates the operation's failure reason. See [API Response Codes](https://docs.payabli.com/api-reference/api-responses) for a full reference.
    /// </summary>
    [JsonPropertyName("responseCode")]
    public int? ResponseCode { get; set; }

    /// <summary>
    /// Describes the reason for a failed operation and how to resolve it.
    /// </summary>
    [JsonPropertyName("responseData")]
    public PayabliApiResponseError400ResponseData? ResponseData { get; set; }

    /// <summary>
    /// Response text for operation: 'Success' or 'Declined'.
    /// </summary>
    [JsonPropertyName("responseText")]
    public string? ResponseText { get; set; }

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
