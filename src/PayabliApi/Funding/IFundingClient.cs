namespace PayabliApi;

public partial interface IFundingClient
{
    /// <summary>
    /// Deposits funds into a paypoint's available payout balance. Deposited funds enter a pending state and aren't available for instant payouts until confirmed through FBO reconciliation.
    /// </summary>
    WithRawResponseTask<DepositFundsResponse> DepositFundsAsync(
        DepositFundsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
