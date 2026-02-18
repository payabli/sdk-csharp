namespace PayabliApi;

public partial interface IHostedPaymentPagesClient
{
    /// <summary>
    /// Loads all of a payment page's details including `pageIdentifier` and `validationCode`. This endpoint requires an `application` API token.
    /// </summary>
    WithRawResponseTask<PayabliPages> LoadPageAsync(
        string entry,
        string subdomain,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a new payment page for a paypoint.
    /// Note: this operation doesn't create a new paypoint, just a payment page for an existing paypoint. Paypoints are created by the Payabli team when a boarding application is approved.
    /// </summary>
    WithRawResponseTask<PayabliApiResponse00Responsedatanonobject> NewPageAsync(
        string entry,
        NewPageRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates a payment page in a paypoint.
    /// </summary>
    WithRawResponseTask<PayabliApiResponse00Responsedatanonobject> SavePageAsync(
        string entry,
        string subdomain,
        PayabliPages request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
