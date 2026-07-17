namespace PayabliApi;

public partial interface ITokenClient
{
    /// <summary>
    /// Exchanges a client ID and client secret for a short-lived Bearer access token using the OAuth2 client-credentials flow. Designed for server-to-server use: the credentials and the returned token stay on your backend. Send the returned `access_token` in the `Authorization` header as `Bearer ` on subsequent API calls. See the [OAuth authentication guide](/developers/oauth-authentication) for the full flow.
    /// </summary>
    WithRawResponseTask<PayabliAccessTokenResponse> CreateServerSideTokenAsync(
        CreateServerSideTokenRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
