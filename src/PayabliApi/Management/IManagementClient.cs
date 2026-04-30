namespace PayabliApi;

public partial interface IManagementClient
{
    /// <summary>
    /// Verifies a bank account and returns detailed verification results from the verification network, including bank name, account status, and response codes. Unlike a pass/fail verification, this endpoint returns granular data to support decision-making and troubleshooting.
    ///
    /// When bank authentication is enabled for the paypoint's organization, the endpoint performs an identity verification check on the account holder. Otherwise, it performs an account existence check. When bank authentication is enabled, the `accountHolderType` and `holderName` fields are required.
    ///
    /// Requires `inboundpayments_create` or `outboundpayments_create` permission.
    /// </summary>
    WithRawResponseTask<VerifyAccountDetailsResponse> VerifyAccountDetailsAsync(
        string entry,
        VerifyAccountDetailsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
