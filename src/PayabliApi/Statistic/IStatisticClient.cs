namespace PayabliApi;

public partial interface IStatisticClient
{
    /// <summary>
    /// Retrieves the basic statistics for an organization or a paypoint, for a given time period, grouped by a particular frequency.
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
    /// Retrieves the basic statistics for a customer for a specific time period, grouped by a selected frequency.
    /// </summary>
    WithRawResponseTask<IEnumerable<SubscriptionStatsQueryRecord>> CustomerBasicStatsAsync(
        string mode,
        string freq,
        int customerId,
        CustomerBasicStatsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves the subscription statistics for a given interval for a paypoint or organization.
    /// </summary>
    WithRawResponseTask<IEnumerable<StatBasicQueryRecord>> SubStatsAsync(
        string interval,
        int level,
        long entryId,
        SubStatsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve the basic statistics about a vendor for a given time period, grouped by frequency.
    /// </summary>
    WithRawResponseTask<IEnumerable<StatisticsVendorQueryRecord>> VendorBasicStatsAsync(
        string mode,
        string freq,
        int idVendor,
        VendorBasicStatsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
