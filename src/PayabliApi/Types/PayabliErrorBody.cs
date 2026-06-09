using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Shape returned by every Payabli API error response. The `responseData`
/// object carries human-readable error context.
/// </summary>
[Serializable]
public record PayabliErrorBody : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Always `false` for error responses.
    /// </summary>
    [JsonPropertyName("isSuccess")]
    public required bool IsSuccess { get; set; }

    /// <summary>
    /// Code for the response. Learn more in
    /// [API Response Codes](/developers/api-reference/api-responses).
    /// </summary>
    [JsonPropertyName("responseCode")]
    public int? ResponseCode { get; set; }

    /// <summary>
    /// Error text describing what went wrong.
    /// </summary>
    [JsonPropertyName("responseText")]
    public required string ResponseText { get; set; }

    /// <summary>
    /// Object with detailed error context.
    /// </summary>
    [JsonPropertyName("responseData")]
    public PayabliErrorBodyResponseData? ResponseData { get; set; }

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
