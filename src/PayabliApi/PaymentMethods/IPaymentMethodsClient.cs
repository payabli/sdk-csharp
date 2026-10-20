namespace PayabliApi;

public partial interface IPaymentMethodsClient
{
    /// <summary>
    /// Lists payment methods with optional filtering and pagination.
    /// </summary>
    WithRawResponseTask<ListPaymentMethodsEnvelope> ListPaymentMethodsAsync(
        ListPaymentMethodsPaymentMethodsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates one or more payment methods for an entity in a single call.
    /// Set each payment method's `accountOwner` to the entity it belongs to.
    /// </summary>
    WithRawResponseTask<PaymentMethodsCreatedEnvelope> CreatePaymentMethodsAsync(
        CreatePaymentMethodsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a payment method by reference. Sensitive fields such as the account and routing numbers are masked.
    /// </summary>
    WithRawResponseTask<PaymentMethodDetailEnvelope> GetPaymentMethodAsync(
        string paymentMethodReference,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deactivates a payment method. This is a soft delete: the payment
    /// method moves to `INACTIVE` and the record is kept.
    /// </summary>
    WithRawResponseTask<PaymentMethodDeactivatedEnvelope> DeactivatePaymentMethodAsync(
        string paymentMethodReference,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Applies a partial update to a payment method. Send only the fields you
    /// want to change. Only payment methods in `PENDING` status can be updated.
    /// Once a payment method is active, change it through the bank account
    /// change process instead.
    /// </summary>
    WithRawResponseTask<PaymentMethodUpdatedEnvelope> UpdatePaymentMethodAsync(
        string paymentMethodReference,
        UpdatePaymentMethodRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
