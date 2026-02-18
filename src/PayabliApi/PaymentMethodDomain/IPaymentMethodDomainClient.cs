namespace PayabliApi;

public partial interface IPaymentMethodDomainClient
{
    /// <summary>
    /// Add a payment method domain to an organization or paypoint.
    /// </summary>
    WithRawResponseTask<AddPaymentMethodDomainApiResponse> AddPaymentMethodDomainAsync(
        AddPaymentMethodDomainRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Cascades a payment method domain to all child entities. All paypoints and suborganization under this parent will inherit this domain and its settings.
    /// </summary>
    WithRawResponseTask<PaymentMethodDomainGeneralResponse> CascadePaymentMethodDomainAsync(
        string domainId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a payment method domain. You can't delete an inherited domain, you must delete a domain at the organization level.
    /// </summary>
    WithRawResponseTask<DeletePaymentMethodDomainResponse> DeletePaymentMethodDomainAsync(
        string domainId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get the details for a payment method domain.
    /// </summary>
    WithRawResponseTask<PaymentMethodDomainApiResponse> GetPaymentMethodDomainAsync(
        string domainId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a list of payment method domains that belong to a PSP, organization, or paypoint.
    /// </summary>
    WithRawResponseTask<ListPaymentMethodDomainsResponse> ListPaymentMethodDomainsAsync(
        ListPaymentMethodDomainsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update a payment method domain's configuration values.
    /// </summary>
    WithRawResponseTask<PaymentMethodDomainGeneralResponse> UpdatePaymentMethodDomainAsync(
        string domainId,
        UpdatePaymentMethodDomainRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Verify a new payment method domain. If verification is successful, Apple Pay is automatically activated for the domain.
    /// </summary>
    WithRawResponseTask<PaymentMethodDomainGeneralResponse> VerifyPaymentMethodDomainAsync(
        string domainId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
