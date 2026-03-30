namespace PayabliApi;

public partial interface IGhostCardClient
{
    /// <summary>
    /// Creates a ghost card, a multi-use virtual debit card issued to a vendor for recurring or discretionary spend.
    ///
    /// Unlike single-use virtual cards issued as part of a payout transaction, ghost cards aren't tied to a specific payout. They're issued directly to a vendor and can be reused up to a configurable number of times within the card's spending limits.
    /// </summary>
    WithRawResponseTask<CreateGhostCardResponse> CreateGhostCardAsync(
        string entry,
        CreateGhostCardRequestBody request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates the status of a virtual card (including ghost cards) under a paypoint.
    /// </summary>
    WithRawResponseTask<PayabliApiResponse> UpdateCardAsync(
        string entry,
        UpdateCardRequestBody request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
