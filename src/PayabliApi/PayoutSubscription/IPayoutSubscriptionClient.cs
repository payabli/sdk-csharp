namespace PayabliApi;

public partial interface IPayoutSubscriptionClient
{
    /// <summary>
    /// Creates a payout subscription to automatically send payouts to a vendor on a recurring schedule. See [Manage payout subscriptions](/guides/pay-out-developer-payout-subscriptions-manage) for a step-by-step guide.
    /// </summary>
    WithRawResponseTask<AddPayoutSubscriptionResponse> CreatePayoutSubscriptionAsync(
        RequestPayoutSchedule request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a single payout subscription's details. See [Manage payout subscriptions](/guides/pay-out-developer-payout-subscriptions-manage) for more information.
    /// </summary>
    WithRawResponseTask<GetPayoutSubscriptionResponse> GetPayoutSubscriptionAsync(
        long id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates a payout subscription's details. See [Manage payout subscriptions](/guides/pay-out-developer-payout-subscriptions-manage) for more information.
    /// </summary>
    WithRawResponseTask<UpdatePayoutSubscriptionResponse> UpdatePayoutSubscriptionAsync(
        long id,
        UpdatePayoutSubscriptionBody request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes a payout subscription and prevents future payouts. See [Manage payout subscriptions](/guides/pay-out-developer-payout-subscriptions-manage) for more information.
    /// </summary>
    WithRawResponseTask<DeletePayoutSubscriptionResponse> DeletePayoutSubscriptionAsync(
        long id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
