namespace PayabliApi;

public partial interface ICustomerClient
{
    /// <summary>
    /// Creates a customer in an entrypoint. An identifier is required to create customer records. Change your identifier settings in Settings &gt; Custom Fields in PartnerHub.
    /// If you don't include an identifier, the record is rejected.
    /// </summary>
    WithRawResponseTask<PayabliApiResponseCustomerQuery> AddCustomerAsync(
        string entry,
        AddCustomerRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a customer record.
    /// </summary>
    WithRawResponseTask<PayabliApiResponse00Responsedatanonobject> DeleteCustomerAsync(
        int customerId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a customer's record and details.
    /// </summary>
    WithRawResponseTask<CustomerQueryRecords> GetCustomerAsync(
        int customerId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Links a customer to a transaction by ID.
    /// </summary>
    WithRawResponseTask<PayabliApiResponse00Responsedatanonobject> LinkCustomerTransactionAsync(
        int customerId,
        string transId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends the consent opt-in email to the customer email address in the customer record.
    /// </summary>
    WithRawResponseTask<PayabliApiResponse00Responsedatanonobject> RequestConsentAsync(
        int customerId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update a customer record. Include only the fields you want to change.
    /// </summary>
    WithRawResponseTask<PayabliApiResponse00Responsedatanonobject> UpdateCustomerAsync(
        int customerId,
        CustomerData request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
