using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Bad request error response (HTTP 400) returned when request validation fails. Follows RFC 7807 Problem Details format with additional Payabli-specific fields.
/// </summary>
[Serializable]
public record V2BadRequestError : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// A URI reference that identifies the problem type. Points to human-readable documentation for this error type.
    /// </summary>
    [JsonPropertyName("type")]
    public required string Type { get; set; }

    /// <summary>
    /// Always "Bad Request" for 400 errors.
    /// </summary>
    [JsonPropertyName("title")]
    public required string Title { get; set; }

    /// <summary>
    /// HTTP status code, always 400 for bad requests.
    /// </summary>
    [JsonPropertyName("status")]
    public required int Status { get; set; }

    /// <summary>
    /// Short description of the error.
    /// </summary>
    [JsonPropertyName("detail")]
    public required string Detail { get; set; }

    /// <summary>
    /// Request URL that caused the error.
    /// </summary>
    [JsonPropertyName("instance")]
    public required string Instance { get; set; }

    /// <summary>
    /// Payabli's unified response code for validation errors. Starts with 'E'. See [Pay In unified response codes reference](/guides/pay-in-unified-response-codes-reference) for more information.
    /// </summary>
    [JsonPropertyName("code")]
    public required string Code { get; set; }

    /// <summary>
    /// Dictionary of field-specific validation errors. Keys are field paths (e.g., "paymentMethod.cardnumber") and values are arrays of error details.
    /// </summary>
    [JsonPropertyName("errors")]
    public Dictionary<string, IEnumerable<V2BadRequestErrorDetail>> Errors { get; set; } =
        new Dictionary<string, IEnumerable<V2BadRequestErrorDetail>>();

    /// <summary>
    /// Pagination token (equivalent to pageIdentifier in v1 APIs). Usually null for errors.
    /// </summary>
    [JsonPropertyName("token")]
    public string? Token { get; set; }

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
