using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Successful response from the token endpoint. Returns the access token, its lifetime, and any state echoed from the request.
/// </summary>
[Serializable]
public record PayabliAccessTokenResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The token type. Send the access token in the `Authorization` header as `Bearer `.
    /// </summary>
    [JsonPropertyName("token_type")]
    public required string TokenType { get; set; }

    /// <summary>
    /// The access token to send on subsequent API calls.
    /// </summary>
    [JsonPropertyName("access_token")]
    public required string AccessToken { get; set; }

    /// <summary>
    /// The token's lifetime in seconds. Request a new token when it expires.
    /// </summary>
    [JsonPropertyName("expires_in")]
    public required int ExpiresIn { get; set; }

    /// <summary>
    /// The opaque value sent in the request, echoed back. Present only when you send `state` in the request.
    /// </summary>
    [JsonPropertyName("state")]
    public string? State { get; set; }

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
