namespace PayabliApi;

public partial interface ITokenStorageClient
{
    /// <summary>
    /// Saves a payment method for reuse. This call exchanges sensitive payment information for a token that can be used to process future transactions. The `ReferenceId` value in the response is the `storedMethodId` to use with transactions.
    /// </summary>
    WithRawResponseTask<AddMethodResponse> AddMethodAsync(
        AddMethodRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves details for a saved payment method.
    /// </summary>
    WithRawResponseTask<GetMethodResponse> GetMethodAsync(
        string methodId,
        GetMethodRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes a saved payment method.
    /// </summary>
    WithRawResponseTask<PayabliApiResponsePaymethodDelete> RemoveMethodAsync(
        string methodId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates a saved payment method.
    /// </summary>
    WithRawResponseTask<PayabliApiResponsePaymethodDelete> UpdateMethodAsync(
        string methodId,
        UpdateMethodRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
