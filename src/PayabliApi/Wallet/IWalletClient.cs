namespace PayabliApi;

public partial interface IWalletClient
{
    /// <summary>
    /// Configure and activate Apple Pay for a Payabli organization
    /// </summary>
    WithRawResponseTask<ConfigureApplePayOrganizationApiResponse> ConfigureApplePayOrganizationAsync(
        ConfigureOrganizationRequestApplePay request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Configure and activate Apple Pay for a Payabli paypoint
    /// </summary>
    WithRawResponseTask<ConfigureApplePaypointApiResponse> ConfigureApplePayPaypointAsync(
        ConfigurePaypointRequestApplePay request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Configure and activate Google Pay for a Payabli organization
    /// </summary>
    WithRawResponseTask<ConfigureApplePayOrganizationApiResponse> ConfigureGooglePayOrganizationAsync(
        ConfigureOrganizationRequestGooglePay request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Configure and activate Google Pay for a Payabli paypoint
    /// </summary>
    WithRawResponseTask<ConfigureGooglePaypointApiResponse> ConfigureGooglePayPaypointAsync(
        ConfigurePaypointRequestGooglePay request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
