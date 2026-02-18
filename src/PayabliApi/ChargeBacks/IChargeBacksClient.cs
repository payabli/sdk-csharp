namespace PayabliApi;

public partial interface IChargeBacksClient
{
    /// <summary>
    /// Add a response to a chargeback or ACH return.
    /// </summary>
    WithRawResponseTask<AddResponseResponse> AddResponseAsync(
        long id,
        ResponseChargeBack request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a chargeback record and its details.
    /// </summary>
    WithRawResponseTask<ChargebackQueryRecords> GetChargebackAsync(
        long id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a chargeback attachment file by its file name.
    /// </summary>
    WithRawResponseTask<string> GetChargebackAttachmentAsync(
        long id,
        string fileName,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
