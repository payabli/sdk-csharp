using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Internal server error response (HTTP 500) returned when an unexpected error occurs. Follows RFC 7807 Problem Details format.
/// </summary>
[Serializable]
public record V2InternalServerError : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Always "Internal Server Error" for 500 errors.
    /// </summary>
    [JsonPropertyName("title")]
    public required string Title { get; set; }

    /// <summary>
    /// HTTP status code, always 500 for internal errors.
    /// </summary>
    [JsonPropertyName("status")]
    public required int Status { get; set; }

    /// <summary>
    /// Additional details about the internal error.
    /// </summary>
    [JsonPropertyName("detail")]
    public required string Detail { get; set; }

    /// <summary>
    /// Request URL that caused the error.
    /// </summary>
    [JsonPropertyName("instance")]
    public required string Instance { get; set; }

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
