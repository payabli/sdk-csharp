using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record CreateServerSideTokenRequest
{
    /// <summary>
    /// The client ID issued for your integration when credentials are provisioned in the Payabli Portal.
    /// </summary>
    [JsonPropertyName("clientId")]
    public required string ClientId { get; set; }

    /// <summary>
    /// The client secret issued alongside the client ID. Keep it on your backend and never expose it in client-side code.
    /// </summary>
    [JsonPropertyName("clientSecret")]
    public required string ClientSecret { get; set; }

    /// <summary>
    /// An optional opaque value echoed back in the response. Use it to correlate the request with its response.
    /// </summary>
    [JsonPropertyName("state")]
    public string? State { get; set; }

    /// <summary>
    /// An optional array of permission IDs that scopes the token to a subset of the credential's granted permissions. When omitted, the token carries all permissions granted to the credential.
    /// </summary>
    [JsonPropertyName("permissions")]
    public IEnumerable<string>? Permissions { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
