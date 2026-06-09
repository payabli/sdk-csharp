namespace PayabliApi;

public partial interface ISubscriptionClient
{
    /// <summary>
    /// Retrieves a single subscription's details.
    /// </summary>
    WithRawResponseTask<SubscriptionQueryRecords> GetSubscriptionAsync(
        int subId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates a subscription's details.
    /// </summary>
    WithRawResponseTask<UpdateSubscriptionResponse> UpdateSubscriptionAsync(
        int subId,
        RequestUpdateSchedule request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes a subscription, autopay, or recurring payment and prevents future charges.
    /// </summary>
    WithRawResponseTask<RemoveSubscriptionResponse> RemoveSubscriptionAsync(
        int subId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a subscription or scheduled payment to run at a specified time and frequency. You can use stored payment method tokens for card, ACH, and digital wallets by passing them into the `paymentMethod.storedMethodId` field.
    /// </summary>
    WithRawResponseTask<AddSubscriptionResponse> NewSubscriptionAsync(
        RequestSchedule request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
