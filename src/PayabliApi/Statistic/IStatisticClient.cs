namespace PayabliApi;

public partial interface IStatisticClient
{
    /// <summary>
    /// Retrieves the basic statistics for an organization or a paypoint over a date range, grouped by a frequency. The response returns one row per time bucket. Counts and volumes cover approved transactions only and leave out declines. Volumes are net of fees.
    /// </summary>
    WithRawResponseTask<IEnumerable<StatBasicExtendedQueryRecord>> BasicStatsAsync(
        string mode,
        string freq,
        int level,
        long entryId,
        BasicStatsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves the basic statistics for a customer over a date range, grouped by a frequency. This is a Pay In view: it counts the customer's approved transactions and returns one row per time bucket. Volume here is the gross amount, before fees.
    /// </summary>
    WithRawResponseTask<IEnumerable<StatCustomerBasicQueryRecord>> CustomerBasicStatsAsync(
        string mode,
        string freq,
        int customerId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves subscription statistics for a paypoint or organization, bucketed by how soon active subscriptions are due to renew. This is a forward-looking forecast of upcoming renewals, not charges already taken. Request a single window with `interval`, or `all` to return every window in one call.
    /// </summary>
    WithRawResponseTask<IEnumerable<SubscriptionStatsQueryRecord>> SubStatsAsync(
        string interval,
        int level,
        long entryId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve the basic statistics about a vendor over a date range, grouped by frequency. The response returns one row per time bucket, breaking the vendor's bills down by bill state (active, sent to approval, approved, in transit, paid, and so on). Volumes are net of fees.
    /// </summary>
    WithRawResponseTask<IEnumerable<StatisticsVendorQueryRecord>> VendorBasicStatsAsync(
        string mode,
        string freq,
        int idVendor,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
