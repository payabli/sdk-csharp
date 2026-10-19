namespace PayabliApi;

public partial interface IGhostCardClient
{
    /// <summary>
    /// Creates a ghost card, a multi-use virtual debit card issued to a vendor for recurring or discretionary spend.
    ///
    /// Unlike single-use virtual cards issued as part of a payout transaction, ghost cards aren't tied to a specific payout. They're issued directly to a vendor and can be reused up to a configurable number of times within the card's spending limits.
    ///
    /// Only one active ghost card can exist per vendor per paypoint. If the vendor already has one, the request fails with error `7067`. To issue a new card to the same vendor, cancel the existing card first. Canceled and expired cards don't count toward this limit. See [Cancel ghost card](/developers/api-reference/cards/cancel-ghost-card).
    /// </summary>
    WithRawResponseTask<CreateGhostCardResponse> CreateGhostCardAsync(
        string entry,
        CreateGhostCardRequestBody request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Cancels a ghost card. This is always a soft delete: Payabli keeps the card record, including its transaction history.
    ///
    /// Canceling a ghost card frees the vendor's slot, so you can issue a new ghost card to the same vendor. A card canceled with this endpoint can't be used, reactivated, or canceled again.
    ///
    /// Requires the `vcard_delete` permission.
    /// </summary>
    WithRawResponseTask<DeleteGhostCardResponse> DeleteGhostCardAsync(
        string cardToken,
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
